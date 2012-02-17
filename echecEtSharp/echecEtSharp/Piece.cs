 using System;
using System.Collections.Generic;
 using System.Linq;
 using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace echecEtSharp
{
    internal class Piece
    {

        protected Vector2 position;
        protected Texture2D texture;
        protected int numberOfMouvs;
        public Boolean IsWhite { get; set; }
        public List<Case> AvailableCases { get; set; }


        public Texture2D Texture
        {
            get { return texture; }
        }

        public int NumberOfMouvs
        {
            get { return numberOfMouvs; }
            set { numberOfMouvs = value; }

        }


        public Piece(Texture2D tex, Boolean isWhite, Boolean canJump)
        {
            this.texture = tex;
            this.IsWhite = isWhite;
            this.AvailableCases = new List<Case>();
            this.numberOfMouvs = 0;
        }

        public bool isInEchec(Boolean white, Case c, List<Case> map)
        {
            var echecCases = new List<Case>();
            var tempEchecCases = new List<Case>();

            if (white)
            {
                tempEchecCases = (from cCase in map
                                  where cCase.Piece != null &&
                                        !cCase.Piece.IsWhite
                                  select cCase).ToList();
            }
            else
            {
                tempEchecCases = (from cCase in map
                                  where cCase.Piece != null &&
                                        cCase.Piece.IsWhite
                                  select cCase).ToList();
            }

            foreach (Case cases in tempEchecCases)
            {
                List<Case> u = cases.Piece.defineEchecCases(white, c, cases, map);
                foreach (Case a in u)
                {
                    echecCases.Add(a);
                }
            }

            if (echecCases.Contains(c))
            {
                return true;
            }
            return false;
        }

        public virtual void defineAvailableCases(Case c, List<Case> map)
        {
        }

        public virtual List<Case> defineEchecCases(Boolean white, Case king, Case c, List<Case> map)
        {
            return new List<Case>();
        }

        public virtual void undefineAvailableCases()
        {

        }

        public bool isOnA(int index)
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

        public bool isOnB(int index)
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

        public bool isOnG(int index)
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

        public bool isOnH(int index)
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

        public bool isOn8(int index)
        {
            if (index < 8)
            {
                return true;
            }
            return false;
        }

        public bool isOn1(int index)
        {
            if (index > 55)
            {
                return true;
            }
            return false;
        }

        public bool isOn6(int index)
        {
            if (index >= 8 && index < 16)
            {
                return true;
            }
            return false;
        }

        public bool isOn2(int index)
        {
            if (index <= 55 && index > 47)
            {
                return true;
            }
            return false;
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch batch, Rectangle rec)
        {
            batch.Draw(texture, rec, Color.White);
        }
    }
}