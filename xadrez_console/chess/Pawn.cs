using System;
using enums;
using board;

namespace chess
{
    class Pawn : Piece
    {

        public Pawn(Board board, Color color) : base(board, color) { }

        public override string ToString()
        {
            return "P";
        }


        private bool EnemyExists(Position pos)
        {
            Piece p = Board.GetBoardPiece(pos);
            return p != null && p.Color != Color;
        }

        private bool Free(Position pos)
        {
            return Board.GetBoardPiece(pos) == null;
        }

        // Função que verifica que posso mover para alguma posição específica
        private bool CanMove(Position pos)
        {
            Piece p = Board.GetBoardPiece(pos);

            return p == null || p.Color != Color;

        }

        // Criando os movimentos possíveis do Rei
        public override bool[,] PossibleMovements()
        {
            // Matriz de movimentos possíveis
            bool[,] mat = new bool[Board.Lines, Board.Columns];

            // Posição a ser verificada
            Position pos = new Position(0,0);

            if(Color == Color.White)
            {
                pos.DefineValues(Position.Line - 1, Position.Column);
                if (Board.ValidPosition(pos) && CanMove(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.DefineValues(Position.Line - 2, Position.Column);
                if (Board.ValidPosition(pos) && CanMove(pos) && QntMovements == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.DefineValues(Position.Line - 1, Position.Column - 1);
                if (Board.ValidPosition(pos) && EnemyExists(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.DefineValues(Position.Line - 1, Position.Column + 1);
                if (Board.ValidPosition(pos) && EnemyExists(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
            }
            else
            {
                pos.DefineValues(Position.Line + 1, Position.Column);
                if (Board.ValidPosition(pos) && CanMove(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.DefineValues(Position.Line + 2, Position.Column);
                if (Board.ValidPosition(pos) && CanMove(pos) && QntMovements == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.DefineValues(Position.Line + 1, Position.Column - 1);
                if (Board.ValidPosition(pos) && EnemyExists(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.DefineValues(Position.Line + 1, Position.Column + 1);
                if (Board.ValidPosition(pos) && EnemyExists(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }


            }



            
            

           

            return mat; // Retorna a matriz de movimentos possíveis
        }


    }
}
