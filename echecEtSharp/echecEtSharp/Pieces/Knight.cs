using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace echecEtSharp.Pieces
{
    class Knight : Piece
    {
         public Knight(Texture2D tex, Vector2 pos, Vector2 behavior, Boolean isWhite, int moveTimes, Boolean canJump)
            : base(tex, pos, behavior, isWhite, moveTimes, canJump)
        {

        }

        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
