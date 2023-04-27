namespace MineFieldApp;

public class Cell
{
    public bool HasBomb { get; set; }
    public string Value { get; private set; }
    public bool IsVisited { get; set; }

    public void Print(string newValue = "")
    {
        if (!string.IsNullOrEmpty(newValue))
        {
            this.Value = newValue;
        }
        else
        {
            if (!this.IsVisited)
            {
                this.Value = " . ";
            }
            else
            {
                this.Value = HasBomb switch
                {
                    true => " * ",
                    false => " = "
                };
            }
        }

        Console.Write(this.Value);
    }
}