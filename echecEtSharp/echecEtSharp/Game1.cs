using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.GamerServices;


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

        private MouseState mouseState;
        private MouseState oldState;

        private KeyboardState keyboardState;
        private KeyboardState oldKeyboardState;

        private Boolean gameTurn;

        private List<Texture2D> textures;

        private bool playAgain;
        private bool gamePlaying;
        private bool winner;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 500;
            graphics.PreferredBackBufferHeight = 650;
            IsMouseVisible = true;
            textures = new List<Texture2D>();

            initGame();
        }

        public void initGame()
        {
            map = new Map();
            player1 = new Player(1, true);
            player2 = new Player(2, false);
            gameTurn = true;
            playAgain = true;
            gamePlaying = true;

        }

        public void loadGame()
        {
            for (int i = 0; i < textures.Count; i++)
            {
                map.AddTexture(textures.ElementAt(i));
                Console.WriteLine(textures.ElementAt(i).Name);
            }

            map.generateMap();

            loadPiecesTextures(player1, "White");
            loadPiecesTextures(player2, "Black");
            player1.generatePieces();
            player2.generatePieces();
            setPiecesOnCases();
            map.AddFont(font);
        }

        public void resetGame()
        {
            initGame();
            loadGame();
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        public void gameOver(bool win)
        {
            gamePlaying = false;
            winner = win;
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            textures.Add(Content.Load<Texture2D>("white"));
            textures.Add(Content.Load<Texture2D>("grey"));
            textures.Add(Content.Load<Texture2D>("blue"));
            textures.Add( Content.Load<Texture2D>("red"));
            textures.Add( Content.Load<Texture2D>("green"));
            textures.Add(Content.Load<Texture2D>("black"));
            font = Content.Load<SpriteFont>("Arial");

            loadGame();
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

            if (gamePlaying)
            {
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
                            if (selectedC.Piece.IsWhite)
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
                        }
                        else if (clickedCase.IsLittleRockPossible)
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
            }
            else
            {
                keyboardState = Keyboard.GetState();
                if (keyboardState.IsKeyDown(Keys.Down))
                {
                    playAgain = false;
                }
                else if (keyboardState.IsKeyDown(Keys.Up))
                {
                    playAgain = true;
                }
                else if (keyboardState.IsKeyDown(Keys.Enter))
                {
                    if(playAgain)
                        resetGame();
                    else
                        Exit();                      
                }

                oldKeyboardState = keyboardState;
            }
    
            base.Update(gameTime);
        }

        private void DrawTurnInfo(SpriteBatch batch)
        {
            if (gameTurn)
            {
                batch.Draw(textures.ElementAt(0), new Rectangle(220, 500, 50, 50), Color.White);
                batch.DrawString(font, "White", new Vector2(227, 518), Color.Black);
            }
            else
            {
                batch.Draw(textures.ElementAt(5), new Rectangle(220, 500, 50, 50), Color.White);
                batch.DrawString(font, "Black", new Vector2(230, 518), Color.White);
            }
        }

        private void drawMenu(SpriteBatch batch)
        {

            if(winner)
                batch.DrawString(font, "White wins ! ", new Vector2(215, 200), Color.Black);
            else
                batch.DrawString(font, "Black wins ! ", new Vector2(215, 200), Color.Black);

            if (playAgain)
            {
                batch.DrawString(font, "Play again", new Vector2(220, 280), Color.Gray);
                batch.DrawString(font, "Quit", new Vector2(238, 300), Color.Black);
            }
            else
            {
                batch.DrawString(font, "Play again", new Vector2(220, 280), Color.Black);
                batch.DrawString(font, "Quit", new Vector2(238, 300), Color.Gray);
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.WhiteSmoke);

            spriteBatch.Begin();
           

            if (gamePlaying)
            {
                map.Draw(spriteBatch);
                DrawTurnInfo(spriteBatch);
            }
            else
            {
                drawMenu(spriteBatch);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
