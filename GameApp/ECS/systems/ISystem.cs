
using System.Collections.Generic;
using GameApp;
using Microsoft.Xna.Framework;

namespace StereoFramework.GameApp.ECS.systems
{
	public interface ISystem
	{
        void Initialize(App app);
        void PostInitialization(App app);
		void Process(List<Entity> entities, GameTime gameTime);
	}
}
