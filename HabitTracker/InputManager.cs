using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitTracker
{
    public class InputManager
    {
        public void InsertData(DbManager dbManager)
        {
            Console.WriteLine("Input data as YYYY-MM-DD:");
            string date = DateInput();
            Console.WriteLine("Input number of coffees:");
            int quantity = NumberInput();
            dbManager.InsertRecord(date, quantity);
        }
        public void GetData(DbManager dbManager)
        {
            List<HabitModel> listOfHabitModel = dbManager.GetRecords();
            Console.WriteLine("-------------------------------------------------------");
            foreach (var habitModel in listOfHabitModel)
            {
                Console.WriteLine($"{habitModel.Id} - {habitModel.Date} - Number of coffees: {habitModel.Quantity}");
            }
            Console.WriteLine("-------------------------------------------------------");
        }
        public void DeleteData(DbManager dbManager)
        {
            Console.WriteLine("Type in Id of the record that you want to delete.");
            int id = NumberInput();
            dbManager.DeleteRecord(id);
        }
        public void UpdateData(DbManager dbManager)
        {
            Console.WriteLine("Choose record you want to update by Id:");
            int id = NumberInput();

            Console.WriteLine("Input data as YYYY-MM-DD:");
            string date = DateInput();
            Console.WriteLine("Input number of coffees:");
            int quantity = NumberInput();
            dbManager.UpdateRecord(id, date, quantity);
        }
        private int NumberInput()
        {
            var number = Console.ReadLine();
            while (!Int32.TryParse(number, out _) || Convert.ToInt32(number) < 0)
            {
                Console.WriteLine("Invalid number.");
                number = Console.ReadLine();
            }
            int returnNumber = Convert.ToInt32(number);
            return returnNumber;
        }
        private string DateInput()
        {
            var input = Console.ReadLine();
            while(!DateTime.TryParse(input, out _))
            {
                Console.WriteLine("Invalid date");
                input = Console.ReadLine();
            }
            DateTime date = DateTime.Parse(input);
            DateOnly dateOnly = DateOnly.FromDateTime(date);
            string toReturn = dateOnly.ToString("yyyy-MM-dd");
            return toReturn;
        }
    }
}
