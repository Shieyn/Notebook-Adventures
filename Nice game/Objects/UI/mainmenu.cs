using System;
using Sh.Framework.Objects;
using Sh.Framework.Graphics;
using Sh.Framework.Graphics.UI;
using Sh.Framework.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nice_game.rules;
using Nice_game.screens.menus;
using Nice_game.UI;

namespace Nice_game.Objects.UI
{
    /// <summary>
    /// The generic type for a menu
    /// </summary>
    public class mainmenu : GenericObject
    {
        Game game;

        Texture2D title;
        Button play;
        Button music;
        Button settings;
        Sprite footer;
        Pane pane;
        NB_dialoguebox leaveConfirmation;

        public gameManager manager;
        public home home;

        int middle;
        bool visible;

        //Shows a different set of buttons depending on the context the instance has been set in.
        public enum context
        {
            menu,
            game
        }

        context c;
        string b1Text;
        string b2Text;
        string b3Text;

        public mainmenu(Game Game, context c)
        {
            game = Game;
            middle = 768 / 2;
            visible = true;
            this.c = c;

            if (manager != null)
            {
                manager = new gameManager(game);
            }

            switch (c)
            {
                case context.menu:
                    b1Text = "play";
                    b2Text = "settings";
                    b3Text = "music";
                    break;

                case context.game:
                    b1Text = "resume";
                    b2Text = "back";
                    b3Text = "retry";
                    break;
            }

            leaveConfirmation = new NB_dialoguebox(game);
        }

        public override void LoadContent()
        {
            leaveConfirmation.LoadContent();
            title = game.Content.Load<Texture2D>("Textures/UI/title");

            Texture2D Left = game.Content.Load<Texture2D>("Textures/UI/button/bL");
            Texture2D Right = game.Content.Load<Texture2D>("Textures/UI/button/bR");
            Texture2D Middle = game.Content.Load<Texture2D>("Textures/UI/button/bM");
            SpriteFont font = game.Content.Load<SpriteFont>("fonts/small");

            leaveConfirmation.LoadContent();
            leaveConfirmation.visible = false;
            leaveConfirmation.title = "Are you sure?";
            leaveConfirmation.message = "All progress is unsaved";
            leaveConfirmation.buttonYoffset = 15;
            leaveConfirmation.MessagePadding = new Vector2(0, 12);
            leaveConfirmation.Type = DialogueBox.type.yesno;

            footer = new Sprite()
            {
                texturename = "Textures/UI/footer",
                color = Color.White,
                position = Vector2.Zero,
                game = game
            };footer.LoadContent();

            pane = new Pane()
            {
                color = Color.Gray,
                buttonLeft = Left,
                buttonMiddle = Middle,
                buttonRight = Right,
                rect = new Rectangle(40, middle - 50, 320, 200)
            };

            play = new Button()
            {
                buttonLeft = Left,
                buttonRight = Right,
                buttonMiddle = Middle,
                labelFont = font,
                label = b1Text,
                focused = true,
                rect = new Rectangle(50, middle, 300, 50)
            }; play.LoadContent();

            music = new Button()
            {
                buttonLeft = Left,
                buttonRight = Right,
                buttonMiddle = Middle,
                labelFont = font,
                label = b3Text,
                focused = true,
                rect = new Rectangle(50, middle + 60, 150, 50)
            }; music.LoadContent();

            settings = new Button()
            {
                buttonLeft = Left,
                buttonRight = Right,
                buttonMiddle = Middle,
                labelFont = font,
                label = b2Text,
                focused = true,
                rect = new Rectangle(200, middle + 60, 150, 50)
            }; settings.LoadContent();

            base.LoadContent();
        }

        public override void Update()
        {
            if (visible)
            {
                play.Update();
                music.Update();
                settings.Update();
                leaveConfirmation.Update();
                
                if (play.pressed)
                {
                    if (c == context.menu)
                    {
                        //new game
                        ScreenManager.Instance.currentscreen = new loading(game);
                        ScreenManager.Instance.reloadscreen();
                        play.pressed = false;
                    }
                    else
                    {
                        //resume game
                        manager.paused = false;
                    }
                    play.pressed = false;
                }

                if (settings.pressed)
                {
                    if (c == context.menu)
                    {
                        //settings menu
                        ScreenManager.Instance.currentscreen = new Settings(game);
                        ScreenManager.Instance.reloadscreen();
                        settings.pressed = false;
                    }
                    else
                    {
                        //home
                        leaveConfirmation.visible = true;
                        if (leaveConfirmation.outcome)
                        {
                            ScreenManager.Instance.currentscreen = new home(game);
                            ScreenManager.Instance.reloadscreen();
                        }
                    }
                }

                if (music.pressed)
                {
                    if (c == context.menu)
                    {
                        //music room
                        ScreenManager.Instance.currentscreen = new Music(game);
                        ScreenManager.Instance.reloadscreen();
                    }
                    else
                    {
                        //load loading screen and then reload screen
                        ScreenManager.Instance.currentscreen = new loading(game);
                        ScreenManager.Instance.reloadscreen();
                    }
                }
            }

            base.Update();
        }

        /// <summary>
        /// shows the menu
        /// </summary>
        public void show()
        {
            visible = true;
        }

        /// <summary>
        /// hides the menu
        /// </summary>
        public void hide()
        {
            visible = false;
        }

        public override void Draw(SpriteBatch batch)
        {
            if (visible)
            {
                batch.Draw(title, new Vector2(0, 0), Color.White);

                pane.Draw(batch);

                play.Draw(batch);
                music.Draw(batch);
                settings.Draw(batch);
                footer.Draw(batch);

                leaveConfirmation.Draw(batch);
            }

            base.Draw(batch);
        }
    }
}
