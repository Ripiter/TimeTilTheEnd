using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTilTheEnd
{
    class Skat
    {
        #region Money earned per minute

        int moneyErnedInAYear = 91680;
        float proceftForSkat = 0.38f;
        int workingMinute = 2220;
        float inTotalBefore = 0f;
        float inTotalAfter = 0f;

        public string MoneyErnedToday()
        {
            string retPrice;
            
                inTotalBefore += MoneyEarnedBeforeSkat();
                inTotalAfter += MoneyEarnedAfterSkat();
                retPrice = "Money Earned Per Minute ('since app started'): \r\nBefore skat: " + inTotalBefore + "\r\nAfter skat " + inTotalAfter;
           
            
            return retPrice;

            
            ///Make it count up, calculate how much for a sec :D
            //return "Money Erned per hour before skat: " + MoneyEarnedBeforeSkat() + "\nMoney after skat " + MoneyEarnedAfterSkat();
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
            int hoursWorkedPerWeek = workingMinute / 5;

            float moneyErnedPerHour = moneyPerDay / hoursWorkedPerWeek;
            return moneyErnedPerHour;
        }

        #endregion
    }
}
