using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace echecEtSharp.Pieces
{
    internal class Pawn : Piece
    {
        public Pawn(Texture2D tex, Boolean isWhite)
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
            if (IsWhite)
            {
                for (int i = 0; i < 3; i++)
                {
                    Case tempC;
                    if (i == 0 && map.ElementAt(map.IndexOf(c) - 8).Piece == null)
                    {
                        tempC = map.ElementAt(map.IndexOf(c) - 8);
                        tempC.AvailableCase = true;
                        AvailableCases.Add(tempC);
                        if (IsOn2(map.IndexOf(c)) && map.ElementAt(map.IndexOf(tempC) - 8).Piece == null)
                        {
                            tempC = map.ElementAt(map.IndexOf(tempC) - 8);
                            tempC.AvailableCase = true;
                            AvailableCases.Add(tempC);
                        }
                    }
                    else if (i == 1 && !IsOnH(map.IndexOf(c)) && map.ElementAt(map.IndexOf(c) - 7).Piece != null &&
                                !map.ElementAt(map.IndexOf(c) - 7).Piece.IsWhite)
                    {
                        tempC = map.ElementAt(map.IndexOf(c) - 7);
                        tempC.AvailableCase = true;
                        AvailableCases.Add(tempC);
                    }
                    else if (i == 2 && !IsOnA(map.IndexOf(c)) && map.ElementAt(map.IndexOf(c) - 9).Piece != null &&
                                !map.ElementAt(map.IndexOf(c) - 9).Piece.IsWhite)
                    {
                        tempC = map.ElementAt(map.IndexOf(c) - 9);
                        tempC.AvailableCase = true;
                        AvailableCases.Add(tempC);
                    } 
                }

            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    Case tempC;
                    if (i == 0 && map.ElementAt(map.IndexOf(c) + 8).Piece == null)
                    {
                        tempC = map.ElementAt(map.IndexOf(c) + 8);
                        tempC.AvailableCase = true;
                        AvailableCases.Add(tempC);
                        if (IsOn6(map.IndexOf(c)) && map.ElementAt(map.IndexOf(tempC) + 8).Piece == null)
                        {
                            tempC = map.ElementAt(map.IndexOf(tempC) + 8);
                            tempC.AvailableCase = true;
                            AvailableCases.Add(tempC);
                        }
                    }
                    else if (i == 1 && map.ElementAt(map.IndexOf(c) + 7).Piece != null && !IsOnA(map.IndexOf(c)) &&
                                map.ElementAt(map.IndexOf(c) + 7).Piece.IsWhite)
                    {
                        tempC = map.ElementAt(map.IndexOf(c) + 7);
                        tempC.AvailableCase = true;
                        AvailableCases.Add(tempC);
                    }
                    else if (i == 2 && map.ElementAt(map.IndexOf(c) + 9).Piece != null && !IsOnH(map.IndexOf(c)) &&
                                map.ElementAt(map.IndexOf(c) + 9).Piece.IsWhite)
                    {
                        tempC = map.ElementAt(map.IndexOf(c) + 9);
                        tempC.AvailableCase = true;
                        AvailableCases.Add(tempC);
                    }
                }

            }

            if(firstEntry)
            {
                MoveOnlyIfNotEchec(c, map, whiteEchec, blackEchec);
            }
        }
    }
}