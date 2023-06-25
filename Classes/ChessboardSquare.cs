using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessboard.Classes
{
    public partial class ChessboardSquare : Label
    {
        public int SquareNum;

        private int _piece = 0;
        private bool _isWhite = true;
        private ImageManager _imageManager;

        public ChessboardSquare(int squareNum, ImageManager imageManager)
        {
            InitializeComponent();

            SquareNum = squareNum;

            Font = new Font("Seoge UI", 30);
            ForeColor = Color.Red;
            TextAlign = ContentAlignment.MiddleCenter;
            _imageManager = imageManager;
        }

        /* public ChessboardSquare(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        } */

        public void SetPiece(int piece, bool isWhite)
        {
            _piece = piece;
            _isWhite = isWhite;
        }

        public void DrawPiece()
        {
            if (_piece == 0)
            {
                Image = null;
                return;
            }
            Image = _imageManager.GetImage(_piece, _isWhite);
        }

        public void MakeSelected()
        {
            if (BackColor == Color.Snow)
            {
                BackColor = Color.Gold;
            }
            else if (BackColor == Color.DimGray)
            {
                BackColor = Color.Goldenrod;
            }
        }

        public void MakeUnselected()
        {
            if (BackColor == Color.Gold)
            {
                BackColor = Color.Snow;
            }
            else if (BackColor == Color.Goldenrod)
            {
                BackColor = Color.DimGray;
            }
        }
    }
}
