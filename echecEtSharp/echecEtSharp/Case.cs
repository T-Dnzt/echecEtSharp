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

        private bool selectedCase;

        public bool SelectedCase
        {
            get { return selectedCase; }
            set { selectedCase = value; }
        }


        private string letterIdentifier;
        private string numberIdentifier;

        public Case(Texture2D texture, int x, int y, int width, int height, string letterId, string numberId)
        {
            this.caseRec = new Rectangle(x, y, width, height);
            this.caseTex = texture;
            this.letterIdentifier = letterId;
            this.numberIdentifier = numberId;
        }


    }
}
