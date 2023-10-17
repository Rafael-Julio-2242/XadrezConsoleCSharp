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
            ValidadePosition(pos); // Valida a posição selecionada
            return GetBoardPiece(pos) != null; // Retorna se a peça está naquela posição ou não
        }

        public Piece GetBoardPiece(int line, int column) // Pega uma peça em uma dada posição
        {
            return pieces[line, column]; // Retorna a peça na posição solicitada
        }

        // Sobrecarga
        public Piece GetBoardPiece(Position pos) // SobreCarga 'GetBoardPiece'(Pega uma peça em uma dada posição)
        {

            return pieces[pos.Line, pos.Column];// Retorna a peça na posição solicitada
        }

        // Coloca uma peça em uma posição especificada
        public void SetBoardPiece(Piece p, Position pos) // Seta uma peça em uma dada posição
        {
            if (IsPieceIn(pos)) throw new BoardException("Já existe uma peça nessa posição"); // Exceção

            // Coloca a peça na posição especificada
            pieces[pos.Line, pos.Column] = p;
            p.Position = pos; // Atualiza a posição da peça
        }

        // Função para tirar uma peça do tabuleiro
        public Piece WithdrawPiece(Position pos)
        {
            // Caso não tenha nada nessa posição, retorna nulo
            if (GetBoardPiece(pos) == null) return null;
            // Pego a peça que está nessa posição
            Piece aux = GetBoardPiece(pos);
            // Digo que ela não tem nenhuma posição por enquanto
            aux.Position = null;
            // Valo que a matriz de peças não tem nada lá agora
            pieces[pos.Line, pos.Column] = null;
            // Retorno a peça
            return aux;

        }

        // Testando se uma dada posição é válida
        public bool ValidPosition(Position pos)
        {
            if(pos.Line < 0 || pos.Line >= Lines || pos.Column < 0 || pos.Column >= Columns)
            {
                return false; // Se não for válida retorna false
            }
            return true; // Se for retorna true
        }

        // Tratando exceção de posição 
        public void ValidadePosition(Position pos)
        {
            if (!ValidPosition(pos)) throw new BoardException("Posição Inválida!"); // Se a posição não for válida\
        }

    }
}
