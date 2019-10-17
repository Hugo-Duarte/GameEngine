using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace GameEngine
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        List<GameObject> gameObjects = new List<GameObject>();
        public Map map = new Map();

        GameHUD gameHUD = new GameHUD();


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            Resolution.Init(ref graphics);
            Resolution.SetVirtualResolution(1280, 720); //Resolution Assets are based in.
            Resolution.SetResolution(1280, 720, false); //Display Resolution.

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

            Camera.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            map.Load(Content);

            gameHUD.Load(Content);

            // TODO: use this.Content to load your game content here
            LoadLevel();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {

            // TODO: Add your update logic here
            Input.Update();
            UpdateObjects();
            map.Update(gameObjects);
            UpdateCamera();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            Resolution.BeginDraw();

            // TODO: Add your drawing code here

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.Default, RasterizerState.CullNone, null, Camera.GetTransformMatrix());
            DrawObjects();
            map.DrawWalls(spriteBatch);
            spriteBatch.End();

            gameHUD.Draw(spriteBatch);

            base.Draw(gameTime);
        }

        public void LoadLevel()
        {
            gameObjects.Add(new Player(new Vector2(640, 360)));
            gameObjects.Add(new Enemy(new Vector2(300, 522)));

            //Add walls:
            map.walls.Add(new Wall(new Rectangle(256, 256, 256, 256)));
            map.walls.Add(new Wall(new Rectangle(0, 650, 1280, 128)));

            //Add decor:
            map.decors.Add(new Decor(Vector2.Zero, "background", 1f));

            map.LoadMap(Content);

            LoadObjects();
        }

        public void LoadObjects()
        {
            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.Initialize();
                gameObject.Load(Content);
            }
        }

        public void UpdateObjects()
        {
            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.Update(gameObjects, map);
            }
        }

        public void DrawObjects()
        {
            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.Draw(spriteBatch);
            }

            foreach (Decor decor in map.decors)
            {
                decor.Draw(spriteBatch);
            }
        }

        private void UpdateCamera()
        {
            if (gameObjects.Count == 0)
                return;

            Camera.Update(gameObjects[0].position);
        }
    }
}
