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
        static void Main(string[] args)
        {
            Logic a = new Logic();

            a.FirstWrite();
            while (true)
            {
                //string printF = a.NormalTimer();
                //a.NormalTimer();
                PrintF(a.NormalTimer());
            }

        }
        static void PrintF(string f)
        {
            Console.WriteLine(f);
            //return f;
        }
        static void HolidayPrint(string f)
        {
            Console.WriteLine(f);
        }
    }
}
