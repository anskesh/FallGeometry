using System;
using System.Collections.Generic;

namespace Game.Observer
{
    public class ScoreObtainObserver : Observer
    {
        public Observable Spawner { get; set; }
        
        private Dictionary<Observable, string> _observables = new Dictionary<Observable, string>();
        private Action<int> _action;

        public ScoreObtainObserver(Action<int> action)
        {
            _action = action;
        }
        
        public void Notify(){}

        public void Notify(int score)
        {
            _action.Invoke(score);
        }

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