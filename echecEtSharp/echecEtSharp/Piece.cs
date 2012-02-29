using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using echecEtSharp.Pieces;

namespace echecEtSharp
{
    public class Piece
    {
        public Piece(Texture2D tex, Boolean isWhite)
        {
            Texture = tex;
            IsWhite = isWhite;
            AvailableCases = new List<Case>();
            NumberOfMoves = 0;
        }

        public int NumberOfMoves { get; set; }
        public Boolean IsWhite { get; set; }
        public List<Case> AvailableCases { get; private set; }
        public Texture2D Texture { get; set; }


        public void SameColorEchec(Case currentCase, List<Case> mapCases, bool whiteEchec, bool blackEchec)
        {
            var casesToDelete = new List<Case>();

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


                        foreach (Case c2 in c1.Piece.AvailableCases)
                        {
                            if (c2.Piece != null && c2.Piece.IsWhite == IsWhite && c2.Piece is King)
                            {
                                casesToDelete.Add(ac);
                            }
                        }
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
                if (AvailableCases.ElementAt(i).Piece is King)
                {
                    AvailableCases.ElementAt(i).AvailableCase = false;
                    AvailableCases.Remove(AvailableCases.ElementAt(i));
                }
            }
        }

        public void MoveOnlyIfNotEchec(Case currentCase, List<Case> mapCases, bool whiteEchec, bool blackEchec)
        {
            if (currentCase.Piece.IsWhite)
            {
                if (whiteEchec)
                {
                    SameColorEchec(currentCase, mapCases, true, blackEchec);
                }

                if (blackEchec)
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


        public virtual void DefineAvailableCases(Case c, List<Case> map, bool whiteEchec, bool blackEchec,
                                                 bool firstEntry)
        {
        }

        public virtual void UndefineAvailableCases()
        {
        }

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

        public bool IsOnC(int index)
        {
            int j = 3;
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

        public bool IsOnD(int index)
        {
            int j = 4;
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

        public bool IsOnE(int index)
        {
            int j = 5;
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

        public bool IsOnF(int index)
        {
            int j = 6;
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

        public bool IsOn7(int index)
        {
            if (index >= 8 && index < 16)
            {
                return true;
            }
            return false;
        }

        public bool IsOn6(int index)
        {
            if (index >= 16 && index < 24)
            {
                return true;
            }
            return false;
        }

        public bool IsOn5(int index)
        {
            if (index >= 24 && index < 32)
            {
                return true;
            }
            return false;
        }

        public bool IsOn4(int index)
        {
            if (index >= 32 && index < 40)
            {
                return true;
            }
            return false;
        }

        public bool IsOn3(int index)
        {
            if (index >= 40 && index < 48)
            {
                return true;
            }
            return false;
        }

        public bool IsOn2(int index)
        {
            if (index >= 48 && index < 54)
            {
                return true;
            }
            return false;
        }

        public bool IsOn1(int index)
        {
            if (index >= 54)
            {
                return true;
            }
            return false;
        }

        

        

        

        public int lineValue(string lineLetter)
        {
            switch (lineLetter)
            {
                case "A":
                    return 1;
                case "B":
                    return 2;
                case "C":
                    return 3;
                case "D":
                    return 4;
                case "E":
                    return 5;
                case "F":
                    return 6;
                case "G":
                    return 7;
                case "H":
                    return 8;
            }
            return 0;
        }
        public KeyValuePair<string,int> getCoord(int pos)
        {
            String lineLetter = "0";
            int lineNumber = 0;
            if(IsOn1(pos))
            {
                lineNumber = 1;
            }else if(IsOn2(pos))
            {
                lineNumber = 2;
            }
            else if (IsOn3(pos))
            {
                lineNumber = 3;
            }
            else if (IsOn4(pos))
            {
                lineNumber = 4;
            }
            else if (IsOn5(pos))
            {
                lineNumber = 5;
            }
            else if (IsOn6(pos))
            {
                lineNumber = 6;
            }
            else if (IsOn7(pos))
            {
                lineNumber = 7;
            }
            else if (IsOn8(pos))
            {
                lineNumber = 8;
            }

            if (IsOnA(pos))
            {
                lineLetter = "A";
            }else if(IsOnB(pos))
            {
                lineLetter = "B";
            }
            else if (IsOnC(pos))
            {
                lineLetter = "C";
            }
            else if (IsOnD(pos))
            {
                lineLetter = "D";
            }
            else if (IsOnE(pos))
            {
                lineLetter = "E";
            }
            else if (IsOnF(pos))
            {
                lineLetter = "F";
            }
            else if (IsOnG(pos))
            {
                lineLetter = "G";
            }
            else if (IsOnH(pos))
            {
                lineLetter = "H";
            }
            return new KeyValuePair<string, int>(lineLetter,lineNumber);
        } 
        

        public bool isInEchec(Boolean white, Case c, List<Case> mapCases)
        {
            return false;
        }

        public Boolean authorizedMvm(Case current, int togo, List<Case> map, Boolean isLeftMvm, Boolean isRightMvm,
                                     Boolean takeOnFly, Boolean onlyTake, Boolean isSameLineNumber, Boolean isSameLineLetter)
        {
            if (togo >= 0 && togo < 64)
            {
                if (isLeftMvm)
                {
                    if (lineValue(getCoord(map.IndexOf(current)).Key) > lineValue(getCoord(togo).Key))
                    {
                        if (!takeOnFly && map.ElementAt(togo).Piece != null)
                        {
                            return false;
                        }
                        if (onlyTake && map.ElementAt(togo).Piece == null)
                        {
                            return false;
                        }
                        if(map.ElementAt(togo).Piece != null && map.ElementAt(togo).Piece.IsWhite == current.Piece.IsWhite)
                        {
                            return false;
                        }
                        if (isSameLineNumber && getCoord(map.IndexOf(current)).Value != getCoord(togo).Value)
                        {
                            return false;
                        }
                        return true;
                    }
                    return false;
                }
                if (isRightMvm)
                {
                    if (lineValue(getCoord(map.IndexOf(current)).Key) < lineValue(getCoord(togo).Key))
                    {
                        if (!takeOnFly && map.ElementAt(togo).Piece != null)
                        {
                            return false;
                        }
                        if (onlyTake && map.ElementAt(togo).Piece == null)
                        {
                            return false;
                        }
                        if (map.ElementAt(togo).Piece != null && map.ElementAt(togo).Piece.IsWhite == current.Piece.IsWhite)
                        {
                            return false;
                        }
                        if (isSameLineNumber && getCoord(map.IndexOf(current)).Value != getCoord(togo).Value)
                        {
                            return false;
                        }
                        return true;
                    }
                    return false;
                }
                if(!takeOnFly && map.ElementAt(togo).Piece != null)
                {
                    return false;
                }
                if (onlyTake && map.ElementAt(togo).Piece == null)
                {
                    return false;
                }
                if (map.ElementAt(togo).Piece != null && map.ElementAt(togo).Piece.IsWhite == current.Piece.IsWhite)
                {
                    return false;
                }
                if(isSameLineLetter && getCoord(map.IndexOf(current)).Key != getCoord(togo).Key)
                {
                    return false;
                }
                return true;

            }
            return false;
        }

        public void Draw(SpriteBatch batch, Rectangle rec)
        {
            batch.Draw(Texture, rec, Color.White);
        }
    }
}