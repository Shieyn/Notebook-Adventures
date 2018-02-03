using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Sh.Framework.Objects;
using Sh.Framework.Objects.Behaviours;
using Nice_game.screens.gameScreen;
using Nice_game.Objects.PlayerBehaviours;

namespace Nice_game.Objects.entities
{
    public class Player : GameObject
    {
        Game game;

        //Components
        public NB_GravPlayerObject GPO;               //basic movement provided by Sh.Framework
        public PlayerStats ps;                      //all forms of statistics and data regarding the player's achievement in the game
        public TriggerHandler th;                   //handler for event triggers
        public PlayerAbillityHandler PAH;           //handler for player abillities

        //misc textures
        Texture2D idle;
        Texture2D invinSpr;
        Texture2D attkSpr;

        public camera cam;

        public MouseState mouse_oldState;
        public MouseState mouse_newState;

        public KeyboardState keyboard_oldState;
        public KeyboardState keyboard_newState;

        level level;

        public bool enableMovement;

        public Player(Game Game, level lvl) : base(Game)
        {
            game = Game;
            level = lvl;

            PAH = new PlayerAbillityHandler(game, this);
            keyboard_oldState = Keyboard.GetState();
            enableMovement = true;

            mouse_oldState = Mouse.GetState();
        }

        public override void LoadContent()
        {
            texturename = "Textures/game/player/idle";
            color = Color.White;
            position = new Vector2(300);

            invinSpr = game.Content.Load<Texture2D>("Textures/game/player/invin");
            attkSpr = game.Content.Load<Texture2D>("Textures/game/player/attk");
            idle = game.Content.Load<Texture2D>("Textures/game/player/idle");

            GPO = new NB_GravPlayerObject()
            {
                game = this.game,
                position = this.position,
                texture = idle,
            };

            ps = new PlayerStats()
            {
                Game = game
            };

            th = new TriggerHandler()
            {
                cam = cam,
                level = level,
                p = this
            };
            PAH.LoadContent();

            base.LoadContent();
        }

        public override void Update()
        {

            th.Update();

            PAH.newState = mouse_newState;
            PAH.Update();
            PAH.oldState = mouse_oldState;

            textureHeight = texture.Height;
            textureWidth = texture.Width;

            hitbox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            
            /*
            //collision with bounding box
            if (position.X + GPO.hsp < cam.ViewPort.Left)
            {
                GPO.position.X -= GPO.hsp;
            }*/

            #region killing the player
            if (ps.lives < 0)
            {
                Nice_game.rules.utils.restart("def", game);
            }

            if (position.Y > 768)
            {
                rules.utils.restart("tests", game);
            }
            #endregion

            #region movement
            if (enableMovement)
            {
                GPO.Update();
                position = GPO.position;

                mouse_newState = Mouse.GetState();              
                mouse_oldState = mouse_newState;
            }
            #endregion

            base.Update();
        }


        public override void Draw(SpriteBatch batch)
        {
            if (PAH.sc.attacking)
                texture = attkSpr;
            else if (PAH.sc.invin)
                batch.Draw(invinSpr, position, Color.White);
            else
                texture = idle;     
            
            PAH.Draw(batch);

            base.Draw(batch);
        }
    }    
}
