using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace echecEtSharp
{
    class Case
    {
        public Piece Piece { get; set;}
        public Rectangle CaseRectangle { get; set; }
        public Texture2D CaseTexture { get; set; }
        public Texture2D Selectedtexture { get; set; }
        public bool SelectedCase { get; set; }
        public bool AvailableCase { get; set; }
        public Texture2D AvailableTexture { get; set; }
        public Texture2D RockTexture { get; set; }
        public Boolean IsLittleRockPossible { get; set; }
        public Boolean IsBigRockPossible { get; set; }

        private string letterIdentifier;
        private string numberIdentifier;


        public Case(Texture2D texture, Texture2D selectedTex, Texture2D availableTex, int x, int y, int width, int height, string letterId, string numberId)
        {
            CaseRectangle = new Rectangle(x, y, width, height);
            Selectedtexture = selectedTex;
            AvailableTexture = availableTex;
            CaseTexture = texture;
            letterIdentifier = letterId;
            numberIdentifier = numberId;
            Piece = null;
            AvailableCase = false;
            IsBigRockPossible = false;
            IsLittleRockPossible = false;
            
        }

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(CaseTexture, CaseRectangle, Color.White);

            if (SelectedCase)
                batch.Draw(Selectedtexture, CaseRectangle, Color.White);               

            if (AvailableCase)
                batch.Draw(AvailableTexture, CaseRectangle, Color.White);
            
            if (Piece != null)
            {
                if (IsBigRockPossible || IsLittleRockPossible)
                {
                    if (Piece.IsWhite)
                        batch.Draw(RockTexture, CaseRectangle, Color.White);
                    else 
                        batch.Draw(RockTexture, CaseRectangle, Color.White);
                }
                Piece.Draw(batch, CaseRectangle);    
            }
        }
    }
}
