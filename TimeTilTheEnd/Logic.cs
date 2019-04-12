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
        Holiday ac = new Holiday();
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
                // Create a new file     
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
            StreamWriter write = new StreamWriter("C:/daysSurvived.txt");
            write.Write(DaysSurvived);
            write.Close();
            //Write to txt file
            //To write counter for days suffered
            //In case program closes
        }
        void ReadingFromTxt()
        {
            using (StreamReader read = new StreamReader("C:/daysSurvived.txt"))
            {
                PrintDaysSurvived = int.Parse(read.ReadLine());
                read.Close();
                //Reading from a txt file
                //To read counter for days suffered
                //In case program closes
            }
        }

      //  public bool Suffering { get => suffering; set => suffering = value; }


        public void NormalTimer()
        {
            DayOfTheWeek();
            DateTime a = DateTime.Parse(timeLeft);

            //DateTime a = DateTime.Parse("16:00:00");

            TimeSpan g;
            TimeSpan minusTime = a - DateTime.Now;
            if (minusTime.Seconds > -1)
            {
                while (Suffering)
                {
                    EatingTime();
                    ReadingFromTxt();
                    Console.Clear();
                    g = a - DateTime.Now;
                    Console.Write(g);
                    Console.WriteLine("");
                    Console.WriteLine("Hours left: " + g.Hours);
                    Console.WriteLine("Minutes left: " + g.Minutes);
                    Console.WriteLine("Seconds left: " + g.Seconds);
                    if (eating == true)
                        Console.WriteLine("Break!!! Eat!!! Now!!!");
                    Console.WriteLine("Days Survived: " + PrintDaysSurvived);
                    TripleAAA();
                    HeadQuarters();
                    
                    Thread.Sleep(980);
                    if (g.Seconds <= -1)
                    {
                        WeAreWorking();
                        TheEndOfTime();
                    }
                }
            }
            else
            {
                Console.WriteLine("Home");
                Thread.Sleep(60000);
            }
        }

        void TheEndOfTime()
        {
            Console.WriteLine("Time has ended");
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
        
        Random rnd = new Random();
        void TripleAAA()
        {
            DateTime[] paskeFerie = ac.Holidaay(2019, 4, 15, 2019, 4, 23);
            DateTime[] sommerFerie = ac.Holidaay(2019, 6, 29, 2019, 7, 11);

            int gg = rnd.Next(1, 3);

            switch (gg) {
                case 1:
                  HolidayCounter(paskeFerie,"paskeferie");
                    break;
                case 2:
                  HolidayCounter(sommerFerie,"sommerferie");
                    break;
                default:
                    Console.WriteLine("Yeet the error");
                    break;
            }

        }
        void HeadQuarters()
        {
            DateTime[] headTwo = ac.Holidaay(2020, 1, 13, 2020, 3, 20);

            HeadCounter(headTwo,"head2");
        }
        void HeadCounter(DateTime[] b, string nameOfHead)
        {
            TimeSpan c = b[0] - DateTime.Now;
            TimeSpan d = b[1] - DateTime.Now;
            TimeSpan e = DateTime.Now - b[1];

            if (DateTime.Now <= b[0])
                Console.WriteLine("Days till " +nameOfHead +": "+ c.Days);
            else if (DateTime.Now >= b[0] && DateTime.Now <= b[1])
                Console.WriteLine(nameOfHead + " now days left: " + d.Days);

            else if (DateTime.Now >= b[1])
                Console.WriteLine("Days since " + nameOfHead + ": " + e.Days);

        }
        void HolidayCounter(DateTime[] b, string nameOfHoliday)
        {
            
            TimeSpan c = b[0] - DateTime.Now;
            TimeSpan d = b[1] - DateTime.Now;
            TimeSpan e = DateTime.Now - b[1];

            if (DateTime.Now <= b[0])
                Console.WriteLine("Days till " +nameOfHoliday +": "+ c.Days);

            else if (DateTime.Now >= b[0] && DateTime.Now <= b[1])
                Console.WriteLine(nameOfHoliday +" now days left: " + d.Days);

            else if (DateTime.Now >= b[1])
                Console.WriteLine("Days since " +nameOfHoliday +": "+ e.Days);
        }

    }
}
