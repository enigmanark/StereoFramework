using System;
using System.Collections.Generic;

namespace StereoFramework.GameApp.ECS.comps_scene
{
    public interface ISceneComponentHandler
    {
        void Process(List<ISceneComponent> comps);
    }
}
