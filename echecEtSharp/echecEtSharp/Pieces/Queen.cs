using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace echecEtSharp.Pieces
{
    internal class Queen : Piece
    {
        public Queen(Texture2D tex, Boolean isWhite)
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
            for (int i = 0; i < 8; i++)
            {
                Case tempC;
                if ((i == 0) && map.IndexOf(c) - 8 >= 0)
                {
                    tempC = map.ElementAt(map.IndexOf(c) - 8);
                    if (IsWhite)
                    {
                        while (tempC.Piece == null || !tempC.Piece.IsWhite)
                        {
                            tempC.AvailableCase = true;
                            AvailableCases.Add(tempC);
                            if ((map.IndexOf(tempC) - 8) >= 0 && !(tempC.Piece != null && !tempC.Piece.IsWhite))
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) - 8);
                            }
                            else
                                break;
                        }
                    }
                    else
                    {
                        while (tempC.Piece == null || tempC.Piece.IsWhite)
                        {
                            tempC.AvailableCase = true;
                            AvailableCases.Add(tempC);
                            if ((map.IndexOf(tempC) - 8) >= 0 && !(tempC.Piece != null && tempC.Piece.IsWhite))
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) - 8);
                            }
                            else
                                break;
                        }
                    }
                }

                if ((i == 1) && map.IndexOf(c) + 8 < 64)
                {
                    tempC = map.ElementAt(map.IndexOf(c) + 8);
                    if (IsWhite)
                    {
                        while (tempC.Piece == null || !tempC.Piece.IsWhite)
                        {
                            tempC.AvailableCase = true;
                            AvailableCases.Add(tempC);
                            if ((map.IndexOf(tempC) + 8) < 64 && !(tempC.Piece != null && !tempC.Piece.IsWhite))
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) + 8);
                            }
                            else
                                break;
                        }
                    }
                    else
                    {
                        while (tempC.Piece == null || tempC.Piece.IsWhite)
                        {
                            tempC.AvailableCase = true;
                            AvailableCases.Add(tempC);
                            if ((map.IndexOf(tempC) + 8) < 64 && !(tempC.Piece != null && tempC.Piece.IsWhite))
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) + 8);
                            }
                            else
                                break;
                        }
                    }
                }

                if ((i == 2) && !IsOnA(map.IndexOf(c)))
                {
                    tempC = map.ElementAt(map.IndexOf(c) - 1);
                    if (IsWhite)
                    {
                        while (!IsOnA(map.IndexOf(tempC) + 1) && (tempC.Piece == null || !tempC.Piece.IsWhite))
                        {
                            tempC.AvailableCase = true;
                            AvailableCases.Add(tempC);
                            if (map.IndexOf(tempC) - 1 >= 0 && !(tempC.Piece != null && !tempC.Piece.IsWhite))
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) - 1);
                            }
                            else
                                break;
                        }
                    }
                    else
                    {
                        while (!IsOnA(map.IndexOf(tempC) + 1) && (tempC.Piece == null || tempC.Piece.IsWhite))
                        {
                            tempC.AvailableCase = true;
                            AvailableCases.Add(tempC);
                            if (map.IndexOf(tempC) - 1 >= 0 && !(tempC.Piece != null && tempC.Piece.IsWhite))
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) - 1);
                            }
                            else
                                break;
                        }
                    }
                }

                if ((i == 3) && !IsOnH(map.IndexOf(c)))
                {
                    tempC = map.ElementAt(map.IndexOf(c) + 1);
                    if (IsWhite)
                    {
                        while (!IsOnH(map.IndexOf(tempC) - 1) && (tempC.Piece == null || !tempC.Piece.IsWhite))
                        {
                            tempC.AvailableCase = true;
                            AvailableCases.Add(tempC);
                            if (map.IndexOf(tempC) + 1 < 64 && !(tempC.Piece != null && !tempC.Piece.IsWhite))
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) + 1);
                            }
                            else
                                break;
                        }
                    }
                    else
                    {
                        while (!IsOnH(map.IndexOf(tempC) - 1) && (tempC.Piece == null || tempC.Piece.IsWhite))
                        {
                            tempC.AvailableCase = true;
                            AvailableCases.Add(tempC);
                            if (map.IndexOf(tempC) + 1 < 64 && !(tempC.Piece != null && tempC.Piece.IsWhite))
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) + 1);
                            }
                            else
                                break;
                        }
                    }
                }

                if (IsWhite)
                {
                    if ((i == 4) && !IsOnH(map.IndexOf(c)) && !IsOn8(map.IndexOf(c)) && map.IndexOf(c) - 7 >= 0)
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
                    if ((i == 4) && !IsOnH(map.IndexOf(c)) && !IsOn8(map.IndexOf(c)) && map.IndexOf(c) - 7 >= 0)
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
                    if ((i == 5) && !IsOnA(map.IndexOf(c)) && !IsOn1(map.IndexOf(c)) && map.IndexOf(c) + 7 < 64)
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
                    if ((i == 5) && !IsOnA(map.IndexOf(c)) && !IsOn1(map.IndexOf(c)) && map.IndexOf(c) + 7 < 64)
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
                    if ((i == 6) && !IsOnA(map.IndexOf(c)) && !IsOn8(map.IndexOf(c)) && map.IndexOf(c) - 9 >= 0)
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
                    if ((i == 6) && !IsOnA(map.IndexOf(c)) && !IsOn8(map.IndexOf(c)) && map.IndexOf(c) - 9 >= 0)
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
                    if ((i == 7) && !IsOnH(map.IndexOf(c)) && !IsOn1(map.IndexOf(c)) && map.IndexOf(c) + 9 < 64)
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
                    if ((i == 7) && !IsOnH(map.IndexOf(c)) && !IsOn1(map.IndexOf(c)) && map.IndexOf(c) + 9 < 64)
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