namespace MineFieldApp;

public class Board
{
    private static int Rows => 10;
    private static int Columns => 10;

    private Cell[,] _board;
    private Player Player { get; set; }

    public Board()
    {
        ResetBoard();
    }

    private void ResetBoard()
    {
        var rand = new Random();
        _board = new Cell[Rows, Columns];
        
        // Set default starting position of player (Left bottom corner)
        Player = new Player(9, 0);

        for (var i = 0; i < Rows; i++)
        {
            for (var j = 0; j < Columns; j++)
            {
                var cell = new Cell(i, j);
                if (rand.Next(5) == 0) 
                {
                    cell.HasBomb = true;
                }
                _board[i, j] = cell;
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
                    Console.Write(" X ");
                }
                else
                {
                    _board[i, j].Print();
                }
            }
            Console.WriteLine();
        }
        
        Console.WriteLine();
    }

    public string GetPlayerPosition()
    {
        return this.Player.ToString();
    }

    public bool ValidateMove(int rowStep, int columnStep)
    {
        var newRowIndex = this.Player.Row + rowStep;
        var newColumnIndex = this.Player.Column + columnStep;

        if (newRowIndex < 0 ||
            newRowIndex > Rows - 1 ||
            newColumnIndex < 0 ||
            newColumnIndex > Rows - 1)
        {
            return true;
        }
        
        // Set player's new location
        this.Player.Row = newRowIndex;
        this.Player.Column = newColumnIndex;

        // Check new location has bomb
        return !_board[newRowIndex, newColumnIndex].HasBomb;
    }

    public int GetPlayerRowIndex()
    {
        return this.Player.Row;
    }
}