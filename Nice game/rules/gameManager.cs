using Sh.Framework.Objects;
using Sh.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Nice_game.Objects.UI;
using Nice_game.Objects.entities;

namespace Nice_game.rules
{
    /// <summary>
    /// has functions that keep the game in check
    /// </summary>
    public class gameManager : GenericObject
    {
        private Game game;

        private mainmenu menu;

        KeyboardState oldState;
        KeyboardState newState;

        public Player player;
        public bool paused;

        Texture2D p;

        public gameManager(Game Game)
        {
            game = Game;

            oldState = Keyboard.GetState();

            paused = false;

            menu = new mainmenu(game, mainmenu.context.game);
            menu.manager = this;
            menu.hide();
        }

        public override void LoadContent()
        {
            menu.LoadContent();

            p = game.Content.Load<Texture2D>("p");

            base.LoadContent();
        }

        public override void Update()
        {
            newState = Keyboard.GetState();

            if (KeyboardStroke.KeyDown(oldState, newState, Keys.Escape))
            {
                if (paused)
                {
                    paused = false;
                }
                else
                {
                    paused = true;
                }
            }
            

            oldState = newState;

            if (paused)
            {
                menu.show();
            }
            else
            {
                menu.hide();
            }
            menu.Update();

            if (!game.IsActive)
                paused = true;

            base.Update();
        }

        public override void Draw(SpriteBatch batch)
        {
            if (paused)
            {
                batch.Draw(p, new Rectangle(0, 0, 1366, 768), Color.Black * 0.5f);
            }

            menu.Draw(batch);

            base.Draw(batch);
        }
    }
}
