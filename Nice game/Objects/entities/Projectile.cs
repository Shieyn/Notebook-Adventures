using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nice_game.Objects.Types;

namespace Nice_game.Objects.entities
{
    public class Projectile : Danmaku
    {
        Vector2 mousePosition;
        Vector2 playerPosition;
        Player Player;

        public Projectile(Game Game, int ind, Player player) : base(Game, ind)
        {
            texture = Game.Content.Load <Texture2D> ("Textures/game/projectile");
            color = Color.White;
            Player = player;
            playerPosition = Player.position;
            mousePosition = Mouse.GetState().Position.ToVector2();
            position = player.position;
            
            mousePosition.X -= player.position.X;
            mousePosition.Y -= player.position.Y;
        }

        public override void Update()
        {
            position.X += mousePosition.X / 15;
            position.Y += mousePosition.Y / 15;

            if (position.X > 1366 || position.X < 0 || position.Y > 768 || position.Y < 0)
            {
                Destroy();
            }

            base.Update();
        }
    }
}
