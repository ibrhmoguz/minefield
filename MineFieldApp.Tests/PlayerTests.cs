namespace MineFieldApp.Tests;

[TestClass]
public class PlayerTests
{
    [TestMethod]
    [DataRow(0,"A")]
    [DataRow(1,"B")]
    [DataRow(2,"C")]
    [DataRow(3,"D")]
    [DataRow(4,"E")]
    [DataRow(5,"F")]
    [DataRow(6,"G")]
    [DataRow(7,"H")]
    [DataRow(8,"I")]
    [DataRow(9,"J")]
    public void GetPosition_WhenSetsRows_SetsPositionText(int row, string position)
    {
        // Arrange
        var player = new Player(row,0);
        
        // Act
        var playerPosition = player.GetPosition();

        // Assert
        Assert.AreEqual($"{position}1", playerPosition);
    }
}