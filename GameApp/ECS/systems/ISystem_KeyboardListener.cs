using System;
using Microsoft.Xna.Framework.Input;

namespace StereoFramework.GameApp.ECS.systems
{
    public interface ISystem_KeyboardListener
    {
        void KeysPressed(Keys[] keys);
    }
}
