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
        /// <summary>
        /// create 2 dates, start day and end day of a date
        /// </summary>
        /// <param name="startyear"></param>
        /// <param name="startmonth"></param>
        /// <param name="startday"></param>
        /// <param name="endyear"></param>
        /// <param name="endmonth"></param>
        /// <param name="endday"></param>
        /// <returns></returns>
        public DateTime[] Holidaay(int startyear, byte startmonth, byte startday, int endyear, byte endmonth, byte endday)
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
