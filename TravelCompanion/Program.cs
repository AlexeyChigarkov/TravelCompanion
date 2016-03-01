using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCompanion
{
    class Program
    {
        static void Main(string[] args)
        {

            ExampleData.LoadData();

            ProgrammConsole pg = new ProgrammConsole();

            while (true)

            {
                Console.Clear();
                pg.Update();
            }
        }
    }
    }

