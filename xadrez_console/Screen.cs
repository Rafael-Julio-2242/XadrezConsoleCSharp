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
            // Percorrendo o tabuleiro
            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write(8 - i + " "); // Imprimindo os números da primeira coluna
                for (int j = 0; j < board.Columns; j++)
                {
                    // Mostrando aquilo que está na posição i j do tabuleiro
                    PrintPiece(board.GetBoardPiece(i, j));
                }
                Console.WriteLine();
            }

            Console.WriteLine("  a b c d e f g h"); // Terminando a ultima linha

        }

        // Método sobrecarregado que imprime o tabuleiro mudando as cores das posições possíveis
        public static void PrintBoard(Board board, bool[,] possiblePositions)
        {
            ConsoleColor bgOriginColor = Console.BackgroundColor; // Pega a cor natural do console
            ConsoleColor highLightPosColor = ConsoleColor.DarkGray;// Pega a cor de "HightLight" de posições possíveis

            // Percorre a matriz do tabuleiro
            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write(8 - i + " "); // Escreve a primeira coluna de números
                for (int j = 0; j < board.Columns; j++)
                {
                    if (possiblePositions[i,j]) // Se a posição atual for uma posição possível
                    {
                        Console.BackgroundColor = highLightPosColor; // Troca a cor do fundo da posição atual
                    }
                    else
                    {
                        Console.BackgroundColor = bgOriginColor; // Se não, coloca a cor normal
                    }
                    PrintPiece(board.GetBoardPiece(i, j)); // Mostra a peça
                    Console.BackgroundColor = bgOriginColor; // Volta a cor normal
                }
                Console.WriteLine();
            }

            Console.WriteLine("  a b c d e f g h"); // Finalizando a ultima linha
            Console.BackgroundColor = bgOriginColor; // Voltando o console para a cor original
        }


        // Função responsável por ler a posição digitada pelo jogador
        public static ChessPosition ReadChessPos()
        {
            string input = Console.ReadLine(); // Input

            char column = input[0]; // Coluna
            int line = int.Parse(input[1] + ""); // Linha

            return new ChessPosition(column, line); // Novo objeto 'ChessPosition' retornado

        }

        // Função que imprime peças
        public static void PrintPiece(Piece piece)
        {
            if (piece == null) // Se a peça for nula
            {
                Console.Write("- "); // Imprimo isto
            }
            else // Se não
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
