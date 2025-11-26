using System;

namespace TowerDefense.Observers
{
    public class EventLogObserver : IGameObserver
    {
        public void Update(string eventMessage)
        {
            Console.WriteLine($"  - Log: {eventMessage}");
        }
    }
}