using Microsoft.Xna.Framework.Media;

namespace Nice_game.screens.menus.music
{
    /// <summary>
    /// not to be confsued with <see cref="selectContainer"/> 
    /// Holds data regarding soundtrack
    /// </summary>
    public class SongContainer
    {
        public Song song;
        public int newgroundsID;     //the ID part of a newgrounds URL

        public SongContainer(Song s, int ID)
        {
            song = s;
            newgroundsID = ID;
        }
    }
}
