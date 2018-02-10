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
    public class Destroy_Should
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
        public void Set_Map_NullValue()
        {
            //arrange
            var enviromentFactoryStub = new Mock<IEnvironmentFactory>();
            var collisionStub = new Mock<ICollision>();

            var shell = new Shell(2, 3, mapMock.Object, Direction.Down, enviromentFactoryStub.Object, collisionStub.Object);

            //act
            shell.Destroy();

            //assert
            Assert.IsNull(shell.Map);
        }
    }
}
