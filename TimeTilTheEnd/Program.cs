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
        static void Main(string[] args)
        {
            Logic a = new Logic();

            a.FirstWrite();
            while (true)
            {
                //string printF = a.NormalTimer();
                //a.NormalTimer();
                //PrintF(a.NormalTimer());
                Console.WriteLine(a.NormalTimer());
                Console.WriteLine(a.HeadQuarters());
                Console.WriteLine(a.HolidayFinder());
            }
        }
    }
}
