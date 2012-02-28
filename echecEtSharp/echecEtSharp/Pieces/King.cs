using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace echecEtSharp.Pieces
{
    internal class King : Piece
    {
        public King(Texture2D tex, Boolean isWhite)
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
         /*   if (c.Piece.IsWhite && map.ElementAt(63).Piece != null && map.ElementAt(63).Piece.NumberOfMoves == 0 &&
                map.ElementAt(60).Piece != null &&
                map.ElementAt(60).Piece is King && map.ElementAt(60).Piece.NumberOfMoves == 0 &&
                !isInEchec(true, map.ElementAt(60), map) && !isInEchec(true, map.ElementAt(58), map) &&
                map.ElementAt(59).Piece == null && map.ElementAt(58).Piece == null && map.ElementAt(57).Piece == null)
            {
                //grand roque blanc
                map.ElementAt(56).IsBigRockPossible = true;
            }
            else if (c.Piece.IsWhite && map.ElementAt(56).Piece != null && map.ElementAt(56).Piece.NumberOfMoves == 0 &&
                     map.ElementAt(60).Piece != null &&
                     map.ElementAt(60).Piece is King && map.ElementAt(60).Piece.NumberOfMoves == 0 &&
                     !isInEchec(true, map.ElementAt(60), map) && !isInEchec(true, map.ElementAt(62), map) &&
                     map.ElementAt(62).Piece == null && map.ElementAt(61).Piece == null)
            {
                //petit roque blanc
                map.ElementAt(63).IsLittleRockPossible = true;
            }
            else if (!c.Piece.IsWhite && map.ElementAt(7).Piece != null && map.ElementAt(7).Piece.NumberOfMoves == 0 &&
                     map.ElementAt(4).Piece != null &&
                     map.ElementAt(4).Piece is King && map.ElementAt(4).Piece.NumberOfMoves == 0 &&
                     !isInEchec(false, map.ElementAt(4), map) && !isInEchec(false, map.ElementAt(6), map) &&
                     map.ElementAt(6).Piece == null && map.ElementAt(5).Piece == null)
            {
                //petit roque noir
                map.ElementAt(7).IsLittleRockPossible = true;
            }
            else if (!c.Piece.IsWhite && map.ElementAt(0).Piece != null && map.ElementAt(0).Piece.NumberOfMoves == 0 &&
                     map.ElementAt(4).Piece != null &&
                     map.ElementAt(4).Piece is King && map.ElementAt(4).Piece.NumberOfMoves == 0 &&
                     !isInEchec(false, map.ElementAt(4), map) && !isInEchec(false, map.ElementAt(2), map) &&
                     map.ElementAt(3).Piece == null && map.ElementAt(2).Piece == null &&
                     map.ElementAt(1).Piece == null)
            {
                //grand roque noir
                map.ElementAt(0).IsBigRockPossible = true;
            }*/

            for (int i = 0; i < 8; i++)
            {
                Case tempC;
                if (i == 0 && !IsOn8(map.IndexOf(c)) &&
                    !isInEchec(c.Piece.IsWhite,map.ElementAt(map.IndexOf(c) - 8),map) &&
                    (map.ElementAt(map.IndexOf(c) - 8).Piece == null ||
                     c.Piece.IsWhite != map.ElementAt(map.IndexOf(c) - 8).Piece.IsWhite && !(map.ElementAt(map.IndexOf(c) - 8).Piece is King)))
                {
                    tempC = map.ElementAt(map.IndexOf(c) - 8);
                    tempC.AvailableCase = true;
                    AvailableCases.Add(tempC);
                }
                else if (i == 1 && !IsOn8(map.IndexOf(c)) && !IsOnH(map.IndexOf(c)) &&
                         !isInEchec(c.Piece.IsWhite, map.ElementAt(map.IndexOf(c) - 7), map) &&
                         (map.ElementAt(map.IndexOf(c) - 7).Piece == null ||
                          c.Piece.IsWhite != map.ElementAt(map.IndexOf(c) - 7).Piece.IsWhite && !(map.ElementAt(map.IndexOf(c) - 7).Piece is King)))
                {
                    tempC = map.ElementAt(map.IndexOf(c) - 7);
                    tempC.AvailableCase = true;
                    AvailableCases.Add(tempC);
                }
                else if (i == 2 && !IsOn8(map.IndexOf(c)) && !IsOnA(map.IndexOf(c)) &&
                         !isInEchec(c.Piece.IsWhite, map.ElementAt(map.IndexOf(c) - 9), map) &&
                         (map.ElementAt(map.IndexOf(c) - 9).Piece == null ||
                          c.Piece.IsWhite != map.ElementAt(map.IndexOf(c) - 9).Piece.IsWhite && !(map.ElementAt(map.IndexOf(c) - 9).Piece is King)))
                {
                    tempC = map.ElementAt(map.IndexOf(c) - 9);
                    tempC.AvailableCase = true;
                    AvailableCases.Add(tempC);
                }
                else if (i == 3 && !IsOnA(map.IndexOf(c)) &&
                         !isInEchec(c.Piece.IsWhite, map.ElementAt(map.IndexOf(c) - 1), map) &&
                         (map.ElementAt(map.IndexOf(c) - 1).Piece == null ||
                          c.Piece.IsWhite != map.ElementAt(map.IndexOf(c) - 1).Piece.IsWhite && !(map.ElementAt(map.IndexOf(c) - 1).Piece is King)))
                {
                    tempC = map.ElementAt(map.IndexOf(c) - 1);
                    tempC.AvailableCase = true;
                    AvailableCases.Add(tempC);
                }
                else if (i == 4 && !IsOnH(map.IndexOf(c)) &&
                         !isInEchec(c.Piece.IsWhite, map.ElementAt(map.IndexOf(c) + 1), map) &&
                         (map.ElementAt(map.IndexOf(c) + 1).Piece == null ||
                          c.Piece.IsWhite != map.ElementAt(map.IndexOf(c) + 1).Piece.IsWhite && !(map.ElementAt(map.IndexOf(c) + 1).Piece is King)))
                {
                    tempC = map.ElementAt(map.IndexOf(c) + 1);
                    tempC.AvailableCase = true;
                    AvailableCases.Add(tempC);
                }
                else if (i == 5 && !IsOn1(map.IndexOf(c)) &&
                         !isInEchec(c.Piece.IsWhite, map.ElementAt(map.IndexOf(c) + 8), map) &&
                         (map.ElementAt(map.IndexOf(c) + 8).Piece == null ||
                          c.Piece.IsWhite != map.ElementAt(map.IndexOf(c) + 8).Piece.IsWhite && !(map.ElementAt(map.IndexOf(c) + 8).Piece is King)))
                {
                    tempC = map.ElementAt(map.IndexOf(c) + 8);
                    tempC.AvailableCase = true;
                    AvailableCases.Add(tempC);
                }
                else if (i == 6 && !IsOnA(map.IndexOf(c)) && !IsOn1(map.IndexOf(c)) &&
                         !isInEchec(c.Piece.IsWhite, map.ElementAt(map.IndexOf(c) + 7), map) &&
                         (map.ElementAt(map.IndexOf(c) + 7).Piece == null ||
                          c.Piece.IsWhite != map.ElementAt(map.IndexOf(c) + 7).Piece.IsWhite && !(map.ElementAt(map.IndexOf(c) + 7).Piece is King)))
                {
                    tempC = map.ElementAt(map.IndexOf(c) + 7);
                    tempC.AvailableCase = true;
                    AvailableCases.Add(tempC);
                }
                else if (i == 7 && !IsOnH(map.IndexOf(c)) && !IsOn1(map.IndexOf(c)) &&
                         !isInEchec(c.Piece.IsWhite, map.ElementAt(map.IndexOf(c) + 9), map) &&
                         (map.ElementAt(map.IndexOf(c) + 9).Piece == null ||
                          c.Piece.IsWhite != map.ElementAt(map.IndexOf(c) + 9).Piece.IsWhite && !(map.ElementAt(map.IndexOf(c) + 9).Piece is King)))
                {
                    tempC = map.ElementAt(map.IndexOf(c) + 9);
                    tempC.AvailableCase = true;
                    AvailableCases.Add(tempC);
                }
            }


            if (firstEntry)
            {
                MoveOnlyIfNotEchec(c, map, whiteEchec, blackEchec);
            }
        }

    }
}