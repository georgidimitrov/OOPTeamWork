﻿using AlphaTank.Program.Contracts;
using AlphaTank.Program.Enums_and_Structs;
using AlphaTank.Program.GameDisplay;
using AlphaTank.Program.Models.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace AlphaTank.UnitTests.GameDisplay.DisplayTests
{
    [TestClass]
    public class NewX_Should
    {
        [TestMethod]
        public void Properly_Assign_Correct_Value()
        {
            //arrange
            var wraperStub = new Mock<IRapper>();
            var mapStub = new Mock<IMap>();
            var gameSettingsMock = new Mock<IGameSettings>();

            var display = new Display(wraperStub.Object, mapStub.Object, gameSettingsMock.Object);

            var rowsSize = 10;
            gameSettingsMock.SetupGet(gs => gs.RowsSize).Returns(rowsSize);

            var expectedValue = 5;

            //act
            display.NewX = expectedValue;

            //assert
            var actualValue = display.NewX;
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void Throw_ArgumentException_When_Value_IsNegative()
        {
            //arrange
            var wraperStub = new Mock<IRapper>();
            var mapStub = new Mock<IMap>();
            var gameSettingsStub = new Mock<IGameSettings>();

            var display = new Display(wraperStub.Object, mapStub.Object, gameSettingsStub.Object);

            //act
            Action settingNegativeValue = () => display.NewX = -2;

            //assert
            Assert.ThrowsException<ArgumentException>(settingNegativeValue);
        }

        [TestMethod]
        public void Throw_ArgumentException_When_Value_IsAbove_OrEqualTo_RowsSize()
        {
            //arrange
            var wraperStub = new Mock<IRapper>();
            var mapStub = new Mock<IMap>();
            var gameSettingsMock = new Mock<IGameSettings>();

            var display = new Display(wraperStub.Object, mapStub.Object, gameSettingsMock.Object);

            var rowsSize = 10;
            gameSettingsMock.SetupGet(gs => gs.RowsSize).Returns(rowsSize);

            //act
            Action settingBiggerValue = () => display.NewX = 12;

            //assert
            Assert.ThrowsException<ArgumentException>(settingBiggerValue);
        }
    }
}
