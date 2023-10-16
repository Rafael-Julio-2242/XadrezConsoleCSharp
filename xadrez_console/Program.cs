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

            ChessPosition pos = new ChessPosition('c',7);



            Console.WriteLine(pos);

            Console.WriteLine(pos.ToPosition());


        }
    }
}