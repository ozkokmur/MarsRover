using MarsRover;
using MarsRover.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MarsRoverTests
{
    [TestClass]
    public class CommandExecutorTest
    {
        [TestMethod]
        public void Test_createPlateau()
        {
            String plateauDimensions = "5 5";
            CommandExecutor.createPlateau(plateauDimensions);

            Assert.AreEqual(5, CommandExecutor.GetPlateauWidth());
            Assert.AreEqual(5, CommandExecutor.GetPlateauHeight());
        }

        [TestMethod]
        public void Test_createRover()
        {
            String roverInitializer = "0 4 W";
            CommandExecutor.createPlateau("5 5");
            CommandExecutor.createRover(roverInitializer);

            Assert.AreEqual(0, CommandExecutor.GetRoverPosX());
            Assert.AreEqual(4, CommandExecutor.GetRoverPosY());
            Assert.AreEqual(DirectionEnum.W, CommandExecutor.GetDirection()); 
        }

        [TestMethod]
        public void Test_moveToOutside()
        {
            CommandExecutor.createPlateau("5 5");
            CommandExecutor.createRover("0 4 W");

            Assert.ThrowsException<InvalidOperationException>(() => CommandExecutor.processCommands("M"));
        }
    }
}
