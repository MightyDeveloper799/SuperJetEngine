using OpenTK.Graphics.OpenGL;

namespace SuperJet
{
    public class MainScene : Scene
    {
        public override void Load()
        {

        }

        public override void Render()
        {
            
        }

        public override void Update()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            UI.RenderText("SuperJet Developer Release", 0.1f, 0.9f);
        }
    }
}
