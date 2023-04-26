namespace MineFieldApp;

public interface IPlayer
{
    int Row { get; set; }
    int Column { get; set; }
    public string GetPosition();
}