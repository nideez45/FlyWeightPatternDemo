// See https://aka.ms/new-console-template for more information

﻿/******************************************************************************
 * Filename    = Program.cs
 *
 * Author      = Nideesh N
 *
 * Product     = SoftwareDesignPatterns
 * 
 * Project     = FlyWeightPatternDemo
 *
 * Description = Console app for user to add a new car and see the flyweight objects.
 *****************************************************************************/


using System.Runtime.InteropServices;
using FlyWeightPatternDemo;

class Program
{
    static void Main()
    {
        FlyWeightFactory factory = new(
                new Car { Company = "Benz",Model = "A"},
                new Car { Company = "Benz",Model = "B"},
                new Car { Company = "Audi",Model = "A"},
                new Car { Company = "Audi",Model = "B"} );

        while (true)
        {
            factory.ListFlyWeights();
            Console.WriteLine( "Press 1 to quit" );
            Console.WriteLine( "Press 2 to add new car" );
            string ?userInput = Console.ReadLine();
            if (userInput == "1")
            {
                break;
            }
            else if(userInput == "2")
            {
                Console.WriteLine( "Enter the company of car:" );
                string company = Console.ReadLine();
                while (string.IsNullOrEmpty( company ))
                {
                    Console.WriteLine( "Company cannot be empty. Please enter the company of car:" );
                    company = Console.ReadLine();
                }

                Console.WriteLine( "Enter the model of car:" );
                string model = Console.ReadLine();
                while (string.IsNullOrEmpty( model ))
                {
                    Console.WriteLine( "Model cannot be empty. Please enter the model of car:" );
                    model = Console.ReadLine();
                }

                Console.WriteLine( "Enter the owner of car:" );
                string owner = Console.ReadLine();
                while (string.IsNullOrEmpty( owner ))
                {
                    Console.WriteLine( "Owner cannot be empty. Please enter the owner of car:" );
                    owner = Console.ReadLine();
                }

                Console.WriteLine( "Enter the number of car:" );
                string number = Console.ReadLine();
                while (string.IsNullOrEmpty( number ))
                {
                    Console.WriteLine( "Number cannot be empty. Please enter the number of car:" );
                    number = Console.ReadLine();
                }

                Console.WriteLine( "Adding the new car" );
               addCar(factory, new Car { Model = model ,Company = company,Number = number,Owner = owner});
            }
            else
            {
                Console.WriteLine( "Not a valid option! try again" );
            }
        }
     
    }
    /// <summary>
    /// Adds a car to the factory and displays its shared and unique state.
    /// </summary>
    /// <param name="factory">The FlyWeightFactory instance.</param>
    /// <param name="car">The car to add and display.</param>
    public static void addCar(FlyWeightFactory factory,Car car )
    {
        FlyWeight flyWeight = factory.GetFlyWeight(new Car { Company = car.Company,Model = car.Model} );

        flyWeight.display( car );

    }
}
