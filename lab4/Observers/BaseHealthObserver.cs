using System;

namespace TowerDefense.Observers
{
    public class BaseHealthObserver : IGameObserver
    {
        private int _baseHealth = 100;

        public void Update(string eventMessage)
        {
            if (eventMessage.Contains("!!!!!Enemy achieved the tower!!!!!"))
            {
                _baseHealth -= 20;
                Console.WriteLine($"  💔 Base HP: {_baseHealth} HP");
                
                if (_baseHealth <= 0)
                {
                    Console.WriteLine("  ☠️  Base is DESTROYED! GAME OVER!");
                }
            }
        }

        public int GetHealth() => _baseHealth;
    }
}
