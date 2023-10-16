using System;
using board;
using enums;

namespace xadrez_console
{
    class Screen
    {
        // Imprime o tabuleiro na tela
        public static void PrintBoard(Board board)
        {

            for(int i = 0; i < board.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++)
                {

                    if(board.GetBoardPiece(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        PrintPiece(board.GetBoardPiece(i, j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine("  a b c d e f g h");

        }

        // Função que imprime uma peça
        public static void PrintPiece(Piece piece)
        {
            if(piece.Color == Color.White) // Se a peça for brance, simplesmente imprime a peça
            {
                Console.Write(piece);
            }
            else // Senão
            {
                ConsoleColor aux = Console.ForegroundColor; // Guarda a cor atual do console

                Console.ForegroundColor = ConsoleColor.Yellow; // Aplica a cor amarela ao console

                Console.Write(piece); // Escreve a peça

                Console.ForegroundColor = aux; // Retorna a cor original do console
            }
        }


    }
}
