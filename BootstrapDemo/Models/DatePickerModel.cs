using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HyperSlackers.Bootstrap.Demo.Models
{
    public class DatePickerModel
    {
        public DateTime Date1 { get; set; }
        public DateTime Date2 { get; set; }

        public DatePickerModel()
        {
            Date1 = DateTime.Now;
            Date2 = DateTime.UtcNow;
        }
    }
}