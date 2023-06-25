using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessboard.Classes
{
    internal class ChessboardManager
    {
        private List<ChessPiece> _pieces;
        private bool _whiteToMove;

        public ChessboardManager()
        {
            _pieces = new List<ChessPiece>();

            _whiteToMove = true;

            // dodajemy białe figury
            _pieces.Add(new ChessPiece(1, true, 48));
            _pieces.Add(new ChessPiece(1, true, 49));
            _pieces.Add(new ChessPiece(1, true, 50));
            _pieces.Add(new ChessPiece(1, true, 51));
            _pieces.Add(new ChessPiece(1, true, 52));
            _pieces.Add(new ChessPiece(1, true, 53));
            _pieces.Add(new ChessPiece(1, true, 54));
            _pieces.Add(new ChessPiece(1, true, 55));

            _pieces.Add(new ChessPiece(4, true, 56));
            _pieces.Add(new ChessPiece(2, true, 57));
            _pieces.Add(new ChessPiece(3, true, 58));
            _pieces.Add(new ChessPiece(5, true, 59));
            _pieces.Add(new ChessPiece(6, true, 60));
            _pieces.Add(new ChessPiece(3, true, 61));
            _pieces.Add(new ChessPiece(2, true, 62));
            _pieces.Add(new ChessPiece(4, true, 63));

            // dodajemy czarne figury
            _pieces.Add(new ChessPiece(1, false, 8));
            _pieces.Add(new ChessPiece(1, false, 9));
            _pieces.Add(new ChessPiece(1, false, 10));
            _pieces.Add(new ChessPiece(1, false, 11));
            _pieces.Add(new ChessPiece(1, false, 12));
            _pieces.Add(new ChessPiece(1, false, 13));
            _pieces.Add(new ChessPiece(1, false, 14));
            _pieces.Add(new ChessPiece(1, false, 15));

            _pieces.Add(new ChessPiece(4, false, 0));
            _pieces.Add(new ChessPiece(2, false, 1));
            _pieces.Add(new ChessPiece(3, false, 2));
            _pieces.Add(new ChessPiece(5, false, 3));
            _pieces.Add(new ChessPiece(6, false, 4));
            _pieces.Add(new ChessPiece(3, false, 5));
            _pieces.Add(new ChessPiece(2, false, 6));
            _pieces.Add(new ChessPiece(4, false, 7));
        }

        public List<ChessPiece> GetPieces()
        {
            return _pieces;
        }

        //public void SetPiecesOnSquares(ChessboardSquare[] squares)
        //{
        //    for (int i = 0; i < squares.Length; i++)
        //    {
        //        squares[i].SetPiece(0, true);
        //    }

        //    foreach (ChessPiece piece in _pieces)
        //    {
        //        squares[piece.GetSquare()].SetPiece(piece.GetPiece(), piece.IsWhite);
        //    }
        //}

        //public void DrawPieces(ChessboardSquare[] squares)
        //{
        //    for (int i = 0; i < squares.Length; i++)
        //    {
        //        squares[i].SetPiece(0, true);
        //    }

        //    foreach (ChessPiece piece in _pieces)
        //    {
        //        squares[piece.GetSquare()].SetPiece(piece.GetPiece(), piece.IsWhite);
        //        squares[piece.GetSquare()].DrawPiece();
        //    }
        //}

        public ChessPiece? FindPiece(int square)
        {
            foreach (ChessPiece piece in _pieces)
            {
                if (piece.GetSquare() == square)
                {
                    return piece;
                }
            }
            return null;
        }

        public void MovePiece(int srcSquare, int destSquare)
        {
            ChessPiece? pieceToMove = FindPiece(srcSquare);
            if (pieceToMove == null)
            {
                return;
            }
            if (pieceToMove.IsWhite != _whiteToMove)
            {
                return;
            }

            ChessPiece? pieceToCapture = FindPiece(destSquare);

            if (pieceToMove.GetPiece() == 6)
            {
                if (MoveKing(pieceToMove, pieceToCapture, srcSquare, destSquare))
                {
                    _whiteToMove = !_whiteToMove;
                }
            }
            else
            {
                if (!IsMoveLegal(pieceToMove, destSquare - srcSquare, pieceToCapture != null))
                {
                    return;
                }

                if (pieceToCapture == null)
                {
                    pieceToMove.SetSquare(destSquare);
                }
                else if (pieceToCapture.IsWhite == pieceToMove.IsWhite)
                {
                    return;
                }
                else
                {
                    _pieces.Remove(pieceToCapture);
                    pieceToMove.SetSquare(destSquare);
                }
                _whiteToMove = !_whiteToMove;
            }
        }

        public bool MoveKing(ChessPiece pieceToMove, ChessPiece? pieceToCapture, int srcSquare, int destSquare)
        {
            int distance = destSquare - srcSquare;

            ChessPiece? rook;
            switch (distance)
            {
                case 2:
                    rook = FindPiece(pieceToMove.IsWhite ? 63 : 7);
                    break;
                case -2:
                    rook = FindPiece(pieceToMove.IsWhite ? 56 : 0);
                    break;
                default:
                    rook = null;
                    break;
            }
            
            if (!IsKingMoveLegal(pieceToMove, rook, distance))
            {
                return false;
            }
            if (rook == null)
            {
                if (pieceToCapture == null)
                {
                    pieceToMove.SetSquare(destSquare);
                }
                else if (pieceToCapture.IsWhite == pieceToMove.IsWhite)
                {
                    return false;
                }
                else
                {
                    _pieces.Remove(pieceToCapture);
                    pieceToMove.SetSquare(destSquare);
                }
            }
            else if (distance == 2)
            {
                pieceToMove.SetSquare(pieceToMove.IsWhite ? 62 : 6);
                rook.SetSquare(pieceToMove.IsWhite ? 61 : 5);
            }
            else if (distance == -2)
            {
                pieceToMove.SetSquare(pieceToMove.IsWhite ? 58 : 2);
                rook.SetSquare(pieceToMove.IsWhite ? 59 : 3);
            }
            return true;
        }

        public bool IsMoveLegal(ChessPiece piece, int distance, bool isCapture)
        {
            if (piece.GetPiece() == 1)
            {
                if (isCapture)
                {
                    return piece.IsWhite ? distance == -7 || distance == -9 : distance == 7 || distance == 9;
                }
                else if (piece.IsMoved)
                {
                    return piece.IsWhite ? distance == -8 : distance == 8;
                }
                else
                {
                    return piece.IsWhite ? distance == -8 || distance == -16 : distance == 8 || distance == 16;
                }

            }
            else
            {
                return IsMovePossible(piece, distance);
            }
        }

        private bool IsKingMoveLegal(ChessPiece piece, ChessPiece? rook, int distance)
        {
            int kingPos = piece.IsWhite ? 60 : 4;

            if (rook == null)
            {
                return distance == -8 || distance == 8  ||
                       distance == -1 || distance == 1  ||
                       distance == -7 || distance == -9 ||
                       distance == 7  || distance == 9;
            }

            if (piece.GetSquare() == kingPos && rook.GetPiece() == 4)
            {
                return !(piece.IsMoved || rook.IsMoved);
            }
            return false;
        }

        public bool IsMovePossible(ChessPiece piece, int distance)
        {
            switch (piece.GetPiece())
            {
                case 2:
                    return distance == 15  || distance == 17  ||
                           distance == 7   || distance == 9   ||
                           distance == -15 || distance == -17 ||
                           distance == -7  || distance == -9;
                case 3:
                    return distance % 7 == 0 || distance % 9 == 0;
                case 4:
                    return distance % 8 == 0 || (distance < 8 && distance > -8);
                case 5:
                    return distance % 7 == 0 || distance % 9 == 0 ||
                        distance % 8 == 0 || (distance < 8 && distance > -8);
                default:
                    return false;
            }
        }
    }
}