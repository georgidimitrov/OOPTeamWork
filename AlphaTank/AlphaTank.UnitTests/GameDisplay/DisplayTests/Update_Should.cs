using AlphaTank.Program.Contracts;
using AlphaTank.Program.GameDisplay;
using AlphaTank.Program.Models.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AlphaTank.UnitTests.GameDisplay.DisplayTests
{
    [TestClass]
    public class Update_Should
    {
        private Mock<IMap> mapMock;

        [TestInitialize]
        public void Initialize()
        {
            mapMock = new Mock<IMap>();

            mapMock.Setup(map => map.GetLength(1)).Returns(10);
            mapMock.Setup(map => map.GetLength(0)).Returns(10);

        }

        [TestMethod]
        public void Properly_Update_CoordinatesGiven()
        {
            //arrange
            var gameObjectStub = new Mock<IGameObject>();
            mapMock.SetupGet(m => m[It.IsAny<int>(), It.IsAny<int>()]).Returns(gameObjectStub.Object);

            var ioWrapperMock = new Mock<IRapper>();
            ioWrapperMock.Setup(io => io.Write(It.IsAny<string>())).Verifiable();

            var display = new Display(ioWrapperMock.Object);

            //act
            display.Update(mapMock.Object, 5, 6, 5, 7);

            //assert
            ioWrapperMock.Verify(io => io.Write(It.IsAny<string>()), Times.Exactly(2));
        }
    }
}
