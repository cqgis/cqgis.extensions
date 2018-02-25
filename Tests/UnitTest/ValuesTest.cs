using System;
using System.Collections.Generic;
using System.Text;
using cqgis.extensions;
using Xunit;
using cqgis.extensions.xunit;

namespace Tests
{
    public class ValuesTest
    {
        [Theory]
        [InlineData(5, 5, 2, 10)]
        [InlineData(1, 2, 2, 10)]
        [InlineData(11, 10, 2, 10)]
        public void Test_ClipIn_Int(int value, int actual, int min, int max)
        {
            value.ClipIn(min, max).ShouldBe(actual);
        }

        [Theory]
        [InlineData(5.0, 5.0, 2.0, 10.0)]
        [InlineData(1.0, 2.0, 2.0, 10.0)]
        [InlineData(11.0, 10.0, 2.0, 10.0)]
        public void Test_ClipIn_double(double value, double actual, double min, double max)
        {
            value.ClipIn(min, max).ShouldBe(actual);
        }



        [Theory]
        [InlineData(5.0f, 5.0f, 2.0f, 10.0f)]
        [InlineData(1.0f, 2.0f, 2.0f, 10.0f)]
        [InlineData(11.0f, 10.0f, 2.0f, 10.0f)]
        public void Test_ClipIn_Float(float value, float actual, float min, float max)
        {
            value.ClipIn(min, max).ShouldBe(actual);
        }


        [Theory]
        [InlineData(5, 5, 2, 10)]
        [InlineData(1, 2, 2, 10)]
        [InlineData(11, 10, 2, 10)]
        public void Test_ClipIn_byte(byte value, byte actual, byte min, byte max)
        {
            value.ClipIn(min, max).ShouldBe(actual);
        }


        [Theory]
        [InlineData(1,"00000001")]
        [InlineData(15, "0000000f")]
        [InlineData(16, "00000010")]
        [InlineData(11_259_375, "00abcdef")]
        public void Test_to16(int value,string string16_8)
        {
           value.to16().ShouldBe(string16_8);
        }

    }
}
