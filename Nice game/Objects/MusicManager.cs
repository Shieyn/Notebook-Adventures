using Microsoft.Xna.Framework;
using Sh.Framework.Objects;

namespace Nice_game.Objects
{
    /// <summary>
    /// Object for handling Game wide audio
    /// </summary>
    public class MusicManager : GenericObject
    {
        Game game;
        //TODO

        public MusicManager(Game Game)
        {
            game = Game;
        }

        public override void LoadContent()
        {
            
            base.LoadContent();
        }
    }
}
