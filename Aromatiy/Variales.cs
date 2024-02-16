using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aromatiy
{
    internal class Variables
    {
        public static int id { get; set; }
        public static int Role { get; set; }
        public static string allName { get; set; }
        public static List<int> selectProduct { get; set; }

        // Статический конструктор для инициализации списка
        static Variables()
        {
            // Инициализация списка
            selectProduct = new List<int>();
        }
    }
}
