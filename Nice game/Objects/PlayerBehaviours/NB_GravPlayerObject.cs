using Microsoft.Xna.Framework.Input;
using Nice_game.screens.gameScreen;
using Sh.Framework.Objects.Behaviours;
using System.Linq;

namespace Nice_game.Objects.PlayerBehaviours
{
    public class NB_GravPlayerObject : BGravPlayerObject
    {
        public NB_GravPlayerObject()
        {
            jump = Keys.Space;
            moveLeft = Keys.A;
            moveRight = Keys.D;
            solids = level.tiles.ToList();
        }
    }
}
