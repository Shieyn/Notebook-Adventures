using Nice_game.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace Nice_game.screens.menus.music
{
    /// <summary>
    /// The box with music in it
    /// </summary>
    public class selectContainer : NB_button
    {
        Texture2D box;
        Game game;

        public Song Song;
        public string newgroundsID;     //The ID part of a newgrounds URL

        public selectContainer(Game Game, Song song) : base (Game)
        {
            game = Game;
            label = song.Name;          //darude sandstorm xddddddddddddddddd hahah im so funny ecks deh
            Song = song;
        }
    }
}
