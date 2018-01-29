using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nice_game.Objects.entities;
using Sh.Framework.Objects;

namespace Nice_game.Objects.PlayerBehaviours
{
    public class StockCombat : GenericObject
    {
        public int AttackType;
        public MouseState mouse_oldState;
        public MouseState mouse_newState;
        public Texture2D pixel;

        //in steps
        public int cooldown;       
        public int invinTime;       

        int a = 0;
        int b = 0;
        int c = 0;
        Player player;

        private bool cooled;
        public bool invin;
        public bool attacking;

        public StockCombat(Player p)
        {
            attacking = false;
            player = p;
            invin = false;
        }

        public override void Update()
        {
            if (AttackType == 0)
            {
                if (mouse_newState.LeftButton == ButtonState.Pressed && mouse_oldState.LeftButton == ButtonState.Released && cooled)
                {
                    cooled = false;
                    attacking = true;
                    a = 0;
                    b = 0;
                }

                if (attacking)
                {
                    if (a > 30)
                    {
                        attacking = false;
                    }
                    else
                    {
                        a++;
                    }
                }

                //cooldown
                if (!cooled && mouse_newState.LeftButton == ButtonState.Released && mouse_oldState.LeftButton == ButtonState.Released)
                {
                    if (b > cooldown)
                    {
                        cooled = true;
                    }
                    else
                    {
                        b++;
                    }
                }

                //invinsibillity
                if (invin)
                {
                    player.ps.lives = 5;

                    if (c > invinTime)
                    {
                        c = 0;
                        invin = false;
                    }
                    else
                    {
                        c++;
                        player.ps.Score++;
                    }
                }
            }
            else
            {
                cooled = true;
                attacking = false;
            }

            //invin
            if (mouse_newState.RightButton == ButtonState.Pressed && mouse_oldState.RightButton == ButtonState.Released && player.ps.sAttk > 0 && !invin)
            {
                player.ps.sAttk--;
                invin = true;
            }

            base.Update();
        }

        public override void Draw(SpriteBatch batch)
        {
            Rectangle cooldownVis = new Rectangle((int)player.position.X, (int)player.position.Y - 30, b, 10);
            Rectangle cooldownRem = new Rectangle(b + (int)player.position.X, (int)player.position.Y - 30, cooldown - b, 10);
            
            if (!cooled)
            {
                batch.Draw(pixel, cooldownVis, Color.Green);
                batch.Draw(pixel, cooldownRem, Color.Gray);
            }
            
            base.Draw(batch);
        }
    }
}
