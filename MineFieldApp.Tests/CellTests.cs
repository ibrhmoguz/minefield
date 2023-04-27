namespace MineFieldApp.Tests;

[TestClass]
public class CellTests
{
    [TestMethod]
    public void Print_WhenPlayerIsInTheCell_SetsValue()
    {
        // Arrange
        var cell = new Cell();

        // Act
        cell.Print(" X ");

        // Assert
        Assert.IsNotNull(cell);
        Assert.AreEqual(" X ", cell.Value);
    }

    [TestMethod]
    public void Print_WhenCellIsVisited_SetsValue()
    {
        // Arrange
        var cell = new Cell {IsVisited = false};

        // Act
        cell.Print();

        // Assert
        Assert.IsNotNull(cell);
        Assert.AreEqual(" . ", cell.Value);
    }

    [TestMethod]
    public void Print_WhenCellIsVisitedAndNotHaveBomb_SetsValue()
    {
        // Arrange
        var cell = new Cell {IsVisited = true};

        // Act
        cell.Print();

        // Assert
        Assert.IsNotNull(cell);
        Assert.AreEqual(" = ", cell.Value);
    }

    [TestMethod]
    public void Print_WhenCellIsVisitedAndHasBomb_SetsValue()
    {
        // Arrange
        var cell = new Cell {IsVisited = true, HasBomb = true};

        // Act
        cell.Print();

        // Assert
        Assert.IsNotNull(cell);
        Assert.AreEqual(" * ", cell.Value);
    }
}