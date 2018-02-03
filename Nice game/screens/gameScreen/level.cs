//v this is a fetish of mine I'm not scared to hide v
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sh.Framework.Objects;
using Sh.Framework.Screens;
using Sh.Framework.Debug;
using TiledSharp;                       //probably the best thing to exist rn        
using Nice_game.rules;
using Nice_game.Objects.entities;
using Nice_game.Objects.entities.enemies;
using Nice_game.Objects.entities.bosses;
using Nice_game.Objects.UI;
using Nice_game.Objects.tiles;
using Nice_game.Objects.deco;
using Nice_game.Objects.pickups;
using Nice_game.Objects.triggers;
using Nice_game.Objects.Types;
using Nice_game.Objects.PlayerBehaviours.Attacks;
using Nice_game.Readonly;
using Nice_game.screens.overlays;

namespace Nice_game.screens.gameScreen
{
    /// <summary>
    /// The main room levels are loaded in
    /// </summary>
    public class level : Screen
    {
        Game game;
        TmxMap map;

        public static DebugConsole console;

        public static Player player;

        gameManager manager;
        public game_HUD hud;

        camera camera;

        background bg;

        public ScriptManager sm;

        public static int stageID;

        AttackOverlay attackoverlay;

        public static List<GameObject> tiles = new List<GameObject>();          //objects the player can collide with
        public static List<Enemy> enemies = new List<Enemy>();        //objects the player can die from
        public static List<Destroyable> pickups = new List<Destroyable>();      //objects the player can collect and use
        public static List<GameObject> deco = new List<GameObject>();           //objects that exist for the sake of existing
        public static List<Trigger> triggers = new List<Trigger>();             //objects that manipulate gameplay
        public static List<Danmaku> projectiles = new List <Danmaku> ();        //objects either the player or an enemy shoot
        public static Boss boss;                                          //the main boss of the stage

        public level(Game Game, int sID)
        {
            stageID = sID;
            Console.WriteLine("started level");
            game = Game;

            player = new Player(game, this);

            manager = new gameManager(game);
            manager.player = player;

            hud = new game_HUD(game, player);

            SpriteFont font = game.Content.Load<SpriteFont>("fonts/small");
            Texture2D pixel = game.Content.Load <Texture2D>("p");

            console = new DebugConsole(pixel, font, new Rectangle(1366 - 400, 0, 400, 0), game);

            camera = new camera();
            camera.focus = player;

            player.cam = camera;

            bg = new background(game);
            bg.reference = camera;

            sm = new ScriptManager(game, player);

            attackoverlay = new AttackOverlay(game);
        }

        public override void LoadContent()
        {
            Game1.ingame = true;
            tiles.Clear();
            enemies.Clear();
            deco.Clear();
            pickups.Clear();
            triggers.Clear();
            projectiles.Clear();
            
            map = new TmxMap(@"Content\stages\stage" + stageID + ".tmx");

            console.write("level started", urgency.comment);

            attackoverlay.LoadContent();

            bg.LoadContent();

            sm.LoadContent();

            #region load map

            for (int layer = 0; layer < map.Layers.Count; layer++)
            {
                for (int tile = 0; tile < map.Layers[layer].Tiles.Count; tile++)
                {
                    int GID = map.Layers[layer].Tiles[tile].Gid;

                    Vector2 TilePosition = new Vector2 ((tile % map.Width) * map.TileWidth, 
                        (float)Math.Floor(tile / (double)map.Width) * map.TileHeight);

                    //Yes
                    switch (GID)
                    {
                        case 0:
                            break;
                        case 1:
                            tiles.Add(new t1(game, TilePosition));
                            break;
                        case 2:
                            tiles.Add(new t2(game, TilePosition));
                            break;
                        case 3:
                            tiles.Add(new t3(game, TilePosition));
                            break;
                        case 4:
                            tiles.Add(new t4(game, TilePosition));
                            break;
                        case 5:
                            tiles.Add(new t5(game, TilePosition));
                            break;
                        case 6:
                            tiles.Add(new t6(game, TilePosition));
                            break;
                        case 7:
                            tiles.Add(new t7(game, TilePosition));
                            break;
                        case 8:
                            tiles.Add(new t8(game, TilePosition));
                            break;
                        case 9:
                            tiles.Add(new t9(game, TilePosition));
                            break;
                        case 10:
                            enemies.Add(new e1(game, TilePosition, player, enemies.Count, camera));
                            break;
                        case 11:
                            pickups.Add(new PICKUPcoin(game, player, TilePosition, 5, pickups.Count));
                            break;
                        case 12:
                            boss = new B1(game, TilePosition.X, this);
                            break;
                        //-----
                        case 19:
                            deco.Add(new cloud(game, 1, TilePosition));
                            break;
                        case 20:
                            deco.Add(new cloud(game, 2, TilePosition));
                            break;
                        case 21:
                            deco.Add(new cloud(game, 3, TilePosition));
                            break;
                        case 22:
                            triggers.Add(new tDialogue(TilePosition.X, game));
                            break;
                        case 23:
                            triggers.Add(new tStaticCamera(TilePosition.X, game));
                            break;
                        case 24:
                            triggers.Add(new tDynamicCamera(TilePosition.X, game));
                            break;

                        case 122:
                            pickups.Add(new PICKUPinvincibility(game, player, TilePosition, pickups.Count));
                            break;
                        case 123:
                            pickups.Add(new PICKUPlife(game, TilePosition, player, pickups.Count));
                            break;
                        case 124:
                            pickups.Add(new PICKUPprojectile(game, player, TilePosition, pickups.Count));
                            break;
                    }
                }
            }

            #endregion

            player.LoadContent();
            manager.LoadContent();
            hud.LoadContent();

            foreach (GameObject t in tiles)
            {
                t.LoadContent();
            }

            foreach (Enemy e in enemies)
            {
                e.LoadContent();
            }

            foreach (GameObject g in deco)
            {
                g.LoadContent();
            }

            foreach (GameObject g in pickups)
            {
                g.LoadContent();
            }

            foreach (Trigger t in triggers)
            {
                t.LoadContent();
            }

            boss.LoadContent();

            base.LoadContent();
        }


        int i = 0;
        public override void Update(GameTime gametime)
        {
            manager.Update();

            sm.Update();

            bg.Update();

            if (i > 3 * 60)
            {
                console.wipe();
                i = 0;
            }
            else
            {
                if (console.log.Count > 0)
                    i++;
            }

            if (!manager.paused)
            {
                player.Update();
                camera.Update();

                foreach (GameObject t in tiles)
                {
                    t.Update();
                }

                foreach (GameObject t in deco)
                {
                    t.Update();
                }

                List<Destroyable> staticPickups = new List<Destroyable>();
                staticPickups = pickups.ToList();
                foreach (GameObject t in staticPickups)
                {
                    t.Update();
                }

                List<Enemy> staticEnemies = new List<Enemy>();
                staticEnemies = enemies.ToList();
                foreach (Enemy g in staticEnemies)
                {
                    g.Update();
                }

                List<Danmaku> staticProjectiles = new List<Danmaku>();
                staticProjectiles = projectiles.ToList();
                foreach (Danmaku d in staticProjectiles)
                {   
                    d.Update();
                }

                foreach (Trigger t in triggers)
                {
                    t.Update();
                }

                boss.Update();
                attackoverlay.Update();
            }
            base.Update(gametime);
        }

        public override void Draw(SpriteBatch spritebatch)
        {
            bg.Draw(spritebatch);

            foreach (GameObject t in tiles)
            {
                t.Draw(spritebatch);
            }

            foreach (GameObject g in deco)
            {
                g.Draw(spritebatch);
            }

            foreach (GameObject g in pickups)
            {
                g.Draw(spritebatch);
            }

            foreach (Trigger t in triggers)
            {
                t.Draw(spritebatch);
            }

            foreach (Danmaku d in projectiles)
            {
                d.Draw(spritebatch);
            }

            foreach (Enemy e in enemies)
            {
                e.Draw(spritebatch);
            }

            boss.Draw(spritebatch);
            player.Draw(spritebatch);

            hud.Draw(spritebatch);
            sm.Draw(spritebatch);

            attackoverlay.Draw(spritebatch);

            manager.Draw(spritebatch);

#if !RELEASE
            console.Draw(spritebatch);
#endif

            base.Draw(spritebatch);
        }
    }
}
 