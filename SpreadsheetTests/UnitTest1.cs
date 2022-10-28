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
        public void Testvariable1()
        {
            ExpressionTree tree = new ExpressionTree("A+B");
            Assert.That(tree.Evaluate() == 0);
            tree.SetVariable("A", 3);
            tree.SetVariable("B", 6);
            Assert.That(tree.Evaluate() == 9);

        }
        [Test]
        public void Testvariable2()
        {
            ExpressionTree tree = new ExpressionTree("A1+B2");
            Assert.That(tree.Evaluate() == 0);
            tree.SetVariable("A1", 3);
            tree.SetVariable("B2", 6);
            Assert.That(tree.Evaluate() == 9);

        }
        [Test]
        public void TestCreatePostfix()
        {
            ExpressionTree tree = new ExpressionTree("(2+3)*(4+5)");
            Assert.That(tree.PostFixExpression == "2 3 + 4 5 + *");

            ExpressionTree tree2 = new ExpressionTree("x * y / (5 * z) + 10");
            Assert.That(tree2.PostFixExpression == "x y * 5 z * / 10 +");

            ExpressionTree tree3 = new ExpressionTree("xxx * y / (5 * zz) + 10");
            Assert.That(tree3.PostFixExpression == "xxx y * 5 zz * / 10 +");

        }

    }
}