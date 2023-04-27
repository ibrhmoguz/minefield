namespace MineFieldApp;

public class Cells : ICells
{
    public int Rows { get; }
    public int Columns { get; }
    private Cell[,] _cells;

    public Cells(int rowCount, int columnCount)
    {
        this.Rows = rowCount;
        this.Columns = columnCount;
        ResetCells();
    }

    public Cell GetCell(int row, int column)
    {
        return _cells[row, column];
    }

    public void Print(int row, int column, string printValue = "")
    {
        this.GetCell(row,column).Print(printValue);
    }

    private void ResetCells()
    {
        var rand = new Random();
        _cells = new Cell[Rows, Columns];
        for (var i = 0; i < Rows; i++)
        {
            for (var j = 0; j < Columns; j++)
            {
                var cell = new Cell();
                if (rand.Next(Rows) == 0)
                {
                    cell.HasBomb = true;
                }

                _cells[i, j] = cell;
            }
        }
    }

    public void SetVisited(int row, int column)
    {
        this.GetCell(row,column).IsVisited = true;
    }
}