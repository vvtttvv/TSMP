using System;
using System.Collections.Generic;
using System.Linq;
using TowerDefense.Commands;
using TowerDefense.Entities;
using TowerDefense.Observers;
using TowerDefense.Strategies;

namespace TowerDefense
{
    public class Game
    {
        private GameField _field;
        private CommandInvoker _invoker;
        private GameEventPublisher _eventPublisher;
        private List<Enemy> _enemies;
        private ScoreObserver _scoreObserver;
        private BaseHealthObserver _baseHealthObserver;
        private static readonly Random rnd = new Random();

        public Game()
        {
            _field = new GameField();
            _invoker = new CommandInvoker();
            _eventPublisher = new GameEventPublisher();
            _enemies = new List<Enemy>();

            _scoreObserver = new ScoreObserver();
            _baseHealthObserver = new BaseHealthObserver();
            _eventPublisher.Subscribe(_scoreObserver);
            _eventPublisher.Subscribe(_baseHealthObserver);
            _eventPublisher.Subscribe(new EventLogObserver());
        }

        public void PlaceTower(string towerName, int damage, int range, int position)
        {
            var tower = new Tower(towerName, damage, range);
            var command = new PlaceTowerCommand(_field, tower, position);
            _invoker.ExecuteCommand(command);
        }

        public void SpawnEnemy(int health, IEnemyStrategy strategy)
        {
            var enemy = new Enemy(health, strategy);
            _enemies.Add(enemy);
            Console.WriteLine($"Enemy Spwned (HP: {health}, Strategy: {strategy.GetStrategyName()})");
        }

        public void GameTurn()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\n Game Turn Begins!");
            Console.WriteLine("\n");
            
            Console.WriteLine("\n Initial Position:");
            foreach (var enemy in _enemies.Where(e => e.IsAlive()).ToList())
            {
                Console.WriteLine($"  👾 {enemy.Strategy.GetStrategyName()}: position {enemy.Position}");
            }
            
            Console.WriteLine("\n Enemies moved:");
            foreach (var enemy in _enemies.Where(e => e.IsAlive()).ToList())
            {
                int oldPosition = enemy.Position;
                enemy.Move(GameField.FieldSize);
                int moved = enemy.Position - oldPosition;
                Console.WriteLine($"  👾 {enemy.Strategy.GetStrategyName()}: {oldPosition} → {enemy.Position} (+{moved} fields)");

                if (enemy.Position >= GameField.FieldSize)
                {
                    _eventPublisher.NotifyObservers("!!!!!Enemy achieved the tower!!!!!");
                    _enemies.Remove(enemy);
                }
            }

            Console.WriteLine("\n Tower Attack:");
            foreach (var tower in _field.GetAllTowers())
            {
                var target = _enemies
                    .Where(e => e.IsAlive())
                    .OrderByDescending(e => e.Position)
                    .FirstOrDefault();

                if (target != null)
                {
                    var attackCommand = new TowerAttackCommand(tower, target);
                    _invoker.ExecuteCommand(attackCommand);

                    if ((target.Strategy is DefensiveStrategy && rnd.Next(2) == 1) ||
                        (target.Strategy is RandomStrategy    && rnd.Next(4) == 1))
                    {
                        attackCommand.Undo();
                    }

                    if (!target.IsAlive())
                    {
                        _eventPublisher.NotifyObservers("Enemy is dead!");
                        _enemies.Remove(target);
                    }
                }
            }

            _field.Display(_enemies);
        }

        public void UndoLastAction()
        {
            _invoker.UndoLastCommand();
        }

        public bool IsGameOver()
        {
            return _baseHealthObserver.GetHealth() <= 0;
        }

        public void ShowStats()
        {
            Console.WriteLine($"\n- Final result: {_scoreObserver.GetScore()}");
            Console.WriteLine($"- Base health: {_baseHealthObserver.GetHealth()}");
        }
    }
}