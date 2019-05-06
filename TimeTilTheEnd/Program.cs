﻿using System;
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
        static Timer a = new Timer();
        public static void DoWork()
        {
            int dayChange = 1;
            while (true)
            {
                a.ChangeHoliday(dayChange);         //Changes holiday
                Console.WriteLine(a.NormalTimer());     //Writes time til school end
                Console.WriteLine(a.WhatWeekWeAreIn()); //Calendar for stuff
                Console.WriteLine(a.HeadQuarters());    //Writes time til hovedforlob 
                Console.WriteLine(a.HolidayFinder());   //Writes time til holiday
                Console.WriteLine(a.MoneyErnedToday());
                Thread.Sleep(1000);
                        dayChange++;

              if (dayChange == 3)
                  dayChange = 1;
            }
        }

        static void Main(string[] args)
        {
            Thread sleepingThread = new Thread(DoWork);
            #region Create file to write in
            try
            {
                a.FirstWrite();
            }
            catch(Exception)
            {
                Console.WriteLine("File Not Created");
            }
            #endregion

            sleepingThread.Start();
        }
    }
}
