using AlphaTank.Program.Contracts;
using AlphaTank.Program.GameDisplay;
using AlphaTank.Program.Models.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AlphaTank.UnitTests.GameDisplay.DisplayTests
{
    [TestClass]
    public class Print_Should
    {
        [TestMethod]
        public void Properly_Print_GivenMap()
        {
            //arrange
            var mapHeight = 10;
            var mapWidth = 10;

            var mapMock = new Mock<IMap>();
            mapMock.Setup(map => map.GetLength(0)).Returns(mapHeight);
            mapMock.Setup(map => map.GetLength(1)).Returns(mapWidth);

            var gameObjectMock = new Mock<IGameObject>();
            mapMock.SetupGet(map => map[It.IsAny<int>(), It.IsAny<int>()]).Returns(gameObjectMock.Object);

            var wraperMock = new Mock<IRapper>();
            wraperMock.Setup(io => io.Write(It.IsAny<string>())).Verifiable();

            var display = new Display(wraperMock.Object);

            //act
            display.Print(mapMock.Object);

            //assert
            wraperMock.Verify(io => io.Write(It.IsAny<string>()), Times.Exactly((mapHeight - 1) * mapWidth));
        }
    }
}
