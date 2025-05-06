using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Player
    {
        public string Name { get; private set; }

        public void AskName()
        {
            Console.Write("Введите имя (мин. 3 символа): ");
            Name = Console.ReadLine();
            while (Name.Length < 3)
            {
                Console.Write("Имя слишком короткое. Повторите: ");
                Name = Console.ReadLine();
            }
        }
    }
}
