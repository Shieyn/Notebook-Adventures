using Sh.Framework.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nice_game.Objects.PlayerBehaviours.Attacks;

namespace Nice_game.Objects.PlayerBehaviours
{
    public class PlayerStats : GenericObject
    {
        public Game Game;

        public int lives;
        public int sAttk;

        public int coins;
        public int Score;

        public int invinTime;

        public PlayerStats()
        {
            lives = 5;
            sAttk = 3;
            coins = 0;
            Score = 0;
        }

        public override void LoadContent()
        {            
            base.LoadContent();
        }

        public override void Update()
        {
            base.Update();
        }
    }
}
