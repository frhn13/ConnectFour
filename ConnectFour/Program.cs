using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectFour
{
    class Program
    {
        static void Main(string[] args)
        {
            bool gameDone;
            String currentPlayer;
            int columnPlaced;
            String winner;
            String playAgainStr;
            String redPlayerName;
            String bluePlayerName;
            bool playAgain = true;
            bool spaceLeft;

            do
            {
                gameDone = false;
                winner = " ";
                currentPlayer = "R";
                Console.WriteLine("Do you want to view the previous winners of the game?");
                String viewWinner = Console.ReadLine();
                if (viewWinner.ToLower() == "yes" || viewWinner.ToLower() == "y")
                {
                    List<String> winners = Files.ReadFromFile();
                    Console.WriteLine();
                    foreach (String prevWinner in winners)
                    {
                        Console.WriteLine(prevWinner);
                    }
                }

                do
                {
                    Console.WriteLine("Who is the Red player?");
                    redPlayerName = Console.ReadLine();
                    Console.WriteLine("Who is the Blue player?");
                    bluePlayerName = Console.ReadLine();
                    if (redPlayerName == "" || bluePlayerName == "")
                        Console.WriteLine("Please enter a name for both players.");

                } while (redPlayerName == "" || bluePlayerName == "");

                ConnectFourPiece[,] gameBoard = new ConnectFourPiece[6, 7];
                for (int x = 0; x < gameBoard.GetLength(0); x++)
                {
                    for (int y = 0; y < gameBoard.GetLength(1); y++)
                    {
                        gameBoard[x, y] = new ConnectFourPiece(x, y);
                    }
                }
                while (!gameDone)
                {
                    spaceLeft = false;
                    Console.WriteLine();
                    for (int x = 0; x < gameBoard.GetLength(0); x++)
                    {
                        for (int y = 0; y < gameBoard.GetLength(1); y++)
                        {
                            if (y < gameBoard.GetLength(1) - 1)
                                Console.Write(gameBoard[x, y].PieceType + "|");
                            else
                                Console.Write(gameBoard[x, y].PieceType);
                        }
                        if (x < gameBoard.GetLength(0) - 1)
                            Console.WriteLine("\n-------------");
                    }
                    Console.WriteLine("\n1 2 3 4 5 6 7\n");
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
                                    gameDone = true;
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
                    foreach (ConnectFourPiece piece in gameBoard)
                    {
                        if (piece.PieceType == " ")
                            spaceLeft = true;
                    }
                    if (!spaceLeft)
                        gameDone = true;

                }
                if (winner == "R")
                {
                    Console.WriteLine("Red has won!");
                    Files.WriteToFile(redPlayerName);
                }
                else if (winner == "B")
                {
                    Console.WriteLine("Blue has won!");
                    Files.WriteToFile(bluePlayerName);
                }
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
                Console.WriteLine("Would you like to play again?");
                playAgainStr = Console.ReadLine();
                playAgain = playAgainStr.ToLower() == "yes" || playAgainStr.ToLower() == "y";
            } while (playAgain);  
            Console.ReadKey();
        }
        static String FindWinner(ConnectFourPiece[,] gameBoard, ConnectFourPiece piecePlaced)
        {
            if (piecePlaced.XCoordinate <= 2)
            {
                if (piecePlaced.PieceType == gameBoard[piecePlaced.XCoordinate + 1, piecePlaced.YCoordinate].PieceType &&
                piecePlaced.PieceType == gameBoard[piecePlaced.XCoordinate + 2, piecePlaced.YCoordinate].PieceType &&
                piecePlaced.PieceType == gameBoard[piecePlaced.XCoordinate + 3, piecePlaced.YCoordinate].PieceType)
                {
                    return piecePlaced.PieceType;
                }
            }
            if (piecePlaced.YCoordinate <= 3)
            {
                if (piecePlaced.PieceType == gameBoard[piecePlaced.XCoordinate, piecePlaced.YCoordinate + 1].PieceType &&
                piecePlaced.PieceType == gameBoard[piecePlaced.XCoordinate, piecePlaced.YCoordinate + 2].PieceType &&
                piecePlaced.PieceType == gameBoard[piecePlaced.XCoordinate, piecePlaced.YCoordinate + 3].PieceType)
                  {
                    return piecePlaced.PieceType;
                }
            }
            if (piecePlaced.YCoordinate <= 4 && piecePlaced.YCoordinate >= 1)
            {
                if (piecePlaced.PieceType == gameBoard[piecePlaced.XCoordinate, piecePlaced.YCoordinate - 1].PieceType &&
                piecePlaced.PieceType == gameBoard[piecePlaced.XCoordinate, piecePlaced.YCoordinate + 1].PieceType &&
                piecePlaced.PieceType == gameBoard[piecePlaced.XCoordinate, piecePlaced.YCoordinate + 2].PieceType)
                {
                    return piecePlaced.PieceType;
                }
            }
            if (piecePlaced.YCoordinate <= 5 && piecePlaced.YCoordinate >= 2)
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
            if (piecePlaced.XCoordinate <= 2 && piecePlaced.YCoordinate <= 3)
            {
                if (piecePlaced.PieceType == gameBoard[piecePlaced.XCoordinate + 1, piecePlaced.YCoordinate + 1].PieceType &&
                piecePlaced.PieceType == gameBoard[piecePlaced.XCoordinate + 2, piecePlaced.YCoordinate + 2].PieceType &&
                piecePlaced.PieceType == gameBoard[piecePlaced.XCoordinate + 3, piecePlaced.YCoordinate + 3].PieceType)
                {
                    return piecePlaced.PieceType;
                }
            }
            if (piecePlaced.XCoordinate <= 3 && piecePlaced.XCoordinate >= 1 && piecePlaced.YCoordinate <= 4 && piecePlaced.YCoordinate >= 1)
            {
                if (piecePlaced.PieceType == gameBoard[piecePlaced.XCoordinate - 1, piecePlaced.YCoordinate - 1].PieceType &&
                piecePlaced.PieceType == gameBoard[piecePlaced.XCoordinate + 1, piecePlaced.YCoordinate + 1].PieceType &&
                piecePlaced.PieceType == gameBoard[piecePlaced.XCoordinate + 2, piecePlaced.YCoordinate + 2].PieceType)
                {
                    return piecePlaced.PieceType;
                }
            }
            if (piecePlaced.XCoordinate <= 4 && piecePlaced.XCoordinate >= 2 && piecePlaced.YCoordinate <= 5 && piecePlaced.YCoordinate >= 2)
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
            if (piecePlaced.XCoordinate >= 3 && piecePlaced.YCoordinate <= 3)
            {
                if (piecePlaced.PieceType == gameBoard[piecePlaced.XCoordinate - 1, piecePlaced.YCoordinate + 1].PieceType &&
                piecePlaced.PieceType == gameBoard[piecePlaced.XCoordinate - 2, piecePlaced.YCoordinate + 2].PieceType &&
                piecePlaced.PieceType == gameBoard[piecePlaced.XCoordinate - 3, piecePlaced.YCoordinate + 3].PieceType)
                {
                    return piecePlaced.PieceType;
                }
            }
            if (piecePlaced.XCoordinate <= 4 && piecePlaced.XCoordinate >= 2 && piecePlaced.YCoordinate <= 4 && piecePlaced.YCoordinate >= 1)
            {
                if (piecePlaced.PieceType == gameBoard[piecePlaced.XCoordinate + 1, piecePlaced.YCoordinate - 1].PieceType &&
                piecePlaced.PieceType == gameBoard[piecePlaced.XCoordinate - 1, piecePlaced.YCoordinate + 1].PieceType &&
                piecePlaced.PieceType == gameBoard[piecePlaced.XCoordinate - 2, piecePlaced.YCoordinate + 2].PieceType)
                {
                    return piecePlaced.PieceType;
                }
            }
            if (piecePlaced.XCoordinate <= 3 && piecePlaced.XCoordinate >= 1 && piecePlaced.YCoordinate <= 5 && piecePlaced.YCoordinate >= 2)
            {
                if (piecePlaced.PieceType == gameBoard[piecePlaced.XCoordinate + 2, piecePlaced.YCoordinate - 2].PieceType &&
                piecePlaced.PieceType == gameBoard[piecePlaced.XCoordinate + 1, piecePlaced.YCoordinate - 1].PieceType &&
                piecePlaced.PieceType == gameBoard[piecePlaced.XCoordinate - 1, piecePlaced.YCoordinate + 1].PieceType)
                {
                    return piecePlaced.PieceType;
                }
            }
            if (piecePlaced.XCoordinate <= 2 && piecePlaced.YCoordinate >= 3)
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
