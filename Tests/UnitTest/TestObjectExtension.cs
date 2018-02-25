using System;
using cqgis.extensions;
using Xunit;
using cqgis.extensions.xunit;

namespace Tests
{
    public class TestObjectExtension
    {
        [Theory]
        [InlineData(null,"","")]
        [InlineData(null, "123", "123")]
        [InlineData("a", "123", "a")]
        public void Test_GetDefaultValueWhileNull<T>(T value,T defaultvalue, T actual)
        {
            value.GetDefaultValueWhileNull(defaultvalue).ShouldBe(actual);
        }


        [Theory]
        [InlineData("123",false)]
        [InlineData("", false)]
        [InlineData(null, true)]
        public void Test_WhileNullDoAction(string value, bool actual)
        {
            bool isnull = false;
            Action a = () => isnull = true;
            value.WhileNullDoAction(a);

            isnull.ShouldBe(actual);
        }

    }
}