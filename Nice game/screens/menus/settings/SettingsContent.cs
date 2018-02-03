using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sh.Framework.Objects;
using System.Collections.Generic;

namespace Nice_game.screens.menus.settings
{
    public class SettingsContent : GenericObject
    {
        Game game;

        public List<SettingsSection> sections = new List<SettingsSection>();

        public SettingsContent(Game Game)
        {
            game = Game;
        }

        public override void LoadContent()
        {
            foreach (SettingsSection s in sections) s.LoadContent();

            base.LoadContent();
        }

        public override void Update()
        {
            foreach (SettingsSection s in sections) s.Update();

            base.Update();
        }

        public override void Draw(SpriteBatch batch)
        {
            foreach (SettingsSection s in sections) s.Draw(batch);

            base.Draw(batch);
        }
    }
}
