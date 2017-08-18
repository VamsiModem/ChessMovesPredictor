using System;
using System.IO;
using NUnit.Framework;
using ChessBoard.Core;
using NUnit.Framework.Internal;

namespace ChessBoard.Tests
{
    [TestFixture]
    public class ChessMovesPredictorTest
    {
        [TestCase(Alphabets.d, 5, ExpectedResult = new string[]{ "e7", "f6", "b6", "c3", "e3", "f4", "b4", "c7" })]
        [TestCase(Alphabets.a, 8, ExpectedResult = new string[] { "b6", "c7" })]
        [TestCase(Alphabets.e, 1, ExpectedResult = new string[] { "f3", "g2", "c2", "d3" })]
        [TestCase(Alphabets.g, 5, ExpectedResult = new string[] { "h7", "e6", "f3", "h3", "e4", "f7"})]
        [TestCase(Alphabets.f, 5, ExpectedResult = new string[] { "g7", "h6", "d6", "e3", "g3", "h4", "d4", "e7" })]
        [TestCase(Alphabets.b, 7, ExpectedResult = new string[] { "d8", "a5", "c5", "d6" })]
        [TestCase(Alphabets.g, 1, ExpectedResult = new string[] { "h3", "e2", "f3" })]
        [Test]
        public string[] PossibleMovesForKnight(Alphabets alphabet, int positionX)
        {
            ChessMovesPredictor chessMovesPredictor = new ChessMovesPredictor();
            Position currentPosition = new Position(positionX, alphabet);
            return chessMovesPredictor.GetKnightMoves(currentPosition);
        }

        [TestCase(Alphabets.g+10, 1)]
        [TestCase(Alphabets.g, 10)]
        [TestCase(Alphabets.g+10, 12)]
        public void PossibleMovesForKnightThrowsException(Alphabets alphabet, int positionX)
        {
            ChessMovesPredictor chessMovesPredictor = new ChessMovesPredictor();
            Position currentPosition = new Position(positionX, alphabet);
            Assert.That(() => chessMovesPredictor.GetKnightMoves(currentPosition), Throws.TypeOf<NotImplementedException>());
        }

        [TestCase(Alphabets.d, 5, ExpectedResult = new string[] { "d8", "d1", "a5", "h5" })]
        [TestCase(Alphabets.a, 8, ExpectedResult = new string[] { "a1", "h8" })]
        [TestCase(Alphabets.e, 1, ExpectedResult = new string[] { "e8","a1", "h1" })]
        [TestCase(Alphabets.g, 5, ExpectedResult = new string[] { "g8", "g1", "a5", "h5"})]
        [TestCase(Alphabets.f, 5, ExpectedResult = new string[] { "f8", "f1", "a5", "h5"})]
        [TestCase(Alphabets.b, 7, ExpectedResult = new string[] { "b8", "b1", "a7", "h7" })]
        [TestCase(Alphabets.g, 1, ExpectedResult = new string[] { "g8", "a1", "h1" })]
        [Test]
        public string[] PossibleMovesForRook(Alphabets alphabet, int positionX)
        {
            ChessMovesPredictor chessMovesPredictor = new ChessMovesPredictor();
            Position currentPosition = new Position(positionX, alphabet);
            return chessMovesPredictor.GetRookMoves(currentPosition);
        }

        [TestCase(Alphabets.g + 10, 1)]
        [TestCase(Alphabets.g, 10)]
        [TestCase(Alphabets.g + 10, 12)]
        public void PossibleMovesForRookThrowsException(Alphabets alphabet, int positionX)
        {
            ChessMovesPredictor chessMovesPredictor = new ChessMovesPredictor();
            Position currentPosition = new Position(positionX, alphabet);
            Assert.That(() => chessMovesPredictor.GetRookMoves(currentPosition), Throws.TypeOf<NotImplementedException>());
        }

        [TestCase(Alphabets.d, 5, ExpectedResult = new string[] { "g8", "a2", "h1", "a8" })]
        [TestCase(Alphabets.a, 8, ExpectedResult = new string[] { "h1" })]
        [TestCase(Alphabets.e, 1, ExpectedResult = new string[] { "h4", "a5" })]
        [TestCase(Alphabets.g, 5, ExpectedResult = new string[] { "h6", "c1", "h4", "d8" })]
        [TestCase(Alphabets.f, 5, ExpectedResult = new string[] { "h7", "b1", "h3", "c8" })]
        [TestCase(Alphabets.b, 7, ExpectedResult = new string[] { "c8", "a6", "h1", "a8" })]
        [TestCase(Alphabets.g, 1, ExpectedResult = new string[] { "h2", "a7" })]
        [Test]
        public string[] PossibleMovesForBishop(Alphabets alphabet, int positionX)
        {
            ChessMovesPredictor chessMovesPredictor = new ChessMovesPredictor();
            Position currentPosition = new Position(positionX, alphabet);
            return chessMovesPredictor.GetBishopMoves(currentPosition);
        }

        [TestCase(Alphabets.g + 10, 1)]
        [TestCase(Alphabets.g, 10)]
        [TestCase(Alphabets.g + 10, 12)]
        public void PossibleMovesForBishopThrowsException(Alphabets alphabet, int positionX)
        {
            ChessMovesPredictor chessMovesPredictor = new ChessMovesPredictor();
            Position currentPosition = new Position(positionX, alphabet);
            Assert.That(() => chessMovesPredictor.GetBishopMoves(currentPosition), Throws.TypeOf<NotImplementedException>());
        }

        [TestCase(Alphabets.d, 5, ExpectedResult = new string[] { "d8", "d1", "a5", "h5", "g8", "a2", "h1", "a8" })]
        [TestCase(Alphabets.a, 8, ExpectedResult = new string[] { "a1", "h8", "h1" })]
        [TestCase(Alphabets.e, 1, ExpectedResult = new string[] { "e8", "a1", "h1", "h4", "a5" })]
        [TestCase(Alphabets.g, 5, ExpectedResult = new string[] { "g8", "g1", "a5", "h5", "h6", "c1", "h4", "d8" })]
        [TestCase(Alphabets.f, 5, ExpectedResult = new string[] { "f8", "f1", "a5", "h5", "h7", "b1", "h3", "c8" })]
        [TestCase(Alphabets.b, 7, ExpectedResult = new string[] { "b8", "b1", "a7", "h7", "c8", "a6", "h1", "a8" })]
        [TestCase(Alphabets.g, 1, ExpectedResult = new string[] { "g8", "a1", "h1", "h2", "a7" })]
        [Test]
        public string[] PossibleMovesForQueen(Alphabets alphabet, int positionX)
        {
            ChessMovesPredictor chessMovesPredictor = new ChessMovesPredictor();
            Position currentPosition = new Position(positionX, alphabet);
            return chessMovesPredictor.GetQueenMoves(currentPosition);
        }

        [TestCase(Alphabets.g + 10, 1)]
        [TestCase(Alphabets.g, 10)]
        [TestCase(Alphabets.g + 10, 12)]
        public void PossibleMovesForQueenThrowsException(Alphabets alphabet, int positionX)
        {
            ChessMovesPredictor chessMovesPredictor = new ChessMovesPredictor();
            Position currentPosition = new Position(positionX, alphabet);
            Assert.That(() => chessMovesPredictor.GetQueenMoves(currentPosition), Throws.TypeOf<NotImplementedException>());
        }
    }
}
