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
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Map map;

        private Player player1;
        private Player player2;

        private SpriteFont font;

        private Texture2D blackTexture;
        private  Texture2D whitetexture;

        private MouseState mouseState;
        private MouseState oldState;

        private Boolean gameTurn;

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

            Console.WriteLine("fu");
            gameTurn = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

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
            for (int top = 56; top < 64; top++)
            {
                map.CaseList.ElementAt(top).Piece = player1.ListPieces.ElementAt(top - 56);
                map.CaseList.ElementAt(48 + (top - 56)).Piece = player1.ListPieces.ElementAt(top - 48);

                map.CaseList.ElementAt(top - 56).Piece = player2.ListPieces.ElementAt(top - 56);
                map.CaseList.ElementAt(8 + (top - 56)).Piece = player2.ListPieces.ElementAt(top - 48);
            }
        }

        protected override void UnloadContent()
        {

        }

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
                        Piece currentPiece = clickedCase.Piece;
                       
                        clickedCase.Piece.NumberOfMouvs += 1;
                        selectedC.Piece.undefineAvailableCases();

                        if (currentPiece != null && currentPiece.GetType().Name == "Pawn")
                        {
                            if (currentPiece.IsWhite && clickedCase.Piece.isOn8(map.CaseList.IndexOf(clickedCase)))
                                player1.turnPawnIntoHulk(clickedCase, (Pieces.Pawn)currentPiece, "White", gameTurn);                                
                            else if (!currentPiece.IsWhite && clickedCase.Piece.isOn1(map.CaseList.IndexOf(clickedCase)))
                                player2.turnPawnIntoHulk(clickedCase, (Pieces.Pawn)currentPiece, "Black", gameTurn);

                        }

                        selectedC.Piece = null;
                        map.unSelectCase();
                        gameTurn = !gameTurn;
                    }
                    else if (clickedCase.IsBigRockPossible)
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

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.WhiteSmoke);

            spriteBatch.Begin();
           
            map.Draw(spriteBatch);
            DrawTurnInfo(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
