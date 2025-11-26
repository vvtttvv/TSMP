using TowerDefense.Entities;

namespace TowerDefense.Strategies
{
    public class DefensiveStrategy : IEnemyStrategy
    {
        public int CalculateNextMove(Enemy enemy, int currentPosition, int targetPosition)
        {
            return currentPosition + 1;
        }

        public string GetStrategyName() => "Defensive";
    }
}