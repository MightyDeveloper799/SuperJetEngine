using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace SuperJet
{
    public class Render2D
    {
        public static void DrawTexture(int textureID, RectangleF source, Vector3 Position, Vector2 size)
        {
            GL.BindTexture(TextureTarget.Texture2D, textureID);

            GL.Begin(PrimitiveType.Quads);

            GL.TexCoord2(source.Left, source.Top); GL.Vertex2(Position.X, Position.Y);
            GL.TexCoord2(source.Right, source.Top); GL.Vertex2(Position.X + size.X, Position.Y);
            GL.TexCoord2(source.Right, source.Bottom); GL.Vertex2(Position.X + size.X, Position.Y + size.Y);
            GL.TexCoord2(source.Left, source.Bottom); GL.Vertex2(Position.X, Position.Y + size.Y);

            GL.End();
        }
    }
}
