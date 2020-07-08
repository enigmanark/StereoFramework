using System.Collections.Generic;
using GameApp;
using Microsoft.Xna.Framework.Input;

namespace StereoFramework.GameApp.ECS.comps_scene.comps
{
    public class SceneComponentInputHandler : ISceneComponentInputHandler, ISceneComponent
    {     
        public void Initialize(App app)
        {

        }

        public void Process(List<ISceneComponent> comps)
        {
            KeyboardState keyboard = Keyboard.GetState();
            foreach(ISceneComponent c in comps)
            {
                if(c is IKeyboardListener)
                {
                    IKeyboardListener l = c as IKeyboardListener;
                    l.KeysPressed(keyboard.GetPressedKeys());
                }
            }
        }

        public void Process(List<Entity> entities)
        {

        }
    }
}
