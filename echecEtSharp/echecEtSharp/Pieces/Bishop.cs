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
            Boolean choc = false;
            for (int i = map.IndexOf(c) - 7; i >= 0; i -= 7)
            {
                if (authorizedMvm(c, i, map, false, true, true, false, false, false) && !choc)
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
            for (int i = map.IndexOf(c) + 7; i < 64; i += 7)
            {
                if (authorizedMvm(c, i, map, true, false, true, false, false, false) && !choc)
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
            for (int i = map.IndexOf(c) + 9; i < 64; i += 9)
            {
                if (authorizedMvm(c, i, map, false, true, true, false, false, false) && !choc)
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
            for (int i = map.IndexOf(c) - 9; i >= 0; i -= 9)
            {
                if (authorizedMvm(c, i, map, true, false, true, false, false, false) && !choc)
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