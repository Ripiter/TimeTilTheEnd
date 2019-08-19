using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTilTheEnd
{
    class Skat
    {
        Logic timer = new Logic();

        #region Variables
        int moneyErnedInAYear = 91680;
        float proceftForSkat = 0.38f;
        float inTotalBefore = 0f;
        float inTotalAfter = 0f;
        string whenStarted;
        bool workingHard;
        #endregion

        #region Properties
        public bool WorkingHard
        {
            get
            {
                return this.workingHard;
            }
        }
        public string WhenStarted
        {
            get
            {
                return this.whenStarted;
            }
            set
            {
                this.whenStarted = value;
            }
        }
        public float InTotalBefore
        {
            get
            {
                return this.inTotalBefore;
            }
            set
            {
                this.inTotalBefore = value;
            }
        }
        public float InTotalAfter
        {
            get
            {
                return this.inTotalAfter;
            }
            set
            {
                this.inTotalAfter = value;
            }
        }
        #endregion
        //TO DO: Read from txt 
        public string MoneyErnedToday()
        {
            string retPrice;
            
            InTotalBefore += MoneyEarnedBeforeSkat();
            InTotalAfter += MoneyEarnedAfterSkat();
            retPrice = "Money Earned Per Minute ('started "+ WhenStarted + "'): \r\nBefore skat: " + InTotalBefore + "\r\nAfter skat " + InTotalAfter;
           
            return retPrice; 
        }

        float MoneyEarnedAfterSkat()
        {
            float moneyForSkat = MoneyEarnedBeforeSkat() * proceftForSkat;

            float moneyAfterSkat = MoneyEarnedBeforeSkat() - moneyForSkat;
            return moneyAfterSkat;
        }

        float MoneyEarnedBeforeSkat()
        {
            float moneyPerDay = moneyErnedInAYear / 365;
            float moneyPerHour = moneyPerDay / 8;
            float moneyPerMinute = moneyPerHour / 60;
           
            return moneyPerMinute;
        }

        //timer.DayOfTheWeek returned time we got free based on the day
        public void WorkHours()
        {
            DateTime startWork = DateTime.Parse("08:00:00");
            DateTime endWork = DateTime.Parse(timer.DayOfTheWeek());
            TimeSpan work = endWork - DateTime.Now;

            if(work.Seconds > -1 && DateTime.Now > startWork)
                workingHard = true;
            else
                workingHard = false;
        }
    }
}
