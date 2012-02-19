using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace echecEtSharp.Pieces
{
    internal class Bishop : Piece
    {
        public Bishop(Texture2D tex, Boolean isWhite, Boolean canJump)
            : base(tex, isWhite, canJump)
        {
            isKing = false;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void undefineAvailableCases()
        {
            foreach (Case c in AvailableCases)
            {
                c.AvailableCase = false;
            }
            AvailableCases.Clear();
        }

        public override void defineAvailableCases(Case c, List<Case> map)
        {
            for (int i = 0; i < 4; i++)
            {
                Case tempC;
                if (IsWhite)
                {
                    if ((i == 0) && !isOnH(map.IndexOf(c)) && !isOn8(map.IndexOf(c)) && map.IndexOf(c) - 7 >= 0)
                    {
                        tempC = map.ElementAt(map.IndexOf(c) - 7);

                        while (tempC.Piece == null || !tempC.Piece.IsWhite && !tempC.Piece.isKing)
                        {
                            tempC.AvailableCase = true;
                            AvailableCases.Add(tempC);
                            if ((map.IndexOf(tempC) - 7) >= 0 && !(tempC.Piece != null && !tempC.Piece.IsWhite) &&
                                !isOnH(map.IndexOf(tempC)))
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) - 7);
                            }
                            else
                                break;
                        }
                    }
                }
                else
                {
                    if ((i == 0) && !isOnH(map.IndexOf(c)) && !isOn8(map.IndexOf(c)) && map.IndexOf(c) - 7 >= 0)
                    {
                        tempC = map.ElementAt(map.IndexOf(c) - 7);

                        while (tempC.Piece == null || tempC.Piece.IsWhite && !tempC.Piece.isKing)
                        {
                            tempC.AvailableCase = true;
                            AvailableCases.Add(tempC);
                            if ((map.IndexOf(tempC) - 7) >= 0 && !(tempC.Piece != null && tempC.Piece.IsWhite) &&
                                !isOnH(map.IndexOf(tempC)))
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) - 7);
                            }
                            else
                                break;
                        }
                    }
                }


                if (IsWhite)
                {
                    if ((i == 1) && !isOnA(map.IndexOf(c)) && !isOn1(map.IndexOf(c)) && map.IndexOf(c) + 7 < 64)
                    {
                        tempC = map.ElementAt(map.IndexOf(c) + 7);
                        while (tempC.Piece == null || !tempC.Piece.IsWhite && !tempC.Piece.isKing)
                        {
                            tempC.AvailableCase = true;
                            AvailableCases.Add(tempC);
                            if ((map.IndexOf(tempC) + 7) < 64 && !(tempC.Piece != null && !tempC.Piece.IsWhite) &&
                                !isOnA(map.IndexOf(tempC)))
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) + 7);
                            }
                            else
                                break;
                        }
                    }
                }
                else
                {
                    if ((i == 1) && !isOnA(map.IndexOf(c)) && !isOn1(map.IndexOf(c)) && map.IndexOf(c) + 7 < 64)
                    {
                        tempC = map.ElementAt(map.IndexOf(c) + 7);
                        while (tempC.Piece == null || tempC.Piece.IsWhite && !tempC.Piece.isKing)
                        {
                            tempC.AvailableCase = true;
                            AvailableCases.Add(tempC);
                            if ((map.IndexOf(tempC) + 7) < 64 && !(tempC.Piece != null && tempC.Piece.IsWhite) &&
                                !isOnA(map.IndexOf(tempC)))
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) + 7);
                            }
                            else
                                break;
                        }
                    }
                }


                if (IsWhite)
                {
                    if ((i == 2) && !isOnA(map.IndexOf(c)) && !isOn8(map.IndexOf(c)) && map.IndexOf(c) - 9 >= 0)
                    {
                        tempC = map.ElementAt(map.IndexOf(c) - 9);

                        while (tempC.Piece == null || !tempC.Piece.IsWhite && !tempC.Piece.isKing)
                        {
                            tempC.AvailableCase = true;
                            AvailableCases.Add(tempC);
                            if ((map.IndexOf(tempC) - 9) >= 0 && !(tempC.Piece != null && !tempC.Piece.IsWhite) &&
                                !isOnA(map.IndexOf(tempC)))
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) - 9);
                            }
                            else
                                break;
                        }
                    }
                }
                else
                {
                    if ((i == 2) && !isOnA(map.IndexOf(c)) && !isOn8(map.IndexOf(c)) && map.IndexOf(c) - 9 >= 0)
                    {
                        tempC = map.ElementAt(map.IndexOf(c) - 9);

                        while (tempC.Piece == null || tempC.Piece.IsWhite && !tempC.Piece.isKing)
                        {
                            tempC.AvailableCase = true;
                            AvailableCases.Add(tempC);
                            if ((map.IndexOf(tempC) - 9) >= 0 && !(tempC.Piece != null && tempC.Piece.IsWhite) &&
                                !isOnA(map.IndexOf(tempC)))
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) - 9);
                            }
                            else
                                break;
                        }
                    }
                }


                if (IsWhite)
                {
                    if ((i == 3) && !isOnH(map.IndexOf(c)) && !isOn1(map.IndexOf(c)) && map.IndexOf(c) + 9 < 64)
                    {
                        tempC = map.ElementAt(map.IndexOf(c) + 9);
                        while (tempC.Piece == null || !tempC.Piece.IsWhite && !tempC.Piece.isKing)
                        {
                            tempC.AvailableCase = true;
                            AvailableCases.Add(tempC);
                            if ((map.IndexOf(tempC) + 9) < 64 && !(tempC.Piece != null && !tempC.Piece.IsWhite) &&
                                !isOnH(map.IndexOf(tempC)))
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) + 9);
                            }
                            else
                                break;
                        }
                    }
                }
                else
                {
                    if ((i == 3) && !isOnH(map.IndexOf(c)) && !isOn1(map.IndexOf(c)) && map.IndexOf(c) + 9 < 64)
                    {
                        tempC = map.ElementAt(map.IndexOf(c) + 9);
                        while (tempC.Piece == null || tempC.Piece.IsWhite && !tempC.Piece.isKing)
                        {
                            tempC.AvailableCase = true;
                            AvailableCases.Add(tempC);
                            if ((map.IndexOf(tempC) + 9) < 64 && !(tempC.Piece != null && tempC.Piece.IsWhite) &&
                                !isOnH(map.IndexOf(tempC)))
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) + 9);
                            }
                            else
                                break;
                        }
                    }
                }
            }
        }

        public override List<Case> defineEchecCases(Boolean white, Case king, Case c, List<Case> map)
        {
            var echecCases = new List<Case>();
            for (int i = 0; i < 4; i++)
            {
                Case tempC;
                if (IsWhite)
                {
                    if ((i == 0) && !isOnH(map.IndexOf(c)) && !isOn8(map.IndexOf(c)) && map.IndexOf(c) - 7 >= 0)
                    {
                        tempC = map.ElementAt(map.IndexOf(c) - 7);

                        while (tempC.Piece == null || tempC.Piece.IsWhite || tempC.Piece is King)
                        {
                            echecCases.Add(tempC);
                            if ((map.IndexOf(tempC) - 7) >= 0 &&
                                !isOnH(map.IndexOf(tempC)))
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) - 7);
                            }
                            else if (tempC.Piece is King && map.IndexOf(tempC) - 7 >= 0)
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) - 7);
                            }
                            else
                                break;
                        }
                    }
                }
                else
                {
                    if ((i == 0) && !isOnH(map.IndexOf(c)) && !isOn8(map.IndexOf(c)) && map.IndexOf(c) - 7 >= 0)
                    {
                        tempC = map.ElementAt(map.IndexOf(c) - 7);

                        while (tempC.Piece == null || !tempC.Piece.IsWhite || tempC.Piece is King)
                        {
                            echecCases.Add(tempC);
                            if ((map.IndexOf(tempC) - 7) >= 0 &&
                                !isOnH(map.IndexOf(tempC)))
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) - 7);
                            }
                            else if (tempC.Piece is King && map.IndexOf(tempC) - 7 >= 0)
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) - 7);
                            }
                            else
                                break;
                        }
                    }
                }


                if (IsWhite)
                {
                    if ((i == 1) && !isOnA(map.IndexOf(c)) && !isOn1(map.IndexOf(c)) && map.IndexOf(c) + 7 < 64)
                    {
                        tempC = map.ElementAt(map.IndexOf(c) + 7);
                        while (tempC.Piece == null || tempC.Piece.IsWhite || tempC.Piece is King)
                        {
                            echecCases.Add(tempC);
                            if ((map.IndexOf(tempC) + 7) < 64 &&
                                !isOnA(map.IndexOf(tempC)))
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) + 7);
                            }
                            else if (tempC.Piece is King && map.IndexOf(tempC) + 7 < 64)
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) + 7);
                            }
                            else
                                break;
                        }
                    }
                }
                else
                {
                    if ((i == 1) && !isOnA(map.IndexOf(c)) && !isOn1(map.IndexOf(c)) && map.IndexOf(c) + 7 < 64)
                    {
                        tempC = map.ElementAt(map.IndexOf(c) + 7);
                        while (tempC.Piece == null || !tempC.Piece.IsWhite || tempC.Piece is King)
                        {
                            echecCases.Add(tempC);
                            if ((map.IndexOf(tempC) + 7) < 64 &&
                                !isOnA(map.IndexOf(tempC)))
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) + 7);
                            }
                            else if (tempC.Piece is King && map.IndexOf(tempC) + 7 < 64)
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) + 7);
                            }
                            else
                                break;
                        }
                    }
                }


                if (IsWhite)
                {
                    if ((i == 2) && !isOnA(map.IndexOf(c)) && !isOn8(map.IndexOf(c)) && map.IndexOf(c) - 9 >= 0)
                    {
                        tempC = map.ElementAt(map.IndexOf(c) - 9);

                        while (tempC.Piece == null || tempC.Piece.IsWhite || tempC.Piece is King)
                        {
                            echecCases.Add(tempC);
                            if ((map.IndexOf(tempC) - 9) >= 0 &&
                                !isOnA(map.IndexOf(tempC)))
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) - 9);
                            }
                            else if (tempC.Piece is King && map.IndexOf(tempC) - 9 >= 0)
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) - 9);
                            }
                            else
                                break;
                        }
                    }
                }
                else
                {
                    if ((i == 2) && !isOnA(map.IndexOf(c)) && !isOn8(map.IndexOf(c)) && map.IndexOf(c) - 9 >= 0)
                    {
                        tempC = map.ElementAt(map.IndexOf(c) - 9);

                        while (tempC.Piece == null || !tempC.Piece.IsWhite || tempC.Piece is King)
                        {
                            echecCases.Add(tempC);
                            if ((map.IndexOf(tempC) - 9) >= 0 &&
                                !isOnA(map.IndexOf(tempC)))
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) - 9);
                            }
                            else if (tempC.Piece is King && map.IndexOf(tempC) - 9 >= 0)
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) - 9);
                            }
                            else
                                break;
                        }
                    }
                }


                if (IsWhite)
                {
                    if ((i == 3) && !isOnH(map.IndexOf(c)) && !isOn1(map.IndexOf(c)) && map.IndexOf(c) + 9 < 64)
                    {
                        tempC = map.ElementAt(map.IndexOf(c) + 9);
                        while (tempC.Piece == null || tempC.Piece.IsWhite || tempC.Piece is King)
                        {
                            echecCases.Add(tempC);
                            if ((map.IndexOf(tempC) + 9) < 64 &&
                                !isOnH(map.IndexOf(tempC)))
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) + 9);
                            }
                            else if (tempC.Piece is King && map.IndexOf(tempC) + 9 < 64)
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) + 9);
                            }
                            else
                                break;
                        }
                    }
                }
                else
                {
                    if ((i == 3) && !isOnH(map.IndexOf(c)) && !isOn1(map.IndexOf(c)) && map.IndexOf(c) + 9 < 64)
                    {
                        tempC = map.ElementAt(map.IndexOf(c) + 9);
                        while (tempC.Piece == null || !tempC.Piece.IsWhite || tempC.Piece is King)
                        {
                            echecCases.Add(tempC);
                            if ((map.IndexOf(tempC) + 9) < 64 &&
                                !isOnH(map.IndexOf(tempC)))
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) + 9);
                            }
                            else if (tempC.Piece is King && map.IndexOf(tempC) + 9 < 64)
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) + 9);
                            }
                            else
                                break;
                        }
                    }
                }
            }
            return echecCases;
        }
    }
}