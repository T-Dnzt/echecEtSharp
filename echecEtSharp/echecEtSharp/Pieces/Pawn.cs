using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace echecEtSharp.Pieces
{
    class Pawn : Piece
    {


        public Pawn(Texture2D tex, Vector2 pos, Vector2 behavior, Boolean isWhite, int moveTimes, Boolean canJump)
            : base(tex, pos, behavior, isWhite, moveTimes, canJump)
        {

        }

        public override void Update(GameTime gameTime)
        {
            MouseState mouseStateCurrent, mouseStatePrevious;

            mouseStateCurrent = Mouse.GetState();

            if (mouseStateCurrent.LeftButton == ButtonState.Pressed && 
                mouseStateCurrent.X < center.X + texture.Width /2 &&
                mouseStateCurrent.X > center.X - texture.Width /2 &&
                mouseStateCurrent.Y < center.Y + texture.Height /2 &&
                mouseStateCurrent.Y > center.Y - texture.Height /2)
            {
                Console.WriteLine("LOL");
            }

            Console.WriteLine("fu");

            mouseStatePrevious = mouseStateCurrent;


            base.Update(gameTime);

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
