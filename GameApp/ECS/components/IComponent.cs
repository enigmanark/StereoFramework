using GameApp;

namespace StereoFramework.GameApp.ECS.components
{
	public interface IComponent
	{
        void SetParentEntity(Entity e);
        void OnAdded();
        void OnInitialize(App app);
	}
}
