//This program has a telephone directory and displays a menu to:
//-Read in file
//-Search by last name or first name
//-Display all telephone directory
//-Add a new entry to the directory
//-Display all the people with the same birthday months
//-Display all the people on the same floor
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class TelephoneDirectory
{
    public string first_name, last_name, middle, phone, room, month, day, year;

    public TelephoneDirectory() { }

    public TelephoneDirectory(String fn, String ln, String mi, String rm, String ph,

    String bDay, String bMonth, String bYear)
    {
        first_name = fn;
        last_name = ln;
        middle = mi;
        room = rm;
        phone = ph;
        day = bDay;
        month = bMonth;
        year = bYear;

    }

    static public TelephoneDirectory[] directory = new TelephoneDirectory[1000];
    static public int countOfRecords = 0;


    //Start
    static void Main()
    {

        string choiceInString;
        int choice = 0;

        while (choice != 6)
        {                       
        loopLable:
            //**********MENU**********
            Console.WriteLine("Enter an option: ");
            Console.WriteLine("0. Read in the telephone directory from a file");
            Console.WriteLine("1. Find an entry using a last name or first name");
            Console.WriteLine("2. Display all telephone directory information");
            Console.WriteLine("3. Add a new entry to the directory");
            Console.WriteLine("4. Dislay the names of all the people with the same birth month");
            Console.WriteLine("5. Display the names of all the people with offices on the same floor");
            Console.WriteLine("6.Quit");

            //Asks for input 
            choiceInString = Console.ReadLine();
            choice = Convert.ToInt32(choiceInString);

            if (choice == 0)
            {
                readInFile();
                Console.WriteLine("Read in telephone directory from a file succeeded!");
                Console.WriteLine();
                Console.WriteLine("What would you like to do next?");
                Console.WriteLine();
                goto loopLable;
            }
            else if (choice == 1)
            {
                Console.WriteLine("Enter a Last name or First name");
                string lastNameEntered = Console.ReadLine();
                searchByLastName(lastNameEntered);
                Console.WriteLine();
                Console.WriteLine("What would you like to do next?");
                Console.WriteLine();
                goto loopLable;
            }
            else if (choice == 2)
            {
                displayAllDirectory();
                Console.WriteLine();
                Console.WriteLine("What would you like to do next?");
                goto loopLable;
            }
            else if (choice == 3)
            {
                string fName, lName, miName, phone, room, dob;
                Console.Write("Enter the first name: ");
                fName = Console.ReadLine();
                Console.Write("Enter the last name: ");
                lName = Console.ReadLine();
                Console.Write("Enter the middle initial: ");
                miName = Console.ReadLine();
                Console.Write("Enter the phone number: ");
                phone = Console.ReadLine();
                Console.Write("Enter the room number: ");
                room = Console.ReadLine();
                Console.Write("Enter the date of birth (format: mm dd yyyy): ");
                dob = Console.ReadLine();

                addNewEntryToDirectory(fName, lName, miName, phone, room, dob);
                Console.WriteLine("What would you like to do next?");
                Console.WriteLine();
                goto loopLable;
            }
            else if (choice == 4)
            {
                displayAllSameBirthDates();
                Console.WriteLine();
                Console.WriteLine("What would you like to do next?");
                goto loopLable;
            }
            else if (choice == 5)
            {
                displayAllSameFloors();
                Console.WriteLine();
                Console.WriteLine("What would you like to do next?");
                goto loopLable;
            }
            else if (choice == 6)
            {
                Console.WriteLine("Press any key to exit.");
                System.Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Wrong Input! Try it Again...");
                goto loopLable;
            }
        }
    }//End

    //Read in file function
    private static void readInFile()
    {
        try
        {
            Console.WriteLine();
            int counter = 0;
            using (StreamReader sr = new StreamReader("Dir.txt"))
            {
                while(!sr.EndOfStream)
                {
                String line = sr.ReadLine();
                counter++;
                }
            }
            Console.WriteLine("{0} names were found in the directory", counter);
       
        }
        catch (Exception e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }
        
    }

    //search by last name or first name function
    private static void searchByLastName(string name)
    {
       
            StreamReader sr = new StreamReader("Dir.txt");
            while (!sr.EndOfStream)
            {
                string[] dataFileString = sr.ReadLine().Split(' ');
                TelephoneDirectory currentEmployee = new TelephoneDirectory();
                currentEmployee.last_name = dataFileString[0];
                currentEmployee.first_name = dataFileString[1];
                currentEmployee.middle = dataFileString[2];
                currentEmployee.phone = dataFileString[3];
                currentEmployee.room = dataFileString[4];
                currentEmployee.month = dataFileString[5];
                currentEmployee.day = dataFileString[6];
                currentEmployee.year = dataFileString[7];

                directory[countOfRecords] = currentEmployee;
                countOfRecords++;

                if ((char.Equals(currentEmployee.last_name, name) || (char.Equals(currentEmployee.first_name, name))) == true)
                {
                    Console.WriteLine("ENTRY FOUND:");
                    Console.WriteLine("Last Name: {0}", currentEmployee.last_name);
                    Console.WriteLine("First Name: {0}", currentEmployee.first_name);
                    Console.WriteLine("Middle Name: {0}", currentEmployee.middle);
                    Console.WriteLine("Phone#: {0}", currentEmployee.phone);
                    Console.WriteLine("Room#: {0}", currentEmployee.room);
                    Console.WriteLine("DOB: {0}/{1}/{2}", currentEmployee.month, currentEmployee.day, currentEmployee.year);
                    Console.WriteLine();
                    return;
                }
                else
                {
                    Console.WriteLine("ENTRY NOT FOUND...");
                }

            }
            sr.Close();              
       }
     //Display all Directory function          
     private static void displayAllDirectory()
    {
        StreamReader sr = new StreamReader("Dir.txt");
     
            while (!sr.EndOfStream)
            {
                string[] dataFileString = sr.ReadLine().Split(' ');
                TelephoneDirectory currentEmployee = new TelephoneDirectory();
                currentEmployee.last_name = dataFileString[0];
                currentEmployee.first_name = dataFileString[1];
                currentEmployee.middle = dataFileString[2];
                currentEmployee.phone = dataFileString[3];
                currentEmployee.room = dataFileString[4];
                currentEmployee.month = dataFileString[5];
                currentEmployee.day = dataFileString[6];
                currentEmployee.year = dataFileString[7];

                directory[countOfRecords] = currentEmployee;
                countOfRecords++;
                Console.WriteLine ("{0}     {1}       {2}         {3}         {4} {5} {6} {7}",currentEmployee.last_name,
                    currentEmployee.first_name,currentEmployee.middle,currentEmployee.phone,
                    currentEmployee.room,currentEmployee.month,currentEmployee.day,currentEmployee.year);
                 Console.WriteLine();
            }
            sr.Close();
     }
    //Display all the people with the same birthdates months function
     private static void displayAllSameBirthDates()
     {
            //JANUARY
             Console.WriteLine("People born in the month of January:");
             StreamReader sr = new StreamReader("Dir.txt");
             while (!sr.EndOfStream)
             {
                 string[] dataFileString = sr.ReadLine().Split(' ');
                 TelephoneDirectory currentEmployee = new TelephoneDirectory();
                 currentEmployee.last_name = dataFileString[0];
                 currentEmployee.first_name = dataFileString[1];
                 currentEmployee.middle = dataFileString[2];
                 currentEmployee.phone = dataFileString[3];
                 currentEmployee.room = dataFileString[4];
                 currentEmployee.month = dataFileString[5];
                 currentEmployee.day = dataFileString[6];
                 currentEmployee.year = dataFileString[7];

                 directory[countOfRecords] = currentEmployee;
                 countOfRecords++;

                 int temp = Convert.ToInt32(currentEmployee.month);
                 if (temp == 1)
                 {
                     Console.WriteLine("{0}, {1}", currentEmployee.last_name, currentEmployee.first_name);
                 }
             }
             sr.Close();
         Console.WriteLine();
         //FEBRUARY
         StreamReader ab = new StreamReader("Dir.txt");
         Console.WriteLine("People born in the month of February:");
         while (!ab.EndOfStream)
         {
             string[] dataFileString = ab.ReadLine().Split(' ');
             TelephoneDirectory currentEmployee = new TelephoneDirectory();
             currentEmployee.last_name = dataFileString[0];
             currentEmployee.first_name = dataFileString[1];
             currentEmployee.middle = dataFileString[2];
             currentEmployee.phone = dataFileString[3];
             currentEmployee.room = dataFileString[4];
             currentEmployee.month = dataFileString[5];
             currentEmployee.day = dataFileString[6];
             currentEmployee.year = dataFileString[7];

             directory[countOfRecords] = currentEmployee;
             countOfRecords++;

             int temp = Convert.ToInt32(currentEmployee.month);
             if (temp == 2)
             {
                 Console.WriteLine("{0}, {1}", currentEmployee.last_name, currentEmployee.first_name);
             }
         }
         ab.Close();
         Console.WriteLine();
         //MARCH
         StreamReader ac = new StreamReader("Dir.txt");
         Console.WriteLine("People born in the month of March:");
         while (!ac.EndOfStream)
         {
             string[] dataFileString = ac.ReadLine().Split(' ');
             TelephoneDirectory currentEmployee = new TelephoneDirectory();
             currentEmployee.last_name = dataFileString[0];
             currentEmployee.first_name = dataFileString[1];
             currentEmployee.middle = dataFileString[2];
             currentEmployee.phone = dataFileString[3];
             currentEmployee.room = dataFileString[4];
             currentEmployee.month = dataFileString[5];
             currentEmployee.day = dataFileString[6];
             currentEmployee.year = dataFileString[7];

             directory[countOfRecords] = currentEmployee;
             countOfRecords++;

             int temp = Convert.ToInt32(currentEmployee.month);
             if (temp == 3)
             {
                 Console.WriteLine("{0}, {1}", currentEmployee.last_name, currentEmployee.first_name);
             }
         }
         ac.Close();
         Console.WriteLine();
         //APRIL
         StreamReader ad = new StreamReader("Dir.txt");
         Console.WriteLine("People born in the month of April:");
         while (!ad.EndOfStream)
         {
             string[] dataFileString = ad.ReadLine().Split(' ');
             TelephoneDirectory currentEmployee = new TelephoneDirectory();
             currentEmployee.last_name = dataFileString[0];
             currentEmployee.first_name = dataFileString[1];
             currentEmployee.middle = dataFileString[2];
             currentEmployee.phone = dataFileString[3];
             currentEmployee.room = dataFileString[4];
             currentEmployee.month = dataFileString[5];
             currentEmployee.day = dataFileString[6];
             currentEmployee.year = dataFileString[7];

             directory[countOfRecords] = currentEmployee;
             countOfRecords++;

             int temp = Convert.ToInt32(currentEmployee.month);
             if (temp == 4)
             {
                 Console.WriteLine("{0}, {1}", currentEmployee.last_name, currentEmployee.first_name);
             }
         }
         ad.Close();
         Console.WriteLine();
         //MAY
         StreamReader ae = new StreamReader("Dir.txt");
         Console.WriteLine("People born in the month of May:");
         while (!ae.EndOfStream)
         {
             string[] dataFileString = ae.ReadLine().Split(' ');
             TelephoneDirectory currentEmployee = new TelephoneDirectory();
             currentEmployee.last_name = dataFileString[0];
             currentEmployee.first_name = dataFileString[1];
             currentEmployee.middle = dataFileString[2];
             currentEmployee.phone = dataFileString[3];
             currentEmployee.room = dataFileString[4];
             currentEmployee.month = dataFileString[5];
             currentEmployee.day = dataFileString[6];
             currentEmployee.year = dataFileString[7];

             directory[countOfRecords] = currentEmployee;
             countOfRecords++;

             int temp = Convert.ToInt32(currentEmployee.month);
             if (temp == 5)
             {
                 Console.WriteLine("{0}, {1}", currentEmployee.last_name, currentEmployee.first_name);
             }
         }
         ae.Close();
         Console.WriteLine();
         //JUNE
         StreamReader af = new StreamReader("Dir.txt");
         Console.WriteLine("People born in the month of June:");
         while (!af.EndOfStream)
         {
             string[] dataFileString = af.ReadLine().Split(' ');
             TelephoneDirectory currentEmployee = new TelephoneDirectory();
             currentEmployee.last_name = dataFileString[0];
             currentEmployee.first_name = dataFileString[1];
             currentEmployee.middle = dataFileString[2];
             currentEmployee.phone = dataFileString[3];
             currentEmployee.room = dataFileString[4];
             currentEmployee.month = dataFileString[5];
             currentEmployee.day = dataFileString[6];
             currentEmployee.year = dataFileString[7];

             countOfRecords++;

             int temp = Convert.ToInt32(currentEmployee.month);
             if (temp == 6)
             {
                 Console.WriteLine("{0}, {1}", currentEmployee.last_name, currentEmployee.first_name);
             }
         }
         af.Close();
         Console.WriteLine();
         //JULY
         StreamReader aj = new StreamReader("Dir.txt");
         Console.WriteLine("People born in the month of July:");
         while (!aj.EndOfStream)
         {
             string[] dataFileString = aj.ReadLine().Split(' ');
             TelephoneDirectory currentEmployee = new TelephoneDirectory();
             currentEmployee.last_name = dataFileString[0];
             currentEmployee.first_name = dataFileString[1];
             currentEmployee.middle = dataFileString[2];
             currentEmployee.phone = dataFileString[3];
             currentEmployee.room = dataFileString[4];
             currentEmployee.month = dataFileString[5];
             currentEmployee.day = dataFileString[6];
             currentEmployee.year = dataFileString[7];

            
             countOfRecords++;

             int temp = Convert.ToInt32(currentEmployee.month);
             if (temp == 7)
             {
                 Console.WriteLine("{0}, {1}", currentEmployee.last_name, currentEmployee.first_name);
             }
         }
         aj.Close();
         Console.WriteLine();
         //AUGUST
         StreamReader ah = new StreamReader("Dir.txt");
         Console.WriteLine("People born in the month of August:");
         while (!ah.EndOfStream)
         {
             string[] dataFileString = ah.ReadLine().Split(' ');
             TelephoneDirectory currentEmployee = new TelephoneDirectory();
             currentEmployee.last_name = dataFileString[0];
             currentEmployee.first_name = dataFileString[1];
             currentEmployee.middle = dataFileString[2];
             currentEmployee.phone = dataFileString[3];
             currentEmployee.room = dataFileString[4];
             currentEmployee.month = dataFileString[5];
             currentEmployee.day = dataFileString[6];
             currentEmployee.year = dataFileString[7];

             countOfRecords++;

             int temp = Convert.ToInt32(currentEmployee.month);
             if (temp == 8)
             {
                 Console.WriteLine("{0}, {1}", currentEmployee.last_name, currentEmployee.first_name);
             }
         }
         ah.Close();
         Console.WriteLine();
         //SEPTEMBER
         StreamReader ag = new StreamReader("Dir.txt");
         Console.WriteLine("People born in the month of September:");
         while (!ag.EndOfStream)
         {
             string[] dataFileString = ag.ReadLine().Split(' ');
             TelephoneDirectory currentEmployee = new TelephoneDirectory();
             currentEmployee.last_name = dataFileString[0];
             currentEmployee.first_name = dataFileString[1];
             currentEmployee.middle = dataFileString[2];
             currentEmployee.phone = dataFileString[3];
             currentEmployee.room = dataFileString[4];
             currentEmployee.month = dataFileString[5];
             currentEmployee.day = dataFileString[6];
             currentEmployee.year = dataFileString[7];

             countOfRecords++;

             int temp = Convert.ToInt32(currentEmployee.month);
             if (temp == 9)
             {
                 Console.WriteLine("{0}, {1}", currentEmployee.last_name, currentEmployee.first_name);
             }
         }
         ag.Close();
         Console.WriteLine();
         //OCTOBER
         StreamReader ak = new StreamReader("Dir.txt");
         Console.WriteLine("People born in the month of October:");
         while (!ak.EndOfStream)
         {
             string[] dataFileString = ak.ReadLine().Split(' ');
             TelephoneDirectory currentEmployee = new TelephoneDirectory();
             currentEmployee.last_name = dataFileString[0];
             currentEmployee.first_name = dataFileString[1];
             currentEmployee.middle = dataFileString[2];
             currentEmployee.phone = dataFileString[3];
             currentEmployee.room = dataFileString[4];
             currentEmployee.month = dataFileString[5];
             currentEmployee.day = dataFileString[6];
             currentEmployee.year = dataFileString[7];

             //directory[countOfRecords] = currentEmployee;
             countOfRecords++;

             int temp = Convert.ToInt32(currentEmployee.month);
             if (temp == 10)
             {
                 Console.WriteLine("{0}, {1}", currentEmployee.last_name, currentEmployee.first_name);
             }
         }
         ak.Close();
         Console.WriteLine();
         //NOVEMBER
         StreamReader al = new StreamReader("Dir.txt");
         Console.WriteLine("People born in the month of November:");
         while (!al.EndOfStream)
         {
             string[] dataFileString = al.ReadLine().Split(' ');
             TelephoneDirectory currentEmployee = new TelephoneDirectory();
             currentEmployee.last_name = dataFileString[0];
             currentEmployee.first_name = dataFileString[1];
             currentEmployee.middle = dataFileString[2];
             currentEmployee.phone = dataFileString[3];
             currentEmployee.room = dataFileString[4];
             currentEmployee.month = dataFileString[5];
             currentEmployee.day = dataFileString[6];
             currentEmployee.year = dataFileString[7];

             countOfRecords++;

             int temp = Convert.ToInt32(currentEmployee.month);
             if (temp == 11)
             {
                 Console.WriteLine("{0}, {1}", currentEmployee.last_name, currentEmployee.first_name);
             }
         }
         al.Close();
         Console.WriteLine();
         //DECEMBER
         StreamReader am = new StreamReader("Dir.txt");
         Console.WriteLine("People born in the month of December:");
         while (!am.EndOfStream)
         {
             string[] dataFileString = am.ReadLine().Split(' ');
             TelephoneDirectory currentEmployee = new TelephoneDirectory();
             currentEmployee.last_name = dataFileString[0];
             currentEmployee.first_name = dataFileString[1];
             currentEmployee.middle = dataFileString[2];
             currentEmployee.phone = dataFileString[3];
             currentEmployee.room = dataFileString[4];
             currentEmployee.month = dataFileString[5];
             currentEmployee.day = dataFileString[6];
             currentEmployee.year = dataFileString[7];

                countOfRecords++;

             int temp = Convert.ToInt32(currentEmployee.month);
             if (temp == 12)
             {
                 Console.WriteLine("{0}, {1}", currentEmployee.last_name, currentEmployee.first_name);
             }
         }
         al.Close();
         Console.WriteLine();
     }
    //Displays all the people with the same floors
     private static void displayAllSameFloors()
     {
         //FIRST FLOOR
         Console.WriteLine("People on the first floor:");
         StreamReader sr = new StreamReader("Dir.txt");
         while (!sr.EndOfStream)
         {
             string[] dataFileString = sr.ReadLine().Split(' ');
             TelephoneDirectory currentEmployee = new TelephoneDirectory();
             currentEmployee.last_name = dataFileString[0];
             currentEmployee.first_name = dataFileString[1];
             currentEmployee.middle = dataFileString[2];
             currentEmployee.phone = dataFileString[3];
             currentEmployee.room = dataFileString[4];
             currentEmployee.month = dataFileString[5];
             currentEmployee.day = dataFileString[6];
             currentEmployee.year = dataFileString[7];

             directory[countOfRecords] = currentEmployee;
             countOfRecords++;

             int temp = Convert.ToInt32(currentEmployee.room);
             if ((temp>=100) && (temp<200))
             {
                 Console.WriteLine("{0}, {1}", currentEmployee.last_name, currentEmployee.first_name);
             }
         }
         sr.Close();
         Console.WriteLine();
         //SECOND FLOOR
         StreamReader ab = new StreamReader("Dir.txt");
         Console.WriteLine("People on the second floor:");
         while (!ab.EndOfStream)
         {
             string[] dataFileString = ab.ReadLine().Split(' ');
             TelephoneDirectory currentEmployee = new TelephoneDirectory();
             currentEmployee.last_name = dataFileString[0];
             currentEmployee.first_name = dataFileString[1];
             currentEmployee.middle = dataFileString[2];
             currentEmployee.phone = dataFileString[3];
             currentEmployee.room = dataFileString[4];
             currentEmployee.month = dataFileString[5];
             currentEmployee.day = dataFileString[6];
             currentEmployee.year = dataFileString[7];

             directory[countOfRecords] = currentEmployee;
             countOfRecords++;

             int temp = Convert.ToInt32(currentEmployee.room);
             if ((temp >= 200) && (temp < 300))
             {
                 Console.WriteLine("{0}, {1}", currentEmployee.last_name, currentEmployee.first_name);
             }
         }
         ab.Close();
         Console.WriteLine();
         //THIRD FLOOR
         StreamReader ac = new StreamReader("Dir.txt");
         Console.WriteLine("People on the third floor:");
         while (!ac.EndOfStream)
         {
             string[] dataFileString = ac.ReadLine().Split(' ');
             TelephoneDirectory currentEmployee = new TelephoneDirectory();
             currentEmployee.last_name = dataFileString[0];
             currentEmployee.first_name = dataFileString[1];
             currentEmployee.middle = dataFileString[2];
             currentEmployee.phone = dataFileString[3];
             currentEmployee.room = dataFileString[4];
             currentEmployee.month = dataFileString[5];
             currentEmployee.day = dataFileString[6];
             currentEmployee.year = dataFileString[7];

             directory[countOfRecords] = currentEmployee;
             countOfRecords++;

             int temp = Convert.ToInt32(currentEmployee.room);
             if ((temp >= 300) && (temp < 400))
             {
                 Console.WriteLine("{0}, {1}", currentEmployee.last_name, currentEmployee.first_name);
             }
         }
         ac.Close();
         Console.WriteLine();
         //FOURTH FLOOR
         StreamReader ad = new StreamReader("Dir.txt");
         Console.WriteLine("People on the fourth floor:");
         while (!ad.EndOfStream)
         {
             string[] dataFileString = ad.ReadLine().Split(' ');
             TelephoneDirectory currentEmployee = new TelephoneDirectory();
             currentEmployee.last_name = dataFileString[0];
             currentEmployee.first_name = dataFileString[1];
             currentEmployee.middle = dataFileString[2];
             currentEmployee.phone = dataFileString[3];
             currentEmployee.room = dataFileString[4];
             currentEmployee.month = dataFileString[5];
             currentEmployee.day = dataFileString[6];
             currentEmployee.year = dataFileString[7];

             directory[countOfRecords] = currentEmployee;
             countOfRecords++;

             int temp = Convert.ToInt32(currentEmployee.room);
             if ((temp >= 400) && (temp < 500))
             {
                 Console.WriteLine("{0}, {1}", currentEmployee.last_name, currentEmployee.first_name);
             }
         }
         ad.Close();
         Console.WriteLine();
         Console.WriteLine();
         //FITHTH FLOOR
         StreamReader ae = new StreamReader("Dir.txt");
         Console.WriteLine("People on the fifth floor:");
         while (!ae.EndOfStream)
         {
             string[] dataFileString = ae.ReadLine().Split(' ');
             TelephoneDirectory currentEmployee = new TelephoneDirectory();
             currentEmployee.last_name = dataFileString[0];
             currentEmployee.first_name = dataFileString[1];
             currentEmployee.middle = dataFileString[2];
             currentEmployee.phone = dataFileString[3];
             currentEmployee.room = dataFileString[4];
             currentEmployee.month = dataFileString[5];
             currentEmployee.day = dataFileString[6];
             currentEmployee.year = dataFileString[7];

             countOfRecords++;

             int temp = Convert.ToInt32(currentEmployee.room);
             if ((temp >= 500) && (temp < 600))
             {
                 Console.WriteLine("{0}, {1}", currentEmployee.last_name, currentEmployee.first_name);
             }
         }
         ae.Close();
         Console.WriteLine();
         Console.WriteLine();
         //SIXTH FLOOR
         StreamReader af = new StreamReader("Dir.txt");
         Console.WriteLine("People on the sixth floor:");
         while (!af.EndOfStream)
         {
             string[] dataFileString = af.ReadLine().Split(' ');
             TelephoneDirectory currentEmployee = new TelephoneDirectory();
             currentEmployee.last_name = dataFileString[0];
             currentEmployee.first_name = dataFileString[1];
             currentEmployee.middle = dataFileString[2];
             currentEmployee.phone = dataFileString[3];
             currentEmployee.room = dataFileString[4];
             currentEmployee.month = dataFileString[5];
             currentEmployee.day = dataFileString[6];
             currentEmployee.year = dataFileString[7];

             countOfRecords++;

             int temp = Convert.ToInt32(currentEmployee.room);
             if ((temp >= 600) && (temp < 700))
             {
                 Console.WriteLine("{0}, {1}", currentEmployee.last_name, currentEmployee.first_name);
             }
         }
         af.Close();
         Console.WriteLine();
         Console.WriteLine();
         //SEVENTH FLOOR
         StreamReader ag = new StreamReader("Dir.txt");
         Console.WriteLine("People on the seventh floor:");
         while (!ag.EndOfStream)
         {
             string[] dataFileString = ag.ReadLine().Split(' ');
             TelephoneDirectory currentEmployee = new TelephoneDirectory();
             currentEmployee.last_name = dataFileString[0];
             currentEmployee.first_name = dataFileString[1];
             currentEmployee.middle = dataFileString[2];
             currentEmployee.phone = dataFileString[3];
             currentEmployee.room = dataFileString[4];
             currentEmployee.month = dataFileString[5];
             currentEmployee.day = dataFileString[6];
             currentEmployee.year = dataFileString[7];

             countOfRecords++;

             int temp = Convert.ToInt32(currentEmployee.room);
             if ((temp >= 700) && (temp < 800))
             {
                 Console.WriteLine("{0}, {1}", currentEmployee.last_name, currentEmployee.first_name);
             }
         }
         ag.Close();
         Console.WriteLine();
         Console.WriteLine();
         //EIGTH FLOOR
         StreamReader ah = new StreamReader("Dir.txt");
         Console.WriteLine("People on the eighth floor:");
         while (!ah.EndOfStream)
         {
             string[] dataFileString = ah.ReadLine().Split(' ');
             TelephoneDirectory currentEmployee = new TelephoneDirectory();
             currentEmployee.last_name = dataFileString[0];
             currentEmployee.first_name = dataFileString[1];
             currentEmployee.middle = dataFileString[2];
             currentEmployee.phone = dataFileString[3];
             currentEmployee.room = dataFileString[4];
             currentEmployee.month = dataFileString[5];
             currentEmployee.day = dataFileString[6];
             currentEmployee.year = dataFileString[7];

             countOfRecords++;

             int temp = Convert.ToInt32(currentEmployee.room);
             if ((temp >= 800) && (temp < 900))
             {
                 Console.WriteLine("{0}, {1}", currentEmployee.last_name, currentEmployee.first_name);
             }
         }
         ah.Close();
         Console.WriteLine();
         Console.WriteLine();
         //NINETH FLOOR
         StreamReader ai = new StreamReader("Dir.txt");
         Console.WriteLine("People on the nineth floor:");
         while (!ai.EndOfStream)
         {
             string[] dataFileString = ai.ReadLine().Split(' ');
             TelephoneDirectory currentEmployee = new TelephoneDirectory();
             currentEmployee.last_name = dataFileString[0];
             currentEmployee.first_name = dataFileString[1];
             currentEmployee.middle = dataFileString[2];
             currentEmployee.phone = dataFileString[3];
             currentEmployee.room = dataFileString[4];
             currentEmployee.month = dataFileString[5];
             currentEmployee.day = dataFileString[6];
             currentEmployee.year = dataFileString[7];

             countOfRecords++;

             int temp = Convert.ToInt32(currentEmployee.room);
             if ((temp >= 900) && (temp < 1000))
             {
                 Console.WriteLine("{0}, {1}", currentEmployee.last_name, currentEmployee.first_name);
             }
         }
         ai.Close();
         Console.WriteLine();
         Console.WriteLine();
         //TENTH FLOOR
         StreamReader ak = new StreamReader("Dir.txt");
         Console.WriteLine("People on the tenth floor:");
         while (!ak.EndOfStream)
         {
             string[] dataFileString = ak.ReadLine().Split(' ');
             TelephoneDirectory currentEmployee = new TelephoneDirectory();
             currentEmployee.last_name = dataFileString[0];
             currentEmployee.first_name = dataFileString[1];
             currentEmployee.middle = dataFileString[2];
             currentEmployee.phone = dataFileString[3];
             currentEmployee.room = dataFileString[4];
             currentEmployee.month = dataFileString[5];
             currentEmployee.day = dataFileString[6];
             currentEmployee.year = dataFileString[7];

             countOfRecords++;

             int temp = Convert.ToInt32(currentEmployee.room);
             if ((temp >= 1000) && (temp < 1100))
             {
                 Console.WriteLine("{0}, {1}", currentEmployee.last_name, currentEmployee.first_name);
             }
         }
         ak.Close();
         Console.WriteLine();
     }
    //Add new entry to the file
     private static void addNewEntryToDirectory(string nameFirst, string nameLast, string nameMiddle, 
         string phoneNum, string roomNum, string dateOfBirth)
     {
         StreamWriter sw = new StreamWriter("Dir.txt", true);
         sw.WriteLine(nameFirst + ' ' + nameLast + ' ' + nameMiddle + ' ' + phoneNum + ' ' + roomNum + ' ' + dateOfBirth);
         sw.Close();
     }
}