//Scott Eslinger
//CS258.001
//Assignment 'Zumba'
//11-19-21 (Fri.)
//This program outputs an array (table) which shows attendance rates and revenue for a Zumba class in a weekly manner.
//It asks the user for a name and whether or not they would like to see the Zumba weekly rates table.


using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;


namespace ZumbaClass
{
    
    class Program
        //This is the part of the Program which the user will interact with.  It just asks for their name and 
        //whether or not they would like to see the table of attendance and revenue data for the Zumba class.
        //It will take the information from the other parts of this program if the user requests to see the table.
    {
        
        static void Main(string[] args)
        {
            string yesOrNoSee;
            string yesOrNoExit;
            string name;
           
            Console.WriteLine("Please enter your name : ");
            //This ^^^ asks the user for a name for this program.
            name = Console.ReadLine();
            Zumba zumba = new Zumba();
            
            do
            {
                Console.Write(name + ", would you like to see the Zumba class attendance and revenues? (Y/N):");
                //The above ^^^ takes the user's input for the 'name' field and asks if they want to see the zumba table.

                yesOrNoSee = Console.ReadLine();
                if (yesOrNoSee.Equals("Y") || yesOrNoSee.Equals("y"))     
                    //This line will take a user input in the form of either an uppercase or lowercase 'y'.  This prevents
                    //the possibility of an exception error for this programeven if the user is typing in 'y' but not in
                    //either uppercase or lowercase.
                {
                    zumba.DisplayZumba();

                }
                Console.Write(name + ", would you like to exit from the Zumba table? (Y/N):");
                yesOrNoExit = Console.ReadLine();


                //The following piece of code determines whether or not the user wants to exit the program.
                //If the user indicated they did want to exit then the program closes.  However, if they chose
                //'N' or 'n' then the question of whether or not they would like to see the Zumba table is repeated.
                //The loop continues until the user chooses to exit the program.
                if (yesOrNoExit.Equals("Y") || yesOrNoExit.Equals("y"))
                {
                    Environment.Exit(0);
                }

            } while (!yesOrNoExit.Equals("N") || !yesOrNoExit.Equals("n"));

        }

    }
}

namespace ZumbaClass
{
    public class Zumba
    {
        int[, ] attendance;     //This int has [,] instead of just [] since there will be multiple sets of ints.
        string[] days;
        int[] daily_attendanceTotal;
        double[] daily_revenueTotal;
        int[] daily_timeslot_attendanceTotal;
        double[] daily_timeslot_revenueTotal;

        public Zumba()
            //This public class holds the data for the table which will be created in the 'DisplayZumba' part of the program.
        {
            
            attendance = new int[6, 4] { { 8, 10, 15, 20 }, { 11, 15, 17, 18 }, { 14, 12, 22, 20 }, { 9, 14, 17, 12 }, { 10, 12, 21, 22 }, { 12, 12, 7, 15 } };
            //The above ^^^ needs to be all in one line so as to match up with the array design.  
            days = new string[6] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"};
            //This contains 6 days and 4 different time slots which will be shown in the printed array.

            daily_attendanceTotal = new int[6] { 0, 0, 0, 0, 0, 0 };
            //The digit '6' in the brackets after 'int' signifies that there will be 6 different ints for the 'daily_attendancetotal.'
            //This will apply to any and all further digit-brackets like the ones below.
            
            daily_revenueTotal = new double[6] { 0, 0, 0, 0, 0, 0 };

            
            daily_timeslot_attendanceTotal = new int[4] { 0, 0, 0, 0 };
            
            daily_timeslot_revenueTotal = new double[4] { 0, 0, 0, 0 };

        }

        public void DisplayZumba()
        {
            int totalAttendance = 0;


            //The code below prints out the Zumba table in a way that is visually appealing.
            //By implementing dashes one can show a clear table for the user when they want to see the data.
            //If the dashes weren't used for this, the data would be even harder to see.

            Console.WriteLine("---------------------------------------------------------");

            Console.WriteLine(" ZUMBA ATTENDANCE ");

            Console.WriteLine("---------------------------------------------------------");

            Console.WriteLine("           |   1:00   |   3:00   |   5:00   |   7:00   ");
            //This ^^^ line of code has multiple spaces between the numbers because it lines up with 
            //the blocks of data per day in a way that's easily readable and understandable.  

            Console.WriteLine("---------------------------------------------------------");



            //The below code prints out the data for the table per each day of the week and timeslot.
            //It takes the attendance rates that were given above and lists them in order from left to right according to the day
            //of the week they are associated with.  
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine(String.Format("{0,-10} | {1,-8} | {2,-8} | {3,-8} | {4,-8} ",
                days[i], attendance[i, 0], attendance[i, 1], attendance[i, 2], attendance[i, 3]));

                Console.WriteLine("---------------------------------------------------------");

            }
            for (int i = 0; i < 6; i++)
            {
                for (int t = 0; t < 4; t++) //The ++ adds one each time for the attendance in this scenario
                {
                    daily_timeslot_attendanceTotal[t] += attendance[i, t];
                    totalAttendance += attendance[i, t];
                }
            }
            Console.WriteLine(String.Format("{0,-10} | {1,-8} | {2,-8} | {3,-8} | {4,-8} ",

            "Total", daily_timeslot_attendanceTotal[0], daily_timeslot_attendanceTotal[1], daily_timeslot_attendanceTotal[2],
            daily_timeslot_attendanceTotal[3]));

            Console.WriteLine("------------------------------------------------------------");

            Console.WriteLine(String.Format("{0,-10} | {1,-8} | {2,-8} | {3,-8} | {4,-8} ",
            "Revenue", daily_timeslot_attendanceTotal[0] * 4.0, daily_timeslot_attendanceTotal[1] * 4.0, daily_timeslot_attendanceTotal[2] * 4.0,
            daily_timeslot_attendanceTotal[3] * 4.0));

            Console.WriteLine("------------------------------------------------------------");

            Console.WriteLine("Total attendance for week : " + totalAttendance);
            //This just prints the total number for the attendance for the week by adding up all the numbers.

            Console.WriteLine("------------------------------------------------------------");

            Console.WriteLine("------------------------------------------------------------");

            Console.WriteLine("Total revenue for week : " + (totalAttendance * 4.0));
            //This calculates the revenue by multiplying the total attendance number by 4.0 (since each session costs $4.00).

            Console.WriteLine("------------------------------------------------------------");

        }
    }
}