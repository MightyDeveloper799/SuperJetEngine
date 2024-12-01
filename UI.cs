using OpenTK.Graphics.OpenGL;
using System;

namespace SuperJet
{
    public class UI
    {
        public static void RenderText(string text, float x, float y)
        {
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex2(x, y);
            GL.Vertex2(x + 1, y);
            GL.Vertex2(x + 1, y + 1);
            GL.Vertex2(x, y + 1);
            GL.End();
        }
    }
}
