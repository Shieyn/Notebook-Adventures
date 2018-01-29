using Microsoft.Xna.Framework;
using Nice_game.screens.gameScreen;
using Sh.Framework.Objects;

namespace Nice_game.Objects.Types
{
    public class Danmaku : GameObject
    {
        int index;
        public Rectangle hitbox;

        public Danmaku(Game Game, int ind) : base(Game)
        {
            index = ind;
        }

        public override void Update()
        {
            hitbox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            base.Update();
        }

        public virtual void Destroy()
        {
            level.projectiles.RemoveAt(index);

            foreach (Danmaku d in level.projectiles)
            {
                if (d.index > this.index)
                {
                    d.index--;
                }
            }
        }
    }
}
