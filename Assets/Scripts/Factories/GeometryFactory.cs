using System.Collections.Generic;
using System.Linq;
using Game.Observer;
using UnityEngine;

namespace Game
{
    public abstract class GeometryFactory
    {
        protected Geometry Template;
        protected int Score;
        protected PointGenerator Generator;
        
        protected Transform Container;
        private Observer.Observer _pauseObserver;
        private ScoreObtainObserver _scoreObserver;

        private List<Geometry> _pool = new List<Geometry>();

        public void InitializeFactory(PointGenerator generator, Observer.Observer pauseObserver, ScoreObtainObserver scoreObserver)
        {
            Generator = generator;
            _pauseObserver = pauseObserver;
            _scoreObserver = scoreObserver;
            
            CreateTemplate();
            CreateScore();
        }

        public Geometry CreateGeometry()
        {
            Geometry figure;

            if (!HasFreeInPool(out figure))
            {
                figure = GameObject.Instantiate(Template, Container);
                _pauseObserver.Add(figure);
                figure.GainScore += delegate(int score) { _scoreObserver.Notify(score); };
            }
            else
                figure.gameObject.SetActive(true);
            
            figure.transform.position = Generator.GetRandomPointToSpawn();
            figure.Initialize(CreateMovement(figure.transform), Score, Generator);

            _pool.Add(figure);

            return figure;
        }

        protected abstract IMovement CreateMovement(Transform transform);
        protected abstract void CreateScore();
        protected abstract void CreateTemplate();

        private bool HasFreeInPool(out Geometry figure)
        {
            figure = _pool.FirstOrDefault(geometry => geometry.gameObject.activeSelf == false);

            if (figure)
                return true;

            return false;
        }
    }
}
