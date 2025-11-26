using TowerDefense.Entities;

namespace TowerDefense.Strategies
{
    public interface IEnemyStrategy
    {
        int CalculateNextMove(Enemy enemy, int currentPosition, int targetPosition);
        string GetStrategyName();
    }
}