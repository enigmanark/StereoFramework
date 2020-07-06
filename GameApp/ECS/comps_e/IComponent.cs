using GameApp;

namespace StereoFramework.GameApp.ECS.comps_e
{
	public interface IComponent
	{
		void OnLoad(App app);
		void OnUnload();
	}
}
