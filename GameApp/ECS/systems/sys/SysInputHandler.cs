using System.Collections.Generic;
using GameApp;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace StereoFramework.GameApp.ECS.systems.sys
{
    public class SystemInputHandler : ISystem_Handler, ISystem
    {
        private List<ISystem_KeyboardListener> keyboardSubscribers;

        public SystemInputHandler()
        {
            this.keyboardSubscribers = new List<ISystem_KeyboardListener>();
        }

        public void Unsubscribe(ISystem_KeyboardListener listener)
        {
            this.keyboardSubscribers.Remove(listener);
        }

        public void Subscribe(ISystem_KeyboardListener listener)
        {
            this.keyboardSubscribers.Add(listener);
        }

        public void Initialize(App app)
        {

        }

        public void Process(List<ISystem> comps, GameTime gameTime)
        {
            KeyboardState keyboard = Keyboard.GetState();
            foreach(ISystem_KeyboardListener l in this.keyboardSubscribers)
            {
                l.KeysPressed(keyboard.GetPressedKeys());
            }
        }

        public void Process(List<Entity> entities, GameTime gameTime)
        {

        }
    }
}
