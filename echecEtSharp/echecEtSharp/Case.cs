using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace echecEtSharp
{
    class Case
    {

        private Piece piece;

        public Piece Piece
        {
            get { return piece; }
            set { piece = value; }
        }


        private Rectangle caseRec;

        public Rectangle CaseRectangle
        {
            get { return caseRec; }
        }
        private Texture2D caseTex;

        public Texture2D CaseTexture
        {
            get { return caseTex; }
            set { caseTex = value; }
        }

        private Texture2D selectedtexture;

        public Texture2D Selectedtexture
        {
            get { return selectedtexture; }
            set { selectedtexture = value; }
        }

        private bool selectedCase;

        public bool SelectedCase
        {
            get { return selectedCase; }
            set { selectedCase = value; }
        }


        private string letterIdentifier;
        private string numberIdentifier;

        public Case(Texture2D texture, Texture2D selectedTex, int x, int y, int width, int height, string letterId, string numberId)
        {
            this.caseRec = new Rectangle(x, y, width, height);
            this.selectedtexture = selectedTex;
            this.caseTex = texture;
            this.letterIdentifier = letterId;
            this.numberIdentifier = numberId;
            this.piece = null;
        }

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(this.caseTex, this.caseRec, Color.White);

            if (this.selectedCase == true)
            {
                batch.Draw(this.selectedtexture, this.caseRec, Color.White);
            }

            if (this.piece != null)
            {
                piece.Draw(batch, this.caseRec);
            }
        }
            


    }
}
