using Sh.Framework.Objects;
using Microsoft.Xna.Framework.Input;

namespace Nice_game.Objects.PlayerBehaviours.Attacks
{
    public class Attack : GenericObject
    {
        protected string name;
        protected string desc;
        public int ID;
        public MouseState mouse_newState;
        public MouseState mouse_oldState;
    }
}
