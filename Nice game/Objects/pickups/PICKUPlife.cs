using Microsoft.Xna.Framework;
using Nice_game.Objects.entities;
using Nice_game.screens.gameScreen;
using Sh.Framework.Objects;
using Nice_game.Objects.Types;

namespace Nice_game.Objects.pickups
{
    public class PICKUPlife : Destroyable
    {
        Player player;

        public PICKUPlife(Game Game, Vector2 pos, Player p, int ind) : base (Game, ind, p)
        {
            texturename = fPrefix + "life";
            position = pos;
            player = p;
        }

        public override void onPickup()
        {
            player.ps.lives++;
            base.onPickup();
        }
    }
}
