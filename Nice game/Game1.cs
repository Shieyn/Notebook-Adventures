using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sh.Framework.Screens;
using Nice_game.debug;
using System;

namespace Nice_game
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public static bool quit;

        public static int revision = 01;

        public static bool ingame;

        Texture2D alphaHeader;

        CLI cli;
        assistant ass;  //aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa

        public Game1()
        {
            Console.WriteLine("started");
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            quit = false;

            cli = new CLI();
            ass = new assistant(this);

            //the game is not capable of handling irregular aspect ratios and resolutions, just don't.
            //Window.AllowUserResizing = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            ingame = false;
            graphics.PreferredBackBufferWidth = 1366;
            graphics.PreferredBackBufferHeight = 768;
            graphics.IsFullScreen = false;
            //Window.AllowAltF4 = false;


#if DEBUG
            Window.Title = "Notebook Adventures [LOCAL DEVELOPMENT BUILD]";
#endif

#if DEV
            Window.Title = String.Format("Notebook Adventures [PUBLIC DEVELOPMENT BUILD {0}]", revision);
#endif

#if RELEASE
            Window.Title = "Notebook Adventures";
#endif

            graphics.ApplyChanges();

            ScreenManager.Instance.currentscreen = new splash(this);

            IsMouseVisible = true;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            alphaHeader = Content.Load<Texture2D>("Textures/UI/branding/header");
            ass.LoadContent();

                ScreenManager.Instance.LoadContent(Content);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            ScreenManager.Instance.UnloadContent();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            this.IsFixedTimeStep = true;
            ass.Update();
            cli.Update();

            // TODO: Add your update logic here
            if (IsActive)
                ScreenManager.Instance.Update(gameTime);

            if (quit)
                Exit();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            //bg.Draw(spriteBatch);
            ScreenManager.Instance.Draw(spriteBatch);
            ass.Draw(spriteBatch);
            
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
