using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;

namespace Nice_game.screens.menus.music.audioController
{
    public class Repeat : Citem
    {
        public Repeat(Game Game) : base (Game)
        {
            path = prefix + "repeat";
            name = "repeat";
        }

        public override void LoadContent()
        {
            rect = new Rectangle(130, 768 - 50, 30, 30);
            base.LoadContent();
        }

        public override void Update()
        {
            hover = notHover;

            if (MediaPlayer.IsRepeating)
            {
                notHover = Color.Orange;
            }
            else
            {
                notHover = Color.Black;
            }

            base.Update();
        }

        public override void OnClick()
        {
            if (MediaPlayer.IsRepeating)
            {
                MediaPlayer.IsRepeating = false;
            }
            else
            {
                MediaPlayer.IsRepeating = true;
            }

            base.OnClick();
        }
    }
}
