using System;
using System.Collections.Generic;
using System.Linq;
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

        public override void DefineAvailableCases(Case c, List<Case> map, bool whiteEchec, bool blackEchec,
                                                  bool firstEntry)
        {
            if (IsWhite)
            {
                if(authorizedMvm(c,map.IndexOf(c) - 8,map,false, false, false, false,false,true))
                {
                    map.ElementAt(map.IndexOf(c) - 8).AvailableCase = true;
                    AvailableCases.Add(map.ElementAt(map.IndexOf(c) - 8));
                }
                if (c.Piece.NumberOfMoves == 0 && authorizedMvm(c, map.IndexOf(c) - 16, map, false, false, false, false, false, true))
                {
                    if(map.ElementAt(map.IndexOf(c) -8).Piece == null)
                    {
                        map.ElementAt(map.IndexOf(c) - 16).AvailableCase = true;
                        AvailableCases.Add(map.ElementAt(map.IndexOf(c) - 16));
                    }
                }
                if (authorizedMvm(c, map.IndexOf(c) - 7, map,false,true,true,true,false,false))
                {
                    map.ElementAt(map.IndexOf(c) - 7).AvailableCase = true;
                    AvailableCases.Add(map.ElementAt(map.IndexOf(c) - 7));
                }
                if (authorizedMvm(c, map.IndexOf(c) - 9, map, true, false, true, true, false, false))
                {
                    map.ElementAt(map.IndexOf(c) - 9).AvailableCase = true;
                    AvailableCases.Add(map.ElementAt(map.IndexOf(c) - 9));
                }
            }
            else
            {
                if (authorizedMvm(c, map.IndexOf(c) + 8, map, false, false, false, false, false, true))
                {
                    map.ElementAt(map.IndexOf(c) + 8).AvailableCase = true;
                    AvailableCases.Add(map.ElementAt(map.IndexOf(c) + 8));
                }
                if (c.Piece.NumberOfMoves == 0 && authorizedMvm(c, map.IndexOf(c) + 16, map, false, false, false, false, false, true))
                {
                    if (map.ElementAt(map.IndexOf(c) +8).Piece == null)
                    {
                        map.ElementAt(map.IndexOf(c) + 16).AvailableCase = true;
                        AvailableCases.Add(map.ElementAt(map.IndexOf(c) + 16));
                    }
                }
                if (authorizedMvm(c, map.IndexOf(c) + 9, map, false, true, true, true, false, false))
                {
                    map.ElementAt(map.IndexOf(c) + 9).AvailableCase = true;
                    AvailableCases.Add(map.ElementAt(map.IndexOf(c) + 9));
                }
                if (authorizedMvm(c, map.IndexOf(c) + 7, map, true, false, true, true, false, false))
                {
                    map.ElementAt(map.IndexOf(c) + 7).AvailableCase = true;
                    AvailableCases.Add(map.ElementAt(map.IndexOf(c) + 7));
                }
            }

            if (firstEntry)
            {
                MoveOnlyIfNotEchec(c, map, whiteEchec, blackEchec);
            }
        }
    }
}