using Sh.Framework.Objects;
using Microsoft.Xna.Framework;

namespace Nice_game.Objects.triggers
{
    /// <summary>
    /// prompts some dialogue script
    /// </summary>
    public class tDialogue : Trigger
    {
        public tDialogue(float x, Game game) : base(x, game)
        {
            name = "Dialogue";
        }
    }
}
