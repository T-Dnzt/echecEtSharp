using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace echecEtSharp
{
    class Piece
    {
        protected Texture2D texture;

        protected Vector2 position;
        protected Vector2 velocity;
        protected Vector2 center;
        protected Vector2 origin;
        protected Vector2 behavior;

        protected Rectangle bounds;
        protected int width;
        protected int height;

        protected float rotation;

        protected Boolean isWhite;
        protected Boolean isAlive;
        protected Boolean canJump;
        protected Boolean selected;

        protected int moveTimes;
        protected float speed;

        public Piece(Texture2D tex, Boolean isWhite,  Boolean canJump)
        {
            this.texture = tex;
            this.isWhite = isWhite;

            this.speed = 0.5f;
            this.velocity = Vector2.Zero;
  
            
            //this.bounds = new Rectangle((int)position.X, (int)position.Y, width, height);
        }



        public virtual void Update(GameTime gameTime)
        {
            //this.center = new Vector2(position.X + texture.Width / 2, position.Y + texture.Height / 2);
        }

        public void Draw(SpriteBatch batch, Rectangle rec)
        {
             batch.Draw(this.texture, rec, Color.White);
        }

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

    }
}
