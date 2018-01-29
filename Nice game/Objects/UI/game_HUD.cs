using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sh.Framework.Objects;
using Sh.Framework.Graphics;
using Nice_game.Objects.entities;

namespace Nice_game.Objects.UI
{
    /// <summary>
    /// Generic type for rendering game-related GUI
    /// </summary>
    public class game_HUD : GenericObject
    {
        Game game;
        Player player;

        Sprite heart;
        Sprite sword;

        SpriteFont font;

        public game_HUD(Game Game, Player p)
        {
            game = Game;
            player = p;
        }

        public override void LoadContent()
        {
            font = game.Content.Load<SpriteFont>("fonts/big");

            heart = new Sprite()
            {
                texturename = "Textures/UI/HUD/heart",
                color = Color.White,
                game = game
            }; heart.LoadContent();

            sword = new Sprite()
            {
                texturename = "Textures/UI/HUD/sword",
                color = Color.White,
                game = game
            }; sword.LoadContent();

            base.LoadContent();
        }

        public override void Draw(SpriteBatch batch)
        {
            if (player != null)
            {
                for (int i = 0; i < player.ps.lives; i++)
                {
                    heart.position = new Vector2(32 * i, 0);
                    heart.Draw(batch);
                }

                for (int i = 0; i < player.ps.sAttk; i++)
                {
                    sword.position = new Vector2(1366 - 32 * (i + 1), 0);
                    sword.Draw(batch);
                }

                batch.DrawString(
                        font,
                        "coins " + player.ps.coins.ToString(),
                        new Vector2 (0, 768 - font.MeasureString ("1").X * 4),
                        Color.Yellow
                    );

                string scoretext = "score " + player.ps.Score.ToString();
                batch.DrawString(font, scoretext, new Vector2(0, 768 - font.MeasureString(scoretext).Y), Color.White);
            }

            base.Draw(batch);
        }
    }
}
