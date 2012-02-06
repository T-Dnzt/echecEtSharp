using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace echecEtSharp
{
    class Piece
    {
        protected Texture2D texture;

        protected Vector2 position;
    
        protected Vector2 center;

        protected Vector2 behavior;

        protected Rectangle bounds;
        protected int width;
        protected int height;

        protected float rotation;
        protected Boolean isWhite;
        protected Boolean isAlive;
        protected Boolean canJump;
        private Dictionary<String, int[]> moveTypes;


 

        public Piece(Texture2D tex, Boolean isWhite,  Boolean canJump)
        {
            this.texture = tex;
            this.isWhite = isWhite;
        }

        public virtual void Update(GameTime gameTime)
        {
            //this.center = new Vector2(position.X + texture.Width / 2, position.Y + texture.Height / 2);
        }

        public void Draw(SpriteBatch batch, Rectangle rec)
        {
             batch.Draw(texture, rec, Color.White);
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

        protected Dictionary<String, int[]> MoveTypes
        {
            get { return moveTypes; }
            set { moveTypes = value; }
        }
    }
}
