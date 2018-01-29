using Microsoft.Xna.Framework;
using Sh.Framework.Objects;

namespace Nice_game.Objects.tiles
{
    public class t7 : GameObject
    {
        private Game game;
        private Vector2 Position;

        public t7(Game Game, Vector2 pos) : base (Game)
        {
            game = Game;
            Position = pos;
        }

        public override void LoadContent()
        {
            position = Position;
            texturename = @"Textures/tiles/t8";
            base.LoadContent();
        }
    }
}
