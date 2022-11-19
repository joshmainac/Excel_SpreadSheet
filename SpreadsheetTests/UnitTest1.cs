using NUnit.Framework;
using ExpressionTreeEngine;
using SpreadsheetEngine;



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
        public void TestCreatePostfix()
        {
            ExpressionTree tree = new ExpressionTree("(2+3)*(4+5)");
            Assert.That(tree.PostFixExpression == "2 3 + 4 5 + *");

            ExpressionTree tree2 = new ExpressionTree("x * y / (5 * z) + 10");
            Assert.That(tree2.PostFixExpression == "x y * 5 z * / 10 +");

            ExpressionTree tree3 = new ExpressionTree("xxx * y / (5 * zz) + 10");
            Assert.That(tree3.PostFixExpression == "xxx y * 5 zz * / 10 +");



        }
        [Test]
        public void TestGetVariableNames()
        {
            ExpressionTree tree = new ExpressionTree("A1+B2");
            string[] mylist1 ={ "A1", "B2" };
            string[] mylist2 = tree.GetVariableNames();
            Assert.That(mylist1[0].Equals(mylist2[0]));
            Assert.That(mylist1[1].Equals(mylist2[1]));


        }
        [Test]
        public void TestSpreadsheet_Evaluate()
        {
            //SpreadsheetEngine.Spreadsheet.cs has a Evaluate(). We want to test this
            Spreadsheet spreadsheet;
            spreadsheet = new Spreadsheet(50, 26);
            spreadsheet.GetCell(1, 1).Text = "=1+1";
            Assert.That(spreadsheet.GetCell(1, 1).Value == "2");




        }
        [Test]
        public void TestSpreadsheet_Evaluate2()
        {
            //SpreadsheetEngine.Spreadsheet.cs has a Evaluate(). We want to test this
            Spreadsheet spreadsheet;
            spreadsheet = new Spreadsheet(50, 26);
            spreadsheet.GetCell(0, 0).Text = "1";
            spreadsheet.GetCell(0, 1).Text = "=A1";
            Assert.That(spreadsheet.GetCell(0, 1).Value == "1");

        }

        public class Tests2
        {
            [SetUp]
            public void Setup()
            {
            }
            [Test]
            public void Testvariable1()
            {
                ExpressionTree tree = new ExpressionTree("A+B");
                tree.SetVariable("A", 3);
                tree.SetVariable("B", 6);
                Assert.That(tree.Evaluate() == 9);

            }
            [Test]
            public void Testvariable22()
            {
                ExpressionTree tree3 = new ExpressionTree("A1+B2");
                //Assert.That(tree3.Evaluate() == 0);
                tree3.SetVariable("A1", 4);
                tree3.SetVariable("B2", 6);
                Assert.That(tree3.Evaluate() == 10);

            }
            [Test]
            public void TestUndoRedo()
            {
                Spreadsheet spreadsheet;
                spreadsheet = new Spreadsheet(50, 26);
                Cell mycell = spreadsheet.GetCell(0, 0);
                mycell.Text = "1";
                spreadsheet.AddUndo(mycell,"Text Change");
                Assert.That(spreadsheet.CountUndo() == 1);
                Assert.That(mycell.Text == "1");
                mycell.Text = "2";
                Assert.That(mycell.Text == "2");
                spreadsheet.ExecuteUndo();
                Assert.That(mycell.Text == "1");
                spreadsheet.ExecuteRedo();
                Assert.That(mycell.Text == "2");


            }


        }









    }
}



