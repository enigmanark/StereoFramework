using GameApp;

namespace StereoFramework.GameApp.ECS.comps_e
{
	public interface IComponent
	{
        void OnInitialize(App app);
		void OnLoad(App app);
		void OnUnload();
	}
}
