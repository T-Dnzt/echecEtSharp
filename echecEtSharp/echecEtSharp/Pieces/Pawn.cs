using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace echecEtSharp.Pieces
{
    internal class Pawn : Piece
    {
        public Pawn(Texture2D tex, Boolean isWhite, Boolean canJump)
            : base(tex, isWhite, canJump)
        {
            moveTypes = new Dictionary<string, int[]>();

            moveTypes.Add("once", new[] {0, 1});
            moveTypes.Add("attack", new[] {1, 1});
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
            if (IsWhite)
            {
                //Vérifier si c'est le premier tour pour le mouvement du pion
                if (isOn8(map.IndexOf(c)))
                {
                    //DEVIENT UNE REEIIIIINE
                }
                else
                {
                    for (int i = 0; i < 3; i++)
                    {
                        Case tempC;
                        if (i == 0 && map.ElementAt(map.IndexOf(c) - 8).Piece == null)
                        {
                            tempC = map.ElementAt(map.IndexOf(c) - 8);
                            tempC.AvailableCase = true;
                            AvailableCases.Add(tempC);
                            if (isOn2(map.IndexOf(c)) && map.ElementAt(map.IndexOf(tempC) - 8).Piece == null)
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) - 8);
                                tempC.AvailableCase = true;
                                AvailableCases.Add(tempC);
                            }
                        }
                        else if (i == 1 && !isOnH(map.IndexOf(c)) && map.ElementAt(map.IndexOf(c) - 7).Piece != null &&
                                 !map.ElementAt(map.IndexOf(c) - 7).Piece.IsWhite)
                        {
                            tempC = map.ElementAt(map.IndexOf(c) - 7);
                            tempC.AvailableCase = true;
                            AvailableCases.Add(tempC);
                        }
                        else if (i == 2 && !isOnA(map.IndexOf(c)) && map.ElementAt(map.IndexOf(c) - 9).Piece != null &&
                                 !map.ElementAt(map.IndexOf(c) - 9).Piece.IsWhite)
                        {
                            tempC = map.ElementAt(map.IndexOf(c) - 9);
                            tempC.AvailableCase = true;
                            AvailableCases.Add(tempC);
                        }
                    }
                }
            }
            else
            {
                //Vérifier si c'est le premier tour pour le mouvement du pion
                if (isOn1(map.IndexOf(c)))
                {
                    //DEVIENT UNE REEIIIIINE
                }
                else
                {
                    for (int i = 0; i < 3; i++)
                    {
                        Case tempC;
                        if (i == 0 && map.ElementAt(map.IndexOf(c) + 8).Piece == null)
                        {
                            tempC = map.ElementAt(map.IndexOf(c) + 8);
                            tempC.AvailableCase = true;
                            AvailableCases.Add(tempC);
                            if (isOn6(map.IndexOf(c)) && map.ElementAt(map.IndexOf(tempC) + 8).Piece == null)
                            {
                                tempC = map.ElementAt(map.IndexOf(tempC) + 8);
                                tempC.AvailableCase = true;
                                AvailableCases.Add(tempC);
                            }
                        }
                        else if (i == 1 && map.ElementAt(map.IndexOf(c) + 7).Piece != null && !isOnA(map.IndexOf(c)) &&
                                 map.ElementAt(map.IndexOf(c) + 7).Piece.IsWhite)
                        {
                            tempC = map.ElementAt(map.IndexOf(c) + 7);
                            tempC.AvailableCase = true;
                            AvailableCases.Add(tempC);
                        }
                        else if (i == 2 && map.ElementAt(map.IndexOf(c) + 9).Piece != null && !isOnH(map.IndexOf(c)) &&
                                 map.ElementAt(map.IndexOf(c) + 9).Piece.IsWhite)
                        {
                            tempC = map.ElementAt(map.IndexOf(c) + 9);
                            tempC.AvailableCase = true;
                            AvailableCases.Add(tempC);
                        }
                    }
                }
            }
        }

        //Modifier cette méthode, créer une méthode générique dans Piece qui prend un paramètre dans chaque pièce
        public override List<Case> defineEchecCases(Case king, Case c, List<Case> map)
        {
            var echecCases = new List<Case>();
            if (king.Piece.IsWhite)
            {
                if (map.IndexOf(c) + 7 < 64 && !isOnA(map.IndexOf(c)))
                {
                    echecCases.Add(map.ElementAt(map.IndexOf(c) + 7));
                }
                if (map.IndexOf(c) + 9 < 64 && !isOnH(map.IndexOf(c)))
                {
                    echecCases.Add(map.ElementAt(map.IndexOf(c) + 9));
                }
            }
            else
            {
                if (map.IndexOf(c) - 7 >= 0 && !isOnH(map.IndexOf(c)))
                {
                    echecCases.Add(map.ElementAt(map.IndexOf(c) - 7));
                }
                if (map.IndexOf(c) - 9 >= 0 && !isOnA(map.IndexOf(c)))
                {
                    echecCases.Add(map.ElementAt(map.IndexOf(c) - 9));
                }
            }
            return echecCases;
        }
    }
}