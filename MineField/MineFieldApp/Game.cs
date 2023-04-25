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
    }

    public void Print()
    {
        this.Board.Print();
    }

    public string GetPlayerPosition()
    {
        return this.Board.GetPlayerPosition();
    }

    public void Move(int rowStep, int columnStep)
    {
        if (!this.Board.ValidateMove(rowStep, columnStep))
        {
            this.TotalLive--;
            if (TotalLive == 0)
            {
                this.State = GameStateEnum.GameOver;
            }
        }
        
        if (this.State == GameStateEnum.InProgress && this.Board.GetPlayerRowIndex() == 0)
        {
            this.State = GameStateEnum.Success;
        }
    }
}