using OpenTK.Graphics.OpenGL;
using System;
using System.IO;

namespace SuperJet
{
    public class Graphics
    {
        public static int LoadTexture(string filePath)
        {
            if (string.IsNullOrEmpty(filePath)) 
                throw new ArgumentException("File path cannot be null or empty.", nameof(filePath));

            if (!File.Exists(filePath)) 
                throw new FileNotFoundException("The image file was not found.", filePath);

            if (!File.Exists(filePath))
                throw new FileNotFoundException("The model file is missing. Double check it if it still exists, and try again.", filePath);

            int vertexArrayObject;
            GL.GenVertexArrays(1, out vertexArrayObject);
            GL.BindVertexArray(vertexArrayObject);

            int vertexBufferObject;
            GL.GenBuffers(1, out vertexBufferObject);
            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBufferObject);
            float[] vertices =
            {
                    -0.5f, -0.5f, 0.0f,
                     0.5f, -0.5f, 0.0f,
                     0.0f, 0.5f, 0.0f
            };
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);

            int positionLocation = 0;
            GL.VertexAttribPointer(positionLocation, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(positionLocation);

            GL.BindVertexArray(0);

            return vertexArrayObject;
        }
    }
}
