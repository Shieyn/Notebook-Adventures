using Microsoft.Xna.Framework;
using Sh.Framework.Objects;

namespace Nice_game.Objects.deco
{
    public class cloud : GameObject
    {
        public cloud(Game Game, int id, Vector2 Position) : base (Game)
        {
            texturename = "Textures/deco/clouds/cloud" + id.ToString();
            color = Color.White;
            position = new Vector2 (Position.X, Position.Y - 128);
        }
    }
}
