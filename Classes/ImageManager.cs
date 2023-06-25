using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessboard.Classes
{
    public class ImageManager
    {
        private Image[] _whitePieces;
        private Image[] _blackPieces;

        public ImageManager()
        {
            string basePath = $@"{AppDomain.CurrentDomain.BaseDirectory}\..\..\..\img\";

            string[] pieceNames = { "pawn", "knight", "bishop", "rook", "queen", "king" };

            _whitePieces = new Image[6];
            _blackPieces = new Image[6];

            for (int i = 0; i < 6; i++)
            {
                _whitePieces[i] = Image.FromFile(basePath + "w" + pieceNames[i] + ".png");
                _blackPieces[i] = Image.FromFile(basePath + "b" + pieceNames[i] + ".png");
            }
        }

        public Image GetImage(int piece, bool isWhite)
        {
            return isWhite ? _whitePieces[piece - 1] : _blackPieces[piece - 1];
        }
    }
}
