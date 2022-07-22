# HabitTracker
Not my first C# application, but first made to introduce my skills.

Console based CRUD application to track amount of coffees drunk in each day.
Developed using C#, SQLite and ADO.NET

# Given Requirements:
- [x] This is an application where you’ll register one habit.
- [x] This habit can't be tracked by time (ex. hours of sleep), only by quantity (ex. number of water glasses a day)
- [x] The application should store and retrieve data from a real database.
- [x] When the application starts, it should create a sqlite database, if one isn’t present.
- [x] It should also create a table in the database, where the habit will be logged.
- [x] The app should show the user a menu of options.
- [x] The users should be able to insert, delete, update and view their logged habit.
- [x] You should handle all possible errors so that the application never crashes.
- [x] The application should only be terminated when the user inserts 0.
- [x] You can only interact with the database using raw SQL. You can’t use mappers such as Entity Framework.
- [x] Your project needs to contain a Read Me file where you'll explain how your app works.

# Features

* SQLite database connection

	- The program uses a SQLite db connection to store and read information. 
	- If no database exists, or the correct table does not exist they will be created on program start.

* A console based UI where users can navigate by key presses
 
 	- IMAGE HERE!

* CRUD DB functions

	- From the main menu users can Create, Read, Update or Delete entries for whichever date they want, entered in yyyy-mm-dd format. 
	- Time and Dates inputted are checked to make sure they are in the correct and realistic format.

# Challenges & Lessons Learned
	
- It was my first time using SQLite (before I've been using only MySql and MS Sql), also it is first time I use ADO.NET (before I've been using EntityFramework).
- Learned: How to implement database in project without heavy EntityFramework. Development with SQLite is way faster than setting up real database.

# Resources Used
- MS docs ;)
- StackOverflow is friend of mine :D
