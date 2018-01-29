using Sh.Framework.Screens;
using Sh.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Threading.Tasks;

namespace Nice_game.screens.menus
{
    public class loading : Screen
    {
        //TODO load game asynchronously

        Game game;
        Text loadText;

        Texture2D pixel;

        string loadingText = "Loading...";
        int a = 0;
        int b = 0;

        public loading(Game Game)
        {
            game = Game;

            loadText = new Text()
            {
                color = Color.White,
                font = "fonts/vanilla",
                game = this.game,
            };loadText.LoadContent();

            pixel = game.Content.Load<Texture2D>("p");
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            loadText.position = new Vector2(0, 768 - loadText.useFont.MeasureString("Loading...").Y);

            spritebatch.Draw(pixel, new Rectangle(0, 0, 1366, 768), Color.Black);

            if (a > 30)
            {
                switch (b)
                {
                    case 0:
                        loadingText = "Loading";
                        break;

                    case 1:
                        loadingText = "Loading.";
                        break;

                    case 2:
                        loadingText = "Loading..";
                        break;

                    case 3:
                        loadingText = "Loading...";
                        b = -1;
                        break;
                }
                b++;
                a = 0;
            }
            else
            {
                a++;
            }

            loadText.text = loadingText;
            loadText.Draw(spritebatch);

            base.Draw(spritebatch);
            start();
        }
        
        public void start()
        {
            ScreenManager.Instance.currentscreen = new gameScreen.level(game, 1);
            ScreenManager.Instance.reloadscreen();
        }
    }
}
