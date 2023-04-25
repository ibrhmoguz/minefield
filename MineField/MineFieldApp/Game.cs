namespace MineFieldApp;

public class Game
{
    public GameStateEnum State { get; private set; }
    private Board Board { get; set; }
    public int TotalLive { get; private set; }

    public void StartNewGame()
    {
        TotalLive = 5;
        State = GameStateEnum.InProgress;
        this.Board = new Board();
        this.Board.ResetBoard();
    }

    public void Print()
    {
        this.Board.Print();
    }

    public string GetPlayerPosition()
    {
        return this.Board.GetPlayerPosition();
    }
}