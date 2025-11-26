using System.Collections.Generic;

namespace TowerDefense.Observers
{
    public class GameEventPublisher
    {
        private List<IGameObserver> _observers = new List<IGameObserver>();

        public void Subscribe(IGameObserver observer)
        {
            _observers.Add(observer);
        }

        public void Unsubscribe(IGameObserver observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyObservers(string eventMessage)
        {
            foreach (var observer in _observers)
            {
                observer.Update(eventMessage);
            }
        }
    }
}
