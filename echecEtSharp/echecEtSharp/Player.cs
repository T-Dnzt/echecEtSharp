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

        private bool isWhitePlayer;


        public Player(int id, bool isWhitePlayer)
        {
            this.isWhitePlayer = isWhitePlayer;
            PieceTextures = new Dictionary<String, Texture2D>();
            ListPieces = new List<Piece>();
        }

        public void CreatePieces(string color, bool whiteC)
        {
            ListPieces.Add(new Rook(PieceTextures[String.Format("{0} Rook", color)], whiteC));
            ListPieces.Add(new Knight(PieceTextures[String.Format("{0} Knight", color)], whiteC));
            ListPieces.Add(new Bishop(PieceTextures[String.Format("{0} Bishop", color)], whiteC));
            ListPieces.Add(new Queen(PieceTextures[String.Format("{0} Queen", color)], whiteC));
            ListPieces.Add(new King(PieceTextures[String.Format("{0} King", color)], whiteC));
            ListPieces.Add(new Bishop(PieceTextures[String.Format("{0} Bishop", color)], whiteC));
            ListPieces.Add(new Knight(PieceTextures[String.Format("{0} Knight", color)], whiteC));
            ListPieces.Add(new Rook(PieceTextures[String.Format("{0} Rook", color)], whiteC));

            for (int i = 0; i < 8; i++)
            {
                ListPieces.Add(new Pawn(PieceTextures[String.Format("{0} Pawn", color)], whiteC));
            }

        }


        public Case FindCase(Map map, Piece p)
        {
            foreach (Case c in map.CaseList)
            {
                if (c.Piece == p)
                    return c;
            }
            return null;
        }

        public void TurnIntoQueen(Case c, Pawn p, string color, bool whiteC)
        {
            Queen q = new Queen(PieceTextures[String.Format("{0} Queen", color)], whiteC);
            ListPieces.Remove(p);
            c.Piece = q;
            ListPieces.Add(q);
        }

        public void GeneratePieces()
        {
            if (isWhitePlayer)
            {
                CreatePieces("White", true);
            }
            else
            {
                CreatePieces("Black", false);
            }

        }

    }
}
