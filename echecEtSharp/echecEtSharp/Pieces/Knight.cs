using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace echecEtSharp.Pieces
{
    internal class Knight : Piece
    {
        public Knight(Texture2D tex, Boolean isWhite)
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

        public override void DefineAvailableCases(Case c, List<Case> map, bool whiteEchec, bool blackEchec, bool firstEntry)
        {
            for (int i = 1; i <= 8; i++)
            {
                Case tempC;

                if ((i == 1 && map.IndexOf(c) - 17 >= 0 && map.IndexOf(c) - 17 < 64) && !IsOnA(map.IndexOf(c)))
                {
                    tempC = map.ElementAt(map.IndexOf(c) - 17);
                    if (tempC.Piece == null || (IsWhite && !tempC.Piece.IsWhite ))
                    {
                        tempC.AvailableCase = true;
                        AvailableCases.Add(tempC);
                    }
                    else if (tempC.Piece == null || (!IsWhite && tempC.Piece.IsWhite))
                    {
                        tempC.AvailableCase = true;
                        AvailableCases.Add(tempC);
                    }
                }
                else if ((i == 2 && map.IndexOf(c) - 15 >= 0 && map.IndexOf(c) - 15 < 64) && !IsOnH(map.IndexOf(c)))
                {
                    tempC = map.ElementAt(map.IndexOf(c) - 15);
                    if (tempC.Piece == null || (IsWhite && !tempC.Piece.IsWhite))
                    {
                        tempC.AvailableCase = true;
                        AvailableCases.Add(tempC);
                    }
                    else if (tempC.Piece == null || (!IsWhite && tempC.Piece.IsWhite))
                    {
                        tempC.AvailableCase = true;
                        AvailableCases.Add(tempC);
                    }
                }
                else if ((i == 3 && map.IndexOf(c) - 10 >= 0 && map.IndexOf(c) - 10 < 64) && !IsOnA(map.IndexOf(c)) &&
                         !IsOnB(map.IndexOf(c)))
                {
                    tempC = map.ElementAt(map.IndexOf(c) - 10);
                    if (tempC.Piece == null || (IsWhite && !tempC.Piece.IsWhite))
                    {
                        tempC.AvailableCase = true;
                        AvailableCases.Add(tempC);
                    }
                    else if (tempC.Piece == null || (!IsWhite && tempC.Piece.IsWhite))
                    {
                        tempC.AvailableCase = true;
                        AvailableCases.Add(tempC);
                    }
                }
                else if ((i == 4 && map.IndexOf(c) - 6 >= 0 && map.IndexOf(c) - 6 < 64) && !IsOnG(map.IndexOf(c)) &&
                         !IsOnH(map.IndexOf(c)))
                {
                    tempC = map.ElementAt(map.IndexOf(c) - 6);
                    if (tempC.Piece == null || (IsWhite && !tempC.Piece.IsWhite))
                    {
                        tempC.AvailableCase = true;
                        AvailableCases.Add(tempC);
                    }
                    else if (tempC.Piece == null || (!IsWhite && tempC.Piece.IsWhite))
                    {
                        tempC.AvailableCase = true;
                        AvailableCases.Add(tempC);
                    }
                }
                else if ((i == 5 && map.IndexOf(c) + 15 >= 0 && map.IndexOf(c) + 15 < 64) &&
                         !IsOnA(map.IndexOf(c)))
                {
                    tempC = map.ElementAt(map.IndexOf(c) + 15);
                    if (tempC.Piece == null || (IsWhite && !tempC.Piece.IsWhite))
                    {
                        tempC.AvailableCase = true;
                        AvailableCases.Add(tempC);
                    }
                    else if (tempC.Piece == null || (!IsWhite && tempC.Piece.IsWhite))
                    {
                        tempC.AvailableCase = true;
                        AvailableCases.Add(tempC);
                    }
                }
                else if ((i == 6 && map.IndexOf(c) + 17 >= 0 && map.IndexOf(c) + 17 < 64) &&
                         !IsOnH(map.IndexOf(c)))
                {
                    tempC = map.ElementAt(map.IndexOf(c) + 17);
                    if (tempC.Piece == null || (IsWhite && !tempC.Piece.IsWhite))
                    {
                        tempC.AvailableCase = true;
                        AvailableCases.Add(tempC);
                    }
                    else if (tempC.Piece == null || (!IsWhite && tempC.Piece.IsWhite))
                    {
                        tempC.AvailableCase = true;
                        AvailableCases.Add(tempC);
                    }
                }
                else if ((i == 7 && map.IndexOf(c) + 6 >= 0 && map.IndexOf(c) + 6 < 64) &&
                         !IsOnA(map.IndexOf(c)) && !IsOnB(map.IndexOf(c)))
                {
                    tempC = map.ElementAt(map.IndexOf(c) + 6);
                    if (tempC.Piece == null || (IsWhite && !tempC.Piece.IsWhite))
                    {
                        tempC.AvailableCase = true;
                        AvailableCases.Add(tempC);
                    }
                    else if (tempC.Piece == null || (!IsWhite && tempC.Piece.IsWhite))
                    {
                        tempC.AvailableCase = true;
                        AvailableCases.Add(tempC);
                    }
                }
                else if ((i == 8 && map.IndexOf(c) + 10 >= 0 && map.IndexOf(c) + 10 < 64) &&
                         !IsOnG(map.IndexOf(c)) && !IsOnH(map.IndexOf(c)))
                {
                    tempC = map.ElementAt(map.IndexOf(c) + 10);
                    if (tempC.Piece == null || (IsWhite && !tempC.Piece.IsWhite))
                    {
                        tempC.AvailableCase = true;
                        AvailableCases.Add(tempC);
                    }
                    else if (tempC.Piece == null || (!IsWhite && tempC.Piece.IsWhite))
                    {
                        tempC.AvailableCase = true;
                        AvailableCases.Add(tempC);
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