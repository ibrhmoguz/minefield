namespace MineFieldApp.Tests;

[TestClass]
public class CellsTests
{
    [TestMethod]
    public void GetCell_WhenRowAndColumnIsGiven_ReturnsCell()
    {
        // Arrange
        var cells = new Cells(5, 5);

        // Act
        var cell = cells.GetCell(2, 3);

        // Assert
        Assert.IsNotNull(cell);
    }
    
    [TestMethod]
    public void SetVisited()
    {
        // Arrange
        var cells = new Cells(5, 5);

        // Act
        cells.SetVisited(2, 3);

        // Assert
        var cell = cells.GetCell(2, 3);
        Assert.IsNotNull(cell);
        Assert.AreEqual(true, cell.IsVisited);
    }
    
    [TestMethod]
    public void Print_WhenCellIsNotVisited_PrintDot()
    {
        // Arrange
        var cells = new Cells(5, 5);
        var cell = cells.GetCell(3, 2);
        
        // Act
        cells.Print(3, 2);

        // Assert
        Assert.IsNotNull(cell);
        Assert.AreEqual(" . ", cell.Value);
    }
    
    [TestMethod]
    public void Print_WhenCellIsVisited_PrintDot()
    {
        // Arrange
        var cells = new Cells(5, 5);
        var cell = cells.GetCell(3, 2);
        cell.IsVisited = true;
        cell.HasBomb = false;
        
        // Act
        cells.Print(3, 2);

        // Assert
        Assert.IsNotNull(cell);
        Assert.AreEqual(" = ", cell.Value);
    }
    
    [TestMethod]
    public void Print_WhenCellIsVisitedAndHasBomb_PrintAsterisk()
    {
        // Arrange
        var cells = new Cells(5, 5);
        var cell = cells.GetCell(3, 2);
        cell.IsVisited = true;
        cell.HasBomb = true;
        
        // Act
        cells.Print(3, 2);

        // Assert
        Assert.IsNotNull(cell);
        Assert.AreEqual(" * ", cell.Value);
    }
}