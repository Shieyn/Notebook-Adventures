using Sh.Framework.Objects;

namespace Nice_game.screens.menus.settings
{
    public class Preference : GenericObject
    {
        public enum InType
        {
            checkbox,
            dropdown,
            button,
            slider
        }

        public InType inputType;
        public string label;
        public string description;

        //Checkbox checkbox;

        public Preference()
        {

        }

        public override void LoadContent()
        {
            switch (inputType)
            {
                case InType.checkbox:

                    break;

                case InType.dropdown:
                    break;

                case InType.button:
                    break;

                case InType.slider:
                    break;
            }
            base.LoadContent();
        }
    }
}
