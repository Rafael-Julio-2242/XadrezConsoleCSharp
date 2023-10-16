using System;
using board;

namespace xadrez_console
{
    class Screen
    {
        // Imprime o tabuleiro na tela
        public static void PrintBoard(Board board)
        {

            for(int i = 0; i < board.Lines; i++)
            {
                for (int j = 0; j < board.Columns; j++)
                {

                    if(board.GetPiece(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(board.GetPiece(i, j) + " ");
                    }
                }
                Console.WriteLine();
            }

        }


    }
}
