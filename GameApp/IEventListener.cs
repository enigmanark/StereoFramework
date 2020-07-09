using System;
namespace StereoFramework.GameApp
{
    public interface IMessageListener
    {
        void Notify(Message e);
    }
}
