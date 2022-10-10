using System.Collections;
using UnityEngine;

namespace Game
{
    public class Game : MonoBehaviour
    {
        private TriangleFactory _triangleFactory;
        private SquareFactory _squareFactory;
        private CircleFactory _circleFactory;

        private void Awake()
        {
            Initialize();
        }

        private void Start()
        {
            StartCoroutine(Spawn(_squareFactory, 0.5f));
            StartCoroutine(Spawn(_triangleFactory, 2f));
        }

        private void Initialize()
        {
            PointGenerator generator = new PointGenerator();
            
            _triangleFactory = new TriangleFactory(generator);
            _squareFactory = new SquareFactory(generator);
            _circleFactory = new CircleFactory(generator);
        }

        private IEnumerator Spawn(GeometryFactory factory, float time)
        {
            while (true)
            {
                factory.CreateGeometry();
                yield return new WaitForSeconds(time);
            }
        }
    }
}