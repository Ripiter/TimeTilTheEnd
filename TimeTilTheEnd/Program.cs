using System;
using System.Threading;


namespace TimeTilTheEnd
{
    class Program
    {
        static Logic timer = new Logic();
        static Skat skat = new Skat();

        static string skatPrint;
        static string whatWeekPrint;
        static int counterDays;

        static void PrintSkat()
        {
            skat.WhenStarted = DateTime.Now.ToString();
            skat.WorkHours();
            while(skat.WorkingHard == true)
            {
                skatPrint = skat.MoneyErnedToday();
                Thread.Sleep(60000);
            }
        }

        static void PrintWhatWeek()
        {
            while (true)
            {
                whatWeekPrint = timer.WhatWeekWeAreIn();
            }
        }
        static void Main(string[] args)
        {
            byte dayChange = 0;
            #region Create file to write in
            try
            {
                timer.FirstWrite();
            }
            catch(Exception)
            {
                Console.WriteLine("File Not Created");
            }
            #endregion
            Thread thrSkat = new Thread(PrintSkat);
            Thread thrWeek = new Thread(PrintWhatWeek);

            thrSkat.Start();
            thrWeek.Start();

            Console.WriteLine("Loading...");
            string printF;
            while (true)
            {
                dayChange++;
                timer.ChangeHoliday(dayChange); //Changes holiday

               // string a = timer.NormalTimer() + "\n" + timer.WhatWeekWeAreIn() + "\n" + timer.HeadQuarters() + "\n" + timer.HolidayFinder() + "\n" + skat.MoneyErnedToday();
                printF = timer.NormalTimer() + whatWeekPrint +"\n" + timer.HeadQuarters() + "\n" + timer.HolidayFinder() + "\n" + skatPrint;
               
                ///Dont know which is better
                //Console.WriteLine(timer.NormalTimer());
                Thread.Sleep(1000);
                Console.Clear();
                Console.WriteLine(printF);            
               
                if (dayChange == timer.DateTimes.Count)
                    dayChange = 0;
                
            }
        }
    }
}
