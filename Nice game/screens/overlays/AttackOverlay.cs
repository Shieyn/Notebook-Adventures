using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sh.Framework.Objects;
using Nice_game.Objects.PlayerBehaviours.Attacks;

namespace Nice_game.screens.overlays
{
    public class AttackOverlay : GenericObject
    {
        Game game;

        Texture2D box;

        public List<Attack> attacks = new List<Attack>();
        public List<Attack> inventory = new List<Attack>();

        public AttackOverlay(Game Game)
        {
            game = Game;
        }

        public override void LoadContent()
        {
            box = game.Content.Load<Texture2D>("Textures/UI/misc/box");
            base.LoadContent();
        }

        public override void Draw(SpriteBatch batch)
        {
            foreach (Attack a in attacks)
            {
                Color valid;

                if (inventory.Contains(a))
                {
                    valid = Color.White;
                }
                else
                {
                    valid = Color.DarkGray;
                }
                batch.Draw(box, new Rectangle((a.ID - 1) * 64, 768 - 64, 64, 64), Color.White);
            }
            base.Draw(batch);
        }
    }
}
