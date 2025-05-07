using System;
using System.Threading;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            int difficulty = 1; // 0=Easy, 1=Normal, 2=Hard
            bool soundOn = true;

            while (true)
            {
                int mainChoice = ShowMainMenu();
                if (mainChoice == 0) // New Game
                {
                    StartGame(difficulty, soundOn);
                    Console.WriteLine("\nPress any key to return to menu...");
                    Console.ReadKey(true);
                }
                else if (mainChoice == 1) // Settings
                {
                    ShowSettingsMenu(ref difficulty, ref soundOn);
                }
                else if (mainChoice == 2) // Exit Game
                {
                    break;
                }
            }
        }

        static int ShowMainMenu()
        {
            string[] options = { "New Game", "Settings", "Exit Game" };
            int index = 0;
            ConsoleKey key;
            do
            {
                Console.Clear();
                Console.WriteLine("=== Snake Game ===\n");
                for (int i = 0; i < options.Length; i++)
                {
                    if (i == index) Console.Write("> ");
                    else Console.Write("  ");
                    Console.WriteLine(options[i]);
                }
                key = Console.ReadKey(true).Key;
                // WASD or arrow navigation
                if (key == ConsoleKey.UpArrow || key == ConsoleKey.W) index = (index + options.Length - 1) % options.Length;
                else if (key == ConsoleKey.DownArrow || key == ConsoleKey.S) index = (index + 1) % options.Length;
            } while (key != ConsoleKey.Enter && key != ConsoleKey.Spacebar);
            return index;
        }

        static void ShowSettingsMenu(ref int difficulty, ref bool soundOn)
        {
            string[] diffOptions = { "Easy", "Normal", "Hard" };
            int diffIndex = difficulty;
            string[] soundOptions = { "On", "Off" };
            int soundIndex = soundOn ? 0 : 1;
            int section = 0; // 0=Difficulty, 1=Sound
            ConsoleKey key;
            do
            {
                Console.Clear();
                Console.WriteLine("=== Settings ===\n");

                Console.WriteLine("Difficulty:");
                for (int i = 0; i < diffOptions.Length; i++)
                {
                    if (section == 0 && i == diffIndex) Console.Write("> ");
                    else Console.Write("  ");
                    Console.WriteLine(diffOptions[i]);
                }

                Console.WriteLine("\nSound:");
                for (int i = 0; i < soundOptions.Length; i++)
                {
                    if (section == 1 && i == soundIndex) Console.Write("> ");
                    else Console.Write("  ");
                    Console.WriteLine(soundOptions[i]);
                }

                Console.WriteLine("\nUse WASD or arrow keys to navigate, Enter or Space to confirm.");
                key = Console.ReadKey(true).Key;

                // Navigate sections
                if (key == ConsoleKey.UpArrow || key == ConsoleKey.W)
                {
                    section = (section + 1) % 2;
                }
                else if (key == ConsoleKey.DownArrow || key == ConsoleKey.S)
                {
                    section = (section + 1) % 2;
                }
                // Change values
                else if (key == ConsoleKey.LeftArrow || key == ConsoleKey.A)
                {
                    if (section == 0) diffIndex = (diffIndex + diffOptions.Length - 1) % diffOptions.Length;
                    else soundIndex = (soundIndex + soundOptions.Length - 1) % soundOptions.Length;
                }
                else if (key == ConsoleKey.RightArrow || key == ConsoleKey.D)
                {
                    if (section == 0) diffIndex = (diffIndex + 1) % diffOptions.Length;
                    else soundIndex = (soundIndex + 1) % soundOptions.Length;
                }
            } while (key != ConsoleKey.Enter && key != ConsoleKey.Spacebar);

            difficulty = diffIndex;
            soundOn = (soundIndex == 0);
        }

        static void StartGame(int difficulty, bool soundOn)
        {
            Console.Clear();

            int width = 80;
            int height = 25;

            Walls walls = new Walls(width, height);
            walls.Draw();

            Point startPoint = new Point(4, 5, '@');
            Snake snake = new Snake(startPoint, 5, Direction.RIGHT);
            snake.Draw();

            FoodCreator foodCreator = new FoodCreator(width, height, 'O');
            Point food = foodCreator.CreateFood();
            food.Draw();

            var scoreManager = new ScoreManager(difficulty);
            scoreManager.Draw(85, 1); // например, в левом верхнем углу

            /*SoundManager soundMgr = new SoundManager();
            soundMgr.Enabled = soundOn;*/

            int speed = difficulty == 0 ? 200 : difficulty == 2 ? 50 : 100;

            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHit(snake))
                {
                    Console.SetCursorPosition(width / 2 - 5, height / 2);
                    Console.WriteLine("GAME OVER");
                    /*soundMgr.PlayGameOver();*/
                    break;
                }

                if (snake.Eat(food))
                {
                    scoreManager.AddPoint();
                    scoreManager.Draw(85, 1);
                    food = foodCreator.CreateFood();
                    food.Draw();
                    /*soundMgr.PlayEat();*/
                }
                else
                {
                    snake.Move();
                }

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    snake.HandleKey(keyInfo.Key);
                }

                Thread.Sleep(speed);
            }
        }
    }
}
