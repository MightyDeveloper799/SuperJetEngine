using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using OpenTK.Graphics.OpenGL;

namespace SuperJet
{
    public class SpriteSheetManager
    {
        private Dictionary<string, int> spriteSheets;

        public SpriteSheetManager() 
        {
            spriteSheets = new Dictionary<string, int>();
        }

        public int LoadSpriteSheet(string filePath)
        {
            if(spriteSheets.ContainsKey(filePath))
                return spriteSheets[filePath];

            if (!File.Exists(filePath))
                throw new FileNotFoundException("The image file is missing. Double check it if it still exists.");

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

                spriteSheets[filePath] = id;
                return id;
            }

            catch (Exception ex)
            {
                throw new ArgumentException($"Failed to load texture: {ex.Message}", ex);
            }
        }
    }
}
