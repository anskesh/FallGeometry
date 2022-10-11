using UnityEngine;

namespace Game
{
    public class CircleFactory : GeometryFactory
    {
        public CircleFactory()
        {
            Container = new GameObject("Circles").transform;
        }

        protected override IMovement CreateMovement(Transform transform)
        {
           return new LinearMovement(transform, Generator);
        }

        protected override void CreateScore()
        {
            Score = 3;
        }
        
        protected override void CreateTemplate()
        {
            Template = Resources.LoadAsync<Geometry>("Circle").asset as Geometry;
        }
    }
}