using Moq;

namespace MineFieldApp.Tests;

[TestClass]
public class BoardTests
{
    [TestMethod]
    [DataRow(-5, 0)]
    [DataRow(1, 0)]
    [DataRow(0, 5)]
    [DataRow(0, -1)]
    public void ValidateMove_WhenInvalid_ReturnsFalse(int rowStep, int columnStep)
    {
        // Arrange
        var playerMock = new Mock<IPlayer>();
        playerMock.Setup(player => player.Row).Returns(4);
        playerMock.Setup(player => player.Column).Returns(0);

        var cellsMock = new Mock<ICells>();
        cellsMock.Setup(c => c.Rows).Returns(5);
        cellsMock.Setup(c => c.Columns).Returns(5);
        var board = new Board(playerMock.Object, cellsMock.Object);

        // Act
        var result = board.ValidateMove(rowStep, columnStep);

        // Assert
        Assert.AreEqual(false, result.IsMoveValid);
    }

    [TestMethod]
    [DataRow(-1, 0)]
    [DataRow(1, 0)]
    [DataRow(0, -1)]
    [DataRow(0, 1)]
    public void ValidateMove_WhenValid_SetsPlayerLocation(int rowStep, int columnStep)
    {
        // Arrange
        var playerMock = new Mock<IPlayer>();
        playerMock.Setup(player => player.Row).Returns(3);
        playerMock.Setup(player => player.Column).Returns(2);

        var cellsMock = new Mock<ICells>();
        cellsMock.Setup(c => c.Rows).Returns(5);
        cellsMock.Setup(c => c.Columns).Returns(5);
        cellsMock.Setup(c => c.GetCell(It.IsAny<int>(), It.IsAny<int>())).Returns(new Cell {HasBomb = false});
        var board = new Board(playerMock.Object, cellsMock.Object);

        // Act
        board.ValidateMove(rowStep, columnStep);

        // Assert
        playerMock.VerifySet(p => p.Row = 3 + rowStep);
        playerMock.VerifySet(p => p.Column = 2 + columnStep);
    }

    [TestMethod]
    public void Print_WhenPrintBoard_CallsCellsPrint()
    {
        // Arrange
        var playerMock = new Mock<IPlayer>();
        playerMock.Setup(player => player.Row).Returns(3);
        playerMock.Setup(player => player.Column).Returns(2);

        var cellsMock = new Mock<ICells>();
        cellsMock.Setup(c => c.Rows).Returns(5);
        cellsMock.Setup(c => c.Columns).Returns(5);
        cellsMock.Setup(c => c.GetCell(3, 2)).Returns(new Cell {IsVisited = false});
        var board = new Board(playerMock.Object, cellsMock.Object);

        // Act
        board.Print();

        // Assert
        playerMock.VerifyGet(p => p.Row, Times.Exactly(25));
        playerMock.VerifyGet(p => p.Column, Times.Exactly(5));
        cellsMock.Verify(cells => cells.GetCell(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        cellsMock.Verify(cells => cells.SetVisited(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        cellsMock.Verify(cells => cells.Print(3, 2, " X "), Times.Once);
        cellsMock.Verify(cells => cells.Print(It.IsAny<int>(), It.IsAny<int>(), ""), Times.Exactly(24));
    }

    [TestMethod]
    public void GetPlayer_ReturnsPlayer()
    {
        // Arrange
        var playerMock = new Mock<IPlayer>();
        playerMock.Setup(player => player.Row).Returns(3);
        playerMock.Setup(player => player.Column).Returns(2);

        var cellsMock = new Mock<ICells>();
        var board = new Board(playerMock.Object, cellsMock.Object);

        // Act
        var player = board.GetPlayer();

        // Assert
        Assert.AreEqual(3, player.Row);
        Assert.AreEqual(2, player.Column);
    }
}