using System;


using board;
namespace chess
{
    class ChessPosition
    {
        public char Column { get; set; }
        public int Line { get; set; }

        public ChessPosition(char column, int line)
        {
            Column = column;
            Line = line;
        }

        // Converte a posição em Xadrez (ChessPosition) em uma Posição para matriz(Position)
        public Position ToPosition()
        {
            return new Position(8 - Line, Column - 'a');
        }

        // ToString
        public override string ToString()
        {
            return "" + Column + Line;
        }

    }
}
