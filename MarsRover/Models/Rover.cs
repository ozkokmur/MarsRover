using MarsRover.Enums;
using System;

namespace MarsRover.Models
{
    public class Rover
    {
        private int posX { get; set; }

        private int posY;

        private DirectionEnum direction;
        public int GetposX()
        {
            return posX;
        }

        public void SetposX(int value)
        {
            posX = value;
        }
        public int GetposY()
        {
            return posY;
        }

        public void SetposY(int value)
        {
            posY = value;
        }

        public DirectionEnum Getdirection()
        {
            return direction;
        }

        public void Setdirection(DirectionEnum value)
        {
            direction = value;
        }

        public String currentPosition()
        {
            return GetposX().ToString() + " " + GetposY().ToString() + " " + Getdirection().ToString();
        }

        public Rover(int pos_x, int pos_y, DirectionEnum directionEnum)
        {
            this.posX = pos_x;
            this.SetposY(pos_y);
            this.Setdirection(directionEnum);
        }
    }
}
