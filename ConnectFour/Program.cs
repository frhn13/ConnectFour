using System;

namespace ConnectFour
{
    class Program
    {
        static void Main(string[] args)
        {
            bool gameWon = false;
            String currentPlayer = "R";
            int columnPlaced;
            
            ConnectFourPiece[,] gameBoard = new ConnectFourPiece[6, 7];
            for (int x = 0; x < gameBoard.GetLength(0); x++)
            {
                for (int y = 0; y < gameBoard.GetLength(1); y++)
                {
                    gameBoard[x, y] = new ConnectFourPiece(x, y);
                }
            }
            while (!gameWon)
            {
                for (int x = 0; x < gameBoard.GetLength(0); x++)
                {
                    for (int y = 0; y < gameBoard.GetLength(1); y++)
                    {
                        Console.Write(gameBoard[x, y].PieceType + "|");
                    }
                    Console.WriteLine();
                }
                if (currentPlayer == "R")
                    Console.WriteLine("Red's turn");
                else
                    Console.WriteLine("Blue's turn");
                Console.WriteLine("Which column do you want to place the piece in?");
                try
                {
                    columnPlaced = Convert.ToInt32(Console.ReadLine());
                    for (int x = gameBoard.GetLength(0) - 1; x >= 0; x--)
                    {
                        if (gameBoard[x, columnPlaced].PieceType == " ")
                        {
                            gameBoard[x, columnPlaced].PieceType = currentPlayer;
                            currentPlayer = (currentPlayer == "R") ? "B" : "R";
                            break;
                        }
                        if (x == 0)
                            Console.WriteLine("No more spaces in that column, try again.");
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Please enter an integer as the column number.");
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine("The column number entered is too big or too small, try again.");
                }
                
            }
            Console.ReadKey();
        }
    }
}
