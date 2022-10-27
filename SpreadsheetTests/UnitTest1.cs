using NUnit.Framework;
using ExpressionTreeEngine;

namespace SpreadsheetTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
        [Test]
        public void TestAddition()
        {
            ExpressionTree tree = new ExpressionTree("5+10+10");
            Assert.That(tree.Evaluate() == 25);

        }
        [Test]
        public void TestSubtraction()
        {
            ExpressionTree tree = new ExpressionTree("25-1");
            Assert.That(tree.Evaluate() == 24);
        }
        [Test]
        public void TestDivision()
        {
            ExpressionTree tree = new ExpressionTree("24/12");
            Assert.That(tree.Evaluate() == 2);
        }

        [Test]
        public void TestMultiplication()
        {
            ExpressionTree tree = new ExpressionTree("2*8");
            Assert.That(tree.Evaluate() == 16);

        }

        [Test]
        public void Testvariable()
        {
            ExpressionTree tree = new ExpressionTree("A1+A2");
            Assert.That(tree.Evaluate() == 0);
            tree.SetVariable("A1", 3);
            tree.SetVariable("A2", 6);
            Assert.That(tree.Evaluate() == 9);

        }

    }
}