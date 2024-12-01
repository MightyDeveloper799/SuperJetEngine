using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using OpenTK;
using System.Drawing;

namespace SuperJet
{
    public class Player : GameObject
    {
        private float speed = 5f;
        private int texture;
        private float jumpForce = 10f;
        private AnimationPlayer animationPlayer;

        public Player()
        {
            Position = new Vector3(0, 0, 0);
            Bounds = new RectangleF(Position.X, Position.Y, 1, 1);
            texture = Graphics.LoadTexture("C:\\Users\\Administrator\\3D Objects\\Miles Tails Prower\\MilesTailsPrower.blend");

            animationPlayer = new AnimationPlayer(128, 32);
            animationPlayer.AddFrame(0, 0, 32, 32);
            animationPlayer.AddFrame(32, 0, 32, 32);
            animationPlayer.AddFrame(64, 0, 32, 32);
            animationPlayer.AddFrame(96, 0, 32, 32);
        }

        public void Update()
        {
            Vector3 movement = Vector3.Zero;

            if (Input.IsKeyPressed(Key.W))
                movement.Z += speed;

            if (Input.IsKeyPressed(Key.S))
                movement.Z -= speed;

            if (Input.IsKeyPressed(Key.A))
                movement.X += speed;

            if (Input.IsKeyPressed(Key.D))
                movement.X -= speed;

            if (Input.IsKeyPressed(Key.Space))
                ApplyJump();

            Position += movement * 0.016f;

            UpdatePhysics();
            animationPlayer.Update(0.016f);
        }

        private void ApplyJump()
        {
            AddToVelocity(new Vector3(0, jumpForce, speed));
        }

        public void Render()
        {
            GL.BindTexture(TextureTarget.Texture2D, texture);

            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0, 0); GL.Vertex2(Position.X, Position.Y);
            GL.TexCoord2(1, 0); GL.Vertex2(Position.X + 1, Position.Y);
            GL.TexCoord2(1, 1); GL.Vertex2(Position.X + 1, Position.Y + 1);
            GL.TexCoord2(0, 1); GL.Vertex2(Position.X, Position.Y + 1);
            GL.End();

            RectangleF currentFrame = animationPlayer.GetCurrentFrame();
            Render2D.DrawTexture(texture, currentFrame, Position, new Vector2(1, 1));
            Render3D.DrawModel(texture, Rotation, Position, new Vector3(0, 0, 0));
        }
    }
}
