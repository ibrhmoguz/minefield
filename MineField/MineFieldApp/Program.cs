namespace MineFieldApp
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Minesweeper!");
            Console.WriteLine("Board (10 X 10):");

            var game = new Game();
            game.StartNewGame();

            while (game.State == GameStateEnum.InProgress)
            {
                Console.Clear();
                Console.WriteLine($"Live: {game.TotalLive}  Position: {game.GetPlayerPosition()}");
                Console.WriteLine();
                
                game.Print();
                
                Console.WriteLine("Move: ");
                Console.ReadKey();
                
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}