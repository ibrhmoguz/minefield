namespace MineFieldApp;

public class Cell
{
    public int Row { get; set; }
    public int Column { get; set; }
    public bool HasBomb { get; set; }

    public Cell(int row, int column)
    {
        Row = row;
        Column = column;
        HasBomb = false;
    }

    public void Print()
    {
        switch (HasBomb)
        {
            case true:
                Console.Write(" * ");
                break;
            case false:
                Console.Write(" . ");
                break;
        }
    }
}