using System;

namespace ConnectFour
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectFourPiece[,] gameBoard = new ConnectFourPiece[6, 7];
            for (int x = 0; x < gameBoard.GetLength(0); x++)
            {
                for (int y = 0; y < gameBoard.GetLength(1); y++)
                {
                    gameBoard[x, y] = new ConnectFourPiece(x, y);
                }
            }
            for (int x = 0; x < gameBoard.GetLength(0); x++)
            {
                for (int y = 0; y < gameBoard.GetLength(1); y++)
                {
                    Console.Write(gameBoard[x, y].PieceType + "|");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
