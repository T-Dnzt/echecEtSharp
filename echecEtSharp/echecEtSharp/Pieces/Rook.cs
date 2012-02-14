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
            if (c.Piece.IsWhite && isOnA(map.IndexOf(c)) && c.Piece.NumberOfMouvs == 0 && map.ElementAt(60).Piece != null &&
                map.ElementAt(60).Piece is King && map.ElementAt(60).Piece.NumberOfMouvs == 0 &&
                !isInEchec(true, map.ElementAt(60), map) && !isInEchec(true, map.ElementAt(58), map) && map.ElementAt(59).Piece == null && map.ElementAt(58).Piece == null && map.ElementAt(57).Piece == null)
            {
                //grand roque blanc
                IsBigRockPossible = true;
            }
            else if (c.Piece.IsWhite && isOnH(map.IndexOf(c)) && c.Piece.NumberOfMouvs == 0 && map.ElementAt(60).Piece != null &&
                     map.ElementAt(60).Piece is King && map.ElementAt(60).Piece.NumberOfMouvs == 0 &&
                     !isInEchec(true, map.ElementAt(60), map) && !isInEchec(true, map.ElementAt(62), map) && map.ElementAt(62).Piece == null && map.ElementAt(61).Piece == null)
            {
                //petit roque blanc
                IsLittleRockPossible = true;
            }
            else if (!c.Piece.IsWhite && isOnH(map.IndexOf(c)) && c.Piece.NumberOfMouvs == 0 && map.ElementAt(4).Piece != null &&
                     map.ElementAt(4).Piece is King && map.ElementAt(4).Piece.NumberOfMouvs == 0 &&
                     !isInEchec(false, map.ElementAt(4), map) && !isInEchec(false, map.ElementAt(6), map) && map.ElementAt(6).Piece == null && map.ElementAt(5).Piece == null)
            {
                //petit roque noir
                IsLittleRockPossible = true;
            }
            else if (!c.Piece.IsWhite && isOnA(map.IndexOf(c)) && c.Piece.NumberOfMouvs == 0 && map.ElementAt(4).Piece != null &&
                map.ElementAt(4).Piece is King && map.ElementAt(4).Piece.NumberOfMouvs == 0 &&
                !isInEchec(false, map.ElementAt(4), map) && !isInEchec(false, map.ElementAt(2), map) && map.ElementAt(3).Piece == null && map.ElementAt(2).Piece == null && map.ElementAt(1).Piece == null)
            {
                //grand roque noir
                IsBigRockPossible = true;
            }

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

                if ((i == 2) && !isOnA(map.IndexOf(c)))
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
                    }
                    else
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

        //Modifier cette méthode, créer une méthode générique dans Piece qui prend un paramètre dans chaque pièce
        public override List<Case> defineEchecCases(Boolean white, Case king, Case c, List<Case> map)
        {
            var echecCases = new List<Case>();
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
                            echecCases.Add(tempC);
                            if ((map.IndexOf(tempC) - 8) >= 0 && !(tempC.Piece != null && !tempC.Piece.IsWhite))
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) - 8);
                            }
                            else if (tempC.Piece is King && map.IndexOf(tempC) - 8 >= 0)
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
                            echecCases.Add(tempC);
                            if ((map.IndexOf(tempC) - 8) >= 0 && !(tempC.Piece != null && tempC.Piece.IsWhite))
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) - 8);
                            }
                            else if (tempC.Piece is King && map.IndexOf(tempC) - 8 >= 0)
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
                            echecCases.Add(tempC);
                            if ((map.IndexOf(tempC) + 8) < 64 && !(tempC.Piece != null && !tempC.Piece.IsWhite))
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) + 8);
                            }
                            else if (tempC.Piece is King && map.IndexOf(tempC) + 8 < 64)
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
                            echecCases.Add(tempC);
                            if ((map.IndexOf(tempC) + 8) < 64 && !(tempC.Piece != null && tempC.Piece.IsWhite))
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) + 8);
                            }
                            else if (tempC.Piece is King && map.IndexOf(tempC) + 8 < 64)
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) + 8);
                            }
                            else
                                break;
                        }
                    }
                }

                if ((i == 2) && !isOnA(map.IndexOf(c)))
                {
                    tempC = map.ElementAt(map.IndexOf(c) - 1);
                    if (IsWhite)
                    {
                        while (!isOnA(map.IndexOf(tempC) + 1) && (tempC.Piece == null || !tempC.Piece.IsWhite))
                        {
                            echecCases.Add(tempC);
                            if (map.IndexOf(tempC) - 1 >= 0 && !(tempC.Piece != null && !tempC.Piece.IsWhite))
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) - 1);
                            }
                            else if (tempC.Piece is King && map.IndexOf(tempC) - 1 >= 0)
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) - 1);
                            }
                            else
                                break;
                        }
                    }
                    else
                    {
                        while (!isOnA(map.IndexOf(tempC) + 1) && (tempC.Piece == null || tempC.Piece.IsWhite))
                        {
                            echecCases.Add(tempC);
                            if (map.IndexOf(tempC) - 1 >= 0 && !(tempC.Piece != null && tempC.Piece.IsWhite))
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) - 1);
                            }
                            else if (tempC.Piece is King && map.IndexOf(tempC) - 1 >= 0)
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
                            echecCases.Add(tempC);
                            if (map.IndexOf(tempC) + 1 < 64 && !(tempC.Piece != null && !tempC.Piece.IsWhite))
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) + 1);
                            }
                            else if (tempC.Piece is King && map.IndexOf(tempC) + 1 < 64)
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
                            echecCases.Add(tempC);
                            if (map.IndexOf(tempC) + 1 < 64 && !(tempC.Piece != null && tempC.Piece.IsWhite))
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) + 1);
                            }
                            else if (tempC.Piece is King && map.IndexOf(tempC) + 1 < 64)
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) + 1);
                            }
                            else
                                break;
                        }
                    }
                }
            }
            return echecCases;
        }
    }
}