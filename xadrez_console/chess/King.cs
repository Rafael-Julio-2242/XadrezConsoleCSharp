using System;
using enums;
using board;

namespace chess
{
    class King : Piece
    {
        private ChessMatch match;
        public King(Board board, Color color, ChessMatch match) : base(board, color) 
        {
            this.match = match;
        }

        public override string ToString()
        {
            return "R";
        }

        // Função que verifica que posso mover para alguma posição específica
        private bool CanMove(Position pos)
        {
            Piece p = Board.GetBoardPiece(pos);

            return p == null || p.Color != Color;

        }

        private bool testTowerRock (Position pos)
        {
            Piece p = Board.GetBoardPiece (pos);
            return p != null && p is Tower && p.Color == Color && p.QntMovements == 0;


        }

        // Criando os movimentos possíveis do Rei
        public override bool[,] PossibleMovements()
        {
            // Matriz de movimentos possíveis
            bool[,] mat = new bool[Board.Lines, Board.Columns];

            // Posição a ser verificada
            Position pos = new Position(0,0);

            // acima
            pos.DefineValues(Position.Line - 1, Position.Column);  
            if(Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // ne
            pos.DefineValues(Position.Line - 1, Position.Column + 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // direita
            pos.DefineValues(Position.Line, Position.Column + 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }


            // se
            pos.DefineValues(Position.Line + 1, Position.Column + 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // abaixo
            pos.DefineValues(Position.Line + 1, Position.Column);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // so
            pos.DefineValues(Position.Line + 1, Position.Column - 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // esquerda
            pos.DefineValues(Position.Line, Position.Column - 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // no
            pos.DefineValues(Position.Line - 1, Position.Column - 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }


            // #JogadaEspecial roque
            if (QntMovements == 0 && !match.Check)
            {   // Roque pequeno
                Position tpos1 = new Position(Position.Line, Position.Column + 3);
                if(testTowerRock(tpos1))
                {
                    Position p1 = new Position(Position.Line, Position.Column + 1);
                    Position p2 = new Position(Position.Line, Position.Column + 2);
                    if(Board.GetBoardPiece(p1) == null && Board.GetBoardPiece(p2) == null)
                    {
                        mat[Position.Line, Position.Column + 2] = true;
                    }

                }

                // Roque Grande
                Position tpos2 = new Position(Position.Line, Position.Column - 4);
                if (testTowerRock(tpos2))
                {
                    Position p1 = new Position(Position.Line, Position.Column - 1);
                    Position p2 = new Position(Position.Line, Position.Column - 2);
                    Position p3 = new Position(Position.Line, Position.Column - 3);
                    if (Board.GetBoardPiece(p1) == null && Board.GetBoardPiece(p2) == null && Board.GetBoardPiece(p3) == null)
                    {
                        mat[Position.Line, Position.Column - 2] = true;
                    }

                }




            }




            // #JogadaEspecial roque

            return mat; // Retorna a matriz de movimentos possíveis
        }


    }
}
