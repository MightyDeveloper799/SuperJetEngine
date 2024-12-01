using OpenTK;

namespace SuperJet
{
    public class TriangleCollider : Collider
    {
        public Vector2 PointA { get; set; }
        public Vector2 PointB { get; set; }
        public Vector2 PointC { get; set; }

        public TriangleCollider(Vector2 pointA, Vector2 pointB, Vector2 pointC)
        {
            PointA = pointA;
            PointB = pointB;
            PointC = pointC;
        }

        public override bool CheckCollision(Collider other)
        {
            return false;
        }
    }
}
