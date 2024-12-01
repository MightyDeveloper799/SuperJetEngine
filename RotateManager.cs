using OpenTK;
using System;

namespace SuperJetEngine
{
    public static class RotateManager
    {
        // Rotates a vector by an angle in degrees
        public static Vector2 Rotate(Vector2 v, float degrees)
        {
            float radians = MathHelper.DegreesToRadians(degrees);
            float cos = (float)Math.Cos(radians);
            float sin = (float)Math.Sin(radians);
            return new Vector2(v.X * cos - v.Y * sin, v.X * sin + v.Y * cos);
        }

        // Rotates a vector around a pivot point by an angle in degrees
        public static Vector2 RotateAround(Vector2 v, Vector2 pivot, float degrees)
        {
            Vector2 translated = v - pivot;
            Vector2 rotated = Rotate(translated, degrees);
            return rotated + pivot;
        }
    }
}
