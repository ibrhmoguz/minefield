namespace MineFieldApp;

public interface IBoard
{
    int Rows { get; }
    int Columns { get; }
    void Print();
    IPlayer GetPlayer();
    MoveValidationResult ValidateMove(int rowStep, int columnStep);
    Cell[,] GetCells();
}