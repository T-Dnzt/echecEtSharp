 using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace echecEtSharp
{
    internal class Piece
    {
        protected Vector2 behavior;

        protected Rectangle bounds;
        protected Boolean canJump;
        protected Vector2 center;

        private List<Case> echecCases;
        protected int height;
        protected Boolean isAlive;

        protected int moveTimes;
        protected Dictionary<string, int[]> moveTypes;
        protected Vector2 origin;
        protected Vector2 position;
        protected float rotation;
        protected Boolean selected;
        protected float speed;
        protected Texture2D texture;
        protected Vector2 velocity;
        protected int width;

        public Piece(Texture2D tex, Boolean isWhite, Boolean canJump)
        {
            texture = tex;
            this.IsWhite = isWhite;
            AvailableCases = new List<Case>();
            speed = 0.5f;
            velocity = Vector2.Zero;


            //this.bounds = new Rectangle((int)position.X, (int)position.Y, width, height);
        }

        public Boolean IsWhite { get; set; }
        public List<Case> AvailableCases { get; set; }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        protected Vector2 Center
        {
            get { return center; }
            set { center = value; }
        }

        protected Vector2 Behavior
        {
            get { return behavior; }
            set { behavior = value; }
        }

        public Texture2D Texture
        {
            get { return texture; }
        }


        public virtual void defineAvailableCases(Case c, List<Case> map)
        {
        }

        public virtual List<Case> defineEchecCases(Case king, Case c, List<Case> map)
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
            //this.center = new Vector2(position.X + texture.Width / 2, position.Y + texture.Height / 2);
        }

        public void Draw(SpriteBatch batch, Rectangle rec)
        {
            batch.Draw(texture, rec, Color.White);
        }
    }
}