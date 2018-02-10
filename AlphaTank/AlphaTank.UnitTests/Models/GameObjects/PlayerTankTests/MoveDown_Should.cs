using AlphaTank.Program.Enums_and_Structs;
using AlphaTank.Program.Factories.Contracts;
using AlphaTank.Program.Logic.Contracts;
using AlphaTank.Program.Models.Contracts;
using AlphaTank.Program.Models.GameObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AlphaTank.UnitTests.Models.GameObjects.PlayerTankTests
{
    [TestClass]
    public class MoveDown_Should
    {
        private Mock<IEnvironmentFactory> enviromentFactoryStub;
        private Mock<IMap> mapMock;

        [TestInitialize]
        public void Initialize()
        {
            enviromentFactoryStub = new Mock<IEnvironmentFactory>();
            mapMock = new Mock<IMap>();

            mapMock.Setup(map => map.GetLength(1)).Returns(10);
            mapMock.Setup(map => map.GetLength(0)).Returns(10);
        }

        [TestMethod]
        public void Return_False_IfDirection_IsNotDown()
        {
            //arrange
            var direction = Direction.Up;
            var collisionStub = new Mock<ICollision>();
            var playerTank = new PlayerTank(3, 3, direction, mapMock.Object, enviromentFactoryStub.Object, collisionStub.Object);

            //act
            var result = playerTank.MoveDown();

            //assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Return_False_IfCollision_IsDetected()
        {
            //arrange
            var row = 3;
            var col = 3;
            var direction = Direction.Down;
            var collisionMock = new Mock<ICollision>();
            var playerTank = new PlayerTank(row, col, direction, mapMock.Object, enviromentFactoryStub.Object, collisionMock.Object);

            collisionMock.Setup(c => c.DetectCollision(mapMock.Object, row + 1, col)).Returns(true);

            //act
            var result = playerTank.MoveDown();

            //assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Return_True_IfCollision_IsNotDetected()
        {
            //arrange
            var row = 3;
            var col = 3;
            var direction = Direction.Down;
            var collisionMock = new Mock<ICollision>();
            var playerTank = new PlayerTank(row, col, direction, mapMock.Object, enviromentFactoryStub.Object, collisionMock.Object);

            collisionMock.Setup(c => c.DetectCollision(mapMock.Object, row + 1, col)).Returns(false);

            //act
            var result = playerTank.MoveDown();

            //assert
            Assert.IsTrue(result);
        }
    }
}
