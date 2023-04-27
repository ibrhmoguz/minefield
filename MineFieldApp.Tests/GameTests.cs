using Moq;

namespace MineFieldApp.Tests;

[TestClass]
public class GameTests
{
    [TestMethod]
    public void Print_WhenPrints_CallsOnce()
    {
        // Arrange
        var boardMock = new Mock<IBoard>();
        var game = new Game(boardMock.Object, 3);

        // Act
        game.Print();

        // Assert
        boardMock.Verify(board => board.Print(), Times.Once);
    }
    
    [TestMethod]
    public void StartNewGame_WhenNoMove_SetsBoard()
    {
        // Arrange
        var boardMock = new Mock<IBoard>();
        var game = new Game(boardMock.Object, 3);

        // Act
        game.StartNewGame();

        // Assert
        Assert.AreEqual(GameStateEnum.InProgress, game.State);
        Assert.AreEqual(3, game.TotalLive);
        Assert.IsNotNull(game.Board);
    }

    [TestMethod]
    public void GetPlayerPosition_WhenStartNewGame_GetsCorrectPosition()
    {
        // Arrange
        var boardMock = new Mock<IBoard>();
        boardMock.Setup(board => board.GetPlayer()).Returns(new Player(3, 0));
        var game = new Game(boardMock.Object, 3);
        game.StartNewGame();

        // Act
        var playerPosition = game.GetPlayerPosition();

        // Assert
        boardMock.Verify(board => board.GetPlayer(), Times.Once);
    }
    
    [TestMethod]
    public void Move_WhenValidateMoveReturnsFalse_TotalMoveShouldNotBeIncreased()
    {
        // Arrange
        var boardMock = new Mock<IBoard>();
        boardMock.Setup(x => x.ValidateMove(1, 1)).Returns(new MoveValidationResult
        {
            IsMoveValid = false
        });
        var game = new Game(boardMock.Object, 1);
        game.StartNewGame();

        // Act
        game.Move(1, 1);

        // Assert
        Assert.AreEqual(0, game.TotalMove);
        Assert.AreEqual(GameStateEnum.InProgress, game.State);
    }

    [TestMethod]
    public void Move_WhenValidateMoveReturnsTrue_DecreasesTotalLiveAndSetsStateToGameOver()
    {
        // Arrange
        var boardMock = new Mock<IBoard>();
        boardMock.Setup(x => x.ValidateMove(1, 1)).Returns(new MoveValidationResult
        {
            IsMoveValid = true, 
            IsBombHit = true
        });
        var game = new Game(boardMock.Object, 1);
        game.StartNewGame();

        // Act
        game.Move(1, 1);

        // Assert
        Assert.AreEqual(0, game.TotalLive);
        Assert.AreEqual(GameStateEnum.GameOver, game.State);
    }

    [TestMethod]
    public void Move_WhenPlayerReachesTheTop_SetsStateToSuccess()
    {
        // Arrange
        var boardMock = new Mock<IBoard>();
        boardMock.Setup(board => board.GetPlayer()).Returns(new Player(0, 1));
        boardMock.Setup(x => x.ValidateMove(1, 0)).Returns(new MoveValidationResult {IsMoveValid = true});
        var game = new Game(boardMock.Object, 1);
        game.StartNewGame();

        // Act
        game.Move(1, 0);

        // Assert
        Assert.AreEqual(GameStateEnum.Success, game.State);
    }
}