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
            if (this.IsWhite)
            {
                //Vérifier si c'est le premier tour pour le mouvement du pion
                if ((map.IndexOf(c) - 7) < 0)
                {
                    //DEVIENT UNE REEIIIIINE
                }
                else
                {
                    for (int i = 0; i < 3; i++)
                    {
                        Case tempC = map.ElementAt(map.IndexOf(c) - (7 + i));

                        if ((i == 0 || i == 2) && tempC.Piece != null && !tempC.Piece.IsWhite)
                        {
                            tempC.AvailableCase = true;
                            AvailableCases.Add(tempC);
                        }
                        else if (i == 1 && tempC.Piece == null)
                        {
                            tempC.AvailableCase = true;
                            AvailableCases.Add(tempC);
                        }
                    }
                }            
            }
            else
            {
                if ((map.IndexOf(c) + 7) > 64)
                {
                    //DEVIENT UNE REEIIIIINE
                }
                else
                {
                    for (int i = 0; i < 3; i++)
                    {
                        Case tempC = map.ElementAt(map.IndexOf(c) + (7 + i));

                        if ((i == 0 || i == 2) && tempC.Piece != null && tempC.Piece.IsWhite)
                        {
                            tempC.AvailableCase = true;
                            AvailableCases.Add(tempC);
                        }
                        else if (i == 1 && tempC.Piece == null)
                        {
                            tempC.AvailableCase = true;
                            AvailableCases.Add(tempC);
                        }
                    }
                }       
            }
        }
    
    }
}
