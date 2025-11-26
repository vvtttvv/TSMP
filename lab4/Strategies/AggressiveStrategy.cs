using TowerDefense.Entities;

namespace TowerDefense.Strategies
{
    public class AggressiveStrategy : IEnemyStrategy
    {
        public int CalculateNextMove(Enemy enemy, int currentPosition, int targetPosition)
        {
            return currentPosition + 2;
        }

        public string GetStrategyName() => "Aggressive";
    }
}