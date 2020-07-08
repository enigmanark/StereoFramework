using System.Collections.Generic;
using GameApp;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace StereoFramework.GameApp.ECS.comps_scene.comps
{
    public class SceneComponentInputHandler : ISceneComponentHandler, ISceneComponent
    {
        private List<IKeyboardListener> keyboardSubscribers;

        public SceneComponentInputHandler()
        {
            this.keyboardSubscribers = new List<IKeyboardListener>();
        }

        public void Unsubscribe(IKeyboardListener listener)
        {
            this.keyboardSubscribers.Remove(listener);
        }

        public void Subscribe(IKeyboardListener listener)
        {
            this.keyboardSubscribers.Add(listener);
        }

        public void Initialize(App app)
        {

        }

        public void Process(List<ISceneComponent> comps, GameTime gameTime)
        {
            KeyboardState keyboard = Keyboard.GetState();
            foreach(IKeyboardListener l in this.keyboardSubscribers)
            {
                l.KeysPressed(keyboard.GetPressedKeys());
            }
        }

        public void Process(List<Entity> entities, GameTime gameTime)
        {

        }
    }
}
