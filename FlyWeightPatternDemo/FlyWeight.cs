using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyWeightPatternDemo
{
    /// <summary>
    /// Represents a flyweight object that shares state with multiple instances.
    /// </summary>
    public class FlyWeight
    {
        private readonly Car _sharedstate;

        /// <summary>
        /// Initializes a new instance of the <see cref="FlyWeight"/> class with shared state.
        /// </summary>
        /// <param name="car">The shared state to associate with the flyweight.</param>
        public FlyWeight( Car car ) => _sharedstate = car;

        /// <summary>
        /// Displays the shared state and unique state of the flyweight.
        /// </summary>
        /// <param name="car">The unique state to display along with the shared state.</param>
        public void display( Car car )
        {
            Console.WriteLine( $"Shared state = {_sharedstate.Company}, {_sharedstate.Model}" );
            Console.WriteLine( $"Unique state = {car.Owner}, {car.Number}" );
        }
    }
}
