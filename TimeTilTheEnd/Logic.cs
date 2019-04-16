using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;


namespace TimeTilTheEnd
{
    class Logic
    {
        Holiday hoe = new Holiday();
        string timeLeft = "16:00:00";
        bool eating = false;
        private bool suffering = true;
        int daysSurvived;
        int printDaysSurvived;
        public int PrintDaysSurvived
        {
            get
            {
                return this.printDaysSurvived;
            }
            set
            {
                this.printDaysSurvived = value;
            }
        }
        public int DaysSurvived
        {
            get
            {
                return this.daysSurvived;
            }
            set
            {
                this.daysSurvived = value;
            }
        }
        public bool Suffering
        {
            get
            {
                return this.suffering;
            }
            set
            {
                this.suffering = value;
            }
        }
         
        public void FirstWrite()
        {
            string fileName = @"C:\daysSurvived.txt";
            try
            {
                // Check if file already exists. If yes, delete it.     
                if (!File.Exists(fileName))
                {
                    // Create a new file in case it doesnt, and start counter at 0     
                    using (StreamWriter sw = File.CreateText(fileName))
                    {
                       sw.WriteLine(0);
                    }    
                }
            }
            catch (Exception)
            {
                Console.WriteLine("File not created");
            }
        }

        void WritingToTxt()
        {
            //Write to txt file
            //To write counter for days suffered
            //In case program closes
            StreamWriter write = new StreamWriter("C:/daysSurvived.txt");
            write.Write(DaysSurvived);
            write.Close();
        }
        void ReadingFromTxt()
        {
            using (StreamReader read = new StreamReader("C:/daysSurvived.txt"))
            {
                //Reading from a txt file
                //To read counter for days suffered
                //In case program closes
                PrintDaysSurvived = int.Parse(read.ReadLine());
                read.Close();
            }
        }

        public string NormalTimer()
        {
            string returnString = "";
            //Check what day is it
            DayOfTheWeek();
            DateTime a = DateTime.Parse(timeLeft);
            //DateTime a = DateTime.Parse("16:00:00");

            TimeSpan g;
            TimeSpan minusTime = a - DateTime.Now;
            if (minusTime.Seconds > -1)
            {
                while (Suffering)
                {
                    Thread.Sleep(975);
                    Console.Clear();
                    EatingTime();
                    ReadingFromTxt();
                    g = a - DateTime.Now;
                    returnString = g + "\n\rHours left: " +g.Hours +"\n\rMinuts left: " + g.Minutes +"\n\rSeconds left: " +g.Seconds+"\n\rDays Survived: "+PrintDaysSurvived+"\r";
                    //Console.Write(g);
                    //Console.WriteLine("");
                    //Console.WriteLine("Hours left: " + g.Hours);
                    //Console.WriteLine("Minutes left: " + g.Minutes);
                    //Console.WriteLine("Seconds left: " + g.Seconds);
                    if (eating == true)
                        returnString = g + "\r Hours left: " + g.Hours + "\r minuts left: " + g.Minutes + "\r seconds left: " + g.Seconds + "\r EAT!!! NOW!!! BREAK!!!";
                    //    Console.WriteLine("Break!!! Eat!!! Now!!!");
                   // Console.WriteLine("Days Survived: " + PrintDaysSurvived);
                    HolidayFinder(); //Prints day left to holiday
                    HeadQuarters(); //Prints day left to hovedforlob
                    
                    if (g.Seconds <= -1)
                    {
                        WeAreWorking();
                        TheEndOfTime();
                    }
                    return returnString;
                }
                return null;
            }
            else
            {
                //Console.WriteLine("Home");
                Thread.Sleep(60000);
                return "Home";
            }
        }


        void TheEndOfTime()
        {
            Suffering = false;
        }
        void WeAreWorking()
        {
            DaysSurvived = PrintDaysSurvived;
            DaysSurvived++;
            WritingToTxt();
        }


        DayOfWeek today = DateTime.Today.DayOfWeek;
        string DayOfTheWeek()
        {
            switch (today)
            {
                case DayOfWeek.Monday:
                    Suffering = true;
                    timeLeft = "16:00:00";
                    break;
                case DayOfWeek.Tuesday:
                    Suffering = true;
                    timeLeft = "16:00:00";
                    break;
                case DayOfWeek.Wednesday:
                    Suffering = true;
                    timeLeft = "16:00:00";
                    break;
                case DayOfWeek.Thursday:
                    Suffering = true;
                    timeLeft = "16:00:00";
                    break;
                case DayOfWeek.Friday:
                    Suffering = true;
                    timeLeft = "13:00:00";
                    break;
                default:
                    Suffering = false;
                    break;
                    //Find Better Way later

            }
            //HolidayFinder();
            return timeLeft;
        }

        void EatingTime()
        {
            DateTime launchTime = DateTime.Parse("11:00:00");
            DateTime doneEating = DateTime.Parse("11:30:00");

            if (launchTime < DateTime.Now)
                eating = true;
            else
                eating = false;

            if (doneEating < DateTime.Now)
                eating = false;
        }        
        
        /// <summary>
        /// Every holiday goes here, where it send it further to calculate the amount of days til next holiday
        /// and time from the last holiday
        /// </summary>
        Random rnd = new Random();
        void HolidayFinder() 
        {
            //ac is holiday method that returns datetime[] with datetime;
            //first 3 numbers are made into 1 datetime and rest is made to check when it ends
            DateTime[] paskeFerie = hoe.Holidaay(2019, 4, 15, 2019, 4, 23);
            DateTime[] sommerFerie = hoe.Holidaay(2019, 6, 29, 2019, 7, 11);

            int gg = rnd.Next(1, 3);

            switch (gg) {
                case 1:
                  HolidayCounter(paskeFerie,"Easter Holiday");
                    break;
                case 2:
                  HolidayCounter(sommerFerie,"Summer Holiday");
                    break;
                default:
                    Console.WriteLine("Yeet the error");
                    break;
            }
        }
        /// <summary>
        /// HeadQuartes are for the days that we are in ringsted
        /// from hovedforlob 2 to hovedforlob 5
        /// </summary>
        void HeadQuarters()
        {
            DateTime[] headTwo = hoe.Holidaay(2020, 1, 13, 2020, 3, 20);

            HeadCounter(headTwo,"head2");
        }
        /// <summary>
        /// DateTime[] is the start date of the x,y and string nameOfHead is for the name of the thing
        /// HeadCounter is made to calculate and print the amount of days to x,y event
        /// </summary>
        /// <param name="b"></param>
        /// <param name="nameOfHead"></param>
        #region HeadCounter, HolidayCounter
        void HeadCounter(DateTime[] b, string nameOfHead)
        {
            //b[0] is day the event starts
            //b[1] is day the event ends
            TimeSpan c = b[0] - DateTime.Now;
            TimeSpan d = b[1] - DateTime.Now;
            TimeSpan e = DateTime.Now - b[1];

            if (DateTime.Now <= b[0])
                Console.WriteLine("Days till " + nameOfHead + ": " + c.Days);

            else if (DateTime.Now >= b[0] && DateTime.Now <= b[1])
                Console.WriteLine(nameOfHead + " now days left: " + d.Days);

            else if (DateTime.Now >= b[1])
                Console.WriteLine("Days since " + nameOfHead + ": " + e.Days);

        }
        void HolidayCounter(DateTime[] b, string nameOfHoliday)
        {
            //b[0] is day the event starts
            //b[1] is day the event ends
            TimeSpan c = b[0] - DateTime.Now;
            TimeSpan d = b[1] - DateTime.Now;
            TimeSpan e = DateTime.Now - b[1];

            if (DateTime.Now <= b[0])
                Console.WriteLine("Days till " + nameOfHoliday + ": " + c.Days);

            else if (DateTime.Now >= b[0] && DateTime.Now <= b[1])
                Console.WriteLine(nameOfHoliday + " now days left: " + d.Days);

            else if (DateTime.Now >= b[1])
                Console.WriteLine("Days since " + nameOfHoliday + ": " + e.Days);
        }
        #endregion

    }
}
