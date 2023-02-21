using System;
using System.ComponentModel.Design;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Transactions;

namespace Inheritance
{
    //Base Class
    class Members
    {
        protected int _Id;
        protected string _FirstName;
        protected string _LastName;
        protected int _Age;

        // default constructor
        public Members()
        {
            _Id = 0;
            _FirstName = string.Empty;
            _LastName = string.Empty;
            _Age = 0;
        }
        //parameterized constructor
        public Members(int id, string firstName, string lastName, int age)
        {
            _Id = id;
            _FirstName = firstName;
            _LastName = lastName;
            _Age = age;
        }
        
        public virtual void addChange()
        {
            Console.Write("ID=");
            _Id=int.Parse(Console.ReadLine());
            Console.Write("First Name=");
            _FirstName = Console.ReadLine();
            Console.Write("Last Name=");
            _LastName = Console.ReadLine();
            Console.Write("Age=");
            _Age = int.Parse(Console.ReadLine());
        }
        public virtual void print()
        {
            Console.WriteLine();
            Console.WriteLine($"      ID: {_Id}");
            Console.WriteLine($"    Name: {_FirstName} {_LastName}");
            Console.WriteLine($"     Age: {_Age}");
        }
    }
    class Games : Members
    {
        private double _MemberFee;
        private string _Location;

        public Games()
        {
            _Id = 0;
            _FirstName = string.Empty;
            _LastName = string.Empty;
            _Age = 0;
            _Location = string.Empty;
            _MemberFee = 0;
        }
        public Games(int id, string firstname, string lastname, int age, double fee, string location)
            : base(id, firstname, lastname, age)
        {
            _Id = id;
            _FirstName = firstname;
            _LastName = lastname;
            _Age = age;
            _MemberFee = fee;
            _Location = location;
        }
        
        public override void addChange()
        {
            Console.WriteLine("Management Information");
            Console.Write($"ID=");
            _Id = int.Parse(Console.ReadLine());
            Console.Write("First Name=");
            _FirstName = Console.ReadLine();
            Console.Write("Last Name=");
            _LastName = Console.ReadLine();
            Console.Write("Age=");
            _Age = int.Parse(Console.ReadLine());
            Console.Write("Salary=");
            _MemberFee = double.Parse(Console.ReadLine());
            Console.Write("Location=");
            _Location = Console.ReadLine();
        }
        public override void print()
        {
            Console.WriteLine();
            Console.WriteLine("      Managers          ");
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine($"     ID: {_Id}     Name: {_FirstName} {_LastName}");
            Console.WriteLine($"     Age: {_Age}   Membership Payment: {_MemberFee}");
            Console.WriteLine($"     Location: {_Location}");
            Console.WriteLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("How many club members do you want to enter?");
            int maxMems;
            while (!int.TryParse(Console.ReadLine(), out maxMems))
                Console.WriteLine("Please enter a whole number");

            Members[] mems = new Members[maxMems];
            Console.WriteLine("How many games are you providing?");
            int maxMgr;
            while (!int.TryParse(Console.ReadLine(), out maxMgr))
                Console.WriteLine("Please enter a whole number");

            Games[] mgr = new Games[maxMgr];

            int choice, rec, type;
            int memCounter = 0, gameCounter = 0;
            choice = Menu();
            while (choice != 4)
            {
                Console.WriteLine("Enter 1 for Games or 2 for Members");
                while (!int.TryParse(Console.ReadLine(), out type))
                    Console.WriteLine("1 for Games or 2 for Members");
                try
                {
                    switch (choice)
                    {
                        case 1:
                            if (type == 1)
                            {
                                if (gameCounter <= maxMgr)
                                {
                                    mgr[gameCounter] = new Games();
                                    mgr[gameCounter].addChange();
                                    gameCounter++;
                                }
                                else
                                    Console.WriteLine("The maximum number of games has been added");

                            }
                            else
                            {
                                if (memCounter <= maxMems)
                                {
                                    mems[memCounter] = new Members();
                                    mems[memCounter].addChange();
                                    memCounter++;
                                }
                                else
                                    Console.WriteLine("The maximum number of members has been added");
                            }

                            break;
                        case 2:
                            Console.Write("Enter the record number you want to change: ");
                            while (!int.TryParse(Console.ReadLine(), out rec))
                                Console.Write("Enter the record number you want to change: ");
                            rec--;
                            if (type == 1)
                            {
                                while (rec > gameCounter - 1 || rec < 0)
                                {
                                    Console.Write("The number you entered was out of range, try again");
                                    while (!int.TryParse(Console.ReadLine(), out rec))
                                        Console.Write("Enter the record number you want to change: ");
                                    rec--;
                                }
                                mgr[rec].addChange();
                            }
                            else
                            {
                                while (rec > memCounter - 1 || rec < 0)
                                {
                                    Console.Write("The number you entered was out of range, try again");
                                    while (!int.TryParse(Console.ReadLine(), out rec))
                                        Console.Write("Enter the record number you want to change: ");
                                    rec--;
                                }
                                mems[rec].addChange();
                            }
                            break;
                        case 3:
                            if (type == 1)
                            {
                                for (int i = 0; i < gameCounter; i++)
                                    mgr[i].print();
                            }
                            else
                            {
                                for (int i = 0; i < memCounter; i++)
                                    mems[i].print();
                            }
                            break;
                        default:
                            Console.WriteLine("You made an invalid selection, please try again");
                            break;
                    }
                }


                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                choice = Menu();

            }
        }


        private static int Menu()
        {
            Console.WriteLine("Please make a selection from the menu");
            Console.WriteLine("1-Add  2-Change  3-Print  4-Quit");
            int selection = 0;
            while (selection < 1 || selection > 4)
                while (!int.TryParse(Console.ReadLine(), out selection))
                    Console.WriteLine("1-Add  2-Change  3-Print  4-Quit");
            return selection;
        }
    }
}

