using MarsRover.Enums;
using MarsRover.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public static class CommandExecutor
    {
        private static Plateau plateau { get; set; }

        private static Rover rover { get; set; }

        public static void createPlateau(String command)
        {
            plateau = new Plateau();
            String[] args = command.Split(' ');

            if(args.Length != 2)
            {
                throw new ArgumentException("Arguments of Plateau dimension are not sufficient!");
            }

            plateau.Setwidth(Convert.ToInt32(args[0]));
            plateau.Setheight(Convert.ToInt32(args[1]));

        }

        public static void createRover(String command)
        {
            String[] args = command.Split(' ');

            if (args.Length != 3)
            {
                throw new ArgumentException("Arguments of Rover are not sufficient!");
            }
            int initial_posX = Convert.ToInt32(args[0]);
            int initial_posY = Convert.ToInt32(args[1]);

            if(initial_posX >= plateau.Getwidth() || initial_posY >= plateau.Getheight())
            {
                throw new Exception("Rover cannot be start actions from outside of plateau!");
            }

            DirectionEnum direction = (DirectionEnum)Enum.Parse(typeof(DirectionEnum), args[2]);
            rover = new Rover(initial_posX, initial_posY, direction);
        }

        public static void move()
        {
            int newVal;
            switch (rover.Getdirection())
            {
                
                case DirectionEnum.N:
                    newVal = rover.GetposY() + 1;
                    if(plateau.Getheight() < newVal)
                    {
                        throw new InvalidOperationException();
                    }
                    rover.SetposY(newVal);
                    break;

                case DirectionEnum.W:
                    newVal = rover.GetposX() - 1;
                    if (0 > newVal)
                    {
                        throw new InvalidOperationException();
                    }
                    rover.SetposX(newVal);
                    break;

                case DirectionEnum.S:
                    newVal = rover.GetposY() -1 ;
                    if (0 > newVal)
                    {
                        throw new InvalidOperationException();
                    }
                    rover.SetposY(newVal);
                    break;

                case DirectionEnum.E:
                    newVal = rover.GetposX() + 1;
                    if (plateau.Getwidth() < newVal)
                    {
                        throw new InvalidOperationException();
                    }
                    rover.SetposX(newVal);
                    break;
                default:
                    throw new Exception("Move Command: Invalid direction input");
            }
                
        }

        public static void processCommands(String commands)
        {
            foreach(char c in commands){
                ActionEnum action = (ActionEnum)Enum.Parse(typeof(ActionEnum), c.ToString());
                processCommand(action);
            }
        }

        public static void processCommand(ActionEnum action)
        {
            switch (action)
            {
                case ActionEnum.L:
                    rover.Setdirection(turnToLeft(rover.Getdirection()));
                    break;

                case ActionEnum.R:
                    rover.Setdirection(turnToRight(rover.Getdirection()));
                    break;

                case ActionEnum.M:
                    move();
                    break;

                default:
                    throw new Exception("Process Command: Invalid action input");
            }
        }

        public static DirectionEnum turnToLeft(DirectionEnum currentDirection)
        {
            if (DirectionEnum.N.Equals(currentDirection))
                return DirectionEnum.W;

            if (DirectionEnum.W.Equals(currentDirection))
                return DirectionEnum.S;

            if (DirectionEnum.S.Equals(currentDirection))
                return DirectionEnum.E;

            if (DirectionEnum.E.Equals(currentDirection))
                return DirectionEnum.N;

            throw new Exception("Turn Left Command: Invalid direction input");
        }

        public static DirectionEnum turnToRight(DirectionEnum currentDirection)
        {
            if (DirectionEnum.N.Equals(currentDirection))
                return DirectionEnum.E;

            if (DirectionEnum.W.Equals(currentDirection))
                return DirectionEnum.N;

            if (DirectionEnum.S.Equals(currentDirection))
                return DirectionEnum.W;

            if (DirectionEnum.E.Equals(currentDirection))
                return DirectionEnum.S;

            throw new Exception("Turn Left Command: Invalid direction input");
        }

        public static String getFinalPosition()
        {
            return rover.currentPosition();
        }

        public static int GetRoverPosX()
        {
            return rover.GetposX();
        }

        public static int GetRoverPosY()
        {
            return rover.GetposY();
        }

        public static DirectionEnum GetDirection()
        {
            return rover.Getdirection();
        }

        public static int GetPlateauWidth()
        {
            return plateau.Getwidth();
        }

        public static int GetPlateauHeight()
        {
            return plateau.Getheight();
        }
    }
}
