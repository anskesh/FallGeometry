using UnityEngine;

namespace Game
{
    public class SquareFactory : GeometryFactory
    {
        public SquareFactory()
        {
            Container = new GameObject("Squares").transform;
        }

        protected override IMovement CreateMovement(Transform transform)
        {
            return new LinearMovement(transform, Generator);
        }

        protected override void CreateScore()
        {
            Score = 1;
        }

        protected override void CreateTemplate()
        {
            Template = Resources.LoadAsync<Geometry>("Square").asset as Geometry;
        }
    }
}