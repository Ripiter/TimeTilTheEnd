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
        string timeLeft = "";
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

            //timeLeft is time we got free
            DateTime a = DateTime.Parse(timeLeft);

            TimeSpan g;
            TimeSpan minusTime = a - DateTime.Now;
            if (minusTime.Seconds > -1)
            {
                while (Suffering)
                {
                    Console.Clear();
                    EatingTime();
                    ReadingFromTxt();
                    g = a - DateTime.Now;
                    returnString = g + "\n\r" +
                                   "Hours left: " +g.Hours +"\n\r" +
                                   "Minuts left: " + g.Minutes +"\n\r" +
                                   "Seconds left: " +g.Seconds+"\n\r" +
                                   "Days Survived: "+PrintDaysSurvived+"\r";
                    if (eating == true)
                        returnString = g + "\r Hours left: " + g.Hours + "\r minuts left: " + g.Minutes + "\r seconds left: " + g.Seconds + "\r EAT!!! NOW!!! BREAK!!!";
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
            }
            return timeLeft;
        }

        /// <summary>
        /// When we got break, message will apear
        /// </summary>
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
        /// Changes the holiday everyday second
        /// </summary>
        int gg;
        public int ChangeHoliday(int threadNumber)
        {
            this.gg = threadNumber;

            return gg;
        }
        /// <summary>
        /// Every holiday goes here, where it send it further to calculate the amount of days til next holiday
        /// and time from the last holiday
        /// </summary>
        public string HolidayFinder() 
        {
            string holidayFound = "";
            //hoe is holiday method that returns datetime[] with datetime;
            //first 3 numbers are made into 1 datetime and rest is made to check when it ends
            DateTime[] paskeFerie = hoe.Holidaay(2019, 4, 15, 2019, 4, 23);
            DateTime[] sommerFerie = hoe.Holidaay(2019, 6, 29, 2019, 7, 11);

            switch (gg) {
                case 1:
                  holidayFound = HolidayCounter(paskeFerie,"Easter Holiday");
                    break;
                case 2:
                  holidayFound = HolidayCounter(sommerFerie,"Summer Holiday");
                    break;
                default:
                  holidayFound = "Yeet the error";
                    break;
            }
            return holidayFound;
        }
        /// <summary>
        /// HeadQuartes are for the days that we are in ringsted
        /// from hovedforlob 2 to hovedforlob 5
        /// </summary>
        public string HeadQuarters()
        {
            DateTime[] headTwo = hoe.Holidaay(2020, 1, 13, 2020, 3, 20);

            string a = HeadCounter(headTwo,"head2");
            return a;
        }
        /// <summary>
        /// DateTime[] is the start date of the x,y and string nameOfHead is for the name of the thing
        /// HeadCounter is made to calculate and print the amount of days to x,y event
        /// </summary>
        /// <param name="dayIndex"></param>
        /// <param name="nameOfHead"></param>
        #region HeadCounter, HolidayCounter
        string HeadCounter(DateTime[] dayIndex, string nameOfHead)
        {
            string daysPrint = "";
            //dayIndex[0] is day the event starts
            //dayIndex[1] is day the event ends
            TimeSpan tilHovedforlob = dayIndex[0] - DateTime.Now;
            TimeSpan whileHovedforlob = dayIndex[1] - DateTime.Now;
            TimeSpan sinceHovedforlob = DateTime.Now - dayIndex[1];

            if (DateTime.Now <= dayIndex[0])
                daysPrint = "Days till " + nameOfHead + ": " + tilHovedforlob.Days;

            else if (DateTime.Now >= dayIndex[0] && DateTime.Now <= dayIndex[1])
                daysPrint = nameOfHead + " now days left: " + whileHovedforlob.Days;

            else if (DateTime.Now >= dayIndex[1])
                daysPrint = "Days since " + nameOfHead + ": " + sinceHovedforlob.Days;

            return daysPrint;
        }
        string HolidayCounter(DateTime[] dayIndex, string nameOfHoliday)
        {
            string holidayCounter = "";
            //dayIndex[0] is day the event starts
            //dayIndex[1] is day the event ends
            TimeSpan timeSpanTilHoliday = dayIndex[0] - DateTime.Now;
            TimeSpan timeSpanWhileHoliday = dayIndex[1] - DateTime.Now;
            TimeSpan timeSpanPastHoliday = DateTime.Now - dayIndex[1];

            if (DateTime.Now <= dayIndex[0])
                holidayCounter = "Days till " + nameOfHoliday + ": " + timeSpanTilHoliday.Days;

            else if (DateTime.Now >= dayIndex[0] && DateTime.Now <= dayIndex[1])
                holidayCounter = nameOfHoliday + " now days left: " + timeSpanWhileHoliday.Days;

            else if (DateTime.Now >= dayIndex[1])
                holidayCounter = "Days since " + nameOfHoliday + ": " + timeSpanPastHoliday.Days;

            return holidayCounter;
        }
        #endregion

    }
}
