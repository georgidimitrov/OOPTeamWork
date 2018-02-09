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
            var notObstacleStub = new Mock<INonObstacle>();

            mapMock.SetupGet((x) => x[It.IsAny<int>(), It.IsAny<int>()]).Returns(notObstacleStub.Object);

            var collision = new Collision();

            //act
            bool detectResult = collision.DetectCollision(mapMock.Object, 0, 0);

            //assert
            Assert.IsFalse(detectResult);
        }

        [TestMethod]
        public void Return_True_IfObject_IsNot_NotObstacle()
        {
            //arrange
            var mapMock = new Mock<IMap>();
            var obstacleStub = new Mock<IPlayerTank>();

            mapMock.SetupGet((x) => x[It.IsAny<int>(), It.IsAny<int>()]).Returns(obstacleStub.Object);

            var collision = new Collision();

            //act
            bool detectResult = collision.DetectCollision(mapMock.Object, 0, 0);

            //assert
            Assert.IsTrue(detectResult);
        }


        [TestMethod]
        public void Throw_NoMapException_When_Map_IsNull()
        {
            var collision = new Collision();

            Assert.ThrowsException<NoMapException>(() => collision.DetectCollision(null, 0, 0));
        }
    }
}
