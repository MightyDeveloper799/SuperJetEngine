using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperJet
{
    public class Render3D
    {
        public static void DrawModel(int vertexArrayObject, Vector3 position, Vector3 rotation, Vector3 scale)
        {
            GL.BindVertexArray(vertexArrayObject);

            Matrix4 model = Matrix4.CreateScale(scale) *
                            Matrix4.CreateRotationX(MathHelper.DegreesToRadians(rotation.X)) *
                            Matrix4.CreateRotationY(MathHelper.DegreesToRadians(rotation.Y)) *
                            Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(rotation.Z)) *
                            Matrix4.CreateTranslation(position);

            GL.UniformMatrix4(20, false, ref model);

            GL.DrawArrays(PrimitiveType.Triangles, 0, 3);

            GL.BindVertexArray(0);
        }
    }
}
