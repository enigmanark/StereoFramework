using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace StereoFramework.GameApp.ECS.comps_scene
{
    public interface ISceneComponentHandler
    {
        void Process(List<ISceneComponent> comps, GameTime gameTime);
    }
}
