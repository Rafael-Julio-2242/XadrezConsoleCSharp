using System;
using enums;

namespace board
{
    abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int QntMovements { get; protected set; }
        public Board Board { get; protected set; }


        public Piece(Board board, Color color)
        {
            Position = null;
            Color = color;
            QntMovements = 0;
            Board = board;
        }

        public void IncreaseQuantityMovement()
        {
            QntMovements++;
        }

        public bool IsMovementPossible()
        {
            bool[,] mat = PossibleMovements();

            for(int i = 0;i < Board.Lines; i++)
            {
                for(int j = 0; j < Board.Columns; j++)
                {
                    if (mat[i,j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CanMoveTo(Position pos)
        {
            return PossibleMovements()[pos.Line, pos.Column];
        }

        public abstract bool[,] PossibleMovements();


    }
}
