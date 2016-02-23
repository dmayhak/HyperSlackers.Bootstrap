using HyperSlackers.Bootstrap.Demo.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HyperSlackers.Bootstrap.Demo.Models
{
    public class DropdownModel
    {
        public ColorType Color1 { get; set; }
        public ColorType Color2 { get; set; }

        public Car Car1 { get; set; }
        public Car Car2 { get; set; }

        public List<Car> CarTypes { get; set; }

        public DropdownModel()
        {
            Color1 = ColorType.Red;
            Color2 = ColorType.Yellow;

            CarTypes = Car.AllCars();

            Car1 = CarTypes[1];
            Car2 = CarTypes[2];
        }

    }
}