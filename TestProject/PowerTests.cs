using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.Tests
{
    public class PowerTests
    {
        [Theory]
        [InlineData(2, 3, 8.0)]
        [InlineData(2, 0, 1.0)]
        [InlineData(2, -2, 0.25)]
        [InlineData(-2, 3, -8.0)]
        [InlineData(-2, 2, 4.0)]
        [InlineData(0, 5, 0.0)]
        [InlineData(1.2345, 2, 1.524)]
        public void Power_ReturnsExpected(double a, int n, double expected)
        {
            double actual = Class.Power(a, n);
            Assert.Equal(expected, actual, 3);
        }
    }
}
