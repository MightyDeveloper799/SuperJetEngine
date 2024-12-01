using OpenTK;

namespace SuperJet
{
    public class CapsuleCollider : Collider
    {
        public float Radius { get; set; }
        public float Height { get; set; }

        public CapsuleCollider(Vector2 position, float radius, float height)
        {
            Position = position;
            Radius = radius;
            Height = height;
        }

        public override bool CheckCollision(Collider other)
        {
            return false;
        }
    }
}
