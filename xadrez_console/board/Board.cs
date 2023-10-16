using System;

namespace board
{
    class Board
    {
        public int Lines { get; set; }
        public int Columns { get; set; }

        private Piece[,] pieces;


        public Board(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            pieces = new Piece[Lines, Columns];
        }

        public Piece GetBoardPiece(int line, int column)
        {
            return pieces[line, column];
        }

        public void SetBoardPiece(Piece p, Position pos)
        {
            pieces[pos.Line, pos.Column] = p;
            p.Position = pos;
        }

    }
}
