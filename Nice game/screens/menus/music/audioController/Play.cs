using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;

namespace Nice_game.screens.menus.music.audioController
{
    public class Play : Citem
    {
        public Play(Game Game) : base (Game)
        {
            path = prefix + "play";
            name = "play";
        }

        public override void LoadContent()
        {
            rect = new Rectangle(20, 768 - 50, 30, 30);
            base.LoadContent();
        }

        public override void OnClick()
        {
            MediaPlayer.Resume();
            base.OnClick();
        }
    }
}
