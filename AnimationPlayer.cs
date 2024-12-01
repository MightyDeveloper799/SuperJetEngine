using System.Collections.Generic;
using System.Drawing;

namespace SuperJet
{
    public class AnimationPlayer
    {
        private List<RectangleF> frames;
        private int currentFrame;
        private float frameTime;
        private float elapsedTime;
        private int spriteSheetWidth;
        private int spriteSheetHeight;

        public AnimationPlayer(int spriteSheetWidth, int spriteSheetHeight)
        {
            frames = new List<RectangleF>();
            currentFrame = 0;
            frameTime = 0.1f;
            elapsedTime = 0f;
            this.spriteSheetWidth = spriteSheetWidth;
            this.spriteSheetHeight = spriteSheetHeight;
        }

        public void AddFrame(int x, int y, int width, int height)
        {
            RectangleF frame = new RectangleF((float)x / spriteSheetWidth, (float)y / spriteSheetHeight, (float)width / spriteSheetWidth, (float)height / spriteSheetHeight);
            frames.Add(frame);
        }

        public void Update(float deltaTime)
        {
            elapsedTime += deltaTime;

            if(elapsedTime >= frameTime)
            {
                currentFrame = (currentFrame + 1) % frames.Count;
                elapsedTime = 0f;
            }
        }

        public RectangleF GetCurrentFrame()
        {
            return frames[currentFrame];
        }
    }
}
