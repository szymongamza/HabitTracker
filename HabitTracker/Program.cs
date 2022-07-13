using HabitTracker;
using System;

class Program
{
    static void Main(string[] args)
    {
        DbManager dbManager = new(@"Data Source=HabitDB.db"); //Creating object that will manage DB. Pass connection string.
        dbManager.CreateTable();
        UserInterface userInterface = new();
        userInterface.MainMenuLoop(dbManager); //Pass dbManager to interface
    }
}
