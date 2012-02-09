using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace echecEtSharp.Pieces
{
    internal class Rook : Piece
    {
        public Rook(Texture2D tex, Boolean isWhite, Boolean canJump)
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
            for (int i = 0; i < 4; i++)
            {
                Case tempC;
                if ((i == 0) && map.IndexOf(c) - 8 >= 0)
                {
                    tempC = map.ElementAt(map.IndexOf(c) - 8);
                    if (IsWhite)
                    {
                        while (tempC.Piece == null || !tempC.Piece.IsWhite)
                        {
                            tempC.AvailableCase = true;
                            AvailableCases.Add(tempC);
                            if ((map.IndexOf(tempC) - 8) >= 0 && !(tempC.Piece != null && !tempC.Piece.IsWhite))
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) - 8);
                            }
                            else
                                break;
                        }
                    }
                    else
                    {
                        while (tempC.Piece == null || tempC.Piece.IsWhite)
                        {
                            tempC.AvailableCase = true;
                            AvailableCases.Add(tempC);
                            if ((map.IndexOf(tempC) - 8) >= 0 && !(tempC.Piece != null && tempC.Piece.IsWhite))
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) - 8);
                            }
                            else
                                break;
                        }
                    }
                }

                if ((i == 1) && map.IndexOf(c) + 8 < 64)
                {
                    tempC = map.ElementAt(map.IndexOf(c) + 8);  
                    if (IsWhite)
                    {
                        while (tempC.Piece == null || !tempC.Piece.IsWhite)
                        {
                            tempC.AvailableCase = true;
                            AvailableCases.Add(tempC);
                            if ((map.IndexOf(tempC) + 8) < 64 && !(tempC.Piece != null && !tempC.Piece.IsWhite))
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) + 8);
                            }
                            else
                                break;
                        }
                    }
                    else
                    {
                        while (tempC.Piece == null || tempC.Piece.IsWhite)
                        {
                            tempC.AvailableCase = true;
                            AvailableCases.Add(tempC);
                            if ((map.IndexOf(tempC) + 8) < 64 && !(tempC.Piece != null && tempC.Piece.IsWhite))
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) + 8);
                            }
                            else
                                break;
                        }
                    }
                }

                if((i == 2) && !isOnA(map.IndexOf(c)))
                {
                    tempC = map.ElementAt(map.IndexOf(c) - 1);
                    if (IsWhite)
                    {
                        while (!isOnA(map.IndexOf(tempC) + 1) && (tempC.Piece == null || !tempC.Piece.IsWhite))
                        {
                            tempC.AvailableCase = true;
                            AvailableCases.Add(tempC);
                            if (map.IndexOf(tempC) - 1 >= 0 && !(tempC.Piece != null && !tempC.Piece.IsWhite))
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) - 1);
                            }
                            else
                                break;
                        }
                    }else
                    {
                        while (!isOnA(map.IndexOf(tempC) + 1) && (tempC.Piece == null || tempC.Piece.IsWhite))
                        {
                            tempC.AvailableCase = true;
                            AvailableCases.Add(tempC);
                            if (map.IndexOf(tempC) - 1 >= 0 && !(tempC.Piece != null && tempC.Piece.IsWhite))
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) - 1);
                            }
                            else
                                break;
                        }
                    }
                }

                if ((i == 3) && !isOnH(map.IndexOf(c)))
                {
                    tempC = map.ElementAt(map.IndexOf(c) + 1);
                    if (IsWhite)
                    {
                        while (!isOnH(map.IndexOf(tempC) - 1) && (tempC.Piece == null || !tempC.Piece.IsWhite))
                        {
                            tempC.AvailableCase = true;
                            AvailableCases.Add(tempC);
                            if (map.IndexOf(tempC) + 1 < 64 && !(tempC.Piece != null && !tempC.Piece.IsWhite))
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) + 1);
                            }
                            else
                                break;
                        }
                    }
                    else
                    {
                        while (!isOnH(map.IndexOf(tempC) - 1) && (tempC.Piece == null || tempC.Piece.IsWhite))
                        {
                            tempC.AvailableCase = true;
                            AvailableCases.Add(tempC);
                            if (map.IndexOf(tempC) + 1 < 64 && !(tempC.Piece != null && tempC.Piece.IsWhite))
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) + 1);
                            }
                            else
                                break;
                        }
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