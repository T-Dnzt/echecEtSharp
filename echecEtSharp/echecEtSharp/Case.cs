using System;
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
            caseRec = new Rectangle(x, y, width, height);
            selectedtexture = selectedTex;
            caseTex = texture;
            letterIdentifier = letterId;
            numberIdentifier = numberId;
            piece = null;
        }

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(caseTex, caseRec, Color.White);

            if (selectedCase)
            {
                batch.Draw(selectedtexture, caseRec, Color.White);
            }

            if (piece != null)
            {
                piece.Draw(batch, caseRec);
            }
        }



    }
}
