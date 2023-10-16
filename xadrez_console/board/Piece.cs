using System;
using enums;

namespace board
{
    class Piece
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

    }
}
