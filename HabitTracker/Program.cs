using HabitTracker;
using System;

class Program
{
    static void Main(string[] args)
    {
        DbManager dbManager = new DbManager(@"Data Source=HabitDB.db"); //Creating object that will manage DB. Pass connection string.
        dbManager.CreateTable();
        UserInterface userInterface = new UserInterface();
        userInterface.MainMenuLoop(dbManager); //Pass dbManager to interface
    }
}
