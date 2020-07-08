using GameApp;

namespace StereoFramework.GameApp.ECS.components
{
	public interface IComponent
	{
        void SetParentEntity(Entity e);
        void OnInitialize(App app);
		void OnLoad(App app);
		void OnUnload();
	}
}
