using AlphaTank.Program.CustomExceptions;
using AlphaTank.Program.Logic;
using AlphaTank.Program.Models.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AlphaTank.UnitTests.Logic.CollisionTests
{
    [TestClass]
    public class IsObstacleOrAlly_Should
    {
        [TestMethod]
        public void Return_False_IfObject_IsNot_Obstacle()
        {
            //arrange
            var mapMock = new Mock<IMap>();
            var notObstacleStub = new Mock<IShell>();

            mapMock.SetupGet((x) => x[It.IsAny<int>(), It.IsAny<int>()]).Returns(notObstacleStub.Object);

            var collision = new Collision();

            //act
            bool detectResult = collision.IsObstacleOrAlly(mapMock.Object, 0, 0);

            //assert
            Assert.IsFalse(detectResult);
        }

        [TestMethod]
        public void Return_True_IfObject_Is_Obstacle()
        {
            //arrange
            var mapMock = new Mock<IMap>();
            var obstacleStub = new Mock<IObstacle>();

            mapMock.SetupGet((x) => x[It.IsAny<int>(), It.IsAny<int>()]).Returns(obstacleStub.Object);

            var collision = new Collision();

            //act
            bool detectResult = collision.IsObstacleOrAlly(mapMock.Object, 0, 0);

            //assert
            Assert.IsTrue(detectResult);
        }


        [TestMethod]
        public void Throw_NoMapException_When_Map_IsNull()
        {
            var collision = new Collision();

            Assert.ThrowsException<NoMapException>(() => collision.IsObstacleOrAlly(null, 0, 0));
        }
    }
}
