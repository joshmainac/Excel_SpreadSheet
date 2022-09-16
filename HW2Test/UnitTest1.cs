using NUnit.Framework;
using HW2;


namespace HW2Test
{
    public class DistinctIntegersTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {

            DistinctIntegers obj1 = new DistinctIntegers();
            int resOne = obj1.DistinctIntegersOne();
            int resTwo = obj1.DistinctIntegersTwo();
            Assert.AreEqual(resTwo, resOne);







        }
        [Test]
        public void Test2()
        {
            DistinctIntegers obj1 = new DistinctIntegers();
            int resOne = obj1.DistinctIntegersOne();
            int resTwo = obj1.DistinctIntegersTwo();
            Assert.AreEqual(resTwo, resOne);
           
           
        }

        [Test]
        public void Test3()
        {
            DistinctIntegers obj1 = new DistinctIntegers();
            int resOne = obj1.DistinctIntegersOne();
            int resThree = obj1.DistinctIntegersThree();
            Assert.AreEqual(resThree, resOne);


        }


        [Test]
        public void Test4()
        {
            DistinctIntegers obj1 = new DistinctIntegers();
            int resThree = obj1.DistinctIntegersThree();
            int resTwo = obj1.DistinctIntegersTwo();
            Assert.AreEqual(resTwo, resThree);


        }

        [Test]
        public void Test5()
        {
            DistinctIntegers obj1 = new DistinctIntegers();
            int resOne = obj1.DistinctIntegersOne();
            int resTwo = obj1.DistinctIntegersTwo();
            int resThree = obj1.DistinctIntegersThree();
            Assert.AreEqual(resTwo, resOne,resThree);


        }
    }
}