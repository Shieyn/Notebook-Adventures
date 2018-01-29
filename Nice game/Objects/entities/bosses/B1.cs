using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nice_game.Objects.Types;
using Nice_game.screens.gameScreen;

namespace Nice_game.Objects.entities.bosses
{
    public class B1 : Boss
    {
        level level;

        public B1(Game Game, float X, level l) : base(Game, l)
        {
            path = "Textures/game/bosses/b1";
            color = Color.White;
            container = new Rectangle((int)X, 0, 256, 256);
            level = l;
            health = 100;
            bossName = "Faggot";
        }

        public override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Update()
        {
            if (!level.sm.awaitingDialogue)
            {
                performAttacks();
            }
            base.Update(); 
        }

        int size = 0;
        bool growth = true;

        public void performAttacks()
        {
            int speed = (100 - (int)health) / 20;

            if (speed == 0)
                speed = 1;

            if (container.X + container.Width / 2 > level.player.position.X)
            {
                container.X -= speed;
            }
            else
            {
                container.X += speed;
            }

            if (container.Y + container.Height / 2 > level.player.position.Y)
            {
                container.Y -= speed;
            }
            else
            {
                container.Y += speed;
            }

            if (50 > health)
            {
                if (growth)
                    size += speed;
                else
                {
                    size -= speed;
                }

                if (size > 256)
                {
                    growth = false;
                }

                if (size < 0)
                {
                    growth = true;
                }

                container.Width = size;
                container.Height = size;
            }

            else if (health <= 0)
            {
                //おまえわもうしんでいる

            }
        }

        public override void Draw(SpriteBatch batch)
        {            
            base.Draw(batch);
        }
    }
}
