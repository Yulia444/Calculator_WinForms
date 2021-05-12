using System;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {

        [Fact]
        public void Test1()
        {

            string expression = "((1+2-4)*(33-121)-(12-3*4))*3";
            int expected = 264;
            Assert.Equal(Int32.Parse(winFormCalculator.MathEvaluator.Result(expression)), expected);
        }

        [Fact]
        public void Test2()
        {
            string expression = "1/0";
            string expected = "безмежність";
            Assert.Equal(winFormCalculator.MathEvaluator.Result(expression), expected);
        }

        [Fact]
        public void Test3()
        {
            string expression = "1+2";
            Assert.IsType<String>(winFormCalculator.MathEvaluator.Result(expression));
        }

        [Fact]
        public void Test4()
        {
            string expression = "1+2";
            Assert.IsType<Double>(winFormCalculator.MathEvaluator.Evaluate(expression));
        }

        [Fact]
        public void Test5()
        {
            string expression = "12.2+2";
            var exception = Assert.Throws<Exception>(() => winFormCalculator.MathEvaluator.Evaluate(expression));
            Assert.Equal("Invalid character.", exception.Message);
        }
    }
}
