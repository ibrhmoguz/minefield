namespace MineFieldApp;

public class Player
{
    public int Row { get; }
    public int Column { get; }

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