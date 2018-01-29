using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;

namespace Nice_game.screens.menus.music.audioController
{
    public class PlayRandom : Citem
    {
        private Game game;

        public Music music;

        static Random rnd;

        public PlayRandom(Game Game) : base(Game)
        {
            game = Game;
            path = prefix + "random";
            name = "random";
        }

        public override void LoadContent()
        {
            rect = new Rectangle(170, 768 - 50, 30, 30);
            base.LoadContent();
        }

        public override void OnClick()
        {
            rnd = new Random();
            int n = rnd.Next(music.library.Count);
            MediaPlayer.Play(music.library[n].song);
            music.nowPlaying = music.library[n].song.Name;

            base.OnClick();
        }
    }
}
