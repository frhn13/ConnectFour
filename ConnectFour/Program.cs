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
            String winner = " ";
            
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
                    columnPlaced = Convert.ToInt32(Console.ReadLine()) - 1;
                    for (int x = gameBoard.GetLength(0) - 1; x >= 0; x--)
                    {
                        if (gameBoard[x, columnPlaced].PieceType == " ")
                        {
                            gameBoard[x, columnPlaced].PieceType = currentPlayer;
                            currentPlayer = (currentPlayer == "R") ? "B" : "R";
                            winner = FindWinner(gameBoard, gameBoard[x, columnPlaced]);
                            if (winner != " ")
                                gameWon = true;
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
            if (winner == "R")
                Console.WriteLine("Red has won!");
            else if (winner == "B")
                Console.WriteLine("Blue has won!");
            else
                Console.WriteLine("No one has won!");
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
        static String FindWinner(ConnectFourPiece[,] gameBoard, ConnectFourPiece piecePlaced)
        {
            Console.WriteLine($"{piecePlaced.PieceType} {piecePlaced.XCoordinate} {piecePlaced.YCoordinate}");
            if (piecePlaced.XCoordinate <= 3 &&
                piecePlaced.PieceType == gameBoard[piecePlaced.XCoordinate + 1, piecePlaced.YCoordinate].PieceType &&
                piecePlaced.PieceType == gameBoard[piecePlaced.XCoordinate + 2, piecePlaced.YCoordinate].PieceType &&
                piecePlaced.PieceType == gameBoard[piecePlaced.XCoordinate + 3, piecePlaced.YCoordinate].PieceType)
            {
                return piecePlaced.PieceType;
            }
            if (piecePlaced.YCoordinate <= 4)
            {
                if (piecePlaced.PieceType == gameBoard[piecePlaced.XCoordinate, piecePlaced.YCoordinate + 1].PieceType &&
                piecePlaced.PieceType == gameBoard[piecePlaced.XCoordinate, piecePlaced.YCoordinate + 2].PieceType &&
                piecePlaced.PieceType == gameBoard[piecePlaced.XCoordinate, piecePlaced.YCoordinate + 3].PieceType)
                  {
                    return piecePlaced.PieceType;
                }
            }
            if (piecePlaced.YCoordinate <= 5 && piecePlaced.YCoordinate >= 1)
            {
                if (piecePlaced.PieceType == gameBoard[piecePlaced.XCoordinate, piecePlaced.YCoordinate - 1].PieceType &&
                piecePlaced.PieceType == gameBoard[piecePlaced.XCoordinate, piecePlaced.YCoordinate + 1].PieceType &&
                piecePlaced.PieceType == gameBoard[piecePlaced.XCoordinate, piecePlaced.YCoordinate + 2].PieceType)
                {
                    return piecePlaced.PieceType;
                }
            }
            if (piecePlaced.YCoordinate <= 6 && piecePlaced.YCoordinate >= 2)
            {
                if (piecePlaced.PieceType == gameBoard[piecePlaced.XCoordinate, piecePlaced.YCoordinate - 2].PieceType &&
                piecePlaced.PieceType == gameBoard[piecePlaced.XCoordinate, piecePlaced.YCoordinate - 1].PieceType &&
                piecePlaced.PieceType == gameBoard[piecePlaced.XCoordinate, piecePlaced.YCoordinate + 1].PieceType)
                {
                    return piecePlaced.PieceType;
                }
            }
            if (piecePlaced.YCoordinate >= 3)
            {
                if (piecePlaced.PieceType == gameBoard[piecePlaced.XCoordinate, piecePlaced.YCoordinate - 3].PieceType &&
                piecePlaced.PieceType == gameBoard[piecePlaced.XCoordinate, piecePlaced.YCoordinate - 2].PieceType &&
                piecePlaced.PieceType == gameBoard[piecePlaced.XCoordinate, piecePlaced.YCoordinate - 1].PieceType)
                {
                    return piecePlaced.PieceType;
                }
            }
            if (piecePlaced.XCoordinate <= 3 && piecePlaced.YCoordinate <= 4)
            {
                if (piecePlaced.PieceType == gameBoard[piecePlaced.XCoordinate + 1, piecePlaced.YCoordinate + 1].PieceType &&
                piecePlaced.PieceType == gameBoard[piecePlaced.XCoordinate + 2, piecePlaced.YCoordinate + 2].PieceType &&
                piecePlaced.PieceType == gameBoard[piecePlaced.XCoordinate + 3, piecePlaced.YCoordinate + 3].PieceType)
                {
                    return piecePlaced.PieceType;
                }
            }
            if (piecePlaced.XCoordinate <= 4 && piecePlaced.XCoordinate >= 1 && piecePlaced.YCoordinate <= 5 && piecePlaced.YCoordinate >= 1)
            {
                if (piecePlaced.PieceType == gameBoard[piecePlaced.XCoordinate - 1, piecePlaced.YCoordinate - 1].PieceType &&
                piecePlaced.PieceType == gameBoard[piecePlaced.XCoordinate + 1, piecePlaced.YCoordinate + 1].PieceType &&
                piecePlaced.PieceType == gameBoard[piecePlaced.XCoordinate + 2, piecePlaced.YCoordinate + 2].PieceType)
                {
                    return piecePlaced.PieceType;
                }
            }
            if (piecePlaced.XCoordinate <= 5 && piecePlaced.XCoordinate >= 2 && piecePlaced.YCoordinate <= 6 && piecePlaced.YCoordinate >= 2)
            {
                if (piecePlaced.PieceType == gameBoard[piecePlaced.XCoordinate - 1, piecePlaced.YCoordinate - 1].PieceType &&
                piecePlaced.PieceType == gameBoard[piecePlaced.XCoordinate - 2, piecePlaced.YCoordinate - 2].PieceType &&
                piecePlaced.PieceType == gameBoard[piecePlaced.XCoordinate + 1, piecePlaced.YCoordinate + 1].PieceType)
                {
                    return piecePlaced.PieceType;
                }
            }
            if (piecePlaced.XCoordinate >= 3 && piecePlaced.YCoordinate >= 3)
            {
                if (piecePlaced.PieceType == gameBoard[piecePlaced.XCoordinate - 1, piecePlaced.YCoordinate - 1].PieceType &&
                piecePlaced.PieceType == gameBoard[piecePlaced.XCoordinate - 2, piecePlaced.YCoordinate - 2].PieceType &&
                piecePlaced.PieceType == gameBoard[piecePlaced.XCoordinate - 3, piecePlaced.YCoordinate - 3].PieceType)
                {
                    return piecePlaced.PieceType;
                }
            }
            if (piecePlaced.XCoordinate >= 3 && piecePlaced.YCoordinate <= 4)
            {
                if (piecePlaced.PieceType == gameBoard[piecePlaced.XCoordinate - 1, piecePlaced.YCoordinate + 1].PieceType &&
                piecePlaced.PieceType == gameBoard[piecePlaced.XCoordinate - 2, piecePlaced.YCoordinate + 2].PieceType &&
                piecePlaced.PieceType == gameBoard[piecePlaced.XCoordinate - 3, piecePlaced.YCoordinate + 3].PieceType)
                {
                    return piecePlaced.PieceType;
                }
            }
            if (piecePlaced.XCoordinate <= 5 && piecePlaced.XCoordinate >= 2 && piecePlaced.YCoordinate <= 5 && piecePlaced.YCoordinate >= 1)
            {
                if (piecePlaced.PieceType == gameBoard[piecePlaced.XCoordinate + 1, piecePlaced.YCoordinate - 1].PieceType &&
                piecePlaced.PieceType == gameBoard[piecePlaced.XCoordinate - 1, piecePlaced.YCoordinate + 1].PieceType &&
                piecePlaced.PieceType == gameBoard[piecePlaced.XCoordinate - 2, piecePlaced.YCoordinate + 2].PieceType)
                {
                    return piecePlaced.PieceType;
                }
            }
            if (piecePlaced.XCoordinate <= 4 && piecePlaced.XCoordinate >= 1 && piecePlaced.YCoordinate <= 6 && piecePlaced.YCoordinate >= 2)
            {
                if (piecePlaced.PieceType == gameBoard[piecePlaced.XCoordinate + 2, piecePlaced.YCoordinate - 2].PieceType &&
                piecePlaced.PieceType == gameBoard[piecePlaced.XCoordinate + 1, piecePlaced.YCoordinate - 1].PieceType &&
                piecePlaced.PieceType == gameBoard[piecePlaced.XCoordinate - 1, piecePlaced.YCoordinate + 1].PieceType)
                {
                    return piecePlaced.PieceType;
                }
            }
            if (piecePlaced.XCoordinate <= 3 && piecePlaced.YCoordinate >= 3)
            {
                if (piecePlaced.PieceType == gameBoard[piecePlaced.XCoordinate + 3, piecePlaced.YCoordinate - 3].PieceType &&
                piecePlaced.PieceType == gameBoard[piecePlaced.XCoordinate + 2, piecePlaced.YCoordinate - 2].PieceType &&
                piecePlaced.PieceType == gameBoard[piecePlaced.XCoordinate + 1, piecePlaced.YCoordinate - 1].PieceType)
                {
                    return piecePlaced.PieceType;
                }
            }
            return " ";
        }
    }
}
