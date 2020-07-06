
using System.Collections.Generic;


namespace StereoFramework.GameApp.ECS.comps_scene
{
	public interface ISceneComponent
	{
		void process(List<Entity> entities);
	}
}
