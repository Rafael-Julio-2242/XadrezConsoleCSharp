using System;
using board;
using enums;
using chess;

namespace xadrez_console
{
    class Screen
    {
        // Imprime o tabuleiro na tela
        public static void PrintBoard(Board board)
        {

            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++)
                {
                    
                    PrintPiece(board.GetBoardPiece(i, j));
                }
                Console.WriteLine();
            }

            Console.WriteLine("  a b c d e f g h");

        }

        public static void PrintBoard(Board board, bool[,] possiblePositions)
        {
            ConsoleColor bgOriginColor = Console.BackgroundColor;
            ConsoleColor highLightPosColor = ConsoleColor.DarkGray;

            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++)
                {
                    if (possiblePositions[i,j])
                    {
                        Console.BackgroundColor = highLightPosColor;
                    }
                    else
                    {
                        Console.BackgroundColor = bgOriginColor;
                    }
                    PrintPiece(board.GetBoardPiece(i, j));
                    Console.BackgroundColor = bgOriginColor;
                }
                Console.WriteLine();
            }

            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = bgOriginColor;
        }
        public static ChessPosition ReadChessPos()
        {
            string input = Console.ReadLine();

            char column = input[0];
            int line = int.Parse(input[1] + "");

            return new ChessPosition(column, line);

        }

        // Função que imprime uma peça
        public static void PrintPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {

                if (piece.Color == Color.White) // Se a peça for brance, simplesmente imprime a peça
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
                Console.Write(" ");
            }


        }


    }
}
