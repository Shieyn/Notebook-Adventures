using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sh.Framework.Objects;

namespace Nice_game.Objects.triggers
{
    /// <summary>
    /// an object that manipulates gameplay
    /// </summary>
    public class Trigger : GenericObject
    {
        public float x;
        public string name;

        Game game;

        public Trigger(float X, Game Game) 
        {
            x = X;
            game = Game;
        }

        Texture2D t;

        public override void LoadContent()
        {
            t = game.Content.Load<Texture2D>("p");
            base.LoadContent();
        }

        public override void Draw(SpriteBatch batch)
        {
            //batch.Draw(t, new Rectangle((int)x, 0, 32, 32), Color.Black);
            base.Draw(batch);
        }
    }
}
