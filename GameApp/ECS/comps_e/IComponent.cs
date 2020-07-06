using GameApp;

namespace ProjectRetrosic.GameApp.ECS.comps_e
{
	public interface IComponent
	{
		void OnLoad(App app);
		void OnUnload();
	}
}
