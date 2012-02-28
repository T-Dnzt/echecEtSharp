 using System;
using System.Collections.Generic;
 using System.Linq;
 using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace echecEtSharp
{
    public class Piece
    {
        public int NumberOfMoves { get; set; }
        public Boolean IsWhite { get; set; }
        public List<Case> AvailableCases { get; private set; }
        public Texture2D Texture { get; set; }


        public Piece(Texture2D tex, Boolean isWhite)
        {
            Texture = tex;
            IsWhite = isWhite;
            AvailableCases = new List<Case>();
            NumberOfMoves = 0;
        }

        public void SameColorEchec(Case currentCase, List<Case> mapCases, bool whiteEchec, bool blackEchec)
        {
            List<Case> casesToDelete = new List<Case>();

            foreach (Case ac in AvailableCases)
            {
                Piece tempPiece = this;

                Piece backupA = null;
                if (ac.Piece != null)
                    backupA = ac.Piece;

                ac.Piece = this;
                currentCase.Piece = null;

                foreach (Case c1 in mapCases)
                {
                    if (c1.Piece != null && c1.Piece.IsWhite == !IsWhite)
                    {
                        c1.Piece.DefineAvailableCases(c1, mapCases, whiteEchec, blackEchec, false);

                        casesToDelete = (from c2 in c1.Piece.AvailableCases
                                         where
                                             c2.Piece != null && c2.Piece.IsWhite == IsWhite && c2.Piece is Pieces.King
                                         select c2).ToList();
                        /*foreach (Case c2 in c1.Piece.AvailableCases)
                        {
                            if (c2.Piece != null && c2.Piece.IsWhite == IsWhite && c2.Piece is Pieces.King)
                            {
                                casesToDelete.Add(ac);
                            }
                        }*/
                        c1.Piece.UndefineAvailableCases();
                    }
                }

                ac.Piece = backupA;
                currentCase.Piece = this;
            }

            foreach (Case cd in casesToDelete)
            {
                if (AvailableCases.Contains(cd))
                {
                    cd.AvailableCase = false;
                    AvailableCases.Remove(cd);
                }
            }
        }

        public void DifferentColorEchec()
        {
            for (int i = 0; i < AvailableCases.Count; i++)
            {
                if (AvailableCases.ElementAt(i).Piece is Pieces.King)
                {
                    AvailableCases.ElementAt(i).AvailableCase = false;
                    AvailableCases.Remove(AvailableCases.ElementAt(i));
                }
            }             
        }

        public void MoveOnlyIfNotEchec(Case currentCase, List<Case> mapCases, bool whiteEchec, bool blackEchec)
        {
            if(currentCase.Piece.IsWhite)
            {
                if (whiteEchec)
                {
                    SameColorEchec(currentCase, mapCases, true, blackEchec);
                }

                if(blackEchec)
                {
                    DifferentColorEchec();
                }
            }
            else
            {
                if (blackEchec)
                {
                    SameColorEchec(currentCase, mapCases, whiteEchec, true);
                }

                if (whiteEchec)
                {
                    DifferentColorEchec();
                }
            }
        }


        public virtual void DefineAvailableCases(Case c, List<Case> map, bool whiteEchec, bool blackEchec, bool firstEntry)
        {}

        public virtual void UndefineAvailableCases()
        {}

        public bool IsOnA(int index)
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

        public bool IsOnB(int index)
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

        public bool IsOnG(int index)
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

        public bool IsOnH(int index)
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

        public bool IsOn8(int index)
        {
            if (index < 8)
            {
                return true;
            }
            return false;
        }

        public bool IsOn1(int index)
        {
            if (index > 55)
            {
                return true;
            }
            return false;
        }

        public bool IsOn6(int index)
        {
            if (index >= 8 && index < 16)
            {
                return true;
            }
            return false;
        }

        public bool IsOn2(int index)
        {
            if (index <= 55 && index > 47)
            {
                return true;
            }
            return false;
        }

        public bool isInEchec(Boolean white, Case c, List<Case> mapCases)
        {
            return false;
        }

        public void Draw(SpriteBatch batch, Rectangle rec)
        {
            batch.Draw(Texture, rec, Color.White);
        }
    }
}