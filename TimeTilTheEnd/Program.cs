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
    class Program : Holiday
    {
        static Timer timer = new Timer();
        static Skat skat = new Skat();
      
        static void Main(string[] args)
        {
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
            
            int dayChange = 1;

            while (true)
            { 
                timer.ChangeHoliday(dayChange);         //Changes holiday
                Console.WriteLine(timer.NormalTimer());     //Writes time til school end
                Console.WriteLine(timer.WhatWeekWeAreIn()); //Calendar for stuff
                Console.WriteLine(timer.HeadQuarters());    //Writes time til hovedforlob 
                Console.WriteLine(timer.HolidayFinder());   //Writes time til holiday
                Console.WriteLine(skat.MoneyErnedToday());
                Thread.Sleep(1000);
                dayChange++;

                if (dayChange == 3)
                    dayChange = 1;
            }
        }
    }
}
