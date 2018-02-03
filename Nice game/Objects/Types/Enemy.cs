using Sh.Framework.Objects;
using Microsoft.Xna.Framework;
using Nice_game.screens.gameScreen;
using Nice_game.Objects.entities;
using System.Collections.Generic;
using System.Linq;

namespace Nice_game.Objects.Types
{
    public class Enemy : GameObject
    {
        public camera camera;
        public int index;
        Player player;

        protected int bonus;
        protected float speed;
        protected string dest;

        public Enemy(Game Game, Vector2 pos, Player p, int id, camera c) : base(Game)
        {
            camera = c;
            player = p;
            index = id;
            texturename = dest;
            position = pos;
        }

        public override void Update()
        {
            Rectangle thisrect;
            Rectangle otherrect;

            thisrect = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            otherrect = new Rectangle((int)player.position.X, (int)player.position.Y, (int)player.textureWidth, (int)player.textureHeight);

            if (thisrect.Intersects(otherrect))
            {
                OnCollision();
            }

            List<Danmaku> staticProjectiles = new List<Danmaku>();
            staticProjectiles = level.projectiles.ToList();
            foreach (Danmaku d in staticProjectiles)
            {
                if (d.hitbox.Intersects(thisrect))
                {
                    Destroy();
                    d.Destroy();
                }
            }
            base.Update();
        }

        public virtual void OnCollision()
        {
            if (!player.PAH.sc.attacking)
            {
                player.ps.lives--;
            }
            else
            {
                player.ps.Score += bonus;
            }

            Destroy();
        }

        public void Destroy()
        {
            level.enemies.RemoveAt(index);

            foreach (Enemy e in level.enemies)
            {
                if (e.index > this.index)
                {
                    e.index--;
                }
            }
        }
    }
}
