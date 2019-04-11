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
                    Thread.Sleep(1000);
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


        string DayOfTheWeek()
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
        
    }
}
