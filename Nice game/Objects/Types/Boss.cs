using Sh.Framework.Objects;
using Sh.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nice_game.screens.gameScreen;
using System.Collections.Generic;
using System.Linq;

namespace Nice_game.Objects.Types
{
    public class Boss : GenericObject
    {
        private Game game;

        public Rectangle container;
        protected string path;
        protected string bossName;
        public Color color;
        public Texture2D texture;

        public float health;
        Texture2D pixel;

        Text healthText;
        level level;

        public Boss(Game Game, level lvl)
        {
            game = Game;
            level = lvl;
        }

        public override void LoadContent()
        {
            pixel = game.Content.Load<Texture2D>("p");
            texture = game.Content.Load<Texture2D>(path);

            healthText = new Text()
            {
                font = "fonts/big",
                game = this.game,
                text = bossName + ": " + health.ToString()
            };healthText.LoadContent();

            base.LoadContent();
        }

        int n = 0;

        public override void Update()
        {
            int inthealth = (int)health;
            healthText.text = bossName + ": " + inthealth.ToString() + "HP";

            List<Danmaku> staticDanmaku = new List<Danmaku>();
            staticDanmaku = level.projectiles.ToList();
            foreach (Danmaku d in staticDanmaku)
            {
                if (d.hitbox.Intersects(container))
                {
                    health += -0.5f;        //idk how tf this makes the health go down but it does so i'll leave it as is.

                    d.Destroy();
                }
            }

            if (level.player.hitbox.Intersects(container))
            {
                if (n >= 120)
                {
                    level.player.ps.lives--;
                    n = 0;
                }
                else
                {
                    n++;
                }
            }
            else
            {
                n = 120;
            }
        base.Update();
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(texture, container, color);

            Color remColor;

            if (health > 50)
            {
                remColor = Color.Red;
            }
            else
            {
                remColor = Color.DarkRed;
            }

            Rectangle healthBarRem = new Rectangle(0, 768 - 20, (int)(health / 100 * 1366), 20);
            Rectangle healthBarVis = new Rectangle(healthBarRem.Right, 768 - 20, 1366 - healthBarRem.Width, 20);

            if (!level.sm.awaitingDialogue)
            {
                healthText.color = remColor;
                healthText.position = new Vector2(1366 - healthText.useFont.MeasureString(healthText.text).X, 768 - 60);
                batch.Draw(pixel, new Rectangle(1366 - (int)healthText.useFont.MeasureString(healthText.text).X, 768 - 60, 999, 999), Color.White);
                healthText.Draw(batch);

                batch.Draw(pixel, healthBarRem, remColor);
                batch.Draw(pixel, healthBarVis, Color.Gray);
            }

            base.Draw(batch);
        }
    }
}
