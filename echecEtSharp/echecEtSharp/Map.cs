using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace echecEtSharp
{
    class Map
    {
        private int[,] mapArray = new int[,] 
        {
            {0,1,0,1,0,1,0,1},
            {1,0,1,0,1,0,1,0},
            {0,1,0,1,0,1,0,1},
            {1,0,1,0,1,0,1,0},
            {0,1,0,1,0,1,0,1},
            {1,0,1,0,1,0,1,0},
            {0,1,0,1,0,1,0,1},
            {1,0,1,0,1,0,1,0},
        };

        private List<Case> caseList;

        public List<Case> CaseList
        {
            get { return caseList; }
        }

        private List<Texture2D> tileTextures;
        private SpriteFont font;
        private List<String> alpha;

        public Map()
        {
            this.tileTextures = new List<Texture2D>();
            this.alpha = new List<String>() { "a", "b", "c", "d", "e", "f", "g", "h" };
            this.caseList = new List<Case>();
        }

        public void generateMap()
        {
            int columnNum = 8;

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {                 
                    Case newCase = new Case(tileTextures[mapArray[y, x]], tileTextures[2], tileTextures[3], 50 + y * 50, 50 + x * 50, 50, 50, alpha.ElementAt(x), columnNum.ToString());
                    newCase.RockTexture = tileTextures[4];
                    caseList.Add(newCase);
                    columnNum--;
                }
            }
        }

        public void AddFont(SpriteFont newFont)
        {
            font = newFont;
        }

        public void AddTexture(Texture2D texture)
        {
            tileTextures.Add(texture);
        }

        public int Width
        {
            get { return mapArray.GetLength(1); }
        }
        public int Height
        {
            get { return mapArray.GetLength(0); }
        }

        public int getIndex(String c, int i)
        {
            return mapArray[alpha.IndexOf(c), i];
        }

        public bool isOverACase(int x, int y)
        {
            foreach (Case c in caseList)
            {
                if (x > c.CaseRectangle.X && x < c.CaseRectangle.X + c.CaseRectangle.Width && y > c.CaseRectangle.Y && y < c.CaseRectangle.Y + c.CaseRectangle.Height)
                {
                    return true;
                }
            }
            return false;
        }

        public void unSelectCase()
        {
            Case sc = getSelectedCase();
            sc.SelectedCase = false;         
        }

        public void selectCase(int x, int y)
        {
            foreach (Case c in caseList)
            {
                if (x > c.CaseRectangle.X && x < c.CaseRectangle.X + c.CaseRectangle.Width && y > c.CaseRectangle.Y && y < c.CaseRectangle.Y + c.CaseRectangle.Height)
                {
                    c.SelectedCase = true;
                    c.Piece.defineAvailableCases(c, caseList);
                }
            }
        }

        public Case getCase(int x, int y)
        {
            foreach (Case c in caseList)
            {
                if (x > c.CaseRectangle.X && x < c.CaseRectangle.X + c.CaseRectangle.Width && y > c.CaseRectangle.Y && y < c.CaseRectangle.Y + c.CaseRectangle.Height)
                {
                    return c;
                }
            }
            return null;
        }

        public Case getCase(int x, int y, bool gameTurn)
        {
            foreach (Case c in caseList)
            {
                if (x > c.CaseRectangle.X && x < c.CaseRectangle.X + c.CaseRectangle.Width && y > c.CaseRectangle.Y && y < c.CaseRectangle.Y + c.CaseRectangle.Height)
                {
                    if (c.Piece != null)
                        if ((gameTurn && c.Piece.IsWhite) || (!gameTurn && !c.Piece.IsWhite))
                            return c;
                        else
                            return null;
                    else
                        return c;

                }
            }
            return null;
        }

        public Case getSelectedCase()
        {
            foreach (Case c in caseList)
            {
                if (c.SelectedCase.Equals(true))
                {
                        return c;
                }
            }
            return null;
        }

      

        public void DrawCases(SpriteBatch batch)
        {
            foreach (Case c in caseList)
            {
                c.Draw(batch);
            }
        }

        public void DrawCoordinates(SpriteBatch batch)
        {
            int columnNum = 8;
            int rowLetter = 0;
            int columnNumPositionLeftY = 70;

            for (int x = 0; x < 8; x++)
            {
                batch.DrawString(font, columnNum.ToString(), new Vector2(20, columnNumPositionLeftY), Color.Black);
                batch.DrawString(font, columnNum.ToString(), new Vector2(9 * 50 + 20, columnNumPositionLeftY), Color.Black);
                columnNumPositionLeftY += 50;
                columnNum--;
            }

            for (int x = 0; x < 8; x++)
            {
                batch.DrawString(font, alpha.ElementAt(x), new Vector2(70 + x * 50, 20 + 9 * 50), Color.Black);
                batch.DrawString(font, alpha.ElementAt(x), new Vector2(70 + x * 50, 20), Color.Black);
                rowLetter++;
            }
        }

        public static Case getKingOriginCase(Boolean white)
        {
            return null;
        }

        // public 
        public void Draw(SpriteBatch batch)
        {
            DrawCoordinates(batch);
            DrawCases(batch);
        }
    }
}
