using System;
using System.Collections.Generic;
using System.Linq;
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

        public override void DefineAvailableCases(Case c, List<Case> map, bool whiteEchec, bool blackEchec,
                                                  bool firstEntry)
        {
            if (authorizedMvm(c, map.IndexOf(c) - 17, map, true, false, true, false, false, false))
            {
                map.ElementAt(map.IndexOf(c) - 17).AvailableCase = true;
                AvailableCases.Add(map.ElementAt(map.IndexOf(c) - 17));
            }
            if (authorizedMvm(c, map.IndexOf(c) - 15, map, false, true, true, false, false, false))
            {
                map.ElementAt(map.IndexOf(c) - 15).AvailableCase = true;
                AvailableCases.Add(map.ElementAt(map.IndexOf(c) - 15));
            }
            if (authorizedMvm(c, map.IndexOf(c) - 10, map, true, false, true, false, false, false))
            {
                map.ElementAt(map.IndexOf(c) - 10).AvailableCase = true;
                AvailableCases.Add(map.ElementAt(map.IndexOf(c) - 10));
            }
            if (authorizedMvm(c, map.IndexOf(c) - 6, map, false, true, true, false, false, false))
            {
                map.ElementAt(map.IndexOf(c) - 6).AvailableCase = true;
                AvailableCases.Add(map.ElementAt(map.IndexOf(c) - 6));
            }

            if (authorizedMvm(c, map.IndexOf(c) + 17, map, false, true, true, false, false, false))
            {
                map.ElementAt(map.IndexOf(c) + 17).AvailableCase = true;
                AvailableCases.Add(map.ElementAt(map.IndexOf(c) + 17));
            }
            if (authorizedMvm(c, map.IndexOf(c) + 15, map, true, false, true, false, false, false))
            {
                map.ElementAt(map.IndexOf(c) + 15).AvailableCase = true;
                AvailableCases.Add(map.ElementAt(map.IndexOf(c) + 15));
            }
            if (authorizedMvm(c, map.IndexOf(c) + 10, map, false, true, true, false, false, false))
            {
                map.ElementAt(map.IndexOf(c) + 10).AvailableCase = true;
                AvailableCases.Add(map.ElementAt(map.IndexOf(c) + 10));
            }
            if (authorizedMvm(c, map.IndexOf(c) + 6, map, true, false, true, false, false, false))
            {
                map.ElementAt(map.IndexOf(c) + 6).AvailableCase = true;
                AvailableCases.Add(map.ElementAt(map.IndexOf(c) + 6));
            }
            if (firstEntry)
            {
                MoveOnlyIfNotEchec(c, map, whiteEchec, blackEchec);
            }
        }
    }
}