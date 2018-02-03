using Sh.Framework.Objects;
using Microsoft.Xna.Framework;
using Nice_game.screens.gameScreen;
using Nice_game.Objects.triggers;
using Nice_game.Objects.Types;

namespace Nice_game.Objects.entities
{
    public class camera : GenericObject
    {
        public Rectangle ViewPort;
        public float speed;

        public enum status
        {
            Dynamic,
            Static
        }

        public status Status = status.Dynamic;

        public Player focus;

        public camera()
        {
        }

        public override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Update()
        {
            speed = level.player.GPO.hsp;
            ViewPort = new Rectangle(0 + (int)speed, 0, 1366, 768);

            if (Status == status.Dynamic)
            {
                if (focus.position.X > 1366 / 4 || focus.position.X < 300)
                {
                    foreach (GameObject g in level.tiles)
                    {
                        g.position.X -= speed;
                    }

                    foreach (Enemy e in level.enemies)
                    {
                        e.position.X -= speed;
                    }

                    foreach (GameObject g in level.deco)
                    {
                        g.position.X -= speed;
                    }

                    foreach (GameObject g in level.pickups)
                    {
                        g.position.X -= speed;
                    }

                    foreach (Trigger t in level.triggers)
                    {
                        t.x -= speed;
                    }

                    foreach (Danmaku d in level.projectiles)
                    {
                        d.position.X -= speed;
                    }

                    level.boss.container.X -= (int)speed;

                    focus.GPO.position.X -= speed;
                }
            }

            base.Update();
        }
    }
}
