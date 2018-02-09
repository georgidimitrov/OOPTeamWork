using AlphaTank.Program.CustomExceptions;
using AlphaTank.Program.Logic;
using AlphaTank.Program.Models.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaTank.UnitTests.Logic.CollisionTests
{
    [TestClass]
    public class DecectCollision_Should
    {
        [TestMethod]
        public void Return_False_IfObject_IsNot_Obstacle()
        {
            //arrange
            var mockMap = new Mock<IMap>();
            var mockNotObstacle = new Mock<INonObstacle>();

            mockMap.SetupGet((x) => x[It.IsAny<int>(), It.IsAny<int>()]).Returns(mockNotObstacle.Object);

            var collision = new Collision();

            //act
            bool detectResult = collision.DetectCollision(mockMap.Object, 0, 0);

            //assert
            Assert.IsFalse(detectResult);
        }

        [TestMethod]
        public void Return_True_IfObject_IsNot_NotObstacle()
        {
            //arrange
            var mockMap = new Mock<IMap>();
            var mockObstacle = new Mock<IPlayerTank>();

            mockMap.SetupGet((x) => x[It.IsAny<int>(), It.IsAny<int>()]).Returns(mockObstacle.Object);

            var collision = new Collision();

            //act
            bool detectResult = collision.DetectCollision(mockMap.Object, 0, 0);

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
