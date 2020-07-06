using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRetrosic.GameApp.ECS.comps_scene
{
	interface ISceneComponent
	{
		void process(List<Entity> entities);
	}
}
