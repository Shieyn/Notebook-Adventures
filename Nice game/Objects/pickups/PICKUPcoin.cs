using Microsoft.Xna.Framework;
using Nice_game.Objects.entities;
using Nice_game.Objects.Types;

namespace Nice_game.Objects.pickups
{
    public class PICKUPcoin : Destroyable
    {
        Game game;
        Player player;
        
        int value;
        int bonus = 50;

        public PICKUPcoin(Game Game, Player p, Vector2 Position, int Value, int index) : base(Game, index, p)
        {
            game = Game;
            player = p;
            value = Value;

            position = new Vector2 (Position.X, Position.Y - 32);
            texturename = fPrefix + "coin";
            color = Color.White;
        }

        public override void onPickup()
        {
            player.ps.coins += value;
            player.ps.Score += bonus;
          
            base.onPickup();
        }
    }
}
