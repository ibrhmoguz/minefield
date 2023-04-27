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
        var board = new Board(playerMock.Object, 5, 5);

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
        var board = new Board(playerMock.Object, 5, 5);

        // Act
        board.ValidateMove(rowStep, columnStep);
        var player = board.GetPlayer();

        // Assert
        playerMock.VerifySet(p => p.Row = 3 + rowStep);
        playerMock.VerifySet(p => p.Column = 2 + columnStep);
    }
}