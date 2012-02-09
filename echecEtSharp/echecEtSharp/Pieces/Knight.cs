using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace echecEtSharp.Pieces
{
    internal class Knight : Piece
    {
        public Knight(Texture2D tex, Boolean isWhite, Boolean canJump)
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
            for (int i = 1; i <= 8; i++)
            {
                Case tempC;

                if ((i == 1 && map.IndexOf(c) - 17 >= 0 && map.IndexOf(c) - 17 < 64) && !isOnA(map.IndexOf(c)))
                {
                    tempC = map.ElementAt(map.IndexOf(c) - 17);
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
                else if ((i == 2 && map.IndexOf(c) - 15 >= 0 && map.IndexOf(c) - 15 < 64) && !isOnH(map.IndexOf(c)))
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
                else if ((i == 3 && map.IndexOf(c) - 10 >= 0 && map.IndexOf(c) - 10 < 64) && !isOnA(map.IndexOf(c)) &&
                         !isOnB(map.IndexOf(c)))
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
                else if ((i == 4 && map.IndexOf(c) - 6 >= 0 && map.IndexOf(c) - 6 < 64) && !isOnG(map.IndexOf(c)) &&
                         !isOnH(map.IndexOf(c)))
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
                         !isOnA(map.IndexOf(c)))
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
                         !isOnH(map.IndexOf(c)))
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
                         !isOnA(map.IndexOf(c)) && !isOnB(map.IndexOf(c)))
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
                         !isOnG(map.IndexOf(c)) && !isOnH(map.IndexOf(c)))
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
        }

        private bool isOnA(int index)
        {
            int j = 1;
            for (int i = 0; i < 8; i++)
            {
                if (index == j - 1)
                {
                    return true;
                }
                j = j + 8;
            }
            return false;
        }

        private bool isOnB(int index)
        {
            int j = 2;
            for (int i = 0; i < 8; i++)
            {
                if (index == j - 1)
                {
                    return true;
                }
                j = j + 8;
            }
            return false;
        }

        private bool isOnG(int index)
        {
            int j = 7;
            for (int i = 0; i < 8; i++)
            {
                if (index == j - 1)
                {
                    return true;
                }
                j = j + 8;
            }
            return false;
        }

        private bool isOnH(int index)
        {
            int j = 8;
            for (int i = 0; i < 8; i++)
            {
                if (index == j - 1)
                {
                    return true;
                }
                j = j + 8;
            }
            return false;
        }
    }
}