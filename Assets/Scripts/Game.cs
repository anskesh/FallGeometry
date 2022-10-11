using System.Collections;
using Game.Observer;
using UnityEngine;

namespace Game
{
    public class Game : MonoBehaviour, Observable
    {
        private TriangleFactory _triangleFactory;
        private SquareFactory _squareFactory;
        private CircleFactory _circleFactory;
        
        private HandlerUI _handlerUI;

        private bool _isMove = true;
        
        private IEnumerator _squareSpawn;
        private IEnumerator _triangleSpawn;
        private IEnumerator _circleSpawn;

        private void Awake()
        {
            Initialize();
        }

        private void Start()
        {
            _squareSpawn = Spawn(_squareFactory, 0.5f);
            _triangleSpawn = Spawn(_triangleFactory, 2f);
            _circleSpawn = Spawn(_circleFactory, 1f);
            
            StartCoroutine(_squareSpawn);
            StartCoroutine(_triangleSpawn);
            StartCoroutine(_circleSpawn);
        }

        private void Initialize()
        {
            _handlerUI = FindObjectOfType<HandlerUI>();
            
            PointGenerator generator = new PointGenerator();
            
            PauseObserver pauseObserver = _handlerUI.PauseObserver;
            pauseObserver.Spawner = this;

            ScoreObtainObserver scoreObtainObserver = _handlerUI.ScoreObtainObserver;
            
            _triangleFactory = new TriangleFactory();
            _triangleFactory.InitializeFactory(generator, pauseObserver, scoreObtainObserver);
            
            _squareFactory = new SquareFactory();
            _squareFactory.InitializeFactory(generator, pauseObserver, scoreObtainObserver);
            
            _circleFactory = new CircleFactory();
            _circleFactory.InitializeFactory(generator, pauseObserver, scoreObtainObserver);
        }

        private IEnumerator Spawn(GeometryFactory factory, float time)
        {
            while (true)
            {
                factory.CreateGeometry();
                yield return new WaitForSeconds(time);
            }
        }

        public void OnNotify()
        {
            _isMove = !_isMove;
            
            if (_isMove)
            {
                StartCoroutine(_squareSpawn);
                StartCoroutine(_triangleSpawn);
                StartCoroutine(_circleSpawn);
            }
            else
            {
                StopCoroutine(_squareSpawn);
                StopCoroutine(_triangleSpawn);
                StopCoroutine(_circleSpawn);
            }
        }
    }
}