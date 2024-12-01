using OpenTK;

namespace SuperJet
{
    public class BoxCollider : Collider
    {
        public Vector2 Size { get; set; }

        public BoxCollider(Vector2 position, Vector2 size)
        {
            Position = position;
            Size = size;
        }

        public override bool CheckCollision(Collider other)
        {
            if(other is BoxCollider)
            {
                BoxCollider box = (BoxCollider)other;
                return Position.X < box.Position.X + box.Size.X &&
                       Position.X + Size.X > box.Position.X &&
                       Position.Y < box.Position.Y + box.Size.Y &&
                       Position.Y + Size.Y > box.Position.Y;
            }

            return false;
        }
    }
}
