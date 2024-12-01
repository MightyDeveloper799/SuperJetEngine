using System.Collections.Generic;

namespace SuperJet
{
    public class Physics
    {
        private static List<GameObject> gameObjects = new List<GameObject>();

        public static void AddGameObject(GameObject obj)
        {
            gameObjects.Add(obj);
        }

        public static void Update()
        {
            foreach (var obj in gameObjects)
            {
                obj.UpdatePhysics();
            }
        }

        public static bool CheckCollision(GameObject a, GameObject b)
        {
            return a.Bounds.IntersectsWith(b.Bounds);
        }
    }
}
