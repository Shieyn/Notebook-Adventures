using Sh.Framework.Screens;
using Sh.Framework.Graphics;
using Sh.Framework.Graphics.UI;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Nice_game.Objects.UI;

namespace Nice_game.screens.menus
{
    public class home : Screen
    {
        Game game;
        mainmenu menu;
        Sprite bg;
        Button exit;
        Texture2D pixel;

        public home(Game Game)
        {
            game = Game;
            menu = new mainmenu(game, mainmenu.context.menu);
        }

        public override void LoadContent()
        {
            menu.LoadContent();

            Texture2D Left = game.Content.Load<Texture2D>("Textures/UI/button/bL");
            Texture2D Right = game.Content.Load<Texture2D>("Textures/UI/button/bR");
            Texture2D Middle = game.Content.Load<Texture2D>("Textures/UI/button/bM");
            SpriteFont font = game.Content.Load<SpriteFont>("fonts/small");

            pixel = game.Content.Load<Texture2D>("p");

            exit = new Button()
            {
                buttonLeft = Left,
                buttonRight = Right,
                buttonMiddle = Middle,
                labelFont = font,
                label = "x",
                focused = true,
                rect = new Rectangle(0, 0, 30, 30),
                buttonColorDefault = Color.Red,
                buttonColorHover = Color.DarkRed,
                buttonColorPressed = Color.Black
            };exit.LoadContent();

            bg = new Sprite()
            {
                texturename = "Textures/bg/bg1",
                color = Color.White,
                position = Vector2.Zero,
                game = game
            };bg.LoadContent();

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            menu.Update();
            exit.Update();

            if (exit.pressed)
            {
                Game1.quit = true;
            }

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            bg.Draw(spritebatch);
            exit.Draw(spritebatch);
            spritebatch.Draw(pixel, new Rectangle(0, 768 - 125, 1366, 125), Color.Black * 0.8f);
            menu.Draw(spritebatch);

            base.Draw(spritebatch);
        }
    }
}
