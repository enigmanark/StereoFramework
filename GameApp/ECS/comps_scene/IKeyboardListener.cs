using System;
using Microsoft.Xna.Framework.Input;

namespace StereoFramework.GameApp.ECS.comps_scene
{
    public interface IKeyboardListener
    {
        void KeysPressed(Keys[] keys);
    }
}
