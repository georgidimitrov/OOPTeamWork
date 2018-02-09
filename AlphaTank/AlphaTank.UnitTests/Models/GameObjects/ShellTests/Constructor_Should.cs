using AlphaTank.Program.CustomExceptions;
using AlphaTank.Program.Enums_and_Structs;
using AlphaTank.Program.Factories.Contracts;
using AlphaTank.Program.Logic.Contracts;
using AlphaTank.Program.Models.Contracts;
using AlphaTank.Program.Models.GameObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace AlphaTank.UnitTests.Models.GameObjects.ShellTests
{
    [TestClass]
    public class Constructor_Should
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
        public void Throw_ArgumentException_When_Row_IsNegative()
        {
            //arrange
            var enviromentFactoryStub = new Mock<IEnvironmentFactory>();
            var collisionStub = new Mock<ICollision>();
            var gameObject = new Mock<GameObject>();

            //act
            Action creatingShell = () => new Shell(-2, 2, mapMock.Object, Direction.Down, enviromentFactoryStub.Object, collisionStub.Object);

            //assert
            Assert.ThrowsException<ArgumentException>(creatingShell);
        }

        [TestMethod]
        public void Throw_ArgumentException_When_Row_IsAbove_Ten()
        {
            //arrange
            var enviromentFactoryStub = new Mock<IEnvironmentFactory>();
            var collisionStub = new Mock<ICollision>();

            //act
            Action creatingShell = () => new Shell(11, 2, mapMock.Object, Direction.Down, enviromentFactoryStub.Object, collisionStub.Object);

            //assert
            Assert.ThrowsException<ArgumentException>(creatingShell);
        }

        [TestMethod]
        public void Throw_ArgumentException_When_Col_IsNegative()
        {
            //arrange
            var enviromentFactoryStub = new Mock<IEnvironmentFactory>();
            var collisionStub = new Mock<ICollision>();

            //act
            Action creatingShell = () => new Shell(2, -1, mapMock.Object, Direction.Down, enviromentFactoryStub.Object, collisionStub.Object);

            //assert
            Assert.ThrowsException<ArgumentException>(creatingShell);
        }

        [TestMethod]
        public void Throw_ArgumentException_When_Col_IsAbove_Ten()
        {
            //arrange
            var enviromentFactoryStub = new Mock<IEnvironmentFactory>();
            var collisionStub = new Mock<ICollision>();

            //act
            Action creatingShell = () => new Shell(1, 20, mapMock.Object, Direction.Down, enviromentFactoryStub.Object, collisionStub.Object);

            //assert
            Assert.ThrowsException<ArgumentException>(creatingShell);
        }

        [TestMethod]
        public void Throw_NoMapException_IfMap_IsNull()
        {
            //arrange
            var factoryStub = new Mock<IEnvironmentFactory>();
            var collisionStub = new Mock<ICollision>();

            //act
            Action creatingShell = () => new Shell(1, 1, null, Direction.Up, factoryStub.Object, collisionStub.Object);

            //assert
            Assert.ThrowsException<NoMapException>(creatingShell);
        }

        [TestMethod]
        public void Throw_ArgumentNullException_IfEnviromentFactory_IsNull()
        {
            //arrange
            var collisionStub = new Mock<ICollision>();
            
            //act
            Action creatingShell = () => new Shell(1, 1, mapMock.Object, Direction.Up, null, collisionStub.Object);

            //assert
            Assert.ThrowsException<ArgumentNullException>(creatingShell);
        }

        [TestMethod]
        public void Throw_ArgumentNullException_IfCollision_IsNull()
        {
            //arrange
            var factoryStub = new Mock<IEnvironmentFactory>();
            var mapMock = new Mock<IMap>();

            mapMock.Setup(map => map.GetLength(1)).Returns(10);
            mapMock.Setup(map => map.GetLength(0)).Returns(10);

            //act
            Action creatingShell = () => new Shell(1, 1, mapMock.Object, Direction.Up, factoryStub.Object, null);

            //assert
            Assert.ThrowsException<ArgumentNullException>(creatingShell);
        }
    }
}
