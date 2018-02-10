using AlphaTank.Program.Models.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AlphaTank.UnitTests.Models.GameObjects.ShellTests
{
    [TestClass]
    public class Move_Should
    {
        private Mock<IMap> mapMock;

        [TestInitialize]
        public void Initialize()
        {
            mapMock = new Mock<IMap>();

            mapMock.Setup(map => map.GetLength(1)).Returns(10);
            mapMock.Setup(map => map.GetLength(0)).Returns(10);
        }

        //
    }
}
