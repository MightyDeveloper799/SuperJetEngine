using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;

namespace SuperJet
{
    public class LevelGenerator
    {
        private List<int> textures;

        public LevelGenerator()
        {
            textures = new List<int>();
        }

        public void GenerateLevel()
        {
            
        }

        public void Render()
        {
            foreach(var texture in textures)
            {
                GL.BindTexture(TextureTarget.Texture2D, texture);
                GL.Begin(PrimitiveType.Quads);
                GL.TexCoord2(0.0, 0.0); GL.Vertex2(0, 0);
                GL.TexCoord2(1.0, 0.0); GL.Vertex2(10, 0);
                GL.TexCoord2(1.0, 1.0); GL.Vertex2(10, 10);
                GL.TexCoord2(0.0, 1.0); GL.Vertex2(0, 10);
                GL.End();
            }
        }
    }
}
