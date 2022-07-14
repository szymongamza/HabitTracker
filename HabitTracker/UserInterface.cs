using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitTracker
{
    public class UserInterface
    {
        public void MainMenuLoop(DbManager dbManager)
        {
            DataInputManager inputManager = new();
            Console.Clear();
            bool quitApp = false;
            while (quitApp == false)
            {
                Console.WriteLine("     MAIN MENU:");
                Console.WriteLine("Type 0 to quit app");
                Console.WriteLine("Type 1 to VIEW all coffee records");
                Console.WriteLine("Type 2 to INSERT coffee record");
                Console.WriteLine("Type 3 to DELETE coffee record");
                Console.WriteLine("Type 4 to UPDATE coffee record");
                var input = Console.ReadLine();
                int option = -1;
                while (input == null)
                {
                    input = Console.ReadLine();
                }
                try
                {
                    option = int.Parse(input);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                switch(option)
                {
                    case 0:
                        quitApp = true;
                        break;
                    case 1:
                        Console.WriteLine("-------------------------------------------------------");
                        inputManager.GetData(dbManager);
                        Console.WriteLine("-------------------------------------------------------");
                        break;
                    case 2:
                        inputManager.InsertData(dbManager);
                        break;
                }

            }
        }
    }
}
