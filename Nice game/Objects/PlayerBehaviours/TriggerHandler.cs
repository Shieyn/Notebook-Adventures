using Microsoft.Xna.Framework;
using Nice_game.Objects.entities;
using Nice_game.Objects.triggers;
using Nice_game.screens.gameScreen;
using Sh.Framework.Objects;

namespace Nice_game.Objects.PlayerBehaviours
{
    public class TriggerHandler : GenericObject
    {
        public camera cam;
        public level level;
        public Player p;

        public override void Update()
        {
            foreach (Trigger t in level.triggers)
            {
                if (new Rectangle((int)p.position.X, (int)p.position.Y, 32, 64).Intersects(new Rectangle((int)t.x, 0, 32, 768)))
                {
                    onTriggerEnter(t.name);
                }
            }

            base.Update();
        }

        public void onTriggerEnter(string name)
        {
            switch (name)
            {
                case "StaticCamera":
                    cam.Status = camera.status.Static;
                    break;

                case "DynamicCamera":
                    cam.Status = camera.status.Dynamic;
                    break;

                case "Dialogue":
                    level.sm.start();
                    p.GPO.position.X += 32;
                    break;
            }
        }
    }
}
