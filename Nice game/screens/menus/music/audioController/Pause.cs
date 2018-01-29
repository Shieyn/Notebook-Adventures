using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;

namespace Nice_game.screens.menus.music.audioController
{
    public class Pause : Citem
    {
        public Pause(Game Game) : base (Game)
        {
            path = prefix + "pause";
            name = "pause";
        }

        public override void LoadContent()
        {
            rect = new Rectangle(50, 768 - 50, 30, 30);
            base.LoadContent();
        }

        public override void OnClick()
        {
            MediaPlayer.Pause();
            base.OnClick();
        }
    }
}
