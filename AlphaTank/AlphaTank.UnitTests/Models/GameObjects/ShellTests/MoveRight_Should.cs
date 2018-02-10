using AlphaTank.Program.Enums_and_Structs;
using AlphaTank.Program.Factories.Contracts;
using AlphaTank.Program.Logic.Contracts;
using AlphaTank.Program.Models.Contracts;
using AlphaTank.Program.Models.GameObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AlphaTank.UnitTests.Models.GameObjects.ShellTests
{
    [TestClass]
    public class MoveRight_Should
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
        public void Return_False_IfCollision_IsDetected()
        {
            //arrange
            var row = 3;
            var col = 3;
            var direction = Direction.Right;
            var collisionMock = new Mock<ICollision>();

            var gameObjectStub = new Mock<IGameObject>();
            mapMock.SetupGet(map => map[It.IsAny<int>(), It.IsAny<int>()]).Returns(gameObjectStub.Object);

            var shell = new Shell(row, col, mapMock.Object, direction, enviromentFactoryStub.Object, collisionMock.Object);

            collisionMock.Setup(c => c.DetectCollision(mapMock.Object, row, col + 1)).Returns(true);

            //act
            var result = shell.MoveRight();

            //assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Return_True_IfCollision_IsNotDetected()
        {
            //arrange
            var row = 3;
            var col = 3;
            var direction = Direction.Right;
            var collisionMock = new Mock<ICollision>();

            var gameObjectStub = new Mock<IGameObject>();
            mapMock.SetupGet(map => map[It.IsAny<int>(), It.IsAny<int>()]).Returns(gameObjectStub.Object);

            var shell = new Shell(row, col, mapMock.Object, direction, enviromentFactoryStub.Object, collisionMock.Object);

            collisionMock.Setup(c => c.DetectCollision(mapMock.Object, row, col + 1)).Returns(false);

            //act
            var result = shell.MoveRight();

            //assert
            Assert.IsTrue(result);
        }
    }
}
