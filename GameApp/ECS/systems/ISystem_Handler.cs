using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace StereoFramework.GameApp.ECS.systems
{
    public interface ISystem_Handler
    {
        void Process(List<ISystem> comps, GameTime gameTime);
    }
}
