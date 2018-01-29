using Microsoft.Xna.Framework;
using Sh.Framework.Objects;

namespace Nice_game.Objects.triggers
{
    /// <summary>
    /// resumes movement of camera
    /// </summary>
    public class tDynamicCamera : Trigger
    {
        public tDynamicCamera(float x, Game game) : base(x, game)
        {
            name = "DynamicCamera";
        }
    }
}
