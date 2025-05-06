using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class GameStatsLogger
    {
        private const string LogFile = "log.txt";

        public static void LogResult(string playerName, int score)
        {
            string line = $"{DateTime.Now}: {playerName} набрал {score} очков.";
            File.AppendAllText(LogFile, line + Environment.NewLine);
        }
    }
}
