using System.Collections.Generic;
using Sh.Framework.Screens;
using Sh.Framework.Physics.Collisions;
using Sh.Framework.Graphics.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Nice_game.screens.menus.music;
using Nice_game.screens.menus.music.audioController;

namespace Nice_game.screens.menus
{
    public class Music : Screen
    {
        Game game;
        Button back;
        Texture2D bg;

        //includes slash
        string prefix = "Audio/soundtrack/";

        //List of all soundtracks to include in the music screen
        public List<SongContainer> library;

        List<selectContainer> buttons;

        AudioController AudioController;

        public string nowPlaying;

        Tooltip description;

        public Music(Game Game)
        {
            game = Game;
            MediaPlayer.Stop();
            AudioController = new AudioController(game, this);
        }

        public override void LoadContent()
        {
            library = new List<SongContainer>();
            buttons = new List<selectContainer>();

            bg = game.Content.Load<Texture2D>("Textures/bg/bg3");

            LoadBack();

            initSongs();

            AudioController.LoadContent();

            description = new Tooltip(game)
            {
                pLeft = "Textures/UI/box/boxLeft",
                pMid = "Textures/UI/box/boxMiddle",
                pRight = "Textures/UI/box/boxRight",
                font = "fonts/small",
            };description.LoadContent();

            foreach (SongContainer s in library)
            {
                buttons.Add(new selectContainer(game, s.song));
            }

            foreach (selectContainer s in buttons)
            {
                s.LoadContent();
            }

            base.LoadContent();
        }

        public override void Update(GameTime gametime)
        {
            UpdateBack();

            AudioController.Update();

            foreach (selectContainer s in buttons)
            {
                s.Update();

                if (s.pressed)
                {
                    MediaPlayer.Play(s.Song);
                    nowPlaying = s.Song.Name;
                    s.pressed = false;
                }
            }

            if (MediaPlayer.State == MediaState.Stopped)
            {
                nowPlaying = "nothing";
            }

            AudioController.NowPlaying = nowPlaying;

            description.Update();

            base.Update(gametime);
        }


        public override void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(bg, Vector2.Zero, Color.White);
            back.Draw(spritebatch);

            int padding = 30;

            int i = 0;
            int ii = 0;
            int y = 0;
            foreach (selectContainer s in buttons)
            {
                if (ii % 5 == 0)
                {
                    y++;
                    i = 0;
                }

                s.rect = new Rectangle(padding + i * 240, padding + y * 100, 240, 100);
                s.Draw(spritebatch);
                i++;
                ii++;
            }

            //this MUST be in a seperate foreach loop or else the z order of the tooltips will screw up
            int count = 0;
            foreach (selectContainer s in buttons)
            {
                if (MouseTouching.RectWithIn(s.rect))
                {
                    description.label = DescriptionManager.description(count);
                    description.LoadContent();
                    description.Draw(spritebatch);
                }
                count++;
            }


            AudioController.Draw(spritebatch);

            base.Draw(spritebatch);
        }

        /// <summary>
        /// Loads back button and all of its assets
        /// </summary>
        void LoadBack()
        {
            Texture2D Left = game.Content.Load<Texture2D>("Textures/UI/button/bL");
            Texture2D Right = game.Content.Load<Texture2D>("Textures/UI/button/bR");
            Texture2D Middle = game.Content.Load<Texture2D>("Textures/UI/button/bM");
            SpriteFont font = game.Content.Load<SpriteFont>("fonts/small");

            back = new Button()
            {
                buttonLeft = Left,
                buttonRight = Right,
                buttonMiddle = Middle,
                labelFont = font,
                label = "X",
                buttonColorDefault = Color.Red,
                buttonColorHover = Color.DarkRed,
                focused = true,
                rect = new Rectangle(0, 0, 32, 32)
            }; back.LoadContent();
        }

        /// <summary>
        /// Updates back button and all of its external logic
        /// </summary>
        void UpdateBack()
        {
            back.Update();

            if (back.pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                ScreenManager.Instance.currentscreen = new home(game);
                ScreenManager.Instance.reloadscreen();
            }
        }

        /// <summary>
        /// Loads songs and adds them to songs list
        /// </summary>
        void initSongs()
        {
            Song yusa = game.Content.Load<Song>(prefix + "yusa");
            library.Add(new SongContainer(yusa, 1));

            Song stage_1 = game.Content.Load<Song>(prefix + "stage_1");
            library.Add(new SongContainer(stage_1, 2));

            Song burst = game.Content.Load<Song>(prefix + "Camellia - Bangin' Burst");
            library.Add(new SongContainer(burst, 3));

            Song jump = game.Content.Load<Song>(prefix + "Camellia_-_LETS_JUMP[grabfrom.com]");
            library.Add(new SongContainer(jump, 4));

            Song eyes = game.Content.Load<Song>(prefix + "closing eyes");
            library.Add(new SongContainer(eyes, 5));

            Song atomosphere = game.Content.Load<Song>(prefix + "exit the earth's atmosphere");
            library.Add(new SongContainer(atomosphere, 6));

            Song lit = game.Content.Load<Song>(prefix + "light it up");
            library.Add(new SongContainer(lit, 7));

            Song owoooo = game.Content.Load<Song>(prefix + "owoozo");
            library.Add(new SongContainer(owoooo, 8));

            Song umaruuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuun = game.Content.Load<Song>(prefix + "umaru");
            library.Add(new SongContainer(umaruuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuun, 683996));
        }
    }

    static class DescriptionManager
    {
        public static string description(int ID)
        {
            switch (ID)
            {
                case 0:
                    return "eyey";
                    break;
                case 1:
                    return "ye"
                    break;

                case 2:
                    return "bangin' bust, nernernernernernernernern";
                    break;

                case 3:
                    return "pump, pump, pump it up\npump pump pump pump it up,\npump, pump, pump it up\npump pump pump pump it up,\npump pump pump pump pump pump pump pump pu-pu-pump pump pu-pump pump, wob wob let's jump, wobwobwowobowbowbowob";
                    break;

                case 4:
                    return "naaamiiii daaa deeee";
                    break;

                case 5:
                    return "r";
                    break;

                case 6:
                    return "you like triangles? I like triangles";
                    break;

                case 7:
                    return "BOKU WA NANI WA SHITE";
                    break;

                case 8:
                    return "umaruuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu\nuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuun";
                    break;

                default:
                    return "";
                    break;
            }
        }
    }
}
