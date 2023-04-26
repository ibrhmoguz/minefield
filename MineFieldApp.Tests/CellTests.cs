namespace MineFieldApp.Tests;

[TestClass]
public class CellTests
{
    [TestMethod]
    public void Print_WhenPlayerIsInTheCell_SetsValue()
    {
        // Arrange
        var cell = new Cell(2, 2);

        // Act
        cell.Print(" X ");

        // Assert
        Assert.IsNotNull(cell);
        Assert.AreEqual(" X ", cell.Value);
    }
    
    [TestMethod]
    public void Print_WhenPlayerIsInTheCellAndCellHasBomb_SetsValue()
    {
        // Arrange
        var cell = new Cell(2, 2) {HasBomb = true};

        // Act
        cell.Print(" X ");

        // Assert
        Assert.IsNotNull(cell);
        Assert.AreEqual(" X ", cell.Value);
    }

    [TestMethod]
    public void Print_WhenCellNotHaveBomb_SetsValue()
    {
        // Arrange
        var cell = new Cell(2, 2);

        // Act
        cell.Print();

        // Assert
        Assert.IsNotNull(cell);
        Assert.AreEqual(" . ", cell.Value);
    }

    [TestMethod]
    public void Print_WhenCellHasBomb_SetsValue()
    {
        // Arrange
        var cell = new Cell(2, 2) {HasBomb = true};

        // Act
        cell.Print();

        // Assert
        Assert.IsNotNull(cell);
        Assert.AreEqual(" * ", cell.Value);
    }
}