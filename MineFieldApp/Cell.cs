namespace MineFieldApp;

public class Cell
{
    public int Row { get; set; }
    public int Column { get; set; }
    public bool HasBomb { get; set; }
    public string Value { get; set; }

    public Cell(int row, int column)
    {
        Row = row;
        Column = column;
        HasBomb = false;
    }

    public void Print(string newValue = "")
    {
        if (!string.IsNullOrEmpty(newValue))
        {
            this.Value = newValue;
        }
        else
        {
            this.Value = HasBomb switch
            {
                true => " * ",
                false => " . "
            };
        }

        Console.Write(this.Value);
    }
}