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

        int MoneyErnedInAYear = 91680;
        float proceftForSkat = 0.38f;

        public string MoneyErnedToday()
        {
            ///Make it count up, calculate how much for a sec :D
            return "Money Erned per hour before skat: " + MoneyErnedBeforeSkat() + "\nMoney after skat" + MoneyErnedAfterSkat();
        }

        float MoneyErnedAfterSkat()
        {
            float moneyForSkat = MoneyErnedBeforeSkat() * proceftForSkat;

            float moneyAfterSkat = MoneyErnedBeforeSkat() - moneyForSkat;
            return moneyAfterSkat;
        }

        float MoneyErnedBeforeSkat()
        {
            float moneyPerDay = MoneyErnedInAYear / 365;
            int hoursWorkedPerWeek = 37 / 5;

            float moneyErnedPerHour = moneyPerDay / hoursWorkedPerWeek;
            return moneyErnedPerHour;
        }

        #endregion
    }
}
