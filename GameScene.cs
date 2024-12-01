using OpenTK.Graphics.OpenGL;

namespace SuperJet
{
    public class GameScene : Scene
    {
        private Player player;
        private AdvancedGenerator advancedGenerator;

        public override void Load()
        {
            player = new Player();
            advancedGenerator = new AdvancedGenerator();
            advancedGenerator.GenerateLevel();
            Physics.AddGameObject(player);
        }

        public override void Render()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            advancedGenerator.Render();
            player.Render();
            UI.RenderText("Score: 100", 0.1f, 0.9f);
        }

        public override void Update()
        {
            Input.Update();
            Physics.Update();
            player.Update();
        }
    }
}
