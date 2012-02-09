using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace echecEtSharp.Pieces
{
    class Pawn : Piece
    {
        public Pawn(Texture2D tex, Boolean isWhite, Boolean canJump)
            : base(tex, isWhite, canJump)
        {
            this.moveTypes = new Dictionary<string, int[]>();

            this.moveTypes.Add("once", new int[] { 0, 1 });
            this.moveTypes.Add("attack", new int[] { 1, 1 });
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }


        public override void undefineAvailableCases()
        {
            foreach (Case c in this.AvailableCases)
            {
                c.AvailableCase = false;
            }
            this.AvailableCases.Clear();
        }

        //Modifier cette méthode, créer une méthode générique dans Piece qui prend un paramètre dans chaque pièce
        public override void defineAvailableCases(Case c, List<Case> map)
        {
            if(IsWhite){
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
                        }
                        else if (i == 1 && !isOnH(map.IndexOf(c)) && map.ElementAt(map.IndexOf(c) - 7).Piece != null && !map.ElementAt(map.IndexOf(c) - 7).Piece.IsWhite)
                        {
                            tempC = map.ElementAt(map.IndexOf(c) - 7);
                            tempC.AvailableCase = true;
                            AvailableCases.Add(tempC);
                        }
                        else if (i == 2 && !isOnA(map.IndexOf(c)) && map.ElementAt(map.IndexOf(c) - 9).Piece != null && !map.ElementAt(map.IndexOf(c) - 9).Piece.IsWhite)
                        {
                            tempC = map.ElementAt(map.IndexOf(c) - 9);
                            tempC.AvailableCase = true;
                            AvailableCases.Add(tempC);
                        }
                    }
                }
            }else
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
                        }
                        else if (i == 1 && map.ElementAt(map.IndexOf(c) + 7).Piece != null && !isOnA(map.IndexOf(c)) && map.ElementAt(map.IndexOf(c) + 7).Piece.IsWhite)
                        {
                            tempC = map.ElementAt(map.IndexOf(c) + 7);
                            tempC.AvailableCase = true;
                            AvailableCases.Add(tempC);
                        }
                        else if (i == 2 && map.ElementAt(map.IndexOf(c) + 9).Piece != null && !isOnH(map.IndexOf(c)) && map.ElementAt(map.IndexOf(c) + 9).Piece.IsWhite)
                        {
                            tempC = map.ElementAt(map.IndexOf(c) + 9);
                            tempC.AvailableCase = true;
                            AvailableCases.Add(tempC);
                        }
                    }
                }
            }
        }
    
    }
}
