using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace echecEtSharp.Pieces
{
    internal class King : Piece
    {
        public King(Texture2D tex, Boolean isWhite, Boolean canJump)
            : base(tex, isWhite, canJump)
        {
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void undefineAvailableCases()
        {
            foreach (Case c in AvailableCases)
            {
                c.AvailableCase = false;
            }
            AvailableCases.Clear();
        }

        //Modifier cette méthode, créer une méthode générique dans Piece qui prend un paramètre dans chaque pièce
        public override void defineAvailableCases(Case c, List<Case> map)
        {
            for (int i = 0; i < 8; i++)
            {
                Case tempC;
                if (i == 0 && !isOn8(map.IndexOf(c)) &&
                    !isInEchec(c.Piece.IsWhite,map.ElementAt(map.IndexOf(c) - 8),map) &&
                    (map.ElementAt(map.IndexOf(c) - 8).Piece == null ||
                     c.Piece.IsWhite != map.ElementAt(map.IndexOf(c) - 8).Piece.IsWhite))
                {
                    tempC = map.ElementAt(map.IndexOf(c) - 8);
                    tempC.AvailableCase = true;
                    AvailableCases.Add(tempC);
                }
                else if (i == 1 && !isOn8(map.IndexOf(c)) && !isOnH(map.IndexOf(c)) &&
                         !isInEchec(c.Piece.IsWhite, map.ElementAt(map.IndexOf(c) - 7), map) &&
                         (map.ElementAt(map.IndexOf(c) - 7).Piece == null ||
                          c.Piece.IsWhite != map.ElementAt(map.IndexOf(c) - 7).Piece.IsWhite))
                {
                    tempC = map.ElementAt(map.IndexOf(c) - 7);
                    tempC.AvailableCase = true;
                    AvailableCases.Add(tempC);
                }
                else if (i == 2 && !isOn8(map.IndexOf(c)) && !isOnA(map.IndexOf(c)) &&
                         !isInEchec(c.Piece.IsWhite, map.ElementAt(map.IndexOf(c) - 9), map) &&
                         (map.ElementAt(map.IndexOf(c) - 9).Piece == null ||
                          c.Piece.IsWhite != map.ElementAt(map.IndexOf(c) - 9).Piece.IsWhite))
                {
                    tempC = map.ElementAt(map.IndexOf(c) - 9);
                    tempC.AvailableCase = true;
                    AvailableCases.Add(tempC);
                }
                else if (i == 3 && !isOnA(map.IndexOf(c)) &&
                         !isInEchec(c.Piece.IsWhite, map.ElementAt(map.IndexOf(c) - 1), map) &&
                         (map.ElementAt(map.IndexOf(c) - 1).Piece == null ||
                          c.Piece.IsWhite != map.ElementAt(map.IndexOf(c) - 1).Piece.IsWhite))
                {
                    tempC = map.ElementAt(map.IndexOf(c) - 1);
                    tempC.AvailableCase = true;
                    AvailableCases.Add(tempC);
                }
                else if (i == 4 && !isOnH(map.IndexOf(c)) &&
                         !isInEchec(c.Piece.IsWhite, map.ElementAt(map.IndexOf(c) + 1), map) &&
                         (map.ElementAt(map.IndexOf(c) + 1).Piece == null ||
                          c.Piece.IsWhite != map.ElementAt(map.IndexOf(c) + 1).Piece.IsWhite))
                {
                    tempC = map.ElementAt(map.IndexOf(c) + 1);
                    tempC.AvailableCase = true;
                    AvailableCases.Add(tempC);
                }
                else if (i == 5 && !isOn1(map.IndexOf(c)) &&
                         !isInEchec(c.Piece.IsWhite, map.ElementAt(map.IndexOf(c) + 8), map) &&
                         (map.ElementAt(map.IndexOf(c) + 8).Piece == null ||
                          c.Piece.IsWhite != map.ElementAt(map.IndexOf(c) + 8).Piece.IsWhite))
                {
                    tempC = map.ElementAt(map.IndexOf(c) + 8);
                    tempC.AvailableCase = true;
                    AvailableCases.Add(tempC);
                }
                else if (i == 6 && !isOnA(map.IndexOf(c)) && !isOn1(map.IndexOf(c)) &&
                         !isInEchec(c.Piece.IsWhite, map.ElementAt(map.IndexOf(c) + 7), map) &&
                         (map.ElementAt(map.IndexOf(c) + 7).Piece == null ||
                          c.Piece.IsWhite != map.ElementAt(map.IndexOf(c) + 7).Piece.IsWhite))
                {
                    tempC = map.ElementAt(map.IndexOf(c) + 7);
                    tempC.AvailableCase = true;
                    AvailableCases.Add(tempC);
                }
                else if (i == 7 && !isOnH(map.IndexOf(c)) && !isOn1(map.IndexOf(c)) &&
                         !isInEchec(c.Piece.IsWhite, map.ElementAt(map.IndexOf(c) + 9), map) &&
                         (map.ElementAt(map.IndexOf(c) + 9).Piece == null ||
                          c.Piece.IsWhite != map.ElementAt(map.IndexOf(c) + 9).Piece.IsWhite))
                {
                    tempC = map.ElementAt(map.IndexOf(c) + 9);
                    tempC.AvailableCase = true;
                    AvailableCases.Add(tempC);
                }
            }
        }

        //Modifier cette méthode, créer une méthode générique dans Piece qui prend un paramètre dans chaque pièce
        public override List<Case> defineEchecCases(Boolean white, Case king, Case c, List<Case> map)
        {
            var echecCases = new List<Case>();
            return echecCases;
        }
    }
}