namespace MineFieldApp;

public class Player : IPlayer
{
    public int Row { get; set; }
    public int Column { get; set; }

    public Player(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public string GetPosition()
    {
        return $"{Util.Letters[Row]}{Column + 1}";
    }
}