using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using echecEtSharp.Pieces;

namespace echecEtSharp
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Map map;
        SpriteFont font;
        Pawn pawn;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 500;
            graphics.PreferredBackBufferHeight = 650;
            IsMouseVisible = true;

            map = new Map();
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
            Texture2D whiteC = Content.Load<Texture2D>("white");
            Texture2D greyC = Content.Load<Texture2D>("grey");
            map.AddTexture(whiteC);
            map.AddTexture(greyC);

            font = Content.Load<SpriteFont>("Arial");
            map.AddFont(font);

            Texture2D pawnTexture = Content.Load<Texture2D>("pawn");
            Vector2 lol = new Vector2(50,100);
            Vector2 behave = new Vector2(1, 1);

            pawn = new Pawn(pawnTexture, lol, behave, false, 1, false); 
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            pawn.Update(gameTime);

            base.Update(gameTime);
        }

      /*  protected void UpdatePlayer(GameTime gameTime)
        {
            MouseState mouseStateCurrent, mouseStatePrevious;

            mouseStateCurrent = Mouse.GetState();

             if (mouseStateCurrent.LeftButton == ButtonState.Pressed &&
                 mouseStateCurrent.X < center.X + texture.Width / 2 &&
                 mouseStateCurrent.X > center.X - texture.Width / 2 &&
                 mouseStateCurrent.Y < center.Y + texture.Height / 2 &&
                 mouseStateCurrent.Y > center.Y - texture.Height / 2)
             {

             }

            Console.WriteLine("fu");

            mouseStatePrevious = mouseStateCurrent;
        }*/

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.WhiteSmoke);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            map.Draw(spriteBatch);
            pawn.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
