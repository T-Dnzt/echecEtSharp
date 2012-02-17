using System;
using echecEtSharp.Pieces;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace echecEtSharp
{
    class Player
    {
        public List<Piece> ListPieces { get; set; }
        public Dictionary<String, Texture2D> PieceTextures { get; set; }

        private int id;
        private bool isWhitePlayer;


        public Player(int id, bool isWhitePlayer)
        {
            this.id = id;
            this.isWhitePlayer = isWhitePlayer;
            PieceTextures = new Dictionary<String, Texture2D>();
            ListPieces = new List<Piece>();
        }

        public void createPieces(string color, bool whiteC)
        {
            ListPieces.Add(new Rook(PieceTextures[String.Format("{0} Rook", color)], whiteC, false));
            ListPieces.Add(new Knight(PieceTextures[String.Format("{0} Knight", color)], whiteC, true));
            ListPieces.Add(new Bishop(PieceTextures[String.Format("{0} Bishop", color)], whiteC, false));
            ListPieces.Add(new Queen(PieceTextures[String.Format("{0} Queen", color)], whiteC, false));
            ListPieces.Add(new King(PieceTextures[String.Format("{0} King", color)], whiteC, false));
            ListPieces.Add(new Bishop(PieceTextures[String.Format("{0} Bishop", color)], whiteC, false));
            ListPieces.Add(new Knight(PieceTextures[String.Format("{0} Knight", color)], whiteC, true));
            ListPieces.Add(new Rook(PieceTextures[String.Format("{0} Rook", color)], whiteC, false));

            for (int i = 0; i < 8; i++)
            {
                ListPieces.Add(new Pawn(PieceTextures[String.Format("{0} Pawn", color)], whiteC, false));
            }

        }

        public void turnPawnIntoHulk(Case c, Pawn p, string color, bool whiteC)
        {
            Queen q = new Queen(PieceTextures[String.Format("{0} Queen", color)], whiteC, false);
            ListPieces.Remove(p);
            c.Piece = q;
            ListPieces.Add(q);
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
