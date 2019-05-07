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
        static string whatWeekPrint;

        static void PrintSkat()
        {
            skat.WhenStarted = DateTime.Now.ToString();
            while (true)
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

            string printF;
            while (true)
            {               
                dayChange++;
                timer.ChangeHoliday(dayChange);         //Changes holiday
                //Console.WriteLine(timer.NormalTimer());     //Writes time til school end
                //Console.WriteLine(timer.WhatWeekWeAreIn()); //Calendar for stuff
                //Console.WriteLine(timer.HeadQuarters());    //Writes time til hovedforlob 
                //Console.WriteLine(timer.HolidayFinder());   //Writes time til holiday
                //Console.WriteLine(skat.MoneyErnedToday());

               // string a = timer.NormalTimer() + "\n" + timer.WhatWeekWeAreIn() + "\n" + timer.HeadQuarters() + "\n" + timer.HolidayFinder() + "\n" + skat.MoneyErnedToday();
                printF = timer.NormalTimer() + whatWeekPrint + "\n" + timer.HeadQuarters() + "\n" + timer.HolidayFinder() + "\n" + skatPrint;

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
