using System;
using TowerDefense.Strategies;

namespace TowerDefense
{
    public class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var game = new Game();

            game.PlaceTower("Archer Tower", 10, 3, 3);
            game.PlaceTower("Cannon Tower", 15, 2, 7);
            game.PlaceTower("DESTROYER", 30, 1, 10);

            Console.WriteLine("\nEnemies:");
            game.SpawnEnemy(80, new AggressiveStrategy());
            game.SpawnEnemy(100, new DefensiveStrategy());
            game.SpawnEnemy(70, new RandomStrategy());
            game.SpawnEnemy(90, new AggressiveStrategy());
            game.SpawnEnemy(85, new DefensiveStrategy());

            for (int turn = 1; turn <= 15 && !game.IsGameOver(); turn++)
            {
                Console.WriteLine($"\n------------ Stage {turn} ------------");
                game.GameTurn();
            }

            game.ShowStats();
        }
    }
}