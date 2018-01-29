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
        private int projectileTimer;

        Texture2D scope;

        public AProjectile(Game Game, Player Player)
        {
            game = Game;
            name = "Gun";
            desc = "Shoot balls in the faces of your enemies";
            projectileTimerLim = 30 - speed;
            player = Player;
        }

        public override void LoadContent()
        {
            ID = 1;
            scope = game.Content.Load<Texture2D>("Textures/UI/cursors/scope");
            base.LoadContent();
        }

        public override void Update()
        {
            System.Console.WriteLine(speed);

            //TODO fix implementation error
            //speed not affecting fire rate
            //DELET THIS 
            if (mouse_newState.LeftButton == ButtonState.Pressed)
            {
                if (mouse_oldState.RightButton == ButtonState.Released)
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
            base.Update();
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(scope, mouse_newState.Position.ToVector2(), Color.Yellow);
            base.Draw(batch);
        }
    }
}
