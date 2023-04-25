namespace MineFieldApp;

public class Player
{
    public int Row { get; set; }
    public int Column { get; set; }

    public Player(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public override string ToString()
    {
        return $"{Util.Letters[Row]}{Column + 1}";
    }
}