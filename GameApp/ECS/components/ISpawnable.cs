using System;
namespace StereoFramework.GameApp.ECS.components
{
    public interface ISpawnable
    {
        Entity GetSpawningEntity();
        void SetSpawning(bool spawn);
        bool IsSpawning();
    }
}
