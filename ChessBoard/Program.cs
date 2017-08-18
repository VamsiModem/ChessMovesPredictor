using System;


namespace ChessBoard.Core
{
    class Program
    {
        private static int positionX;
        private static Alphabets alphabet;
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a piece name [knight, rook, bishop, queen] and current position [a-h][1-8]\nExample: knight d5");
            string[] input = Console.ReadLine().Split(' ');
            while (!IsValidInput(input))
            {
                Console.WriteLine("Please choose a piece in [knight, rook, bishop, queen] and current position in format 'd3' alphabet can range from [a-h] and numbers [1-8]");
                input = Console.ReadLine().Split(' ');
            }
            string piece = input[0].ToLower();
            PrintMoves(piece);
            Console.ReadLine();
        }

        /// <summary>
        /// Prints all the possible moves by calling the approriate function by piece
        /// </summary>
        /// <param name="piece"></param>
        private static void PrintMoves(string piece)
        {
            ChessMovesPredictor chessMovesPredictor = new ChessMovesPredictor();
            Position currentPosition = new Position(positionX, alphabet);
            string[] moves;
            switch (piece)
            {
                case "bishop":
                    moves = chessMovesPredictor.GetBishopMoves(currentPosition);
                    chessMovesPredictor.PrintPossibleMoves(moves);
                    break;
                case "rook":
                    moves = chessMovesPredictor.GetRookMoves(currentPosition);
                    chessMovesPredictor.PrintPossibleMoves(moves);
                    break;
                case "queen":
                    moves = chessMovesPredictor.GetQueenMoves(currentPosition);
                    chessMovesPredictor.PrintPossibleMoves(moves);
                    break;
                case "knight":
                    moves = chessMovesPredictor.GetKnightMoves(currentPosition);
                    chessMovesPredictor.PrintPossibleMoves(moves);
                    break;
            }
        }

        /// <summary>
        /// Checks if the provided input is valid oor not
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        private static bool IsValidInput(string[] input)
        {
            bool isValid = false;

            if (input.Length == 2)
            {
                string piece = input[0].ToLower();
                string currentPosition = input[1].ToLower();
                if (piece.Equals("knight") || piece.Equals("rook") || piece.Equals("bishop") || piece.Equals("queen"))
                {
                    if (currentPosition.Length == 2)
                    {
                        if (Enum.TryParse(currentPosition[0].ToString(), true, out alphabet))
                        {
                            positionX = Convert.ToInt32(currentPosition[1].ToString());
                            if (positionX >= 1 && positionX <= 8)
                            {
                                isValid = true;
                            }
                        }
                    }
                }
            }
            return isValid;
        }
    }
}
