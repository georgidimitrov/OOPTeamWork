using AlphaTank.Program.Contracts;
using AlphaTank.Program.CustomExceptions;
using AlphaTank.Program.Enums_and_Structs;
using AlphaTank.Program.GameDisplay;
using AlphaTank.Program.Models.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace AlphaTank.UnitTests.GameDisplay.DisplayTests
{
    [TestClass]
    public class Contructor_Should
    {
        private Mock<IRapper> wraperStub;
        private Mock<IMap> mapStub;
        private Mock<IGameSettings> gameSettingsStub;

        [TestInitialize]
        public void Initialize()
        {
            wraperStub = new Mock<IRapper>();
            mapStub = new Mock<IMap>();
            gameSettingsStub = new Mock<IGameSettings>();
        }

        [TestMethod]
        public void Throw_ArgumentNullException_When_Wrapper_IsNull()
        {
            //arrange & act
            Action creatingDisplay = () => new Display(null, mapStub.Object, gameSettingsStub.Object);

            //assert
            Assert.ThrowsException<ArgumentNullException>(creatingDisplay);
        }

        [TestMethod]
        public void Throw_NoMapException_When_Map_IsNull()
        {
            //arrange & act
            Action creatingDisplay = () => new Display(wraperStub.Object, null, gameSettingsStub.Object);

            //assert
            Assert.ThrowsException<NoMapException>(creatingDisplay);
        }

        [TestMethod]
        public void Throw_ArgumentNullException_When_GameSettings_IsNull()
        {
            //arrange & act
            Action creatingDisplay = () => new Display(wraperStub.Object, mapStub.Object, null);

            //assert
            Assert.ThrowsException<ArgumentNullException>(creatingDisplay);
        }
    }
}
