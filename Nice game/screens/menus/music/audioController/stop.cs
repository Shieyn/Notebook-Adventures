using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;

namespace Nice_game.screens.menus.music.audioController
{
    public class Stop : Citem
    {
        public Stop(Game Game) : base(Game)
        {
            path = prefix + "stop";
            name = "stop";
        }

        public override void LoadContent()
        {
            rect = new Rectangle(90, 768 - 50, 30, 30);
            base.LoadContent();
        }

        public override void OnClick()
        {
            MediaPlayer.Stop();
            base.OnClick();
        }
    }
}
