using GameApp;

namespace StereoFramework.GameApp.ECS.components
{
	public interface IComponent
	{
        void OnInitialize(App app);
		void OnLoad(App app);
		void OnUnload();
	}
}
