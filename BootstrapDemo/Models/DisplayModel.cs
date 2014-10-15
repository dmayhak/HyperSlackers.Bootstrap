using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HyperSlackers.Bootstrap.Demo.Models
{
    public class DisplayModel
    {
        public string SomeText1 { get; set; }
        public string SomeText2 { get; set; }

        public DisplayModel()
        {
            SomeText1 = "Some Text";
            SomeText2 = "Some Text or for display";
        }
    }
}