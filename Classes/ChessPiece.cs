using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessboard.Classes
{
    internal class ChessPiece
    {
        private int _piece;
        public bool IsWhite;
        private int _currSquare;
        public bool IsMoved;

        public ChessPiece(int piece, bool isWhite, int startSquare)
        {
            _piece = piece;
            IsWhite = isWhite;
            _currSquare = startSquare;
            IsMoved = false;
        }

        public int GetPiece()
        {
            return _piece;
        }

        public int GetSquare()
        {
            return _currSquare;
        }

        public void SetSquare(int square)
        {
            _currSquare = square;
            IsMoved = true;
        }
    }
}
