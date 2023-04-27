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
                var cell = new Cell();
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
                    if (!_cells[i, j].IsVisited)
                    {
                        _cells[i, j].IsVisited = true;
                    }
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

    public MoveValidationResult ValidateMove(int rowStep, int columnStep)
    {
        var newRowIndex = this.Player.Row + rowStep;
        var newColumnIndex = this.Player.Column + columnStep;

        if (newRowIndex < 0 ||
            newRowIndex > Rows - 1 ||
            newColumnIndex < 0 ||
            newColumnIndex > Columns - 1)
        {
            return new MoveValidationResult {IsMoveValid = false};
        }

        // Set player's new location
        this.Player.Row = newRowIndex;
        this.Player.Column = newColumnIndex;
        
        // Set cell is visited
        _cells[newRowIndex, newColumnIndex].IsVisited = true;

        // Check new location has bomb
        return new MoveValidationResult
        {
            IsMoveValid = true,
            IsBombHit = _cells[newRowIndex, newColumnIndex].HasBomb
        };
    }
}