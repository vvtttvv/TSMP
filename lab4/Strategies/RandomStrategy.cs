using System;
using TowerDefense.Entities;

namespace TowerDefense.Strategies
{
    public class RandomStrategy : IEnemyStrategy
    {
        private Random _random = new Random();

        public int CalculateNextMove(Enemy enemy, int currentPosition, int targetPosition)
        {
            return currentPosition + _random.Next(1, 3);
        }

        public string GetStrategyName() => "Random";
    }
}