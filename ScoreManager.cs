using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class ScoreManager
    {
        public int Score { get; private set; }

        public void AddPoints(int amount)
        {
            Score += amount;
        }

        public void SaveScore(string playerName)
        {
            string line = $"{playerName};{Score};{DateTime.Now}";
            File.AppendAllText("results.txt", line + Environment.NewLine);
        }

        public static string[] GetTopResults(int count)
        {
            if (!File.Exists("results.txt"))
                return new string[0];

            var lines = File.ReadAllLines("results.txt");
            Array.Sort(lines, (a, b) =>
                int.Parse(b.Split(';')[1]).CompareTo(int.Parse(a.Split(';')[1]))); // по убыванию очков
            return lines.Length > count ? lines[..count] : lines;
        }

        public void Reset()
        {
            Score = 0;
        }
    }
}
