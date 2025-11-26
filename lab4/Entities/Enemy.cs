using TowerDefense.Strategies;

namespace TowerDefense.Entities
{
    public class Enemy
    {
        public int Health { get; set; }
        public int Position { get; set; }
        public IEnemyStrategy Strategy { get; set; }

        public Enemy(int health, IEnemyStrategy strategy)
        {
            Health = health;
            Position = 0;
            Strategy = strategy;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
        }

        public void Move(int targetPosition)
        {
            Position = Strategy.CalculateNextMove(this, Position, targetPosition);
        }

        public bool IsAlive() => Health > 0;
    }
}