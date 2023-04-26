namespace MineFieldApp;

public interface IBoard
{
    int Rows { get; }
    int Columns { get; }
    void Print();
    Player GetPlayer();
    bool ValidateMove(int rowStep, int columnStep);
    Cell[,] GetCells();
}