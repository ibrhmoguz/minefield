namespace MineFieldApp;

public interface IBoard
{
    void Print();
    IPlayer GetPlayer();
    MoveValidationResult ValidateMove(int rowStep, int columnStep);
}