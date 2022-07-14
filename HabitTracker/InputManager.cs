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
            dbManager.InsertRecord(date, quantity);
        }
        public void GetData(DbManager dbManager)
        {
            List<HabitModel> listOfHabitModel = dbManager.GetRecords();
            Console.WriteLine("-------------------------------------------------------");
            foreach (var habitModel in listOfHabitModel)
            {
                Console.WriteLine($"{habitModel.Id} - {DateOnly.FromDateTime(habitModel.Date)} - Number of coffees: {habitModel.Quantity}");
            }
            Console.WriteLine("-------------------------------------------------------");
        }
        public void DeleteData(DbManager dbManager)
        {
            Console.WriteLine("Type in Id of the record that you want to delete.");
            var idTemp = Console.ReadLine();
            int id = 0;
            while (idTemp == null)
            {
                idTemp = Console.ReadLine();
            }
            try
            {
                id = int.Parse(idTemp);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            dbManager.DeleteRecord(id);
        }
        public void UpdateData(DbManager dbManager)
        {
            Console.WriteLine("Choose record you want to update by Id:");
            var idTemp = Console.ReadLine();
            int id = 0;
            while (idTemp == null)
            {
                idTemp = Console.ReadLine();
            }
            try
            {
                id = int.Parse(idTemp);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Input data as DD-MM-YYYY:");
            var date = Console.ReadLine();
            while (date == null)
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
            dbManager.UpdateRecord(id, date, quantity);
        }
    }
}
