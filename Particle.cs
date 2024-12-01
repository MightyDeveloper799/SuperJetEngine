using OpenTK;

namespace SuperJet
{
    public class Particle
    {
        public Vector3 Position;
        public Vector3 Velocity;
        public Vector3 Color;
        public float Life;

        public Particle(Vector3 position, Vector3 velocity, Vector3 color, float life)
        {
            Position = position;
            Velocity = velocity;
            Color = color;
            Life = life;
        }

        public void Update(float deltaTime)
        {
            Position += Velocity * deltaTime;
            Life -= deltaTime;
        }
    }
}
