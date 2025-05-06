using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class LevelManager
    {
        public enum Difficulty { Easy, Medium, Hard }

        public int GetSpeed(Difficulty level)
        {
            return level switch
            {
                Difficulty.Easy => 200,
                Difficulty.Medium => 120,
                Difficulty.Hard => 70,
                _ => 150
            };
        }
    }
}
