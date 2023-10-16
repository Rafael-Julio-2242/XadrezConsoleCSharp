using System;
using enums;
using board;
using System.ComponentModel.DataAnnotations;

namespace chess
{
    class Tower : Piece
    {

        public Tower(Board board, Color color) : base(board, color) { }

        public override string ToString()
        {
            return "T";
        }

        private bool CanMove(Position pos)
        {
            Piece p = Board.GetBoardPiece(pos);

            return p == null || p.Color != Color;

        }

        public override bool[,] PossibleMovements()
        {
            bool[,] mat = new bool[Board.Lines, Board.Columns];

            Position pos = new Position(0, 0);

            // acima
            pos.DefineValues(Position.Line - 1, Position.Column);
            while(Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.GetBoardPiece(pos) != null && Board.GetBoardPiece(pos).Color != Color) break;

                pos.Line -= 1;

            }

            // abaixo
            pos.DefineValues(Position.Line + 1, Position.Column);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.GetBoardPiece(pos) != null && Board.GetBoardPiece(pos).Color != Color) break;

                pos.Line += 1;

            }

            // direita
            pos.DefineValues(Position.Line, Position.Column + 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.GetBoardPiece(pos) != null && Board.GetBoardPiece(pos).Color != Color) break;

                pos.Column += 1;

            }

            // esquerda
            pos.DefineValues(Position.Line, Position.Column - 1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.GetBoardPiece(pos) != null && Board.GetBoardPiece(pos).Color != Color) break;

                pos.Column -= 1;

            }

            return mat;

        }

    }
}
