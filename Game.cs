using OpenTK;
using OpenTK.Graphics.OpenGL;
using SuperJetEngine;
using System;

namespace SuperJet
{
    public class Game
    {
        private GameWindow gameWindow;
        private Player player;
        private SceneManager sceneManager;
        private AdvancedGenerator advancedGenerator;

        public Game(GameWindow gameWindow)
        {
            this.gameWindow = gameWindow;
            sceneManager = new SceneManager();
            sceneManager.AddScene("Main Menu", new MainScene());
            sceneManager.AddScene("Game", new GameScene());
            sceneManager.ChangeScene("Main Menu");
            player = new Player();
            advancedGenerator = new AdvancedGenerator();
        }

        public void Load(object sender, EventArgs e)
        {
            advancedGenerator.GenerateLevel();
            Physics.AddGameObject(player);
        }

        public void UpdateFrame(object sender, FrameEventArgs e)
        {
            Input.Update();
            Physics.Update();
            player.Update();
            sceneManager.Update();
        }

        public void RenderFrame(object sender, FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            advancedGenerator.Render();
            player.Render();
            sceneManager.Render();
            UI.RenderText("Score: 100", 0.1f, 0.9f);

            gameWindow.SwapBuffers();
        }

        public void AddJavaCodes(string SourceDirectory, string javaClassPath)
        {
            ScriptManager.AddJavaClass(SourceDirectory, javaClassPath);
        }

        public void ExecuteJavaCodes(string javaClassPath)
        {
            string outputDirectory = "compiled_scripts";
            ScriptExecuter.ExecuteJavaClass(javaClassPath, outputDirectory);
        }
    }
}
