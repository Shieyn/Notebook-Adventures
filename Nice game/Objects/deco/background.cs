using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nice_game.Objects.entities;
using Sh.Framework.Objects;

namespace Nice_game.Objects.deco
{
    public class background : GenericObject
    {
        Game game;

        Texture2D bg;
        Rectangle position;

        public camera reference;

        public background(Game Game)
        {
            game = Game;
        }

        public override void LoadContent()
        {
            bg = game.Content.Load<Texture2D>("Textures/bg/bg2");
            base.LoadContent();
        }

        public override void Update()
        {
            position = new Rectangle (reference.ViewPort.X - 16, reference.ViewPort.Y - 2, reference.ViewPort.Width + 8, reference.ViewPort.Height + 8);
            base.Update();
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(bg, position, Color.White);
            base.Draw(batch);
        }
    }
}
