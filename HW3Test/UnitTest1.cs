using NUnit.Framework;
using HW3;

namespace HW3Test
{
    public class FibonacciTextReaderTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            FibonacciTextReader obj1 = new FibonacciTextReader(1);
            Assert.AreEqual("0", obj1.ReadLine());
        }

        [Test]
        public void Test2()
        {
            FibonacciTextReader obj1 = new FibonacciTextReader(2);
            obj1.ReadLine();
            Assert.AreEqual("1", obj1.ReadLine());
        }

        [Test]
        public void Test3()
        {
            FibonacciTextReader obj1 = new FibonacciTextReader(10);
            obj1.ReadLine();
            obj1.ReadLine();
            obj1.ReadLine();
            Assert.AreEqual("2", obj1.ReadLine());
        }
    }
}