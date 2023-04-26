namespace MineFieldApp;

public class Game
{
    public GameStateEnum State { get; private set; }
    public IBoard Board { get; set; }
    public int TotalLive { get; private set; }
    
    public Game(IBoard board, int livesCount)
    {
        this.Board = board;
        this.TotalLive = livesCount;
    }

    public void StartNewGame()
    {
        State = GameStateEnum.InProgress;
    }

    public void Print()
    {
        this.Board.Print();
    }

    public string GetPlayerPosition()
    {
        return this.Board.GetPlayer().ToString();
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
        
        if (this.State == GameStateEnum.InProgress && this.Board.GetPlayer().Row == 0)
        {
            this.State = GameStateEnum.Success;
        }
    }
}