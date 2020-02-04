using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowRoomForm.Helper
{
    public static class Guard
    {
        public static void Before(this DateTime start, DateTime end)
        {
            if (end < start) throw new Exception("Start date must be before end date.");
        }
    }
}
