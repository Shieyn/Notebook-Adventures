using Microsoft.Xna.Framework;
using Nice_game.Objects.entities;
using Nice_game.Objects.Types;

namespace Nice_game.Objects.pickups
{
    public class PICKUPinvincibility : Destroyable
    {
        Player player;

        public PICKUPinvincibility(Game Game, Player p, Vector2 Position, int index) : base(Game, index, p)
        {
            position = Position;
            texturename = fPrefix + "invin";
            player = p;
        }

        public override void onPickup()
        {
            player.ps.sAttk++;
            base.onPickup();
        }
    }
}
