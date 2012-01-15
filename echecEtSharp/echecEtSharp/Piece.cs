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
        protected float rotation;

        protected Boolean isWhite;
        protected Boolean isAlive;
        protected Boolean canJump;
        protected Boolean selected;

        protected int moveTimes;
        protected float speed;

        public Piece(Texture2D tex, Vector2 pos, Vector2 behavior, Boolean isWhite, int moveTimes, Boolean canJump)
        {
            this.texture = tex;
            this.position = pos;
            this.behavior = behavior;
            this.isWhite = isWhite;
            this.moveTimes = moveTimes;

            this.canJump = false;
            this.isAlive = true;
            this.selected = false;

            this.speed = 0.5f;
            this.velocity = Vector2.Zero;
            this.center = new Vector2(position.X + texture.Width / 2, position.Y + texture.Height / 2);
            this.origin = new Vector2(texture.Width / 2, texture.Height / 2);
        }

        public void canMoveThisWay()
        {

        }

        public void die()
        {

        }

        public virtual void Update(GameTime gameTime)
        {
            this.center = new Vector2(position.X + texture.Width / 2, position.Y + texture.Height / 2);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, center, null, Color.White, rotation, origin, 1.0f, SpriteEffects.None, 0);
        }

        protected Vector2 Position
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

    }
}
