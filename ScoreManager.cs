using System;

namespace Snake
{
    /// <summary>
    /// Управляет подсчётом очков в зависимости от уровня сложности:
    /// Easy = 1 очко за еду;
    /// Normal = 2;
    /// Hard = 3.
    /// </summary>
    public class ScoreManager
    {
        private readonly int pointsPerFood;
        public int Score { get; private set; }

        /// <param name="difficulty">0 = Easy, 1 = Normal, 2 = Hard</param>
        public ScoreManager(int difficulty)
        {
            // Настраиваем вес очка в зависимости от сложности
            pointsPerFood = difficulty switch
            {
                0 => 1,
                2 => 3,
                _ => 2, // Normal
            };
            Score = 0;
        }

        /// <summary>
        /// При поедании еды добавляет нужное количество очков.
        /// </summary>
        public void AddPoint()
        {
            Score += pointsPerFood;
        }

        /// <summary>
        /// Рисует текущий счёт в консоли в указанной позиции.
        /// </summary>
        /// <param name="x">колонка</param>
        /// <param name="y">строка</param>
        public void Draw(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write($"Score: {Score}");
        }
    }
}