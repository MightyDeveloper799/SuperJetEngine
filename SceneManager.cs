using System.Collections.Generic;

namespace SuperJet
{
    public class SceneManager
    {
        private Dictionary<string, Scene> scenes;
        private Scene currentScene;

        public SceneManager()
        {
            scenes = new Dictionary<string, Scene>();
        }

        public void AddScene(string name, Scene scene)
        {
            scenes[name] = scene;
        }

        public void ChangeScene(string name)
        {
            if(scenes.ContainsKey(name))
            {
                currentScene = scenes[name];
                currentScene.Load();
            }
        }

        public void Update()
        {
            if (currentScene != null)
                currentScene.Update();
        }

        public void Render()
        {
            if (currentScene != null)
                currentScene.Render();
        }
    }
}
