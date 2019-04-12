using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TimeTilTheEnd
{
    class Holiday
    {
        public DateTime[] Holidaay(int startyear, int startmonth, int startday, int endyear, int endmonth, int endday)
        {
            DateTime startdate = new DateTime(startyear, startmonth, startday);
            DateTime enddate = new DateTime(endyear, endmonth, endday);

            DateTime[] date = new DateTime[2];
            date[0] = startdate;
            date[1] = enddate;
            return date;
        }
    }
}
