﻿using System;
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
                    try
                    {
                        Console.Clear();
                        Screen.PrintMatch(match);

                        Console.Write("Origem: ");
                        Position origin = Screen.ReadChessPos().ToPosition();

                        match.ValidadeOriginPosition(origin);

                        bool[,] possiblePositions = match.Board.GetBoardPiece(origin).PossibleMovements();

                        Console.Clear();
                        Screen.PrintBoard(match.Board, possiblePositions);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Position destiny = Screen.ReadChessPos().ToPosition();

                        match.ValidadeDestinationPosition(origin, destiny);

                        match.MakeMovement(origin, destiny);

                    }
                    catch(BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }

                Console.Clear();
                Screen.PrintMatch(match);

            }
           catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}