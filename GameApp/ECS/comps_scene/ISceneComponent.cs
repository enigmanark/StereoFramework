
using System.Collections.Generic;
using GameApp;

namespace StereoFramework.GameApp.ECS.comps_scene
{
	public interface ISceneComponent
	{
        void Initialize(App app);
		void Process(List<Entity> entities);
	}
}
