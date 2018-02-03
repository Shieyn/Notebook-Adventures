using Sh.Framework.Objects;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Nice_game.Objects.PlayerBehaviours.Attacks
{
    public class Attack : GenericObject
    {
        protected string name;
        protected string desc;
        public int ID;
        public MouseState mouse_newState;
        public MouseState mouse_oldState;
        public Texture2D icon;
        protected string prefix = "Textures/UI/AttackIcons/";
    }
}
