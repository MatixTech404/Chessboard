using Chessboard.Classes;

namespace Chessboard
{
    public partial class Form1 : Form
    {
        private ChessboardSquare[] _squareList = new ChessboardSquare[64];
        ChessboardManager chessboardManager;
        ImageManager imageManager;

        ChessboardSquare? srcSquare = null;

        public Form1()
        {
            InitializeComponent();

            chessboardManager = new ChessboardManager();
            imageManager = new ImageManager();

            UtworzSzachownice();

            SetPieces();
            DrawPieces();
        }

        private void BtnClicked(object? sender, EventArgs e)
        {
            if (sender == null)
            {
                return;
            }

            ChessboardSquare square = (ChessboardSquare)sender;

            if (srcSquare == null)
            {
                square.MakeSelected();
                srcSquare = square;
                return;
            }

            if (srcSquare == square)
            {
                square.MakeUnselected();
                srcSquare = null;
                return;
            }

            chessboardManager.MovePiece(srcSquare.SquareNum, square.SquareNum);
            SetPieces();
            DrawPieces();
            srcSquare.MakeUnselected();

            srcSquare = null;
        }

        private void SquareMouseDown(object? sender, MouseEventArgs e)
        {
            if (sender == null)
            {
                return;
            }
            ChessboardSquare square = (ChessboardSquare)sender;
            if (square.SquareNum != 0)
            {
                DoDragDrop(square.SquareNum, DragDropEffects.Move);
            }
        }

        private void SquareDragOver(object? sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void SquareDragDrop(object? sender, DragEventArgs e)
        {
            if (sender == null)
            {
                return;
            }
            ChessboardSquare square = (ChessboardSquare)sender;

            int from = (int)e.Data.GetData(typeof(int));
            int to = square.SquareNum;

            chessboardManager.MovePiece(from, to);
            SetPieces();
            DrawPieces();
        }

        private void SetPieces()
        {
            List<ChessPiece> pieces = chessboardManager.GetPieces();

            for (int i = 0; i < _squareList.Length; i++)
            {
                _squareList[i].SetPiece(0, true);
            }

            foreach (ChessPiece piece in pieces)
            {
                _squareList[piece.GetSquare()].SetPiece(piece.GetPiece(), piece.IsWhite);
            }
        }

        private void DrawPieces()
        {
            for (int i = 0; i < _squareList.Length; i++)
            {
                _squareList[i].DrawPiece();
            }
        }

        private void UtworzSzachownice()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    ChessboardSquare s = new ChessboardSquare(i * 8 + j, imageManager);

                    s.Location = new Point(j * 50, i * 50);
                    s.Width = 50;
                    s.Height = 50;
                    s.BackColor = (i + j) % 2 == 0 ? Color.Snow : Color.DimGray;

                    s.AllowDrop = true;
                    s.Click += BtnClicked;
                    s.MouseDown += SquareMouseDown;
                    s.DragOver += SquareDragOver;
                    s.DragDrop += SquareDragDrop;

                    _squareList[i * 8 + j] = s;
                    panelSzach.Controls.Add(s);
                }
            }
        }
    }
}