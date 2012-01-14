using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        private List<Texture2D> tileTextures;
        private SpriteFont font;
        private List<String> alpha;

        public Map()
        {
            tileTextures = new List<Texture2D>();
            alpha = new List<String>() { "a", "b", "c", "d", "e", "f", "g", "h" };
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

        public void Draw(SpriteBatch batch)
        {
            int columnNum = 8;
            int rowLetterTop = 0;
            int rowLetterDown = 0;
            int columnNumPositionLeftY = 70;
            int columnNumPositionRightX = 9 * 50 + 20;

            for (int x = 0; x < Width; x++)
            {
                batch.DrawString(font, columnNum.ToString(), new Vector2(20, columnNumPositionLeftY), Color.Black);
                batch.DrawString(font, columnNum.ToString(), new Vector2(columnNumPositionRightX, columnNumPositionLeftY), Color.Black);


                columnNumPositionLeftY += 50;
                columnNum--;

                for (int y = 0; y < Height + 1; y++)
                {
                    if (y == 8)
                    {
                        batch.DrawString(font, alpha.ElementAt(rowLetterDown), new Vector2(70 + x * 50, 20 + 9 * 50), Color.Black);
                        rowLetterDown++;
                    }
                    else if (y < Height)
                    {

                        if (y == 0)
                        {
                            batch.DrawString(font, alpha.ElementAt(rowLetterTop), new Vector2(70 + x * 50, 20 + y * 50), Color.Black);
                            rowLetterTop++;
                        }

                        int textureIndex = mapArray[y, x];
                        if (textureIndex == -1)
                            continue;

                        Texture2D texture = tileTextures[textureIndex];
                        batch.Draw(texture, new Rectangle(50 + x * 50, 50 + y * 50, 50, 50), Color.White);
                    }
                }


            }
        }
    }
}
