using System;
using enums;
using board;
using board.exceptions;

namespace chess
{
    class ChessMatch
    {
        public Board Board { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Finished { get; private set; }

        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            PlacePieces();
            Finished = false;
        }

        public void PerformMovement(Position origin, Position destiny)
        {
            Piece p = Board.WithdrawPiece(origin);
            p.IncreaseQuantityMovement();

            Piece capturedPiece = Board.WithdrawPiece(destiny);

            Board.SetBoardPiece(p, destiny);

        }

        public void MakeMovement(Position origin, Position destiny)
        {
            PerformMovement(origin, destiny);
            Turn++;
            ChangePlayer();
        }

        public void ValidadeOriginPosition(Position pos)
        {
            if (Board.GetBoardPiece(pos) == null)
            {
                throw new BoardException("Não existe peça na posição origem escolhida! ");
            }
            if(CurrentPlayer != Board.GetBoardPiece(pos).Color)
            {
                throw new BoardException("A peça de Origem escolhida não é sua");
            }
            if(!Board.GetBoardPiece(pos).IsMovementPossible())
            {
                throw new BoardException("Nao existem movimentos possíveis para essa peça");
            }
        }

        public void ValidadeDestinationPosition(Position origin, Position destiny)
        {
            if(!Board.GetBoardPiece(origin).CanMoveTo(destiny))
            {
                throw new BoardException("Posição de destino inválida!");
            }
        }

        private void ChangePlayer()
        {
            if (CurrentPlayer == Color.White) CurrentPlayer = Color.Black;
            else CurrentPlayer = Color.White;
        }

        // Inicializando as peças
        private void PlacePieces()
        {
            Board.SetBoardPiece(new Tower(Board, Color.White), new ChessPosition('c', 1).ToPosition());
            Board.SetBoardPiece(new Tower(Board, Color.White), new ChessPosition('c', 2).ToPosition());
            Board.SetBoardPiece(new Tower(Board, Color.White), new ChessPosition('d', 2).ToPosition());
            Board.SetBoardPiece(new Tower(Board, Color.White), new ChessPosition('e', 2).ToPosition());
            Board.SetBoardPiece(new Tower(Board, Color.White), new ChessPosition('e', 1).ToPosition());
            Board.SetBoardPiece(new King(Board, Color.White), new ChessPosition('d', 1).ToPosition());


            Board.SetBoardPiece(new Tower(Board, Color.Black), new ChessPosition('c', 7).ToPosition());
            Board.SetBoardPiece(new Tower(Board, Color.Black), new ChessPosition('c', 8).ToPosition());
            Board.SetBoardPiece(new Tower(Board, Color.Black), new ChessPosition('d', 7).ToPosition());
            Board.SetBoardPiece(new Tower(Board, Color.Black), new ChessPosition('e', 7).ToPosition());
            Board.SetBoardPiece(new Tower(Board, Color.Black), new ChessPosition('e', 8).ToPosition());
            Board.SetBoardPiece(new King(Board, Color.Black), new ChessPosition('d', 8).ToPosition());

        }

    }
}
