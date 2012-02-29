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

            if (authorizedMvm(c, map.IndexOf(c) - 8, map, false, false, false, false, false, true))
            {
                map.ElementAt(map.IndexOf(c) - 8).AvailableCase = true;
                AvailableCases.Add(map.ElementAt(map.IndexOf(c) - 8));
            }
            if (authorizedMvm(c, map.IndexOf(c) - 7, map, false, true, false, false, false, false))
            {
                map.ElementAt(map.IndexOf(c) - 7).AvailableCase = true;
                AvailableCases.Add(map.ElementAt(map.IndexOf(c) - 7));
            }
            if (authorizedMvm(c, map.IndexOf(c) - 9, map, true, false, false, false, false, false))
            {
                map.ElementAt(map.IndexOf(c) - 9).AvailableCase = true;
                AvailableCases.Add(map.ElementAt(map.IndexOf(c) - 9));
            }
            if (authorizedMvm(c, map.IndexOf(c) + 8, map, false, false, false, false, false, true))
            {
                map.ElementAt(map.IndexOf(c) + 8).AvailableCase = true;
                AvailableCases.Add(map.ElementAt(map.IndexOf(c) + 8));
            }
            if (authorizedMvm(c, map.IndexOf(c) + 7, map, true, false, false, false, false, false))
            {
                map.ElementAt(map.IndexOf(c) + 7).AvailableCase = true;
                AvailableCases.Add(map.ElementAt(map.IndexOf(c) + 7));
            }
            if (authorizedMvm(c, map.IndexOf(c) + 9, map, false, true, false, false, false, false))
            {
                map.ElementAt(map.IndexOf(c) + 9).AvailableCase = true;
                AvailableCases.Add(map.ElementAt(map.IndexOf(c) + 9));
            }
            if (authorizedMvm(c, map.IndexOf(c) + 1, map, false, true, false, false, true, false))
            {
                map.ElementAt(map.IndexOf(c) + 1).AvailableCase = true;
                AvailableCases.Add(map.ElementAt(map.IndexOf(c) + 1));
            }
            if (authorizedMvm(c, map.IndexOf(c) - 1, map, true, false, false, false, true, false))
            {
                map.ElementAt(map.IndexOf(c) - 1).AvailableCase = true;
                AvailableCases.Add(map.ElementAt(map.IndexOf(c) - 1));
            }


            if (firstEntry)
            {
                MoveOnlyIfNotEchec(c, map, whiteEchec, blackEchec);
            }
        }

    }
}