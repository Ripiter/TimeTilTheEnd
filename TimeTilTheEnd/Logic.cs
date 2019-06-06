using System;
using System.Collections.Generic;
using System.Threading;
using System.Globalization;


namespace TimeTilTheEnd
{
    class Logic
    {
        Holiday hoe = new Holiday();
        List<DateTime> dateTimes = new List<DateTime>();
        
        #region Variables
        TimeSpan daysSurviveTime;
        DateTime startSchool = DateTime.Parse("04/08/2018");
        string timeLeft = "";
        bool eating = false;
        private bool suffering = true;
        #endregion

        #region Get Set
        public List<DateTime> DateTimes
        {
            get
            {
                return this.dateTimes;
            }
            set
            {
                this.dateTimes = value;
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
        #endregion
        
        public string NormalTimer()
        {
            string returnString;
            //Check what day is it
            ///DayOfTheWeek();
            DateTime a = DateTime.Parse(DayOfTheWeek());

            //timeLeft is time we got free
            
            TimeSpan g = a - DateTime.Now;
            if (g.Seconds > -1)
            {
                while (Suffering)
                {
                   // string week = WhatWeekWeAreIn();
                    EatingTime();
                    returnString = g + "\n\r" +
                                   "Hours left: " + g.Hours + "\n\r" +
                                   "Minuts left: " + g.Minutes + "\n\r" +
                                   "Seconds left: " + g.Seconds + "\n\r";
                    if (eating == true)
                        returnString = g + "\r Hours left: " + g.Hours + "\r Minuts left: " + g.Minutes + "\r seconds left: " + g.Seconds + "\r EAT!!! NOW!!! BREAK!!!";
                    
                    if (g.Seconds <= -1)
                    {
                        //Changes Suffering to false and
                        //Adds a day to day survived
                        TheEndOfTime();
                       // WeAreDoneWorking();
                    }
                    return returnString;
                }
                return "Home";
            }
            else
            {
                Suffering = false;
                Thread.Sleep(600);
                return "Home";
            }
        }

        void TheEndOfTime()
        {
            Suffering = false;
        }
        /// <summary>
        /// From Timespan that we set return days from that date
        /// </summary>
        /// <returns></returns>
        public int WeAreDoneWorking()
        {
            daysSurviveTime = DateTime.Today - startSchool;
            return daysSurviveTime.Days;
        }

        //Gets array, and adds it to the list
        //List is used in rotating the holidays
        void ListOfHolidays(DateTime[] dates)
        {
            if (!dateTimes.Contains(dates[0]))
                dateTimes.Add(dates[0]);   
        }
        /// <summary>
        /// Finds what day, and return time we are done
        /// </summary>
        /// <returns></returns>
        public string DayOfTheWeek()
        {
            DayOfWeek today = DateTime.Today.DayOfWeek;
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

        public string WhatWeekWeAreIn()
        {
            CultureInfo culture1 = CultureInfo.CurrentCulture;
           
         
            // Gets the Calendar instance associated with a CultureInfo.
            CultureInfo myCI = new CultureInfo(culture1.Name);
            Calendar myCal = myCI.Calendar;

            // Gets the DTFI properties required by GetWeekOfYear.
            CalendarWeekRule myCWR = myCI.DateTimeFormat.CalendarWeekRule;
            DayOfWeek myFirstDOW = myCI.DateTimeFormat.FirstDayOfWeek;

            //Console.WriteLine("The current week {0}.", myCal.GetWeekOfYear(DateTime.Now, myCWR, myFirstDOW));

            string calendarReturn = string.Format("The current week: {0}" +"\n\r"+
                                                  "Day of the year: {1}" + "\n\r" +
                                                  "What month we are in: {2}",
                                                   myCal.GetWeekOfYear(DateTime.Now, myCWR, myFirstDOW), DateTime.Now.DayOfYear, DateTime.Now.Month);

            return calendarReturn;
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
        int changeHolidayDay;
        public int ChangeHoliday(int threadNumber)
        {
            this.changeHolidayDay = threadNumber;

            return changeHolidayDay;
        }
        #region HeadCounter, HolidayCounter
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


            ListOfHolidays(paskeFerie);
            ListOfHolidays(sommerFerie);
            switch (changeHolidayDay) {
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
            
            
            string a = HeadCounter(headTwo, "hovedforloeb 2");
            return a;
        }
        /// <summary>
        /// DateTime[] is the start date of the x,y and string nameOfHead is for the name of the thing
        /// HeadCounter is made to calculate and print the amount of days to x,y event
        /// </summary>
        /// <param name="dayIndex"></param>
        /// <param name="nameOfHead"></param>
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
