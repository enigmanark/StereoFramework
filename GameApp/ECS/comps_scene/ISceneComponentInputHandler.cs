using System;
using System.Collections.Generic;

namespace StereoFramework.GameApp.ECS.comps_scene
{
    public interface ISceneComponentInputHandler
    {
        void Process(List<ISceneComponent> comps);
    }
}
