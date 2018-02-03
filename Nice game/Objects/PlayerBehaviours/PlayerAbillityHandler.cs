using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sh.Framework.Objects;
using Sh.Framework.Input;
using Nice_game.Objects.entities;
using Nice_game.Objects.PlayerBehaviours.Attacks;
using System.Linq;

namespace Nice_game.Objects.PlayerBehaviours
{
    public class PlayerAbillityHandler : GenericObject
    {
        public int attackType;

        public List<int> inventory = new List<int>();       //list of attacks the player HAS
        public List<Attack> attacks = new List<Attack>();   //list of attacks available     

        public static AProjectile Projectile;

        public MouseState oldState;
        public MouseState newState;

        public KeyboardState k_oldState;
        public KeyboardState k_newState;

        //Add ALL attacks here
        public StockCombat sc;
        public AProjectile projectile;

        private Player player;
        private Game game;

        public PlayerAbillityHandler(Game Game, Player player)
        {
            game = Game;
            this.player = player;
            attackType = 0;

            initAttacks();
        }

        /// <summary>
        /// initialize all attacks
        /// </summary>
        void initAttacks()
        {
            #region instantiate attacks
            sc = new StockCombat(player)
            {
                AttackType = attackType,
                pixel = game.Content.Load<Texture2D>("p"),
                cooldown = 30,
                invinTime = 60 * 3
            };

            projectile = new AProjectile(game, player)
            {
                speed = 10
            };
            #endregion

            #region add attacks
            attacks.Add(projectile);
            #endregion
        }

        public override void LoadContent()
        {
            sc.LoadContent();

            foreach (Attack a in attacks)
                a.LoadContent();

            base.LoadContent();
        }

        public override void Update()
        {
            sc.mouse_newState = newState;
            sc.Update();
            sc.AttackType = attackType;
            sc.mouse_oldState = oldState;

            foreach (int i in inventory)
            {
                if (attacks.Any(e => e.ID == i))
                {
                    if (attackType == i)
                    {
                        attacks[i - 1].mouse_newState = newState;
                        attacks[i - 1].Update();
                        attacks[i - 1].mouse_newState = oldState;
                    }
                }
            }

            k_newState = Keyboard.GetState();

            if (KeyboardStroke.KeyDown(k_oldState, k_newState, Keys.E))
            {
                if (attackType != inventory.Count)
                    attackType++;
                else
                    attackType = 0;
            }

            if (KeyboardStroke.KeyDown(k_oldState, k_newState, Keys.Q))
            {
                if (attackType != 0)
                    attackType--;
                else
                    attackType = inventory.Count;
            }

            k_oldState = k_newState;

            base.Update();
        }

        public override void Draw(SpriteBatch batch)
        {
            sc.Draw(batch);

            foreach (int i in inventory)
            {
                if (attacks.Any(e => e.ID == i))
                {
                    if (attackType == i)
                        attacks[i - 1].Draw(batch);
                }
            }

            base.Draw(batch);
        }
    }
}
