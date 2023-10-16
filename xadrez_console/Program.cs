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
                Board b = new Board(8, 8);

                b.SetBoardPiece(new Tower(b, Color.Black), new Position(0, 0));
                b.SetBoardPiece(new Tower(b, Color.Black), new Position(1, 9));
                b.SetBoardPiece(new King(b, Color.Black), new Position(2, 4));

                Screen.PrintBoard(b);
            }
           catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}