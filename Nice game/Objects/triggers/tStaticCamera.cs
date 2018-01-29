using Microsoft.Xna.Framework;
using Sh.Framework.Objects;

namespace Nice_game.Objects.triggers
{
    /// <summary>
    /// stops movement of camera
    /// </summary>
    public class tStaticCamera : Trigger
    {
        public tStaticCamera(float x, Game game) : base(x, game)
        {
            name = "StaticCamera";
        }
    }
}
