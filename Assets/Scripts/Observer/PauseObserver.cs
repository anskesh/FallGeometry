using System.Collections.Generic;

namespace Game.Observer
{
    public class PauseObserver: Observer
    {
        private Dictionary<Observable, string> _observables = new Dictionary<Observable, string>();
        public Observable Spawner { get; set; }

        public void Notify()
        {
            Spawner.OnNotify();
            
            foreach (var observable in _observables.Keys)
                observable.OnNotify();
        }

        public void Notify(int score) {}

        public void Add(Observable observable)
        {
            if (_observables.ContainsKey(observable))
                return;
            
            _observables.Add(observable, nameof(observable));
        }

        public void Remove(Observable observable)
        {
            if (_observables.ContainsKey(observable))
                _observables.Remove(observable);
        }
    }
}