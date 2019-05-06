using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using Microsoft.Win32;


namespace TimeTilTheEnd
{
    class Program
    {
        static Logic timer = new Logic();
        static Skat skat = new Skat();

        static string skatPrint;

        static void PrintSkat()
        {
            skatPrint = skat.MoneyErnedToday();
        }
        static void Main(string[] args)
        {
            int dayChange = 0;
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
            //TODO: add more threads
            Thread thr = new Thread(PrintSkat);
            thr.Start();
             
            while (true)
            {
                dayChange++;
                timer.ChangeHoliday(dayChange);         //Changes holiday
                //Console.WriteLine(timer.NormalTimer());     //Writes time til school end
                //Console.WriteLine(timer.WhatWeekWeAreIn()); //Calendar for stuff
                //Console.WriteLine(timer.HeadQuarters());    //Writes time til hovedforlob 
                //Console.WriteLine(timer.HolidayFinder());   //Writes time til holiday
                //Console.WriteLine(skat.MoneyErnedToday());

                Console.Clear();
               // string a = timer.NormalTimer() + "\n" + timer.WhatWeekWeAreIn() + "\n" + timer.HeadQuarters() + "\n" + timer.HolidayFinder() + "\n" + skat.MoneyErnedToday();
                string printF = timer.NormalTimer() + "\n" + timer.WhatWeekWeAreIn() + "\n" + timer.HeadQuarters() + "\n" + timer.HolidayFinder() + "\n" + skatPrint;

                ///Dont know which is better

                Console.WriteLine(printF);


                Thread.Sleep(1000);
                Console.WriteLine(timer.DateTimes.Count);
                if (dayChange == timer.DateTimes.Count)
                    dayChange = 0;

                Console.WriteLine(timer.DateTimes.Count);
            }
        }
    }
}
