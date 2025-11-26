using System;
using System.Collections.Generic;
using System.Linq;

namespace TowerDefense.Entities
{
    public class GameField
    {
        private Dictionary<int, Tower> _towers = new Dictionary<int, Tower>();
        public const int FieldSize = 12;

        public void PlaceTower(Tower tower, int position)
        {
            _towers[position] = tower;
        }

        public void RemoveTower(int position)
        {
            _towers.Remove(position);
        }

        public Tower? GetTowerAt(int position)
        {
            return _towers.ContainsKey(position) ? _towers[position] : null;
        }

        public List<Tower> GetAllTowers()
        {
            return _towers.Values.ToList();
        }

        public void Display(List<Enemy> enemies)
        {
            Console.WriteLine("\n" + new string('=', 65));
            Console.Write("Field: ");
            
            for (int i = 0; i < FieldSize; i++)
            {
                bool hasTower = _towers.ContainsKey(i);
                var enemiesHere = enemies.Where(e => e.Position == i && e.IsAlive()).ToList();
                
                if (hasTower && enemiesHere.Any())
                    Console.Write("[👾X I]");
                else if (hasTower)
                    Console.Write("[I]");
                else if (enemiesHere.Any())
                    Console.Write($"[{enemiesHere.Count}👾]");
                else
                    Console.Write("[ ]");
            }
            Console.WriteLine(" [🏰BASE]");
            
            var aliveEnemies = enemies.Where(e => e.IsAlive()).ToList();
            if (aliveEnemies.Any())
            {
                Console.WriteLine(new string('-', 65));
                foreach (var enemy in aliveEnemies.OrderBy(e => e.Position))
                {
                    string healthBar = new string('|', Math.Max(1, enemy.Health / 10));
                    Console.WriteLine($"  👾 Pos.{enemy.Position} | HP:{enemy.Health,3} {healthBar} | {enemy.Strategy.GetStrategyName()}");
                }
            }
            Console.WriteLine(new string('=', 65));
        }
    }
}