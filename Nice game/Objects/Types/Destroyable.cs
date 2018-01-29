using Microsoft.Xna.Framework;
using Nice_game.Objects.entities;
using Nice_game.screens.gameScreen;
using Sh.Framework.Objects;

namespace Nice_game.Objects.Types
{
    /// <summary>
    /// A generic type for destroyable objects
    /// </summary>
    public class Destroyable : GameObject
    {
        Player player;
        public int index;

        protected string fPrefix = "Textures/pickups/";

        public Destroyable(Game Game, int ind, Player p) : base (Game)
        {
            player = p;
            index = ind;
        }

        public override void Update()
        {
            Rectangle thisrect = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            Rectangle otherrect = new Rectangle((int)player.position.X, (int)player.position.Y, (int)player.textureWidth, (int)player.textureHeight);

            if (thisrect.Intersects(otherrect))
            {
                onPickup();

                level.pickups.RemoveAt(index);

                foreach (Destroyable p in level.pickups)
                {
                    if (p.index > this.index)
                    {
                        p.index--;
                    }
                }
            }

            base.Update();
        }

        /// <summary>
        /// called when player touches this object;
        /// </summary>
        public virtual void onPickup()
        { }
    }
}
