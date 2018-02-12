using AlphaTank.Program.Enums_and_Structs;
using AlphaTank.Program.Factories.Contracts;
using AlphaTank.Program.GameEngine.TimerProvider;
using AlphaTank.Program.Logic.Contracts;
using AlphaTank.Program.Models.Contracts;
using AlphaTank.Program.Models.GameObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AlphaTank.UnitTests.Models.GameObjects.EnemyTankTests
{
    [TestClass]
    public class DetectPlayer_Should
    {
        private Mock<IEnvironmentFactory> enviromentFactoryStub;
        private Mock<IMap> mapMock;
        private Mock<IPlayerTank> playerTankMock;
        private Mock<ICollision> collisionMock;
        private Mock<IGameTimer> timerMock;

        [TestInitialize]
        public void Initialize()
        {
            enviromentFactoryStub = new Mock<IEnvironmentFactory>();
            mapMock = new Mock<IMap>();

            mapMock.Setup(map => map.GetLength(1)).Returns(10);
            mapMock.Setup(map => map.GetLength(0)).Returns(10);
        }

        [TestMethod]
        public void Return_True_When_PlayerTankIs_OnSameRow_LowerColumn_IfRow_IsClean()
        {
            //arrange
            int row = 2;
            int playerTankColumn = 3;
            int enemyTankColumn = 5;

            playerTankMock = new Mock<IPlayerTank>();
            playerTankMock.SetupGet(pt => pt.RowPosition).Returns(row);
            playerTankMock.SetupGet(pt => pt.ColumnPosition).Returns(playerTankColumn);

            collisionMock = new Mock<ICollision>();
            collisionMock.Setup(c => c.IsObstacleOrAlly(mapMock.Object, It.IsAny<int>(), It.IsAny<int>())).Returns(false);

            timerMock = new Mock<IGameTimer>();
            timerMock.Setup(timer => timer.EnemyTankShootCooldown()).Returns(true);

            var enemyTank = new EnemyTank(row, enemyTankColumn, Direction.Right, mapMock.Object, playerTankMock.Object, enviromentFactoryStub.Object, collisionMock.Object, timerMock.Object);

            //act
            bool result = enemyTank.DetectPlayer();

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Return_True_When_PlayerTankIs_OnSameRow_BiggerColumn_IfRow_IsClean()
        {
            //arrange
            int row = 2;
            int playerTankColumn = 8;
            int enemyTankColumn = 5;

            playerTankMock = new Mock<IPlayerTank>();
            playerTankMock.SetupGet(pt => pt.RowPosition).Returns(row);
            playerTankMock.SetupGet(pt => pt.ColumnPosition).Returns(playerTankColumn);

            collisionMock = new Mock<ICollision>();
            collisionMock.Setup(c => c.IsObstacleOrAlly(mapMock.Object, It.IsAny<int>(), It.IsAny<int>())).Returns(false);

            timerMock = new Mock<IGameTimer>();
            timerMock.Setup(timer => timer.EnemyTankShootCooldown()).Returns(true);

            var enemyTank = new EnemyTank(row, enemyTankColumn, Direction.Right, mapMock.Object, playerTankMock.Object, enviromentFactoryStub.Object, collisionMock.Object, timerMock.Object);

            //act
            bool result = enemyTank.DetectPlayer();

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Return_True_When_PlayerTankIs_OnSameColumn_LowerRow_IfColumn_IsClean()
        {
            //arrange
            int playertankRow = 2;
            int enemyTankRow = 3;
            int col = 5;

            playerTankMock = new Mock<IPlayerTank>();
            playerTankMock.SetupGet(pt => pt.RowPosition).Returns(playertankRow);
            playerTankMock.SetupGet(pt => pt.ColumnPosition).Returns(col);

            collisionMock = new Mock<ICollision>();
            collisionMock.Setup(c => c.IsObstacleOrAlly(mapMock.Object, It.IsAny<int>(), It.IsAny<int>())).Returns(false);

            timerMock = new Mock<IGameTimer>();
            timerMock.Setup(timer => timer.EnemyTankShootCooldown()).Returns(true);

            var enemyTank = new EnemyTank(enemyTankRow, col, Direction.Right, mapMock.Object, playerTankMock.Object, enviromentFactoryStub.Object, collisionMock.Object, timerMock.Object);

            //act
            bool result = enemyTank.DetectPlayer();

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Return_True_When_PlayerTankIs_OnSameColumn_BiggerRow_IfColumn_IsClean()
        {
            //arrange
            int playertankRow = 2;
            int enemyTankRow = 1;
            int col = 5;

            playerTankMock = new Mock<IPlayerTank>();
            playerTankMock.SetupGet(pt => pt.RowPosition).Returns(playertankRow);
            playerTankMock.SetupGet(pt => pt.ColumnPosition).Returns(col);

            collisionMock = new Mock<ICollision>();
            collisionMock.Setup(c => c.IsObstacleOrAlly(mapMock.Object, It.IsAny<int>(), It.IsAny<int>())).Returns(false);

            timerMock = new Mock<IGameTimer>();
            timerMock.Setup(timer => timer.EnemyTankShootCooldown()).Returns(true);

            var enemyTank = new EnemyTank(enemyTankRow, col, Direction.Right, mapMock.Object, playerTankMock.Object, enviromentFactoryStub.Object, collisionMock.Object, timerMock.Object);

            //act
            bool result = enemyTank.DetectPlayer();

            //assert
            Assert.IsTrue(result);
        }
    }
}
