
using System.Collections.Generic;
using GameApp;
using Microsoft.Xna.Framework;

namespace StereoFramework.GameApp.ECS.comps_scene
{
	public interface ISceneComponent
	{
        void Initialize(App app);
		void Process(List<Entity> entities, GameTime gameTime);
	}
}
