using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.Tests
{
    public class PasswordTests
    {
        [Theory]
        [InlineData("Asdrr1rff!")]
        [InlineData("As!r1rrd")]
        [InlineData("Asdff!Asd1ff!Asdff!Asd!qqqqqqq")]
        public void Password_ReturnsExpected(string pwd)
        {
            Assert.True(Class.IsPasswordStrong(pwd));
        }

        [Theory]
        [InlineData("A1sdff!")]
        [InlineData("As1dff!Asdff!Asdff!Asd!Asdff!Asdff!Asdff!Asd!Asdff")]
        [InlineData("As!rrrdff")]
        [InlineData("Asd1aaaff")]
        [InlineData("ASDFG1HJKL!")] 
        [InlineData("aaaa1sdff!")]
        [InlineData("Aaaa1sdffё!")]
        [InlineData("")]
        public void Password_False_ReturnsExpected(string pwd)
        {
            Assert.False(Class.IsPasswordStrong(pwd));
        }

        [Fact]
        public void Password_Null_ReturnsExpected()
        {
            Assert.False(Class.IsPasswordStrong(null));
        }

    }
}
