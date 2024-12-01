using OpenTK;

namespace SuperJetEngine
{
    public static class VectorManager
    {
        // Adds two vectors
        public static Vector2 Add(Vector2 v1, Vector2 v2)
        {
            return v1 + v2;
        }

        // Subtracts the second vector from the first
        public static Vector2 Subtract(Vector2 v1, Vector2 v2)
        {
            return v1 - v2;
        }

        // Scales a vector by a scalar
        public static Vector2 Scale(Vector2 v, float scalar)
        {
            return v * scalar;
        }

        // Calculates the dot product of two vectors
        public static float Dot(Vector2 v1, Vector2 v2)
        {
            return Vector2.Dot(v1, v2);
        }

        // Normalizes a vector
        public static Vector2 Normalize(Vector2 v)
        {
            return Vector2.Normalize(v);
        }

        // Calculates the magnitude of a vector
        public static float Magnitude(Vector2 v)
        {
            return v.Length;
        }

        // Calculates the distance between two vectors
        public static float Distance(Vector2 v1, Vector2 v2)
        {
            return Vector2.Distance(v1, v2);
        }

        // Linearly interpolates between two vectors
        public static Vector2 Lerp(Vector2 v1, Vector2 v2, float t)
        {
            return Vector2.Lerp(v1, v2, t);
        }
    }
}

