using Sh.Framework.Objects;
using Microsoft.Xna.Framework;
using Nice_game.Objects;
using Nice_game.Objects.entities;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sh.Framework.Input;
using Nice_game.screens.gameScreen;

namespace Nice_game.Readonly
{
    /// <summary>
    /// Object for returning approrpiate dialogue
    /// </summary>
    public class ScriptManager : GenericObject
    {
        private Game game;
        public DialogueDrawer dd;
        bool toggleDialogue;

        Player player;

        KeyboardState oldState;
        KeyboardState newState;

        int prog = 0;

        public bool awaitingDialogue;

        public ScriptManager(Game Game, Player p)
        {
            dd = new DialogueDrawer(Game);
            game = Game;
            oldState = Keyboard.GetState();
            player = p;
            awaitingDialogue = true;
        }

        public override void LoadContent()
        {
            dd.LoadContent();
            base.LoadContent();
        }

        public override void Update()
        {
            dd.Update();

            if (toggleDialogue)
            {
                player.enableMovement = false;
                dd.show();

                newState = Keyboard.GetState();

                if (KeyboardStroke.KeyDown(oldState, newState, Keys.Space))
                {
                    prog++;
                }

                oldState = newState;

                switch (level.stageID)
                {
                    case 1:
                        switch (prog)
                        {
                            case 0:
                                dd.DrawMessage("???", "who are you?");
                                break;

                            case 1:
                                dd.DrawMessage("you", "a faggot");
                                break;

                            case 2:
                                awaitingDialogue = false;
                                toggleDialogue = false;
                                break;
                        }
                        break;
                }
            }
            else
            {
                player.enableMovement = true;
                dd.hide();
            }
            base.Update();
        }

        public void start()
        {
            toggleDialogue = true;
        }

        public override void Draw(SpriteBatch batch)
        {
            dd.Draw(batch);
            base.Draw(batch);
        }
    }
}
