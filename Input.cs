using OpenTK.Input;
using System;

namespace SuperJet
{
    public class Input
    {
        public static bool IsKeyPressed(Key key)
        {
            return Keyboard.GetState().IsKeyDown(key);
        }

        public static void Update()
        {

        }
    }
}
