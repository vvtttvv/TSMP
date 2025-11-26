using System;

namespace TowerDefense.Observers
{
    public class ScoreObserver : IGameObserver
    {
        private int _score = 0;

        public void Update(string eventMessage)
        {
            if (eventMessage.Contains("Enemy is dead!"))
            {
                _score += 10;
                Console.WriteLine($"  - Score: {_score} points");
            }
        }

        public int GetScore() => _score;
    }
}
