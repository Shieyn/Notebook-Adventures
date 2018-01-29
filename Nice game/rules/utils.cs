using Sh.Framework.Screens;
using Nice_game.screens.gameScreen;
using Nice_game.screens.menus;
using Microsoft.Xna.Framework;

namespace Nice_game.rules
{
    /// <summary>
    /// handles miscellaneous actions (will merge with, or implement into gameManager later
    /// </summary>
    public static class utils
    {
        /// <summary>
        /// Calls a death screen depending on what ID has been given
        /// </summary>
        /// <param name="id">context regarding death</param>
        /// <param name="game"></param>
        public static void restart(string id, Game game)
        {
            switch (id)
            {
                case "tests":
                    ScreenManager.Instance.currentscreen = new home(game);
                    ScreenManager.Instance.reloadscreen();
                    break;

                case "def":
                    ScreenManager.Instance.currentscreen = new home(game);
                    ScreenManager.Instance.reloadscreen();
                    break;
            }
        }
    }
}
