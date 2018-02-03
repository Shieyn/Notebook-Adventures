using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nice_game.screens.gameScreen;
using Nice_game.Objects.Types;
using Nice_game.Objects.entities;

namespace Nice_game.Objects.PlayerBehaviours.Attacks
{
    public class AProjectile : Attack
    {
        private Game game;
        public int speed;
        public Player player;

        private int projectileTimerLim;
        private int projectileTimer = 0;

        private MouseState oldState;
        private MouseState newState;

        Texture2D scope;

        public AProjectile(Game Game, Player Player)
        {
            game = Game;
            name = "Gun";
            desc = "Shoot balls in the faces of your enemies";
            player = Player;
            oldState = Mouse.GetState();
        }

        public override void LoadContent()
        {
            ID = 1;
            scope = game.Content.Load<Texture2D>("Textures/UI/cursors/scope");
            projectileTimerLim = 30 - speed;
            icon = game.Content.Load<Texture2D>(prefix + "gun");
            base.LoadContent();
        }

        public override void Update()
        {
            //DELET THIS 
            //(dont)
            newState = Mouse.GetState();
            if (newState.LeftButton == ButtonState.Pressed)
            {
                if (oldState.LeftButton == ButtonState.Released)
                    level.projectiles.Add(new Projectile(game, level.projectiles.Count, player));

                if (projectileTimer > projectileTimerLim)
                {
                    level.projectiles.Add(new Projectile(game, level.projectiles.Count, player));
                    projectileTimer = 0;
                }
                else
                {
                    projectileTimer++;
                }
            }
            else
                projectileTimer = 0;

            oldState = newState;

            base.Update();
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(scope, newState.Position.ToVector2(), Color.Yellow);
            base.Draw(batch);
        }
    }
}
