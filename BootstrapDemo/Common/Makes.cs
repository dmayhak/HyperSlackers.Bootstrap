using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HyperSlackers.Bootstrap.Demo.Common
{
    public class Car
    {
        public string Code { get; set; }
        public string Name { get; set; }

        public static List<Car> AllCars()
        {
            List<Car> cars = new List<Car>();

            cars.Add(new Car { Code = "F150", Name = "Ford F-150 Pick-Up" });
            cars.Add(new Car { Code = "CAM", Name = "Chevy Camero" });
            cars.Add(new Car { Code = "S10", Name = "Chevy S-10 Pick-Up" });
            cars.Add(new Car { Code = "CHAR", Name = "Dodge Charger" });
            cars.Add(new Car { Code = "DART", Name = "Dodge Dart" });

            return cars;
        }
    }
}