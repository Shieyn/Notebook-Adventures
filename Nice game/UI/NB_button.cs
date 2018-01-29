using Sh.Framework.Graphics.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Nice_game.UI
{
    public class NB_button : Button
    {
        Game game;

        public NB_button(Game Game)
        {
            game = Game;
        }

        public override void LoadContent()
        {
            buttonLeft = game.Content.Load<Texture2D>("Textures/UI/button/bL");
            buttonMiddle = game.Content.Load<Texture2D>("Textures/UI/button/bM");
            buttonRight = game.Content.Load<Texture2D>("Textures/UI/button/bR");
            labelFont = game.Content.Load<SpriteFont>("fonts/small");
            base.LoadContent();
        }
    }
}
