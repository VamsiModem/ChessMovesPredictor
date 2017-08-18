using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoard.Core
{
    
    public class ChessMovesPredictor
    {
        private int max = (int)NumberProperties.Max;  //Represents the maximun number for rows and columns
        private int min = (int)NumberProperties.Min; //Represents the minimum number for rows and columns

        /// <summary>
        /// Gets the possible moves of knight 
        /// </summary>
        /// <param name="currentPosition">Current position of Knight</param>
        /// <returns>Possible moves as string[]</returns>
        public string[] GetKnightMoves(Position currentPosition)
        {
            int alphabetInt = (int) currentPosition.Y;
            string[] possibleMoves = new string[8];
            if ((currentPosition.X >= 1 && currentPosition.X <= 8) && (alphabetInt >=1 && alphabetInt <= 8))
            {
                int[,] offsets = new int[,]
                {
                    {1,2}, {2,1}, {-2,1}, {-1,-2}, {1,-2}, {2,-1}, {-2,-1}, {-1,2}
                };
                for (int i = 0; i < (offsets.Length / offsets.Rank); i++)
                {
                    int y = offsets[i, 0];
                    int x = offsets[i, 1];
                    Alphabets calculatedAlphabet = currentPosition.Y + (y);
                    int calculatedNumber = currentPosition.X + (x);
                    if (Enum.IsDefined(typeof(Alphabets), calculatedAlphabet) &&
                        calculatedNumber <= this.max && calculatedNumber >= this.min)
                    {
                        possibleMoves[i] = calculatedAlphabet.ToString() + calculatedNumber.ToString();
                    }
                }
                possibleMoves = Array.FindAll(possibleMoves, z => z != null);
            }
            else
            {
                throw new NotImplementedException();
            }
            
            return possibleMoves;
        }

        /// <summary>
        /// Gets the possible moves of Rook 
        /// </summary>
        /// <param name="currentPosition"></param>
        /// <returns>Possible moves as string[]</returns>
        public string[] GetRookMoves(Position currentPosition)
        {
            string[] possibleMoves = new string[4];
            int alphabetInt = (int)currentPosition.Y;
            if ((currentPosition.X >= 1 && currentPosition.X <= 8) && (alphabetInt >= 1 && alphabetInt <= 8))
            {
                possibleMoves[0] = currentPosition.Y.ToString() + this.max.ToString(); //top
                possibleMoves[1] = currentPosition.Y.ToString() + this.min.ToString(); //bottom
                possibleMoves[2] = ((Alphabets) this.min).ToString() + currentPosition.X.ToString(); //left
                possibleMoves[3] = ((Alphabets) this.max).ToString() + currentPosition.X; // right
                possibleMoves = FilterInvalidMoves(possibleMoves, currentPosition);
            }
            else
            {
                throw new NotImplementedException();
            }
            return possibleMoves;
        }

        /// <summary>
        /// Gets the possible moves of Bishop 
        /// </summary>
        /// <param name="currentPosition"></param>
        /// <returns>Possible moves as string[]</returns>
        public string[] GetBishopMoves(Position currentPosition)
        {
            string[] possibleMoves = new string[4];
            int alphabetInt = (int)currentPosition.Y;
            Position temPosition;
            if ((currentPosition.X >= 1 && currentPosition.X <= 8) && (alphabetInt >= 1 && alphabetInt <= 8))
            {
                temPosition = new Position(currentPosition.X, currentPosition.Y);
                //TopRight
                while (!(temPosition.Y.Equals((Alphabets) this.max) || temPosition.X == this.max))
                {
                    temPosition.X += 1;
                    temPosition.Y += 1;
                }
                possibleMoves[0] = temPosition.GetPositionAsString();
                //BottomLeft
                temPosition = new Position(currentPosition.X, currentPosition.Y);
                while (!(temPosition.Y.Equals((Alphabets) this.min) || temPosition.X == this.min))
                {
                    temPosition.X -= 1;
                    temPosition.Y -= 1;
                }
                possibleMoves[1] = temPosition.GetPositionAsString();
                //BottomRight
                temPosition = new Position(currentPosition.X, currentPosition.Y);
                while (!(temPosition.Y.Equals((Alphabets) this.max) || temPosition.X == this.min))
                {
                    temPosition.X -= 1;
                    temPosition.Y += 1;
                }
                possibleMoves[2] = temPosition.GetPositionAsString();
                //TopLeft
                temPosition = new Position(currentPosition.X, currentPosition.Y);
                while (!(temPosition.Y.Equals((Alphabets) this.min) || temPosition.X == this.max))
                {
                    temPosition.X += 1;
                    temPosition.Y -= 1;
                }
                possibleMoves[3] = temPosition.GetPositionAsString();
                possibleMoves = FilterInvalidMoves(possibleMoves, currentPosition);
            }
            else
            {
                throw new NotImplementedException();
            }
            return possibleMoves;
        }

        /// <summary>
        /// Gets the possible moves of Queen
        /// </summary>
        /// <param name="currentPosition"></param>
        /// <returns>Possible moves as string[]</returns>
        public string[] GetQueenMoves(Position currentPosition)
        {
            string[] queenMoves = new string[8];
            string[] rookMoves = GetRookMoves(currentPosition);
            string[] bishopMoves = GetBishopMoves(currentPosition);
            rookMoves.CopyTo(queenMoves, 0);
            for (int i = 0; i < bishopMoves.Length; i++)
            {
                if (Array.BinarySearch(bishopMoves, currentPosition.GetPositionAsString()) < 0)
                {
                    queenMoves[i + rookMoves.Length] = bishopMoves[i];
                }
            }
            queenMoves = Array.FindAll(queenMoves, z => z != null);
            queenMoves = FilterInvalidMoves(queenMoves, currentPosition);
            return queenMoves;
        }

        /// <summary>
        /// Prints all the possible moves to console
        /// </summary>
        /// <param name="moves"></param>
        public void PrintPossibleMoves(string[] moves)
        {
            string result = moves[0];
            for (int i = 1; i < moves.Length; i++)
            {
                if (moves[i] != null)
                {
                    result += " , " + moves[i];

                }
            }
            Console.WriteLine(result);
        }

        /// <summary>
        /// Removes all the null values and positions that are equal to current position
        /// </summary>
        /// <param name="moves"></param>
        /// <param name="currentPosition"></param>
        /// <returns></returns>
        private string[] FilterInvalidMoves(string[] moves, Position currentPosition)
        {
            for (int i = 0; i < moves.Length; i++)
            {
                if (moves[i].Equals(currentPosition.GetPositionAsString()))
                {
                    moves[i] = null;
                }
            }
            return Array.FindAll(moves, z => z != null);
        }
    }
}
