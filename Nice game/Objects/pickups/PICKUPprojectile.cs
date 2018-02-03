using Microsoft.Xna.Framework;
using Nice_game.Objects.entities;
using Nice_game.Objects.Types;

namespace Nice_game.Objects.pickups
{
    public class PICKUPprojectile : Destroyable
    {
        Player player;
        private Game game;

        public PICKUPprojectile(Game Game, Player p, Vector2 Position, int index) : base(Game, index, p)
        {
            position = Position;
            texturename = fPrefix + "projectile";
            player = p;
            game = Game;
        }

        public override void onPickup()
        {
            player.PAH.inventory.Add(1);
            player.PAH.projectile.speed = 1;
        }
    }
}
