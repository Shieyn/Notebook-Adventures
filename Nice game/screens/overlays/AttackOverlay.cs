using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sh.Framework.Objects;
using Nice_game.Objects.PlayerBehaviours.Attacks;
using Nice_game.Objects.entities;
using Nice_game.screens.gameScreen;
using System.Linq;

namespace Nice_game.screens.overlays
{
    public class AttackOverlay : GenericObject
    {
        Game game;

        Texture2D box;

        int attackType_2;

        int Y;
        int offset;

        private List<Attack> attacks = new List<Attack>();
        private List<int> inventory = new List<int>();

        public AttackOverlay(Game Game)
        {
            game = Game;
            attackType_2 = level.player.PAH.attackType;
        }

        public override void LoadContent()
        {
            Y = 768 - 200;
            offset = 10;
            box = game.Content.Load<Texture2D>("Textures/UI/misc/box");
            base.LoadContent();
        }

        public override void Update()
        {
            attacks = level.player.PAH.attacks;
            inventory = level.player.PAH.inventory;

            base.Update();
        }

        int i = 0;
        bool a = false;
        public override void Draw(SpriteBatch batch)
        {

            if (level.player.PAH.attackType != attackType_2)
            {
                a = true;
            }

            if (a)
            {
                if (i < 1 * 60)
                {
                    DrawInterface(batch);
                    i++;
                }
                else
                    a = false;
            }
            else
                i = 0;

            attackType_2 = level.player.PAH.attackType;

            base.Draw(batch);
        }
        
        void DrawInterface(SpriteBatch batch)
        {
            Color drawCol;
            Color col;

            if (level.player.PAH.attackType == 0)
                col = Color.Green;
            else
                col = Color.White;

            batch.Draw(box, new Rectangle(offset, Y, 64, 64), col);

            foreach (int i in inventory)
            {
                if (level.player.PAH.attackType == i)
                    drawCol = Color.Green;
                else
                    drawCol = Color.White;

                batch.Draw(box, new Rectangle(offset + i * 64, Y, 64, 64), drawCol);
                batch.Draw(attacks[i - 1].icon, new Rectangle(offset + i * 64, Y, 64, 64), drawCol);
            }
        }
    }
}