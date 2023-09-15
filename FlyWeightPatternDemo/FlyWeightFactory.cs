using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyWeightPatternDemo
{
    /// <summary>
    /// Represents a factory for managing flyweight objects.
    /// </summary>
    public class FlyWeightFactory
    {
        private readonly List<Tuple<FlyWeight , string>> _flyweights;

        /// <summary>
        /// Initializes a new instance of the <see cref="FlyWeightFactory"/> class with initial flyweights.
        /// </summary>
        /// <param name="args">The initial flyweight objects to add to the factory.</param>
        public FlyWeightFactory( params Car[] args )
        {
            _flyweights = new();
            foreach (Car elem in args)
            {
                _flyweights.Add( new Tuple<FlyWeight , string>( new FlyWeight( elem ) , GetKey( elem ) ) );
            }
        }

        /// <summary>
        /// Generates a string representation for Car object
        /// </summary>
        public string GetKey( Car elem )
        {
            List<string> elements = new()
            {
                elem.Company,
                elem.Model
            };

            if (elem.Owner != null && elem.Number != null)
            {
                elements.Add( elem.Number );
                elements.Add( elem.Owner );
            }

            return string.Join( "_" , elements );
        }

        /// <summary>
        /// Retrieves a flyweight based on its shared state.
        /// </summary>
        /// <param name="sharedState">The shared state for the flyweight.</param>
        /// <returns>A flyweight object, either reused or newly created.</returns>
        public FlyWeight GetFlyWeight( Car sharedState )
        {
            string key = GetKey( sharedState );
            bool ok = false;
            foreach (Tuple<FlyWeight , string> tuple in _flyweights)
            {
                if (tuple.Item2 == key)
                {
                    ok = true;
                    Console.WriteLine( "Reusing existing flyweight" );
                    return tuple.Item1;
                }
            }

            if (!ok)
            {
                _flyweights.Add( new Tuple<FlyWeight , string>( new FlyWeight( sharedState ) , key ) );
            }
            Console.WriteLine( "Can't find a flyweight, creating a new one" );
            return new FlyWeight( sharedState );
        }

        /// <summary>
        /// Lists all the flyweights currently stored in the factory.
        /// </summary>
        public void ListFlyWeights()
        {
            int count = _flyweights.Count;
            Console.WriteLine( $"FlyWeightFactory has {count} flyweights:" );
            foreach (Tuple<FlyWeight , string> flyweight in _flyweights)
            {
                Console.WriteLine( flyweight.Item2 );
            }
        }
    }
}
