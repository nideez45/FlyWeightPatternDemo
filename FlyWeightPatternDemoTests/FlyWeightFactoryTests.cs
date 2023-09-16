/******************************************************************************
 * Filename    = FlyWeightFactoryTests.cs
 *
 * Author      = Nideesh N
 *
 * Product     = SoftwareDesignPatterns
 * 
 * Project     = FlyWeightPatternDemoTests
 *
 * Description = Unit tests for Fly Weight pattern demo.
 *****************************************************************************/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlyWeightPatternDemo;
namespace FlyWeightPatternDemo.Tests
{
    [TestClass]
    public class FlyWeightFactoryTests
    {
        /// <summary>
        /// Tests the GetKey method with a simple car object.
        /// </summary>
        [TestMethod]
        public void GetKeyTest1()
        {
            FlyWeightFactory factory = new();
            string expected = "Benz_A";
            string actual = factory.GetKey( new Car { Company = "Benz" , Model = "A" } );
            Assert.AreEqual( expected , actual );
        }

        /// <summary>
        /// Tests the GetKey method with a car object containing more properties.
        /// </summary>
        [TestMethod]
        public void GetkeyTest2()
        {
            FlyWeightFactory factory = new();
            string expected = "Benz_A_123_Owner1";
            string actual = factory.GetKey( new Car { Company = "Benz" , Model = "A" , Owner = "Owner1" , Number = "123" } );
            Assert.AreEqual( expected , actual );
        }

        /// <summary>
        /// Tests if GetFlyWeight returns a non-null result.
        /// </summary>
        [TestMethod]
        public void GetFlyWeightTest1()
        {
            FlyWeightFactory factory = new();
            Car car = new() { Company = "Benz" , Model = "A" };
            FlyWeight result = factory.GetFlyWeight( car );
            Assert.IsNotNull( result );
        }

        /// <summary>
        /// Tests if the "Can't find a flyweight, creating a new one" message is printed.
        /// </summary>
        [TestMethod]
        public void GetFlyWeightTest2()
        {
            FlyWeightFactory factory = new();
            Car car = new() { Company = "Benz" , Model = "A" };
            using var sw = new StringWriter();
            Console.SetOut( sw );
            factory.GetFlyWeight( car );
            string output = sw.ToString();
            Assert.IsTrue( output.Contains( "Can't find a flyweight, creating a new one" ) );
        }

        /// <summary>
        /// Tests if the "Reusing existing flyweight" message is printed.
        /// </summary>
        [TestMethod]
        public void GetFlyWeightTest3()
        {
            
            FlyWeightFactory factory = new();
            Car car1 = new() { Company = "Benz" , Model = "A" };
            Car car2 = new() { Company = "Benz" , Model = "A" };

            using var sw = new StringWriter();
            Console.SetOut( sw );
            factory.GetFlyWeight( car1 );
            factory.GetFlyWeight( car2 );
            string output = sw.ToString();

            Assert.IsTrue( output.Contains( "Reusing existing flyweight" ) );
        }

        /// <summary>
        /// Tests if ListFlyWeights correctly lists the flyweights.
        /// </summary>
        [TestMethod]
        public void ListFlyWeights1()
        {
            FlyWeightFactory factory = new();
            Car car1 = new() { Company = "Benz" , Model = "A" };
            Car car2 = new() { Company = "Audi" , Model = "A" };
            factory.GetFlyWeight( car1 );
            factory.GetFlyWeight( car2 );

            using var sw = new StringWriter();
            Console.SetOut( sw );
            factory.ListFlyWeights();
            string output = sw.ToString();

            string expected = "FlyWeightFactory has 2 flyweights:\r\nBenz_A\r\nAudi_A\r\n";
            Assert.AreEqual( output , expected );
        }

        /// <summary>
        /// Tests if ListFlyWeights correctly lists no flyweights.
        /// </summary>
        [TestMethod]
        public void ListFlyWeights2()
        {
            FlyWeightFactory factory = new();

            using var sw = new StringWriter();
            Console.SetOut( sw );
            factory.ListFlyWeights();
            string output = sw.ToString();

            string expected = "FlyWeightFactory has 0 flyweights:\r\n";
            Assert.AreEqual( output , expected );
        }

        /// <summary>
        /// Tests the display method of FlyWeight for the expected output.
        /// </summary>
        [TestMethod]
        public void FlyWeightTest()
        {
            FlyWeightFactory factory = new();
            Car car = new() { Company = "Benz" , Model = "A" , Owner = "Owner1" , Number = "123" };
            FlyWeight flyWeight = factory.GetFlyWeight( new Car { Company = car.Company , Model = car.Model } );

            using var sw = new StringWriter();
            Console.SetOut( sw );
            flyWeight.display( car );
            string output = sw.ToString();

            string expected = "Shared state = Benz, A\r\nUnique state = Owner1, 123\r\n";
            Assert.AreEqual( output , expected );
        }
    }
}
