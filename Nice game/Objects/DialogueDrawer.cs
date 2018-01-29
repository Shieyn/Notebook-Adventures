using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sh.Framework.Objects;
using Sh.Framework.Graphics.UI;
using Sh.Framework.Graphics;

namespace Nice_game.Objects
{
    public class DialogueDrawer : GenericObject
    {
        Pane pane;
        Game game;

        /// <summary>
        /// Who is talking
        /// </summary>
        Text speaker;   

        /// <summary>
        /// What are they saying
        /// </summary>
        Text message;

        int height = 140;

        float mainAlpha = 0;

        public DialogueDrawer(Game Game)
        {
            game = Game;
        }

        public override void LoadContent()
        {
            pane = new Pane()
            {
                buttonLeft = game.Content.Load<Texture2D>("Textures/UI/box/boxleft"),
                buttonRight = game.Content.Load<Texture2D>("Textures/UI/box/boxright"),
                buttonMiddle = game.Content.Load<Texture2D>("Textures/UI/box/boxmiddle"),
                alpha = mainAlpha - 3.0f,
                color = Color.White,
                rect = new Rectangle (0, 768 - height, 1366, height)
            };

            speaker = new Text()
            {
                color = Color.Black * mainAlpha,
                game = this.game,
                font = "fonts/big",
                position = new Vector2(5, 768 - height + 15),
                text = "speaker"
            }; speaker.LoadContent();

            message = new Text()
            {
                color = Color.Black * mainAlpha,
                game = this.game,
                font = "fonts/small",
                position = new Vector2(5, 768 - height + 70),
                text = "message"
            }; message.LoadContent();

            base.LoadContent();
        }

        public void DrawMessage(string speakerText, string messageText)
        {
            speaker.text = speakerText;
            message.text = messageText;
        }

        public void show()
        {
            mainAlpha = 1.0f;
        }

        public void hide()
        {
            mainAlpha = 0;
        }

        public override void Update()
        {
            speaker.color = Color.Black * mainAlpha;
            message.color = Color.Black * mainAlpha;
            pane.alpha = mainAlpha;

            base.Update();
        }

        public override void Draw(SpriteBatch batch)
        {
            pane.Draw(batch);
            speaker.Draw(batch);
            message.Draw(batch);

            string continueText = "Space to continue...";
            batch.DrawString(speaker.useFont, continueText, new Vector2(1366 - speaker.useFont.MeasureString(continueText).X - 10, 768 - speaker.useFont.MeasureString(continueText).Y - 20), Color.Gray * mainAlpha);

            base.Draw(batch);
        }
    }
}
