using System.Collections.Generic;
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

        private HashSet<Piece> pieces;
        private HashSet<Piece> capturatedPieces;
        public bool Check { get; private set; }

        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            Check = false;

            pieces = new HashSet<Piece>();
            capturatedPieces = new HashSet<Piece>();

            Finished = false;
            PlacePieces();

        }

        // Função responsável por executar o movimento do jogador
        public Piece PerformMovement(Position origin, Position destiny)
        {
            Piece p = Board.WithdrawPiece(origin); // Pego a peça na posição de origem
            p.IncreaseQuantityMovement(); // Aumento a quantidade de movimentos

            Piece capturedPiece = Board.WithdrawPiece(destiny); // Pego a peça capturada se houver

            Board.SetBoardPiece(p, destiny); // Coloco a peça na pos origem na pos destino

            if(capturedPiece != null)
            {
                capturatedPieces.Add(capturedPiece);
            }
            return capturedPiece;
        }

        public void UndoMove(Position origin, Position destiny, Piece capturatedPiece)
        {
            Piece p = Board.WithdrawPiece(destiny);

            p.DecreaseQuantityMovement();
            if(capturatedPiece != null)
            {
                Board.SetBoardPiece(capturatedPiece, destiny);
                capturatedPieces.Remove(capturatedPiece);
            }
            Board.SetBoardPiece(p, origin);

        } 

        // Função utilizada no movimento do jogador
        public void MakeMovement(Position origin, Position destiny)
        {
            Piece capturatedPiece = PerformMovement(origin, destiny);
            if (IsInCheck(CurrentPlayer))  
            {
               
                UndoMove(origin, destiny, capturatedPiece);
                throw new BoardException("Você não pode se colocar em Check");
            }
            if (IsInCheck(Adversary(CurrentPlayer)))
            {
               
                Check = true;
            }
            else
            {
                Check = false;
            }

            Turn++; // Passa um turno
            ChangePlayer(); // Muda qual jogador está jogando
        }

        // Função responsável por validar uma posição origem
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

        // Função responsável por validar a posição de destino
        public void ValidadeDestinationPosition(Position origin, Position destiny)
        {
            if(!Board.GetBoardPiece(origin).CanMoveTo(destiny))
            {
                throw new BoardException("Posição de destino inválida!");
            }
        }

        // Função responsável por mudar o player atual
        private void ChangePlayer()
        {
            if (CurrentPlayer == Color.White) CurrentPlayer = Color.Black;
            else CurrentPlayer = Color.White;
        }

        public void PlaceNewPiece(char column, int line, Piece p)
        {
            Board.SetBoardPiece(p, new ChessPosition(column, line).ToPosition());
            pieces.Add(p);
        }


        public HashSet<Piece> GetOnGamePieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();

            foreach (Piece p in pieces)
            {
                if (p.Color == color) aux.Add(p);

            }
            aux.ExceptWith(GetCapturatedPieces(color));

            return aux;
        }

        // Retorna a cor adversária
        private Color Adversary(Color color)
        {
            if (color == Color.White) return Color.Black;
            else return Color.White;
        }


        public bool IsInCheck(Color color)
        {
            Piece k = GetKing(color);
            if(k == null)
            {
                throw new BoardException($"Não há rei da cor {color} no tabuleiro!");
            }

            foreach (Piece p in GetOnGamePieces(Adversary(color)))
            {
                bool[,] mat = p.PossibleMovements();
                if (mat[k.Position.Line, k.Position.Column])
                {
                    return true;
                }
            }
            return false;
        }

        private Piece GetKing(Color color)
        {
            foreach (Piece p in GetOnGamePieces(color))
            {

                if(p is King)
                {
                    
                    return p;
                }

            }
            
            return null;
        }

        public HashSet<Piece> GetCapturatedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();

            foreach (Piece p in capturatedPieces)
            {
                if (p.Color == color) aux.Add(p);

            }

            return aux;
        }



        // Inicializando as peças do jogo
        private void PlacePieces()
        {
            PlaceNewPiece('c', 1, new Tower(Board, Color.White));
            PlaceNewPiece('c', 2, new Tower(Board, Color.White));
            PlaceNewPiece('d', 2, new Tower(Board, Color.White));
            PlaceNewPiece('e', 2, new Tower(Board, Color.White));
            PlaceNewPiece('e', 1, new Tower(Board, Color.White));
            PlaceNewPiece('d', 1, new King(Board, Color.White));

            PlaceNewPiece('c', 7, new Tower(Board, Color.Black));
            PlaceNewPiece('c', 8, new Tower(Board, Color.Black));
            PlaceNewPiece('d', 7, new Tower(Board, Color.Black));
            PlaceNewPiece('e', 7, new Tower(Board, Color.Black));
            PlaceNewPiece('e', 8, new Tower(Board, Color.Black));
            PlaceNewPiece('d', 8, new  King(Board, Color.Black));

        }

    }
}
