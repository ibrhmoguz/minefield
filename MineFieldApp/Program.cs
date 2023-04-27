namespace MineFieldApp
{
    public static class Program
    {
        static void Main(string[] args)
        {
            // Default board size 10 X 10
            CreateGame();

            var key = Console.ReadKey();
            while (key.Key == ConsoleKey.Y)
            {
                CreateGame();
                key = Console.ReadKey();
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        private static void CreateGame()
        {
            var game = new Game(new Board(new Player(9, 0), new Cells(10, 10)), 5);
            StartNewGame(game);
        }

        private static void StartNewGame(Game game)
        {
            game.StartNewGame();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Minesweeper Game");
                Console.WriteLine($"Live:{game.TotalLive}   Position:{game.GetPlayerPosition()}   Total Move:{game.TotalMove}");
                Console.WriteLine();

                game.Print();

                if (game.State != GameStateEnum.InProgress)
                {
                    break;
                }

                Console.WriteLine("Move (up, down, left, right key): ");
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        game.Move(-1, 0);
                        break;
                    case ConsoleKey.DownArrow:
                        game.Move(1, 0);
                        break;
                    case ConsoleKey.LeftArrow:
                        game.Move(0, -1);
                        break;
                    case ConsoleKey.RightArrow:
                        game.Move(0, 1);
                        break;
                }
            }

            switch (game.State)
            {
                case GameStateEnum.GameOver:
                    Console.WriteLine("Game over");
                    break;
                case GameStateEnum.Success:
                    Console.WriteLine("Winner!");
                    break;
            }

            Console.WriteLine("Play again? (y/n)");
        }
    }
}