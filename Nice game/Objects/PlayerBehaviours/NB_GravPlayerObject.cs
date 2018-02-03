using Microsoft.Xna.Framework.Input;
using Nice_game.screens.gameScreen;
using Sh.Framework.Objects.Behaviours;
using System;
using System.Linq;
using Microsoft.Xna.Framework;

namespace Nice_game.Objects.PlayerBehaviours
{
    public class NB_GravPlayerObject : BGravPlayerObject_2
    {
        int maxSpeed = 14;

        public NB_GravPlayerObject()
        {
            jump = Keys.Space;
            moveLeft = Keys.A;
            moveRight = Keys.D;
            solids = level.tiles.ToList();
            speed = 10;
        }

        public override void Update()
        {
            base.Update();
        }
    }
}
