using Microsoft.Xna.Framework;
using Nice_game.Objects.Types;
using Microsoft.Xna.Framework.Graphics;

namespace Nice_game.Objects.entities.enemies
{
    public class e1 : Enemy
    {
        private Game game;

        public e1(Game Game, Vector2 pos, Player p, int id, camera c) : base(Game, pos, p, id, c)
        {
            speed = 10;
            bonus = 300;
            texturename = "Textures/game/enemies/e1";
            game = Game;
        }

        public override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Update()
        {
            if (camera.ViewPort.Right > position.X)
                position.X -= speed;

            base.Update();
        }

        public override void Draw(SpriteBatch batch)
        {
            base.Draw(batch);
        }
    }
}
