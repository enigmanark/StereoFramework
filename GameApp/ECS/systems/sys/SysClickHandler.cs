using System;
using System.Collections.Generic;
using GameApp;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using StereoFramework.GameApp.ECS.components.comps;

namespace StereoFramework.GameApp.ECS.systems.sys
{
    public class SysClickHandler : ISystem, IEventListener
    {
        private List<Entity> currentEntities;
        private EventBoard eventBoard;

        public SysClickHandler(App app)
        {
            this.eventBoard = app.GetEventBoard();
        }

        public void Initialize(App app)
        {

        }

        public void Notify(Event e)
        {
            if(e == Event.MouseDown)
            {
                foreach (Entity entity in this.currentEntities)
                {
                    var c = entity.GetComponent<Comp_Click>();
                    if (c != null)
                    {
                        var click = c as Comp_Click;
                        var s = entity.GetComponent<Comp_Spatial>();
                        var spatial = s as Comp_Spatial;

                        var mouse = Mouse.GetState();
                        var mpos = mouse.Position;
                        if(spatial.GetRectangle().Contains(mpos))
                        {
                            this.eventBoard.Post(click.theEvent);
                        }
                    }
                }
            }
        }

        public void PostInitialization(App app)
        {

        }

        public void Process(List<Entity> entities, GameTime gameTime)
        {
            this.currentEntities = entities;
        }
    }
}
