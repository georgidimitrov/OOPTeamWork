using AlphaTank.Program.Contracts;
using AlphaTank.Program.Enums_and_Structs;
using AlphaTank.Program.Factories.Contracts;
using AlphaTank.Program.GameEngine;
using AlphaTank.Program.GameEngine.ControlProvider;
using AlphaTank.Program.GameEngine.TimerProvider;
using AlphaTank.Program.Logic.Contracts;
using AlphaTank.Program.Models.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTank.UnitTests.GameEngine.EngineTests
{
    [TestClass]
    public class Start_Should
    {
        Mock<IMap> mapStub;
        Mock<IPlayerTank> playerTankStub;
        Mock<IEnvironmentFactory> environmentFactoryStub;
        Mock<ICollision> collisionStub;
        Mock<IKeyboardWraper> keyboardStub;
        Mock<IGameTimer> timerStub;
        Mock<IGameSettings> gameSettingsStub;
        Mock<IDisplay> displayStub;

        [TestInitialize]
        public void Initialize()
        {
            mapStub = new Mock<IMap>();
            playerTankStub = new Mock<IPlayerTank>();
            environmentFactoryStub = new Mock<IEnvironmentFactory>();
            collisionStub = new Mock<ICollision>();
            keyboardStub = new Mock<IKeyboardWraper>();
            timerStub = new Mock<IGameTimer>();
            gameSettingsStub = new Mock<IGameSettings>();
            displayStub = new Mock<IDisplay>();
        }

        [TestMethod]
        public void TakeCare_That_DisplayPrint_IsCalledOnce()
        {
            //arrange
            var gameSettingsMock = new Mock<IGameSettings>();
            gameSettingsMock.SetupGet(gs => gs.IsPlayerAlive).Returns(false);

            var displayMock = new Mock<IDisplay>();
            displayMock.Setup(d => d.Print()).Verifiable();

            var engine = new Engine(displayMock.Object, mapStub.Object, playerTankStub.Object, environmentFactoryStub.Object, collisionStub.Object, keyboardStub.Object, timerStub.Object, gameSettingsMock.Object);

            //act
            engine.Start();

            //assert
            displayMock.Verify(d => d.Print(), Times.Once);
        }

        [TestMethod]
        public void TakeCare_That_ShellMove_IsCalles()
        {
            //arrange
            var gameSettingsMock = new Mock<IGameSettings>();
            gameSettingsMock.SetupGet(gs => gs.IsPlayerAlive).Returns(true);

            var timerMock = new Mock<IGameTimer>();
            timerMock.Setup(t => t.ShellSpeed()).Returns(true);

            var engine = new Engine(displayStub.Object, mapStub.Object, playerTankStub.Object, environmentFactoryStub.Object, collisionStub.Object, keyboardStub.Object, timerMock.Object, gameSettingsMock.Object);

            var shellMock = new Mock<IShell>();
            shellMock.SetupGet(sh => sh.Map).Returns(mapStub.Object);
            shellMock.Setup(sh => sh.Move()).Verifiable();

            engine.Shells.Add(shellMock.Object);

            //act
            engine.Start();

            //assert
            shellMock.Verify(sh => sh.Move(), Times.Once);
        }

        [TestMethod]
        public void TakeCare_That_PlayerTankShoot_IsCalled_When_FireButtonIsPressed()
        {

        }

        [TestMethod]
        public void TakeCare_That_PlayerTankMoveUp_IsCalled_When_MoveUpButtonIsPressed()
        {

        }

        [TestMethod]
        public void TakeCare_That_PlayerTankMoveRight_IsCalled_When_MoveRightButtonIsPressed()
        {

        }

        [TestMethod]
        public void TakeCare_That_PlayerTankMoveDown_IsCalled_When_MoveDownButtonIsPressed()
        {

        }

        [TestMethod]
        public void TakeCare_That_PlayerTankMoveLeft_IsCalled_When_MoveLeftButtonIsPressed()
        {

        }

        [TestMethod]
        public void TakeCare_That_EnemyTank_HasShot_When_PlayerTank_IsDetected()
        {

        }

        [TestMethod]
        public void TakeCare_That_EnemyTank_HasMoved_When_PlayerTank_IsNotDetected()
        {

        }

        [TestMethod]
        public void TakeCare_That_DisplayUpdate_IsCalled_When_Shell_HasMoved()
        {

        }

        [TestMethod]
        public void TakeCare_That_DisplayUpdate_IsCalled_When_When_FireButtonIsPressed()
        {

        }

        [TestMethod]
        public void TakeCare_That_DisplayUpdate_IsCalled_When_When_MoveUpButtonIsPressed()
        {

        }

        [TestMethod]
        public void TakeCare_That_DisplayUpdate_IsCalled_When_When_MoveRightButtonIsPressed()
        {

        }

        [TestMethod]
        public void TakeCare_That_DisplayUpdate_IsCalled_When_When_MoveDownButtonIsPressed()
        {

        }

        [TestMethod]
        public void TakeCare_That_DisplayUpdate_IsCalled_When_When_MoveLeftButtonIsPressed()
        {

        }
    }
}
