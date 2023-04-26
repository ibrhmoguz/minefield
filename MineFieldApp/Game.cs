namespace MineFieldApp;

public class Game
{
    public GameStateEnum State { get; private set; }
    private Board Board { get; set; }
    public int TotalLive { get; private set; }
    private int Rows { get; }
    private int Columns { get; }

    public Game(int rowCount, int columnCount)
    {
        this.Rows = rowCount;
        this.Columns = columnCount;
    }

    public void StartNewGame()
    {
        TotalLive = 5;
        State = GameStateEnum.InProgress;
        this.Board = new Board(this.Rows, this.Columns);
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