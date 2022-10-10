using UnityEngine;

namespace Game
{
    public class PointGenerator
    {
        private Camera _camera;
        
        private readonly float _leftBorder;
        private readonly float _rightBorder;
        private readonly float _topBorder;
        private readonly float _bottomBorder;

        public PointGenerator()
        {
            _camera = Camera.main;

            _leftBorder = _camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
            _rightBorder = _camera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
            
            _topBorder = _camera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
            _bottomBorder = _camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        }

        public Vector3 GetRandomPointToSpawn()
        {
            float x = Random.Range(_leftBorder, _rightBorder);
            float y = Random.Range(_bottomBorder, _topBorder);

            return new Vector3(x, y, 0);
        }

        public Vector3 GetRandomPointToMove()
        {
            float x = Random.Range(_leftBorder - 1, _rightBorder + 1);
            float y = Random.Range(_bottomBorder - 1, _topBorder + 1);

            return new Vector3(x, y, 0);
        }
        
        public bool OnField(Vector3 position)
        {
            if (position.x > _leftBorder && position.x < _rightBorder && position.y < _topBorder && position.y > _bottomBorder)
                return true;

            return false;
        }
    }
}