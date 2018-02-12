using AlphaTank.Program.Enums_and_Structs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AlphaTank.UnitTests.Enums_and_Structs.GameSettingsTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void Throw_ArgumentException_When_RowSize_IsNegative()
        {
            //arrange
            var refreshRate = new TimeSpan(0, 0, 0, 0, 200);
            var shellCooldown = new TimeSpan(0, 0, 0, 0, 600);
            var shellSpeed = new TimeSpan(0, 0, 0, 0, 100);
            var enemyTankShootCooldown = new TimeSpan(0, 0, 0, 0, 1800);

            //act
            Action creatingSettings = () => new GameSettings(-2, 2, refreshRate, shellCooldown, shellSpeed, enemyTankShootCooldown);

            //assert
            Assert.ThrowsException<ArgumentException>(creatingSettings);
        }

        [TestMethod]
        public void Throw_ArgumentException_When_ColSize_IsNegative()
        {
            //arrange
            var refreshRate = new TimeSpan(0, 0, 0, 0, 200);
            var shellCooldown = new TimeSpan(0, 0, 0, 0, 600);
            var shellSpeed = new TimeSpan(0, 0, 0, 0, 100);
            var enemyTankShootCooldown = new TimeSpan(0, 0, 0, 0, 1800);

            //act
            Action creatingSettings = () => new GameSettings(2, -1, refreshRate, shellCooldown, shellSpeed, enemyTankShootCooldown);

            //assert
            Assert.ThrowsException<ArgumentException>(creatingSettings);
        }

        [TestMethod]
        public void Correctly_Assign_PassedValues()
        {
            //arrange
            var rowsSize = 4;
            var colsSize = 5;
            var refreshRate = new TimeSpan(0, 0, 0, 0, 200);
            var shellCooldown = new TimeSpan(0, 0, 0, 0, 600);
            var shellSpeed = new TimeSpan(0, 0, 0, 0, 100);
            var enemyTankShootCooldown = new TimeSpan(0, 0, 0, 0, 1800);

            //act
            var gameSettings = new GameSettings(rowsSize, colsSize, refreshRate, shellCooldown, shellSpeed, enemyTankShootCooldown);

            //assert
            Assert.AreEqual(rowsSize, gameSettings.RowsSize);
            Assert.AreEqual(colsSize, gameSettings.ColsSize);
            Assert.AreEqual(refreshRate, gameSettings.RefreshRate);
            Assert.AreEqual(shellCooldown, gameSettings.ShellCooldown);
            Assert.AreEqual(shellSpeed, gameSettings.ShellSpeed);
        }
    }
}
