using MarsRover.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {

            String plateauDimension = Console.ReadLine();

            CommandExecutor.createPlateau(plateauDimension);
            List<String> finalPositions = new List<String>();
            String newRoverPosition = "";
            while (true)
            {
                if (String.IsNullOrEmpty(newRoverPosition))
                {
                    newRoverPosition = Console.ReadLine();
                }
                CommandExecutor.createRover(newRoverPosition);

                String roverCommands = Console.ReadLine();
                CommandExecutor.processCommands(roverCommands);

                finalPositions.Add(CommandExecutor.getFinalPosition());

                newRoverPosition = Console.ReadLine();

                if (String.IsNullOrEmpty(newRoverPosition))
                    break;
            }

            foreach(String p in finalPositions){
                Console.WriteLine(p);
            }

            Console.ReadKey();
        }
    }
}
