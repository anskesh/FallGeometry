using UnityEngine;

namespace Game
{
    public class RandomMovement: IMovement
    {
        private Transform _transform;
        private PointGenerator _generator;

        private readonly float _cooldown = 0.9f;
        private float _remainingTime = 0;
        
        public RandomMovement(Transform transform, PointGenerator generator)
        {
            _transform = transform;
            _generator = generator;
        }
        
        public void Move()
        {
            _remainingTime += Time.deltaTime;
            if (_remainingTime >= _cooldown)
            {
                _transform.position = _generator.GetRandomPointToMove();
                _remainingTime = 0;
            }
        }
    }
}