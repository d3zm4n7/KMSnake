using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Params
    {
        private string resourcesFolder;

        public Params()
        {
            var ind = Directory.GetCurrentDirectory().ToString()
                .IndexOf("bin", StringComparison.Ordinal); // Получить индекс папки bin

            string binFolder =
                Directory.GetCurrentDirectory().ToString().Substring(0, ind)
                .ToString(); // путь до указанной в индексе папки

            resourcesFolder = binFolder + "resources\\";
        }

        public string GetResourceFolder()
        {
            return resourcesFolder;
        }
    }
}
