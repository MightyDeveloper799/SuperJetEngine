using OpenTK;
using OpenTK.Graphics;

namespace SuperJet
{
    public class Program
    {
        private Particle particle;
        private ParticleSystem particleSystem;

        public static void Main()
        {
            using (GameWindow game = new GameWindow(800, 600, GraphicsMode.Default))
            {
                Game mainGame = new Game(game);
                game.Load += mainGame.Load;                
                game.UpdateFrame += mainGame.UpdateFrame;
                game.RenderFrame += mainGame.RenderFrame;
                game.Run(60.0);
            }
        }
    }
}
