using Microsoft.Xna.Framework;
using Sh.Framework.Objects;

namespace Nice_game.Objects.tiles
{
    public class t1 : GameObject
    {
        private Game game;
        private Vector2 Position;

        public t1(Game Game, Vector2 pos) : base (Game)
        {
            game = Game;
            Position = pos;
        }

        public override void LoadContent()
        {
            position = Position;
            texturename = @"Textures/tiles/t2";

            base.LoadContent();
        }
    }
}
