using System;
using board;
using board.exceptions;
using chess;
using enums;

namespace xadrez_console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessMatch match = new ChessMatch();

                while(!match.Finished)
                {
                    Console.Clear();
                    Screen.PrintBoard(match.Board);

                    Console.WriteLine();

                    Console.Write("Origem: ");
                    Position origin = Screen.ReadChessPos().ToPosition();
                    bool[,] possiblePositions = match.Board.GetBoardPiece(origin).PossibleMovements();

                    Console.Clear();
                    Screen.PrintBoard(match.Board, possiblePositions);

                    Console.WriteLine();
                    Console.Write("Destino: ");
                    Position destiny = Screen.ReadChessPos().ToPosition();

                    match.PerformMovement(origin, destiny);

                }
            }
           catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}