using System;
using echecEtSharp.Pieces;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace echecEtSharp
{
    class Player
    {
        private King king;

        internal King King
        {
            get { return king; }
            set { king = value; }
        }
        private Queen queen;

        internal Queen Queen
        {
            get { return queen; }
            set { queen = value; }
        }
        private List<Rook> rooks;

        internal List<Rook> Rooks
        {
            get { return rooks; }
            set { rooks = value; }
        }
        private List<Knight> knights;

        internal List<Knight> Knights
        {
            get { return knights; }
            set { knights = value; }
        }
        private List<Bishop> bishops;

        internal List<Bishop> Bishops
        {
            get { return bishops; }
            set { bishops = value; }
        }
        private List<Pawn> pawns;

        internal List<Pawn> Pawns
        {
            get { return pawns; }
            set { pawns = value; }
        }

        //private List<Texture2D> pieceTextures;
        private Dictionary<String, Texture2D> pieceTextures;

        public Dictionary<String, Texture2D> PieceTextures
        {
            get { return pieceTextures; }
            set { pieceTextures = value; }
        }

        private List<Piece> pieces;

        private int id;
        private bool turnToPlay;
        private bool isWhitePlayer;


        public Player(int id, bool isWhitePlayer)
        {
            this.id = id;
            this.isWhitePlayer = isWhitePlayer;
            pieceTextures = new Dictionary<String, Texture2D>();
  
        }

        public void createPieces(string color, bool whiteC)
        {

            king = new King(pieceTextures[String.Format("{0} King", color)], whiteC, false);
            queen = new Queen(pieceTextures[String.Format("{0} Queen", color)], whiteC, false);

            rooks = new List<Rook>();
            rooks.Add(new Rook(pieceTextures[String.Format("{0} Rook", color)], whiteC, false));
            rooks.Add(new Rook(pieceTextures[String.Format("{0} Rook", color)], whiteC, false));

            knights = new List<Knight>();
            knights.Add(new Knight(pieceTextures[String.Format("{0} Knight", color)], whiteC, true));
            knights.Add(new Knight(pieceTextures[String.Format("{0} Knight", color)], whiteC, true));

            bishops = new List<Bishop>();
            bishops.Add(new Bishop(pieceTextures[String.Format("{0} Bishop", color)], whiteC, false));
            bishops.Add(new Bishop(pieceTextures[String.Format("{0} Bishop", color)], whiteC, false));

            pawns = new List<Pawn>();
            for (int i = 0; i < 8; i++)
            {
                pawns.Add(new Pawn(pieceTextures[String.Format("{0} Pawn", color)], whiteC, false));
            }

        }

        public void generatePieces()
        {
            if (isWhitePlayer)
            {
                createPieces("White", true);
            }
            else
            {
                createPieces("Black", false);
            }

        }

    }
}
