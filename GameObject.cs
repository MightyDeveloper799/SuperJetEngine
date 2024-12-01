using OpenTK;
using System.Drawing;

namespace SuperJet
{
    public class GameObject
    {
        public Vector3 Position { get; set; }
        public Vector3 Rotation { get; set; }
        public Vector3 Scale { get; set; }
        public Vector3 velocity; 
        public Vector3 Acceleration {  get; set; }
        public RectangleF Bounds { get; set; }
        public float Mass { get; set; }

        public Vector3 Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }

        public GameObject()
        {
            Position = Vector3.Zero;
            Rotation = Vector3.Zero;
            Scale = Vector3.One;
            velocity = Vector3.Zero;
            Acceleration = Vector3.Zero;
            Mass = 1.0f;
        }

        public void ApplyForce(Vector3 force)
        {
            Acceleration += force / Mass;
        }

        public void AddToVelocity(Vector3 delta)
        {
            velocity += delta;
        }

        public void UpdatePhysics()
        {
            velocity += Acceleration;
            Position += velocity;
            Acceleration = Vector3.Zero;
            Bounds = new RectangleF(Position.X, Position.Y, Bounds.Width, Bounds.Height);
        }
    }
}
