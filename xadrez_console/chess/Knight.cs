using System;
using enums;
using board;
using System.ComponentModel.DataAnnotations;

namespace chess
{
    class Knight : Piece
    {

        public Knight(Board board, Color color) : base(board, color) { }

        public override string ToString()
        {
            return "C";
        }

        // Função que verifica que posso mover para alguma posição específica
        private bool CanMove(Position pos)
        {
            Piece p = Board.GetBoardPiece(pos);

            return p == null || p.Color != Color;

        }
        // Criando os movimentos possíveis da Torre
        public override bool[,] PossibleMovements()
        {   // Matriz de movimentos possíveis
            bool[,] mat = new bool[Board.Lines, Board.Columns];

            // Posição a ser verificada
            Position pos = new Position(0, 0);

            pos.DefineValues(Position.Line - 1, Position.Column - 2);
            if(Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.DefineValues(Position.Line - 2, Position.Column - 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.DefineValues(Position.Line - 2, Position.Column + 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.DefineValues(Position.Line - 1, Position.Column + 2);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.DefineValues(Position.Line + 1, Position.Column + 2);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.DefineValues(Position.Line + 2 , Position.Column + 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.DefineValues(Position.Line + 2, Position.Column - 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            pos.DefineValues(Position.Line + 1, Position.Column - 2);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            return mat; // Retorna a matriz de movimentos possíveis

        }

    }
}
