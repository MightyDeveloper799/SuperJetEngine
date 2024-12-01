using OpenTK;

namespace SuperJetEngine
{
    public static class ScaleManager
    {
        // Scales a vector by a scalar value
        public static Vector2 Scale(Vector2 v, float scalar)
        {
            return v * scalar;
        }

        // Scales a vector by another vector component-wise
        public static Vector2 Scale(Vector2 v, Vector2 scale)
        {
            return new Vector2(v.X * scale.X, v.Y * scale.Y);
        }

        // Scales a vector uniformly
        public static Vector2 UniformScale(Vector2 v, float scalar)
        {
            return v * scalar;
        }
    }
}
