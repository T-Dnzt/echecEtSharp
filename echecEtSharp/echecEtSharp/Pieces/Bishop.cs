using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace echecEtSharp.Pieces
{
    internal class Bishop : Piece
    {
        public Bishop(Texture2D tex, Boolean isWhite)
            : base(tex, isWhite)
        {
        }

        public override void UndefineAvailableCases()
        {
            foreach (Case c in AvailableCases)
            {
                c.AvailableCase = false;
            }
            AvailableCases.Clear();
        }

        public override void DefineAvailableCases(Case c, List<Case> map, bool whiteEchec, bool blackEchec,
                                                  bool firstEntry)
        {
            for (int i = 0; i < 4; i++)
            {
                Case tempC;
                if (IsWhite)
                {
                    if ((i == 0) && !IsOnH(map.IndexOf(c)) && !IsOn8(map.IndexOf(c)) && map.IndexOf(c) - 7 >= 0)
                    {
                        tempC = map.ElementAt(map.IndexOf(c) - 7);
                        while (tempC.Piece == null || !tempC.Piece.IsWhite)
                        {
                            tempC.AvailableCase = true;
                            AvailableCases.Add(tempC);
                            if ((map.IndexOf(tempC) - 7) >= 0 && !(tempC.Piece != null && !tempC.Piece.IsWhite) &&
                                !IsOnH(map.IndexOf(tempC)))
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
                    if ((i == 0) && !IsOnH(map.IndexOf(c)) && !IsOn8(map.IndexOf(c)) && map.IndexOf(c) - 7 >= 0)
                    {
                        tempC = map.ElementAt(map.IndexOf(c) - 7);

                        while (tempC.Piece == null || tempC.Piece.IsWhite)
                        {
                            tempC.AvailableCase = true;
                            AvailableCases.Add(tempC);
                            if ((map.IndexOf(tempC) - 7) >= 0 && !(tempC.Piece != null && tempC.Piece.IsWhite) &&
                                !IsOnH(map.IndexOf(tempC)))
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
                    if ((i == 1) && !IsOnA(map.IndexOf(c)) && !IsOn1(map.IndexOf(c)) && map.IndexOf(c) + 7 < 64)
                    {
                        tempC = map.ElementAt(map.IndexOf(c) + 7);
                        while (tempC.Piece == null || !tempC.Piece.IsWhite)
                        {
                            tempC.AvailableCase = true;
                            AvailableCases.Add(tempC);
                            if ((map.IndexOf(tempC) + 7) < 64 && !(tempC.Piece != null && !tempC.Piece.IsWhite) &&
                                !IsOnA(map.IndexOf(tempC)))
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
                    if ((i == 1) && !IsOnA(map.IndexOf(c)) && !IsOn1(map.IndexOf(c)) && map.IndexOf(c) + 7 < 64)
                    {
                        tempC = map.ElementAt(map.IndexOf(c) + 7);
                        while (tempC.Piece == null || tempC.Piece.IsWhite)
                        {
                            tempC.AvailableCase = true;
                            AvailableCases.Add(tempC);
                            if ((map.IndexOf(tempC) + 7) < 64 && !(tempC.Piece != null && tempC.Piece.IsWhite) &&
                                !IsOnA(map.IndexOf(tempC)))
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
                    if ((i == 2) && !IsOnA(map.IndexOf(c)) && !IsOn8(map.IndexOf(c)) && map.IndexOf(c) - 9 >= 0)
                    {
                        tempC = map.ElementAt(map.IndexOf(c) - 9);

                        while (tempC.Piece == null || !tempC.Piece.IsWhite)
                        {
                            tempC.AvailableCase = true;
                            AvailableCases.Add(tempC);
                            if ((map.IndexOf(tempC) - 9) >= 0 && !(tempC.Piece != null && !tempC.Piece.IsWhite) &&
                                !IsOnA(map.IndexOf(tempC)))
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
                    if ((i == 2) && !IsOnA(map.IndexOf(c)) && !IsOn8(map.IndexOf(c)) && map.IndexOf(c) - 9 >= 0)
                    {
                        tempC = map.ElementAt(map.IndexOf(c) - 9);

                        while (tempC.Piece == null || tempC.Piece.IsWhite)
                        {
                            tempC.AvailableCase = true;
                            AvailableCases.Add(tempC);
                            if ((map.IndexOf(tempC) - 9) >= 0 && !(tempC.Piece != null && tempC.Piece.IsWhite) &&
                                !IsOnA(map.IndexOf(tempC)))
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
                    if ((i == 3) && !IsOnH(map.IndexOf(c)) && !IsOn1(map.IndexOf(c)) && map.IndexOf(c) + 9 < 64)
                    {
                        tempC = map.ElementAt(map.IndexOf(c) + 9);
                        while (tempC.Piece == null || !tempC.Piece.IsWhite)
                        {
                            tempC.AvailableCase = true;
                            AvailableCases.Add(tempC);
                            if ((map.IndexOf(tempC) + 9) < 64 && !(tempC.Piece != null && !tempC.Piece.IsWhite) &&
                                !IsOnH(map.IndexOf(tempC)))
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
                    if ((i == 3) && !IsOnH(map.IndexOf(c)) && !IsOn1(map.IndexOf(c)) && map.IndexOf(c) + 9 < 64)
                    {
                        tempC = map.ElementAt(map.IndexOf(c) + 9);
                        while (tempC.Piece == null || tempC.Piece.IsWhite)
                        {
                            tempC.AvailableCase = true;
                            AvailableCases.Add(tempC);
                            if ((map.IndexOf(tempC) + 9) < 64 && !(tempC.Piece != null && tempC.Piece.IsWhite) &&
                                !IsOnH(map.IndexOf(tempC)))
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) + 9);
                            }
                            else
                                break;
                        }
                    }
                }
            }

            if (firstEntry)
            {
                MoveOnlyIfNotEchec(c, map, whiteEchec, blackEchec);
            }
        }
    }
}