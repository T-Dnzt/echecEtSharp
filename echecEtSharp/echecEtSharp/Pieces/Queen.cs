using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace echecEtSharp.Pieces
{

    class Queen : Piece
    {
        public Queen(Texture2D tex, Boolean isWhite, Boolean canJump)
            : base(tex, isWhite, canJump)
        {

        }

        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }

     
    }
    
}
