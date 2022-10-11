using UnityEngine;

namespace Game
{
    public class TriangleFactory : GeometryFactory
    {
        public TriangleFactory()
        {
            Container = new GameObject("Triangles").transform;
        }
        
        protected override IMovement CreateMovement(Transform transform)
        {
            return new RandomMovement(transform, Generator);
        }

        protected override void CreateScore()
        {
            Score = 5;
        }
        
        protected override void CreateTemplate()
        {
            Template = Resources.LoadAsync<Geometry>("Triangle").asset as Geometry;
        }
    }
}