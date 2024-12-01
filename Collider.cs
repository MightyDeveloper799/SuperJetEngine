using OpenTK;

namespace SuperJet
{
    public abstract class Collider
    {
        public Vector2 Position { get; set; }

        public abstract bool CheckCollision(Collider other);
    }
}
