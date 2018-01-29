using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sh.Framework.Screens;
using Sh.Framework.Graphics;
using Sh.Framework.Objects;
using Nice_game.Objects.entities;
using Nice_game.Objects.entities.enemies;
using Nice_game.Objects.tiles;
using Nice_game.Objects.UI;
using Nice_game.rules;
using System.Linq;

namespace Nice_game.screens.gameScreen
{
    /// <summary>
    /// deprecated testing interface
    /// </summary>
    public class tests : Screen
    {
        Game game;

        Text debugheader;

        public static Player player;

        gameManager manager;
        game_HUD hud;

        public static List<GameObject> tiles = new List<GameObject>();
        public static List<GameObject> enemies = new List<GameObject>();

        public tests(Game Game)
        {
            game = Game;

            //player = new Player(game);

            manager = new gameManager(game);
            manager.player = player;

            hud = new game_HUD(game, player);

            tiles.Clear();
            enemies.Clear();

            for (int i = 0; i < 80; i++)
            {
                tiles.Add(new t1(game, new Vector2(32 * i, 550)));
            }

            //enemies.Add(new e1(game, new Vector2(800, 500), player, enemies.Count));
        }

        public override void LoadContent()
        {
            player.LoadContent();
            manager.LoadContent();
            hud.LoadContent();

            foreach (GameObject t in tiles)
            {
                t.LoadContent();
            }

            foreach (GameObject g in enemies)
            {
                g.LoadContent();
            }

            debugheader = new Text()
            {
                color = Color.White,
                font = "fonts/small",
                game = game,
                position = Vector2.Zero,
                text = "testing interface"
            }; debugheader.LoadContent();

            base.LoadContent();
        }

        public override void Update(GameTime gametime)
        {
            manager.Update();

            if (!manager.paused)
            {
                player.Update();

                foreach (GameObject t in tiles)
                {
                    t.Update();
                }

                List<GameObject> staticEnemies = new List<GameObject>();
                staticEnemies = enemies.ToList();

                foreach (GameObject g in staticEnemies)
                {
                    g.Update();
                }
            }

            base.Update(gametime);
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            foreach (GameObject t in tiles)
            {
                t.Draw(spritebatch);
            }

            foreach (GameObject g in enemies)
            {
                g.Draw (spritebatch);
            }

            hud.Draw(spritebatch);

            debugheader.Draw(spritebatch);
            player.Draw(spritebatch);
            manager.Draw(spritebatch);
            base.Draw(spritebatch);
        }
    }
}
