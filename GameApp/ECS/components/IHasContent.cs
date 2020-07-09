using System;
using GameApp;

namespace StereoFramework.GameApp.ECS.components
{
    public interface IHasContent
    {
        void OnLoad(App app);
        void OnUnload();
    }
}
