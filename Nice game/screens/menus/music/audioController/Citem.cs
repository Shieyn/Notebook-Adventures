using Sh.Framework.Objects;
using Sh.Framework.Graphics.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Nice_game.screens.menus.music.audioController
{
    /// <summary>
    /// Parent object of all other controller items
    /// </summary>
    public class Citem : ClickableObject
    {
        Game game;

        public string prefix = "Textures/UI/AudioController/";
        protected string path;
        protected string name;

        Texture2D texture;

        private Color color;

        Tooltip tooltip;

        protected Color hover = Color.Gray;
        protected Color notHover = Color.White;

        public Citem(Game Game)
        {
            game = Game;
        }

        public override void LoadContent()
        {
            texture = game.Content.Load<Texture2D>(path);

            tooltip = new Tooltip(game)
            {
                pLeft = "Textures/UI/box/boxLeft",
                pMid = "Textures/UI/box/boxMiddle",
                pRight = "Textures/UI/box/boxRight",
                font = "fonts/small",
                label = name,
                padding = new Vector2(16, 10),
            };tooltip.LoadContent();
            base.LoadContent();
        }

        public override void Update()
        {
            tooltip.Update();

            if (hovering)
            {
                color = hover;
            }
            else
            {
                color = notHover;
            }
            base.Update();
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(texture, rect, color);

            if (hovering)
                tooltip.Draw(batch);

            base.Draw(batch);
        }
    }
}
