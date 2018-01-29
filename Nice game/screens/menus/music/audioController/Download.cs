using System.Diagnostics;
using Microsoft.Xna.Framework;
using Nice_game.UI;
using Microsoft.Xna.Framework.Graphics;

namespace Nice_game.screens.menus.music.audioController
{
    public class Download : NB_button
    {
        Game game;

        public Music music;
        public string np;

        public Download(Game Game) : base(Game)
        {
            label = "Download";
            game = Game;
        }

        public override void OnClick()
        {
            string ID = "~null";

            foreach (SongContainer s in music.library)
            {
                if (s.song.Name == np)
                {
                    ID = s.newgroundsID.ToString();
                }
            }

            string URL = @"https://www.newgrounds.com/audio/listen/" + ID;

            if (ID != "~null")
            {
                Process.Start(URL);
            }
            base.OnClick();
        }
    }
}
