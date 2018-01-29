using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sh.Framework.Screens;
using Sh.Framework.Graphics;
using Sh.Framework.Graphics.UI;

namespace Nice_game.screens.menus
{
    public class settings : Screen
    {
        Game game;

        Texture2D bg;

        Texture2D shF;
        Texture2D pixel;
        Text shFtext;
        Text tS;
        Text Shieyn;

        Button back;

        Text title;

        public settings(Game Game)
        {
            game = Game;
        }

        public override void LoadContent()
        {
            shF = game.Content.Load<Texture2D>("Textures/UI/branding/shframework");
            pixel = game.Content.Load<Texture2D>("p");

            title = new Text()
            {
                color = Color.Black,
                text = "Settings",
                font = "fonts/big",
                game = game,
                position = new Vector2(135, 81)
            }; title.LoadContent();

            shFtext = new Text()
            {
                color = Color.White,
                text = "Powered by: Sh.Framework",
                font = "fonts/vanilla",
                game = game,
                position = new Vector2(125, 768 - 125 + 62)
            }; shFtext.LoadContent();

            tS = new Text()
            {
                color = Color.White,
                text = "Tiled level editor IO powered by TiledSharp",
                font = "fonts/vanilla",
                game = game,
                position = new Vector2(600, 768 - 125 + 62)
            }; tS.LoadContent();

            Shieyn = new Text()
            {
                color = Color.Black,
                text = "Developed by Shieyn",
                font = "fonts/vanilla",
                game = game,
                position = new Vector2(1366 - 330, 768 - 150)
            }; Shieyn.LoadContent();

            Texture2D Left = game.Content.Load<Texture2D>("Textures/UI/button/bL");
            Texture2D Right = game.Content.Load<Texture2D>("Textures/UI/button/bR");
            Texture2D Middle = game.Content.Load<Texture2D>("Textures/UI/button/bM");
            SpriteFont font = game.Content.Load<SpriteFont>("fonts/small");

            back = new Button()
            {
                buttonLeft = Left,
                buttonRight = Right,
                buttonMiddle = Middle,
                labelFont = font,
                label = "X",
                buttonColorDefault = Color.Red,
                buttonColorHover = Color.DarkRed,
                focused = true,
                rect = new Rectangle (0, 0, 32, 32)
            }; back.LoadContent();

            bg = game.Content.Load<Texture2D>("Textures/bg/bg1");

            base.LoadContent();
        }

        public override void Update(GameTime gametime)
        {
            back.Update();

            if (back.pressed)
            {
                ScreenManager.Instance.currentscreen = new home(game);
                ScreenManager.Instance.reloadscreen();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                ScreenManager.Instance.currentscreen = new home(game);
                ScreenManager.Instance.reloadscreen();
            }

            base.Update(gametime);
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(bg, Vector2.Zero, Color.White);
            title.Draw(spritebatch);

            spritebatch.Draw(pixel, new Rectangle(0, 768 - 125, 1366, 125), Color.Black * 0.8f);
            spritebatch.Draw(shF, new Rectangle(0, 768 - 125, 125, 125), Color.White);
            shFtext.Draw(spritebatch);
            tS.Draw(spritebatch);
            back.Draw(spritebatch);
            Shieyn.Draw(spritebatch);

            base.Draw(spritebatch);
        }
    }
}
