using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace echecEtSharp.Pieces
{
    internal class Rook : Piece
    {
        public Rook(Texture2D tex, Boolean isWhite)
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
           /* if (c.Piece.IsWhite && IsOnA(map.IndexOf(c)) && c.Piece.NumberOfMoves == 0 &&
                map.ElementAt(60).Piece != null &&
                map.ElementAt(60).Piece is King && map.ElementAt(60).Piece.NumberOfMoves == 0 &&
                !isInEchec(true, map.ElementAt(60), map) && !isInEchec(true, map.ElementAt(58), map) &&
                map.ElementAt(59).Piece == null && map.ElementAt(58).Piece == null && map.ElementAt(57).Piece == null)
            {
                //grand roque blanc
                map.ElementAt(60).IsBigRockPossible = true;
            }
            else if (c.Piece.IsWhite && IsOnH(map.IndexOf(c)) && c.Piece.NumberOfMoves == 0 &&
                     map.ElementAt(60).Piece != null &&
                     map.ElementAt(60).Piece is King && map.ElementAt(60).Piece.NumberOfMoves == 0 &&
                     !isInEchec(true, map.ElementAt(60), map) && !isInEchec(true, map.ElementAt(62), map) &&
                     map.ElementAt(62).Piece == null && map.ElementAt(61).Piece == null)
            {
                //petit roque blanc
                map.ElementAt(60).IsLittleRockPossible = true;
            }
            else if (!c.Piece.IsWhite && IsOnH(map.IndexOf(c)) && c.Piece.NumberOfMoves == 0 &&
                     map.ElementAt(4).Piece != null &&
                     map.ElementAt(4).Piece is King && map.ElementAt(4).Piece.NumberOfMoves == 0 &&
                     !isInEchec(false, map.ElementAt(4), map) && !isInEchec(false, map.ElementAt(6), map) &&
                     map.ElementAt(6).Piece == null && map.ElementAt(5).Piece == null)
            {
                //petit roque noir
                map.ElementAt(4).IsLittleRockPossible = true;
            }
            else if (!c.Piece.IsWhite && IsOnA(map.IndexOf(c)) && c.Piece.NumberOfMoves == 0 &&
                     map.ElementAt(4).Piece != null &&
                     map.ElementAt(4).Piece is King && map.ElementAt(4).Piece.NumberOfMoves == 0 &&
                     !isInEchec(false, map.ElementAt(4), map) && !isInEchec(false, map.ElementAt(2), map) &&
                     map.ElementAt(3).Piece == null && map.ElementAt(2).Piece == null &&
                     map.ElementAt(1).Piece == null)
            {
                //grand roque noir
                map.ElementAt(4).IsBigRockPossible = true;
            }*/


            Boolean choc = false;
            for(int i = map.IndexOf(c) - 8; i >= 0; i -= 8)
            {
                if (authorizedMvm(c, i, map, false, false, true, false, false, true) && !choc)
                {
                    map.ElementAt(i).AvailableCase = true;
                    AvailableCases.Add(map.ElementAt(i));   
                }
                if (map.ElementAt(i).Piece != null)
                {
                    choc = true;
                }
            }
            choc = false;
            for (int i = map.IndexOf(c) + 8; i < 64; i += 8)
            {
                if (authorizedMvm(c, i, map, false, false, true, false, false, true) && !choc)
                {
                    map.ElementAt(i).AvailableCase = true;
                    AvailableCases.Add(map.ElementAt(i));
                }
                if (map.ElementAt(i).Piece != null)
                {
                    choc = true;
                }
            }
            choc = false;
            for (int i = map.IndexOf(c) - 1; i >= 0; i -= 1)
            {
                if (authorizedMvm(c, i, map, true, false, true, false, true, false) && !choc)
                {
                    map.ElementAt(i).AvailableCase = true;
                    AvailableCases.Add(map.ElementAt(i));
                }
                if (map.ElementAt(i).Piece != null)
                {
                    choc = true;
                }
            }
            choc = false;
            for (int i = map.IndexOf(c) + 1; i < 64; i += 1)
            {
                if (authorizedMvm(c, i, map, false, true, true, false, true, false) && !choc)
                {
                    map.ElementAt(i).AvailableCase = true;
                    AvailableCases.Add(map.ElementAt(i));
                }
                if (map.ElementAt(i).Piece != null)
                {
                    choc = true;
                }
            }

            if (firstEntry)
            {
                MoveOnlyIfNotEchec(c, map, whiteEchec, blackEchec);
            }
          
        }
    }
}