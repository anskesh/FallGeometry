using UnityEngine;

namespace Game
{
    public class SquareFactory : GeometryFactory
    {
        public SquareFactory(PointGenerator generator)
        {
            Generator = generator;
            
            CreateTemplate();
            CreateScore();
        }

        protected override IMovement CreateMovement(Transform transform)
        {
            return new NoMovement();
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