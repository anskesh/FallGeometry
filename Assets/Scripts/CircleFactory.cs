using UnityEngine;

namespace Game
{
    public class CircleFactory : GeometryFactory
    {
        public CircleFactory(PointGenerator generator)
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
            Score = 3;
        }
        
        protected override void CreateTemplate()
        {
            Template = Resources.LoadAsync<Geometry>("Circle").asset as Geometry;
        }
    }
}