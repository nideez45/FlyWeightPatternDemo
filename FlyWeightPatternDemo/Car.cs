/******************************************************************************
 * Filename    = Car.cs
 *
 * Author      = Nideesh N
 *
 * Product     = SoftwareDesignPatterns
 * 
 * Project     = FlyWeightPatternDemo
 *
 * Description = Contains the Car class
 *****************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyWeightPatternDemo
{
    /// <summary>
    /// Represents a car with various properties.
    /// </summary>
    public class Car
    {
        public string ?Owner { get; set; }

        public string ?Number { get; set; }

        public string ?Company { get; set; }

        public string ?Model { get; set; }
    }
}
