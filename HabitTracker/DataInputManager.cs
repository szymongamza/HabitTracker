using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitTracker
{
    public class DataInputManager
    {
        public void InsertData(DbManager dbManager)
        {
            Console.WriteLine("Input data as DD-MM-YYYY:");
            var date = Console.ReadLine();
            while(date == null)
            {
                date = Console.ReadLine();
            }
            Console.WriteLine("Input number of coffees:");
            var numberOfCoffees = Console.ReadLine();
            int quantity = 0;
            while (numberOfCoffees == null)
            {
                numberOfCoffees = Console.ReadLine();
            }
            try
            {
                quantity = int.Parse(numberOfCoffees);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine(date);
            dbManager.InsertRecord(date, quantity);
        }
        public void GetData(DbManager dbManager)
        {
            List<HabitModel> listOfHabitModel = dbManager.GetRecords();

            foreach(var habitModel in listOfHabitModel)
            {
                Console.WriteLine($"{habitModel.Id} - {DateOnly.FromDateTime(habitModel.Date)} - Number of coffees: {habitModel.Quantity}");
            }
        }
    }
}
