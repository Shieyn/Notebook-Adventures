using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using Sh.Framework.Screens;

namespace Nice_game
{
    public class splash : SplashScreenVideo
    {
        Game game;

        public splash(Game Game)
        {
            game = Game;
        }

        public override void LoadContent()
        {
            splash = game.Content.Load<Video>("splash/splash");
            player = new VideoPlayer();
            splashrect = new Rectangle(0, 0, 1366, 768);
            splashColor = Color.White;

            base.LoadContent();
        }

        public override void OnFinish()
        {
            ScreenManager.Instance.currentscreen = new screens.menus.home(game);
            ScreenManager.Instance.reloadscreen();

            base.OnFinish();
        }
    }
}
