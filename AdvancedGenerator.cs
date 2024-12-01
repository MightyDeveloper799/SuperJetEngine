using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Collections.Generic;

namespace SuperJet
{
    public class AdvancedGenerator
    {
        private List<GameObject> gameObjects;

        public AdvancedGenerator()
        {
            gameObjects = new List<GameObject>();
        }

        public void GenerateLevel()
        {
            for(int i = 0; i < 10; i++)
            {
                GameObject obj = new GameObject();
                obj.Position = new Vector3();
                obj.Bounds = new System.Drawing.RectangleF(obj.Position.X, obj.Position.Y, 1, 1);
                gameObjects.Add(obj);
                Physics.AddGameObject(obj);
            }
        }

        public void Render()
        {
            foreach(var obj in gameObjects)
            {
                GL.Begin(PrimitiveType.Quads);
                GL.Vertex2(obj.Position.X, obj.Position.Y);
                GL.Vertex2(obj.Position.X + 1, obj.Position.Y);
                GL.Vertex2(obj.Position.X + 1, obj.Position.Y + 1);
                GL.Vertex2(obj.Position.X, obj.Position.Y + 1);
                GL.End();
            }
        }
    }
}
