using Moq;

namespace MineFieldApp.Tests;

[TestClass]
public class GameTests
{
    [TestMethod]
    public void TestStartNewGame()
    {
        // Arrange
        var boardMock = new Mock<IBoard>();
        boardMock.Setup(board => board.Rows).Returns(5);
        boardMock.Setup(board => board.Columns).Returns(5);
        var game = new Game(boardMock.Object, 3);

        // Act
        game.StartNewGame();

        // Assert
        Assert.AreEqual(GameStateEnum.InProgress, game.State);
        Assert.AreEqual(3, game.TotalLive);
        Assert.IsNotNull(game.Board);
        Assert.AreEqual(5, game.Board.Rows);
        Assert.AreEqual(5, game.Board.Columns);
    }

    [TestMethod]
    public void TestGetPlayerPosition()
    {
        // Arrange
        var boardMock = new Mock<IBoard>();
        boardMock.Setup(board => board.Rows).Returns(4);
        boardMock.Setup(board => board.Columns).Returns(4);
        boardMock.Setup(board => board.GetPlayer()).Returns(new Player(3,0));
        var game = new Game(boardMock.Object, 3);
        game.StartNewGame();

        // Act
        var playerPosition = game.GetPlayerPosition();

        // Assert
        Assert.IsNotNull(playerPosition);
        Assert.AreEqual("D1", playerPosition);
    }
    
    [TestMethod]
    public void Move_WhenValidateMoveReturnsFalse_DecreasesTotalLiveAndSetsStateToGameOver()
    {
        // Arrange
        var boardMock = new Mock<IBoard>();
        boardMock.Setup(board => board.Rows).Returns(3);
        boardMock.Setup(board => board.Columns).Returns(3);
        boardMock.Setup(x => x.ValidateMove(1, 1)).Returns(false);
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
        boardMock.Setup(board => board.Rows).Returns(3);
        boardMock.Setup(board => board.Columns).Returns(3);
        boardMock.Setup(board => board.GetPlayer()).Returns(new Player(0,1));
        boardMock.Setup(x => x.ValidateMove(1, 0)).Returns(true);
        var game = new Game(boardMock.Object, 1);
        game.StartNewGame();

        // Act
        game.Move(1, 0);

        // Assert
        Assert.AreEqual(GameStateEnum.Success, game.State);
    }
    
    [TestMethod]
    public void TestPrint()
    {
        // Arrange
        var game = new Game(new Board(7, 7), 5);
        game.StartNewGame();

        // Act
        game.Print();

        // Assert
        var cells = game.Board.GetCells();
        Assert.IsNotNull(cells);
        
        for (var i = 0; i < 7; i++)
        {
            for (var j = 0; j < 7; j++)
            {
                var cell = cells[i, j];

                Assert.IsNotNull(cell);
                // Player's default starting position
                if (i == 6 && j == 0)
                {
                    Assert.AreEqual(" X ", cell.Value);
                }
                else if (cell.HasBomb)
                {
                    Assert.AreEqual(" * ", cell.Value);
                }
                else
                {
                    Assert.AreEqual(" . ", cell.Value);
                }
            }
        }
    }
    
}