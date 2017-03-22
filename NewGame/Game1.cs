
using Core.Entity;
using Core.Entity.Component.PlayerComponents;
using Core.Service;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace KnightInvaders
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        CharacterEntity character;
        EntityObject player;
        TileCursor cursor;
        Button button;
        EntityContainer EntityContainer;
        private Texture2D characterSheetTexture;

        public Game1()
        {
            EntityContainer = new EntityContainer();
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.IsFullScreen = true;
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 480;
            graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;
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
            // character = new CharacterEntity(this.GraphicsDevice);
            EntityContainer.Initialize(GraphicsDevice);
            //player = new EntityInputObject(new Vector2((GraphicsDevice.Viewport.Bounds.Right -100) / 2, GraphicsDevice.Viewport.Bounds.Bottom - 200),new PlayerInputComponent(), 
            //    new PlayerPhysicsComponent(), new PlayerGraphicsComponent(this.GraphicsDevice));
            //cursor = new TileCursor(this.GraphicsDevice);
            //button = new Button(this.GraphicsDevice);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);


            // TODO: use this.Content to load your game content here
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                Exit();
            EntityContainer.Update(gameTime);
            // TODO: Add your update logic here
            //player.Update(gameTime);
            //cursor.Update(gameTime);
            ////character.Update(gameTime);
            //button.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            //add entity here     
            EntityContainer.Draw(spriteBatch);           
            //player.Draw(spriteBatch);
            //cursor.Draw(spriteBatch);
            //character.Draw(spriteBatch);
            //button.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
