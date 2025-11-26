using System;
using TowerDefense.Entities;

namespace TowerDefense.Commands
{
    public class TowerAttackCommand : ICommand
    {
        private Tower _tower;
        private Enemy _enemy;
        private int _damageDealt;

        public TowerAttackCommand(Tower tower, Enemy enemy)
        {
            _tower = tower;
            _enemy = enemy;
        }

        public void Execute()
        {
            _damageDealt = _tower.Damage;
            _enemy.TakeDamage(_damageDealt);
            Console.WriteLine($"  - {_tower.Name} is attacking enemy (HP: {_enemy.Health})");
        }

        public void Undo()
        {
            _enemy.Health += _damageDealt;
            Console.WriteLine($" The atack was blocked! Enemy's HP: {_enemy.Health})");
        }
    }
}