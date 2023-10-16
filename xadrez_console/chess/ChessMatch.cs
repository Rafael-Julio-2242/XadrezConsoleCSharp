using System;
using enums;
using board;
namespace chess
{
    class ChessMatch
    {
        public Board Board { get; private set; }
        private int turn;
        private Color currentPlayer;
        public bool Finished { get; private set; }  

        public ChessMatch()
        {
            Board = new Board(8,8);
            turn = 1;
            currentPlayer = Color.White;
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
        // Inicializando as peças
        private void PlacePieces()
        {
            Board.SetBoardPiece(new Tower(Board, Color.White), new ChessPosition('c',1).ToPosition());
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
            Board.SetBoardPiece(new King (Board, Color.Black), new ChessPosition('d', 8).ToPosition());

        }

    }
}
