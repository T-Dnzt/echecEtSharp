using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace echecEtSharp
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Map map;

        Player player1;
        Player player2;

        SpriteFont font;

        Texture2D blackTexture;
        Texture2D whitetexture;

        MouseState mouseState;
        MouseState oldState;

        Boolean gameTurn;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 500;
            graphics.PreferredBackBufferHeight = 650;
            IsMouseVisible = true;

            map = new Map();
            player1 = new Player(1, true);
            player2 = new Player(2, false);

            gameTurn = true;
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
            Texture2D blueC = Content.Load<Texture2D>("blue");
            Texture2D redC = Content.Load<Texture2D>("red");
            Texture2D greenC = Content.Load<Texture2D>("green");
            blackTexture = Content.Load<Texture2D>("black");
            whitetexture = whiteC;

            map.AddTexture(whiteC);
            map.AddTexture(greyC);
            map.AddTexture(blueC);
            map.AddTexture(redC);
            map.AddTexture(greenC);
            map.generateMap();


            loadPiecesTextures(player1, "White");
            loadPiecesTextures(player2, "Black");
            player1.generatePieces();
            player2.generatePieces();
            setPiecesOnCases();


            font = Content.Load<SpriteFont>("Arial");
            map.AddFont(font);

            // Texture2D pawnTexture = Content.Load<Texture2D>("pawn");

            // pawn = new Pawn(pawnTexture, lol, behave, false, 1, false); 

        }

        private void loadPiecesTextures(Player player, String name)
        {
            player.PieceTextures.Add(String.Format("{0} King", name), Content.Load<Texture2D>(String.Format("{0}king", name.ToLower())));
            player.PieceTextures.Add(String.Format("{0} Knight", name), Content.Load<Texture2D>(String.Format("{0}knight", name.ToLower())));
            player.PieceTextures.Add(String.Format("{0} Pawn", name), Content.Load<Texture2D>(String.Format("{0}pawn", name.ToLower())));
            player.PieceTextures.Add(String.Format("{0} Queen", name), Content.Load<Texture2D>(String.Format("{0}queen", name.ToLower())));
            player.PieceTextures.Add(String.Format("{0} Rook", name), Content.Load<Texture2D>(String.Format("{0}rook", name.ToLower())));
            player.PieceTextures.Add(String.Format("{0} Bishop", name), Content.Load<Texture2D>(String.Format("{0}bishop", name.ToLower())));
        }

        private void setPiecesOnCases()
        {
            map.CaseList.ElementAt(56).Piece = player1.Rooks.ElementAt(0);
            map.CaseList.ElementAt(0).Piece = player2.Rooks.ElementAt(0);

            map.CaseList.ElementAt(57).Piece = player1.Knights.ElementAt(0);
            map.CaseList.ElementAt(1).Piece = player2.Knights.ElementAt(0);

            map.CaseList.ElementAt(58).Piece = player1.Bishops.ElementAt(0);
            map.CaseList.ElementAt(2).Piece = player2.Bishops.ElementAt(0);

            map.CaseList.ElementAt(59).Piece = player1.Queen;
            map.CaseList.ElementAt(3).Piece = player2.Queen;

            map.CaseList.ElementAt(60).Piece = player1.King;
            map.CaseList.ElementAt(4).Piece = player2.King;

            map.CaseList.ElementAt(61).Piece = player1.Bishops.ElementAt(1);
            map.CaseList.ElementAt(5).Piece = player2.Bishops.ElementAt(1);

            map.CaseList.ElementAt(62).Piece = player1.Knights.ElementAt(1);
            map.CaseList.ElementAt(6).Piece = player2.Knights.ElementAt(1);

            map.CaseList.ElementAt(63).Piece = player1.Rooks.ElementAt(0);
            map.CaseList.ElementAt(7).Piece = player2.Rooks.ElementAt(1);

            for (int i = 0; i < 8; i++)
            {
                map.CaseList.ElementAt(48 + i).Piece = player1.Pawns.ElementAt(i);
                map.CaseList.ElementAt(8 + i).Piece = player2.Pawns.ElementAt(i);
            }
            // 48 56




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
                Exit();

            mouseState = Mouse.GetState();


            if (mouseState.LeftButton == ButtonState.Released &&
                oldState.LeftButton == ButtonState.Pressed &&
                map.isOverACase(mouseState.X, mouseState.Y))
            {
                Case selectedC = map.getSelectedCase();
                if (selectedC != null)
                {
                    Case clickedCase = map.getCase(mouseState.X, mouseState.Y);
                    if (selectedC.Piece.AvailableCases.Contains(clickedCase))
                    {
                        clickedCase.Piece = selectedC.Piece;
                        clickedCase.Piece.NumberOfMouvs += 1;
                        selectedC.Piece.undefineAvailableCases();
                        selectedC.Piece = null;
                        map.unSelectCase();
                        gameTurn = !gameTurn;
                    }else if (clickedCase.IsBigRockPossible)
                    {
                        if(selectedC.Piece.IsWhite)
                        {
                            clickedCase.IsBigRockPossible = false;
                            selectedC.Piece.NumberOfMouvs += 1;
                            map.CaseList.ElementAt(59).Piece = map.CaseList.ElementAt(56).Piece;
                            selectedC.Piece.undefineAvailableCases();
                            selectedC.Piece = null;
                            map.CaseList.ElementAt(58).Piece = map.CaseList.ElementAt(60).Piece;
                            map.CaseList.ElementAt(58).Piece.NumberOfMouvs += 1;
                            map.CaseList.ElementAt(60).Piece = null;
                            map.unSelectCase();
                            gameTurn = !gameTurn;
                        }
                        else
                        {
                            clickedCase.IsBigRockPossible = false;
                            selectedC.Piece.NumberOfMouvs += 1;
                            map.CaseList.ElementAt(3).Piece = map.CaseList.ElementAt(0).Piece;
                            selectedC.Piece.undefineAvailableCases();
                            map.CaseList.ElementAt(0).Piece = null;
                            map.CaseList.ElementAt(2).Piece = map.CaseList.ElementAt(4).Piece;
                            map.CaseList.ElementAt(2).Piece.NumberOfMouvs += 1;
                            map.CaseList.ElementAt(4).Piece = null;
                            map.unSelectCase();
                            gameTurn = !gameTurn;
                        }
                    }else if (clickedCase.IsLittleRockPossible)
                    {
                        if (selectedC.Piece.IsWhite)
                        {
                            clickedCase.IsLittleRockPossible = false;
                            selectedC.Piece.NumberOfMouvs += 1;
                            map.CaseList.ElementAt(61).Piece = map.CaseList.ElementAt(63).Piece;
                            selectedC.Piece.undefineAvailableCases();
                            map.CaseList.ElementAt(63).Piece = null;
                            map.CaseList.ElementAt(62).Piece = map.CaseList.ElementAt(60).Piece;
                            map.CaseList.ElementAt(62).Piece.NumberOfMouvs += 1;
                            map.CaseList.ElementAt(60).Piece = null;
                            map.unSelectCase();
                            gameTurn = !gameTurn;
                        }
                        else
                        {
                            clickedCase.IsLittleRockPossible = false;
                            selectedC.Piece.NumberOfMouvs += 1;
                            map.CaseList.ElementAt(5).Piece = map.CaseList.ElementAt(7).Piece;
                            selectedC.Piece.undefineAvailableCases();
                            map.CaseList.ElementAt(7).Piece = null;
                            map.CaseList.ElementAt(6).Piece = map.CaseList.ElementAt(4).Piece;
                            map.CaseList.ElementAt(6).Piece.NumberOfMouvs += 1;
                            map.CaseList.ElementAt(4).Piece = null;
                            map.unSelectCase();
                            gameTurn = !gameTurn;
                        }
                    }
                    else
                    {
                        selectedC.Piece.undefineAvailableCases();
                        map.unSelectCase();
                        foreach (Case cCase in map.CaseList)
                        {
                            cCase.IsBigRockPossible = false;
                            cCase.IsLittleRockPossible = false;
                        }
                    } 
                }
                else
                {
                    if (map.getCase(mouseState.X, mouseState.Y, gameTurn) != null && map.getCase(mouseState.X, mouseState.Y, gameTurn).Piece != null)
                    {
                        map.selectCase(mouseState.X, mouseState.Y);
                    }
                }

            }

            oldState = mouseState;


            base.Update(gameTime);
        }

        private void DrawTurnInfo(SpriteBatch batch)
        {
            if (gameTurn)
            {
                batch.Draw(whitetexture, new Rectangle(220, 500, 50, 50), Color.White);
                batch.DrawString(font, "White", new Vector2(227, 518), Color.Black);
            }
            else
            {
                batch.Draw(blackTexture, new Rectangle(220, 500, 50, 50), Color.White);
                batch.DrawString(font, "Black", new Vector2(230, 518), Color.White);
            }
     
      
        }

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
            DrawTurnInfo(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
