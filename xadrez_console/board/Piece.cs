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

        // Aumenta a quantidade de movimentos já feitos
        public void IncreaseQuantityMovement()
        {
            QntMovements++;
        }

        // Função que verifica se é possível se mover
        public bool IsMovementPossible()
        {
            bool[,] mat = PossibleMovements(); // Matriz de movimentos possíveis recolhida da função 'PossibleMovements'
            // Percorre a matriz
            for(int i = 0;i < Board.Lines; i++)
            {
                for(int j = 0; j < Board.Columns; j++)
                {
                    if (mat[i,j])
                    {
                        return true; // Se houver algum movimento possível, retorna true
                    }
                }
            }
            return false; // Se não, retorna false
        }

        // Função que auxilia na verificação de posições
        public bool CanMoveTo(Position pos)
        {
            return PossibleMovements()[pos.Line, pos.Column]; // Retorna se eu posso me mover pra posição mencionada
        }

        // Retorna uma matriz com os movimentos possíveis a serem feitos
        // É algo que difere de peça por peça, então é um método abstrato
        public abstract bool[,] PossibleMovements();


    }
}
