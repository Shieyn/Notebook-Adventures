using Sh.Framework.Objects;
using Sh.Framework.Graphics.UI;
using Sh.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Sh.Framework.Physics.Collisions;

namespace Nice_game.screens.menus.music.audioController
{
    /// <summary>
    /// The toolbar on the bottom that implements other controller objects
    /// </summary>
    public class AudioController : GenericObject
    {
        Game game;
        Pane Base;

        Text nowPlaying;
        public string NowPlaying;

        Play play;
        Pause pause;
        Stop stop;
        Repeat repeat;
        PlayRandom playrandom;

        Download download;

        Music music;

        Tooltip message;

        public AudioController(Game game, Music m)
        {
            this.game = game;

            play = new Play(game);
            pause = new Pause(game);
            stop = new Stop(game);
            repeat = new Repeat(game);
            playrandom = new PlayRandom(game);
            playrandom.music = m;

            music = m;

            download = new Download(game);
        }

        public override void LoadContent()
        {
            Base = new Pane()
            {
                buttonLeft = game.Content.Load<Texture2D>("Textures/UI/box/boxLeft"),
                buttonMiddle = game.Content.Load<Texture2D>("Textures/UI/box/boxMiddle"),
                buttonRight = game.Content.Load<Texture2D>("Textures/UI/box/boxRight"),
                rect = new Rectangle(0, 768 - 80, 1366, 80)
            };

            nowPlaying = new Text()
            {
                game = game,
                color = Color.Black,
                font = "fonts/small"
            };nowPlaying.LoadContent();

            message = new Tooltip(game)
            {
                pLeft = "Textures/UI/box/boxLeft",
                pMid = "Textures/UI/box/boxMiddle",
                pRight = "Textures/UI/box/boxRight",
                font = "fonts/small",
                label = "Download this song from its official source\nSupport the dev who made the game and the soundtracks",
                padding = new Vector2(16, 10),
                CornerCutting = PaneToMouse.cutType.jump
            }; message.LoadContent();

            play.LoadContent();
            pause.LoadContent();
            stop.LoadContent();
            repeat.LoadContent();
            playrandom.LoadContent();
            download.LoadContent();

            base.LoadContent();
        }

        public override void Update()
        {
            play.Update();
            pause.Update();
            stop.Update();
            repeat.Update();
            playrandom.Update();
            download.Update();
            
            message.Update();

            base.Update();
        }

        public override void Draw(SpriteBatch batch)
        {
            Base.Draw(batch);

            playrandom.Draw(batch);
            repeat.Draw(batch);
            stop.Draw(batch);
            pause.Draw(batch);
            play.Draw(batch);

            string np = string.Format("Now playing: {0}", NowPlaying ?? "nothing");
            nowPlaying.text = np;
            nowPlaying.position = new Vector2(1366 - (nowPlaying.useFont.MeasureString (np).X + 15), 768 - 50);
            nowPlaying.Draw(batch);

            if (MediaPlayer.State != MediaState.Stopped)
            {
                download.np = NowPlaying;
                download.music = music;
                download.rect = new Rectangle(1366 - ((int)nowPlaying.useFont.MeasureString(np).X + 30 + 180), 768 - 65, 180, 50);
                download.Draw(batch);

                if (MouseTouching.RectWithIn(download.rect))
                {
                    message.Draw(batch);
                }
            }

            base.Draw(batch);
        }
    }
}
