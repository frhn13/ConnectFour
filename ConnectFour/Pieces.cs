using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectFour
{
    class ConnectFourPiece
    {
        public ConnectFourPiece(int xCoordinate, int yCoordinate)
        {
            this.PieceType = " ";
            this.XCoordinate = xCoordinate;
            this.YCoordinate = yCoordinate;
        }

        public ConnectFourPiece(String pieceType, int xCoordinate, int yCoordinate)
        {
            this.PieceType = pieceType;
            this.XCoordinate = xCoordinate;
            this.YCoordinate = yCoordinate;
        }

        public String PieceType
        {
            get; set;
        }

        public int XCoordinate
        {
            get; set;
        }

        public int YCoordinate
        {
            get; set;
        }
    }
}
