using OpenTK;

namespace SuperJet
{
    public class CircleCollider : Collider
    {
        public float Radius { get; set; } 
        
        public CircleCollider(Vector2 position, float radius)
        {
            Position = position;
            Radius = radius;
        }

        public override bool CheckCollision(Collider other)
        {
            if(other is CircleCollider)
            {
                CircleCollider circle = (CircleCollider)other;
                float distance = Vector2.Distance(Position, circle.Position);
                return distance < Radius + circle.Radius;
            }

            return false;
        }
    }
}