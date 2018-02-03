using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sh.Framework.Objects;
using Sh.Framework.Screens;
using Sh.Framework.Graphics;

namespace Nice_game.screens.gameScreen
{
    //TODO add exiting
    public class preview : Screen
    {
        mapImage map;
        Game game;

        Text instructions;
        Text levelname;

        string ID;

        public preview(Game game)
        {
            ID = 1.ToString();      //actually fight me
            this.game = game;
        }

        public override void LoadContent()
        {
            map = new mapImage()
            {
                levelID = ID,
                prefix = "Textures/stage_previews/",
                game = this.game
            };
            map.LoadContent();

            instructions = new Text()
            {
                color = Color.Black,
                font = "fonts/small",
                game = game,
                position = Vector2.Zero,
                text = "WASD to pan\nScroll to zoom\nControl to reset position\nShift to go faster\n\nSpace to start"
            }; instructions.LoadContent();

            levelname = new Text()
            {
                color = Color.Black,
                font = "fonts/big",
                game = game,
                text = "Stage " + ID
            }; levelname.LoadContent();

            base.LoadContent();
        }

        public override void Update(GameTime gametime)
        {
            map.Update();

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                ScreenManager.Instance.currentscreen = new level(game, Convert.ToInt32(ID));
                ScreenManager.Instance.reloadscreen();
            }
            base.Update(gametime);
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            map.Draw(spritebatch);
            levelname.position = new Vector2(1366 - (levelname.useFont.MeasureString (levelname.text).X + 10), 0);
            levelname.Draw(spritebatch);
            instructions.Draw(spritebatch);
            base.Draw(spritebatch);
        }
    }

    class mapImage : GenericObject
    {
        public string levelID;
        public string prefix;   //include backslash
        public Game game;

        private Texture2D map;
        private int scaleFactor;
        private Vector2 position;
        private Rectangle rect;
        private int speed;
        private int scrolloffset;

        public mapImage()
        {
        }

        public override void LoadContent()
        {
            map = game.Content.Load<Texture2D>(prefix + "stage" + levelID);
            position.X = 0;
            position.Y = 768 / 2 - map.Height / 2;
            scaleFactor = 1;
            base.LoadContent();
        }

        public override void Update()
        {
            MouseState mouse = Mouse.GetState();
            KeyboardState keyboard = Keyboard.GetState();
            
            scaleFactor = (mouse.ScrollWheelValue/ 120) + 1 + scrolloffset;

            if (scaleFactor <= 0)
            {
                scaleFactor = 1;
                scrolloffset ++;
            }

            if (keyboard.IsKeyDown(Keys.LeftShift))
            {
                speed = 40;
            }
            else
            {
                speed = 20;
            }

            if (keyboard.IsKeyDown(Keys.LeftControl))
            {
                position = Vector2.Zero;
            }

            if (keyboard.IsKeyDown(Keys.D)) position.X -= speed;
            if (position.X < 0) if (keyboard.IsKeyDown(Keys.A)) position.X += speed;
            if (keyboard.IsKeyDown(Keys.W)) position.Y += speed;
            if (keyboard.IsKeyDown(Keys.S)) position.Y -= speed;

            rect = new Rectangle((int)position.X, (int)position.Y, scaleFactor * map.Width, scaleFactor * map.Height);
            base.Update();
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(map, rect, Color.White);
            base.Draw(batch);
        }
    }
}
