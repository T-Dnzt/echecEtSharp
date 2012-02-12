﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace echecEtSharp.Pieces
{
    internal class Queen : Piece
    {
        public Queen(Texture2D tex, Boolean isWhite, Boolean canJump)
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

                if (IsWhite)
                {
                    if ((i == 4) && !isOnH(map.IndexOf(c)) && !isOn8(map.IndexOf(c)) && map.IndexOf(c) - 7 >= 0)
                    {
                        tempC = map.ElementAt(map.IndexOf(c) - 7);

                        while (tempC.Piece == null || !tempC.Piece.IsWhite)
                        {
                            tempC.AvailableCase = true;
                            AvailableCases.Add(tempC);
                            if ((map.IndexOf(tempC) - 7) >= 0 && !(tempC.Piece != null && !tempC.Piece.IsWhite) &&
                                !isOnH(map.IndexOf(tempC)))
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) - 7);
                            }
                            else
                                break;
                        }
                    }
                }
                else
                {
                    if ((i == 4) && !isOnH(map.IndexOf(c)) && !isOn8(map.IndexOf(c)) && map.IndexOf(c) - 7 >= 0)
                    {
                        tempC = map.ElementAt(map.IndexOf(c) - 7);

                        while (tempC.Piece == null || tempC.Piece.IsWhite)
                        {
                            tempC.AvailableCase = true;
                            AvailableCases.Add(tempC);
                            if ((map.IndexOf(tempC) - 7) >= 0 && !(tempC.Piece != null && tempC.Piece.IsWhite) &&
                                !isOnH(map.IndexOf(tempC)))
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) - 7);
                            }
                            else
                                break;
                        }
                    }
                }


                if (IsWhite)
                {
                    if ((i == 5) && !isOnA(map.IndexOf(c)) && !isOn1(map.IndexOf(c)) && map.IndexOf(c) + 7 < 64)
                    {
                        tempC = map.ElementAt(map.IndexOf(c) + 7);
                        while (tempC.Piece == null || !tempC.Piece.IsWhite)
                        {
                            tempC.AvailableCase = true;
                            AvailableCases.Add(tempC);
                            if ((map.IndexOf(tempC) + 7) < 64 && !(tempC.Piece != null && !tempC.Piece.IsWhite) &&
                                !isOnA(map.IndexOf(tempC)))
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) + 7);
                            }
                            else
                                break;
                        }
                    }
                }
                else
                {
                    if ((i == 5) && !isOnA(map.IndexOf(c)) && !isOn1(map.IndexOf(c)) && map.IndexOf(c) + 7 < 64)
                    {
                        tempC = map.ElementAt(map.IndexOf(c) + 7);
                        while (tempC.Piece == null || tempC.Piece.IsWhite)
                        {
                            tempC.AvailableCase = true;
                            AvailableCases.Add(tempC);
                            if ((map.IndexOf(tempC) + 7) < 64 && !(tempC.Piece != null && tempC.Piece.IsWhite) &&
                                !isOnA(map.IndexOf(tempC)))
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) + 7);
                            }
                            else
                                break;
                        }
                    }
                }


                if (IsWhite)
                {
                    if ((i == 6) && !isOnA(map.IndexOf(c)) && !isOn8(map.IndexOf(c)) && map.IndexOf(c) - 9 >= 0)
                    {
                        tempC = map.ElementAt(map.IndexOf(c) - 9);

                        while (tempC.Piece == null || !tempC.Piece.IsWhite)
                        {
                            tempC.AvailableCase = true;
                            AvailableCases.Add(tempC);
                            if ((map.IndexOf(tempC) - 9) >= 0 && !(tempC.Piece != null && !tempC.Piece.IsWhite) &&
                                !isOnA(map.IndexOf(tempC)))
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) - 9);
                            }
                            else
                                break;
                        }
                    }
                }
                else
                {
                    if ((i == 6) && !isOnA(map.IndexOf(c)) && !isOn8(map.IndexOf(c)) && map.IndexOf(c) - 9 >= 0)
                    {
                        tempC = map.ElementAt(map.IndexOf(c) - 9);

                        while (tempC.Piece == null || tempC.Piece.IsWhite)
                        {
                            tempC.AvailableCase = true;
                            AvailableCases.Add(tempC);
                            if ((map.IndexOf(tempC) - 9) >= 0 && !(tempC.Piece != null && tempC.Piece.IsWhite) &&
                                !isOnA(map.IndexOf(tempC)))
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) - 9);
                            }
                            else
                                break;
                        }
                    }
                }


                if (IsWhite)
                {
                    if ((i == 7) && !isOnH(map.IndexOf(c)) && !isOn1(map.IndexOf(c)) && map.IndexOf(c) + 9 < 64)
                    {
                        tempC = map.ElementAt(map.IndexOf(c) + 9);
                        while (tempC.Piece == null || !tempC.Piece.IsWhite)
                        {
                            tempC.AvailableCase = true;
                            AvailableCases.Add(tempC);
                            if ((map.IndexOf(tempC) + 9) < 64 && !(tempC.Piece != null && !tempC.Piece.IsWhite) &&
                                !isOnH(map.IndexOf(tempC)))
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) + 9);
                            }
                            else
                                break;
                        }
                    }
                }
                else
                {
                    if ((i == 7) && !isOnH(map.IndexOf(c)) && !isOn1(map.IndexOf(c)) && map.IndexOf(c) + 9 < 64)
                    {
                        tempC = map.ElementAt(map.IndexOf(c) + 9);
                        while (tempC.Piece == null || tempC.Piece.IsWhite)
                        {
                            tempC.AvailableCase = true;
                            AvailableCases.Add(tempC);
                            if ((map.IndexOf(tempC) + 9) < 64 && !(tempC.Piece != null && tempC.Piece.IsWhite) &&
                                !isOnH(map.IndexOf(tempC)))
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) + 9);
                            }
                            else
                                break;
                        }
                    }
                }
            }
        }

        //Modifier cette méthode, créer une méthode générique dans Piece qui prend un paramètre dans chaque pièce
        public override List<Case> defineEchecCases(Case king, Case c, List<Case> map)
        {
            var echecCases = new List<Case>();
            for (int i = 0; i < 8; i++)
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

                if (IsWhite)
                {
                    if ((i == 4) && !isOnH(map.IndexOf(c)) && !isOn8(map.IndexOf(c)) && map.IndexOf(c) - 7 >= 0)
                    {
                        tempC = map.ElementAt(map.IndexOf(c) - 7);

                        while (tempC.Piece == null || !tempC.Piece.IsWhite)
                        {
                            echecCases.Add(tempC);
                            if ((map.IndexOf(tempC) - 7) >= 0 && !(tempC.Piece != null && !tempC.Piece.IsWhite) &&
                                !isOnH(map.IndexOf(tempC)))
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) - 7);
                            }
                            else if (tempC.Piece is King && map.IndexOf(tempC) - 7 >= 0)
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) - 7);
                            }
                            else
                                break;
                        }
                    }
                }
                else
                {
                    if ((i == 4) && !isOnH(map.IndexOf(c)) && !isOn8(map.IndexOf(c)) && map.IndexOf(c) - 7 >= 0)
                    {
                        tempC = map.ElementAt(map.IndexOf(c) - 7);

                        while (tempC.Piece == null || tempC.Piece.IsWhite)
                        {
                            echecCases.Add(tempC);
                            if ((map.IndexOf(tempC) - 7) >= 0 && !(tempC.Piece != null && tempC.Piece.IsWhite) &&
                                !isOnH(map.IndexOf(tempC)))
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) - 7);
                            }
                            else if (tempC.Piece is King && map.IndexOf(tempC) - 7 >= 0)
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) - 7);
                            }
                            else
                                break;
                        }
                    }
                }


                if (IsWhite)
                {
                    if ((i == 5) && !isOnA(map.IndexOf(c)) && !isOn1(map.IndexOf(c)) && map.IndexOf(c) + 7 < 64)
                    {
                        tempC = map.ElementAt(map.IndexOf(c) + 7);
                        while (tempC.Piece == null || !tempC.Piece.IsWhite)
                        {
                            echecCases.Add(tempC);
                            if ((map.IndexOf(tempC) + 7) < 64 && !(tempC.Piece != null && !tempC.Piece.IsWhite) &&
                                !isOnA(map.IndexOf(tempC)))
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) + 7);
                            }
                            else if (tempC.Piece is King && map.IndexOf(tempC) + 7 < 64)
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) + 7);
                            }
                            else
                                break;
                        }
                    }
                }
                else
                {
                    if ((i == 5) && !isOnA(map.IndexOf(c)) && !isOn1(map.IndexOf(c)) && map.IndexOf(c) + 7 < 64)
                    {
                        tempC = map.ElementAt(map.IndexOf(c) + 7);
                        while (tempC.Piece == null || tempC.Piece.IsWhite)
                        {
                            echecCases.Add(tempC);
                            if ((map.IndexOf(tempC) + 7) < 64 && !(tempC.Piece != null && tempC.Piece.IsWhite) &&
                                !isOnA(map.IndexOf(tempC)))
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) + 7);
                            }
                            else if (tempC.Piece is King && map.IndexOf(tempC) + 7 < 64)
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) + 7);
                            }
                            else
                                break;
                        }
                    }
                }


                if (IsWhite)
                {
                    if ((i == 6) && !isOnA(map.IndexOf(c)) && !isOn8(map.IndexOf(c)) && map.IndexOf(c) - 9 >= 0)
                    {
                        tempC = map.ElementAt(map.IndexOf(c) - 9);

                        while (tempC.Piece == null || !tempC.Piece.IsWhite)
                        {
                            echecCases.Add(tempC);
                            if ((map.IndexOf(tempC) - 9) >= 0 && !(tempC.Piece != null && !tempC.Piece.IsWhite) &&
                                !isOnA(map.IndexOf(tempC)))
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) - 9);
                            }
                            else if (tempC.Piece is King && map.IndexOf(tempC) - 9 >= 0)
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) - 9);
                            }
                            else
                                break;
                        }
                    }
                }
                else
                {
                    if ((i == 6) && !isOnA(map.IndexOf(c)) && !isOn8(map.IndexOf(c)) && map.IndexOf(c) - 9 >= 0)
                    {
                        tempC = map.ElementAt(map.IndexOf(c) - 9);

                        while (tempC.Piece == null || tempC.Piece.IsWhite)
                        {
                            echecCases.Add(tempC);
                            if ((map.IndexOf(tempC) - 9) >= 0 && !(tempC.Piece != null && tempC.Piece.IsWhite) &&
                                !isOnA(map.IndexOf(tempC)))
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) - 9);
                            }
                            else if (tempC.Piece is King && map.IndexOf(tempC) - 9 >= 0)
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) - 9);
                            }
                            else
                                break;
                        }
                    }
                }


                if (IsWhite)
                {
                    if ((i == 7) && !isOnH(map.IndexOf(c)) && !isOn1(map.IndexOf(c)) && map.IndexOf(c) + 9 < 64)
                    {
                        tempC = map.ElementAt(map.IndexOf(c) + 9);
                        while (tempC.Piece == null || !tempC.Piece.IsWhite)
                        {
                            echecCases.Add(tempC);
                            if ((map.IndexOf(tempC) + 9) < 64 && !(tempC.Piece != null && !tempC.Piece.IsWhite) &&
                                !isOnH(map.IndexOf(tempC)))
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) + 9);
                            }
                            else if (tempC.Piece is King && map.IndexOf(tempC) + 9 < 64)
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) + 9);
                            }
                            else
                                break;
                        }
                    }
                }
                else
                {
                    if ((i == 7) && !isOnH(map.IndexOf(c)) && !isOn1(map.IndexOf(c)) && map.IndexOf(c) + 9 < 64)
                    {
                        tempC = map.ElementAt(map.IndexOf(c) + 9);
                        while (tempC.Piece == null || tempC.Piece.IsWhite)
                        {
                            echecCases.Add(tempC);
                            if ((map.IndexOf(tempC) + 9) < 64 && !(tempC.Piece != null && tempC.Piece.IsWhite) &&
                                !isOnH(map.IndexOf(tempC)))
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) + 9);
                            }
                            else if (tempC.Piece is King && map.IndexOf(tempC) + 9 < 64)
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) + 9);
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