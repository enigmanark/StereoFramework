using System;
namespace StereoFramework.GameApp
{
    public interface IEventListener
    {
        void Notify(Event e);
    }
}
