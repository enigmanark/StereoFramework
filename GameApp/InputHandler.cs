using System.Collections.Generic;
using GameApp;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using StereoFramework.GameApp.ECS;
using StereoFramework.GameApp.ECS.systems;

namespace StereoFramework.GameApp
{
    public class InputHandler
    {
        private EventBoard eventBoard;
        private List<ISystem_KeyboardListener> keyboardSubscribers;

        public InputHandler(App app)
        {
            this.eventBoard = app.GetEventBoard();
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


        public void Process(GameTime gameTime)
        {
            KeyboardState keyboard = Keyboard.GetState();
            foreach(ISystem_KeyboardListener l in this.keyboardSubscribers)
            {
                l.KeysPressed(keyboard.GetPressedKeys());
            }

            MouseState mouse = Mouse.GetState();
            if(mouse.LeftButton == ButtonState.Pressed)
            {
                this.eventBoard.Post(Event.MouseDown);
            }
        }
    }
}
