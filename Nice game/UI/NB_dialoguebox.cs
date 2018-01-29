using Sh.Framework.Graphics.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Nice_game.UI
{
    public class NB_dialoguebox : DialogueBox
    {
        Game game;

        NB_button button;

        public NB_dialoguebox(Game Game)
        {
            game = Game;
        }

        public override void LoadContent()
        {
            button = new NB_button(game);
            button.rect = new Rectangle(0, 0, 140, 30);
            button.LoadContent();

            Pane pane = new Pane()
            {
                buttonLeft = game.Content.Load<Texture2D>("Textures/UI/box/boxleft"),
                buttonMiddle = game.Content.Load<Texture2D>("Textures/UI/box/boxmiddle"),
                buttonRight = game.Content.Load<Texture2D>("Textures/UI/box/boxright"),
                rect = new Rectangle (1366 / 2 - 300 / 2, 768 / 2 - 100 / 2, 300, 100),
                alpha = 1,
                color = Color.White
            };

            font = game.Content.Load<SpriteFont>("fonts/small");
            TitleAlign = Align.Middle;
            MessageAlign = Align.Middle;
            window = pane;
            selectionButton = button;
            base.LoadContent();
        }
    }
}
