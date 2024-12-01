using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace SuperJet
{
    public class ImageManager
    {
        private static Dictionary<string, int> images = new Dictionary<string, int>();

        public static int LoadImage(string filePath)
        {
            if (images.ContainsKey(filePath))
                return images[filePath];

            if (!File.Exists(filePath))
                throw new FileNotFoundException("The Image file was not found.", filePath);

            try
            {
                int id = GL.GenTexture();
                GL.BindTexture(TextureTarget.Texture2D, id);

                Bitmap bmp = new Bitmap(filePath);
                BitmapData data = bmp.LockBits(
                    new Rectangle(0, 0, bmp.Width, bmp.Height),
                    ImageLockMode.ReadOnly,
                    System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0,
                    OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);

                bmp.UnlockBits(data);

                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
                GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

                images[filePath] = id;
                return id;
            }

            catch(Exception ex)
            {
                throw new ArgumentException($"Failed to load the image files: {ex.Message}", ex);
            }
        }

        public static int GetImage(string filePath)
        {
            if(images.ContainsKey(filePath))
                return images[filePath];

            throw new ArgumentException("Images can't be loaded.");
        }
    }
}
