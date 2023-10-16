using System;
using board.exceptions;

namespace board
{
    class Board
    {
        public int Lines { get; set; } // Quantidade de linhas do tabuleiro
        public int Columns { get; set; } // Quantidade de colunas do tabuleiro

        private Piece[,] pieces; // Matriz de peças


        public Board(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            pieces = new Piece[Lines, Columns];
        }

        public bool IsPieceIn(Position pos) // Checa se existe uma peça em uma dada posição
        {
            ValidadePosition(pos);
            return GetBoardPiece(pos) != null;
        }

        public Piece GetBoardPiece(int line, int column) // Pega uma peça em uma dada posição
        {
            return pieces[line, column];
        }

        // Sobrecarga
        public Piece GetBoardPiece(Position pos) // SobreCarga 'GetBoardPiece'(Pega uma peça em uma dada posição)
        {

            return pieces[pos.Line, pos.Column];
        }

        public void SetBoardPiece(Piece p, Position pos) // Seta uma peça em uma dada posição
        {
            if (IsPieceIn(pos)) throw new BoardException("Já existe uma peça nessa posição");

            pieces[pos.Line, pos.Column] = p;
            p.Position = pos;
        }

        // Testando se uma dada posição é válida
        public bool ValidPosition(Position pos)
        {
            if(pos.Line < 0 || pos.Line >= Lines || pos.Column < 0 || pos.Column >= Columns)
            {
                return false;
            }
            return true;
        }

        // Tratando exceção de posição 
        public void ValidadePosition(Position pos)
        {
            if (!ValidPosition(pos)) throw new BoardException("Posição Inválida!");
        }

    }
}
