using UnityEngine;

namespace Game
{
    public class LinearMovement: IMovement
    {
        private readonly Transform _transform;
        private readonly PointGenerator _generator;
        
        private readonly float _cooldown = 1f;
        private float _remainingTime = 0;

        private Vector3 _targetPosition;

        public LinearMovement(Transform transform, PointGenerator pointGenerator)
        {
            _transform = transform;
            _generator = pointGenerator;
            
            _targetPosition = _generator.GetRandomPointToSpawn();
        }
        
        public void Move()
        {
            _remainingTime += Time.deltaTime;
            _transform.Translate(_targetPosition * Time.deltaTime);
            
            
            if (_remainingTime >= _cooldown)
            {
                _targetPosition = _generator.GetRandomPointToSpawn();
                _remainingTime = 0;
            }
        }
    }
}