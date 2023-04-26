namespace MineFieldApp;

public class Board : IBoard
{
    public int Rows { get; }
    public int Columns { get; }
    private Cell[,] _cells;
    private IPlayer Player { get; }

    public Board(IPlayer player, int rowCount, int columnCount)
    {
        this.Rows = rowCount;
        this.Columns = columnCount;
        this.Player = player;
        ResetBoard();
    }

    private void ResetBoard()
    {
        var rand = new Random();
        _cells = new Cell[Rows, Columns];
        for (var i = 0; i < Rows; i++)
        {
            for (var j = 0; j < Columns; j++)
            {
                var cell = new Cell(i, j);
                if (rand.Next(Rows) == 0)
                {
                    cell.HasBomb = true;
                }

                _cells[i, j] = cell;
            }
        }
    }

    public void Print()
    {
        Console.Write("  ");

        // Column numbers
        for (var i = 0; i < Columns; i++)
        {
            Console.Write($" {i + 1} ");
        }

        Console.WriteLine();

        // Board
        for (var i = 0; i < Rows; i++)
        {
            Console.Write($"{Util.Letters[i]} ");
            for (var j = 0; j < Columns; j++)
            {
                if (this.Player.Row == i && this.Player.Column == j)
                {
                    _cells[i, j].Print(" X ");
                }
                else
                {
                    _cells[i, j].Print();
                } 
            }

            Console.WriteLine();
        }

        Console.WriteLine();
    }

    public IPlayer GetPlayer()
    {
        return this.Player;
    }

    public bool ValidateMove(int rowStep, int columnStep)
    {
        var newRowIndex = this.Player.Row + rowStep;
        var newColumnIndex = this.Player.Column + columnStep;

        if (newRowIndex < 0 ||
            newRowIndex > Rows - 1 ||
            newColumnIndex < 0 ||
            newColumnIndex > Columns - 1)
        {
            return false;
        }

        // Set player's new location
        this.Player.Row = newRowIndex;
        this.Player.Column = newColumnIndex;

        // Check new location has bomb
        return _cells[newRowIndex, newColumnIndex].HasBomb;
    }

    public Cell[,] GetCells()
    {
        return this._cells;
    }
}