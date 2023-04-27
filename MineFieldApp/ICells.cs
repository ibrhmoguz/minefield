namespace MineFieldApp;

public interface ICells
{
    int Rows { get; }
    int Columns { get; }
    Cell GetCell(int row, int column);
    void Print(int row, int column, string printValue = "");
    void SetVisited(int row, int column);
}