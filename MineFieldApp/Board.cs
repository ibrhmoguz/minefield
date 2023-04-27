namespace MineFieldApp;

public class Board : IBoard
{
    private readonly IPlayer _player;
    private readonly ICells _cells;

    public Board(IPlayer player, ICells cells)
    {
        _player = player;
        _cells = cells;
    }

    public void Print()
    {
        Console.Write("  ");

        // Column numbers
        for (var i = 0; i < _cells.Columns; i++)
        {
            Console.Write($" {i + 1} ");
        }

        Console.WriteLine();

        // Board
        for (var i = 0; i < _cells.Rows; i++)
        {
            Console.Write($"{Util.Letters[i]} ");
            for (var j = 0; j < _cells.Columns; j++)
            {
                if (_player.Row == i && _player.Column == j)
                {
                    if (!_cells.GetCell(i,j).IsVisited)
                    {
                        _cells.SetVisited(i,j);
                    }

                    _cells.Print(i,j, " X ");
                }
                else
                {
                    _cells.Print(i,j);
                }
            }

            Console.WriteLine();
        }

        Console.WriteLine();
    }

    public IPlayer GetPlayer()
    {
        return _player;
    }

    public MoveValidationResult ValidateMove(int rowStep, int columnStep)
    {
        var newRowIndex = _player.Row + rowStep;
        var newColumnIndex = _player.Column + columnStep;

        if (newRowIndex < 0 ||
            newRowIndex > _cells.Rows - 1 ||
            newColumnIndex < 0 ||
            newColumnIndex > _cells.Columns - 1)
        {
            return new MoveValidationResult {IsMoveValid = false};
        }

        // Set player's new location
        _player.Row = newRowIndex;
        _player.Column = newColumnIndex;

        // Set cell is visited
        var cell = _cells.GetCell(newRowIndex, newColumnIndex);
        cell.IsVisited = true;

        // Check new location has bomb
        return new MoveValidationResult
        {
            IsMoveValid = true,
            IsBombHit = cell.HasBomb
        };
    }
}