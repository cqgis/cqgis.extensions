using System;
using cqgis.extensions;
using Tests;
using Xunit;
using cqgis.extensions.xunit;

namespace Tests
{
    public class TestGuidExtension
    {
        [Fact]
        public void Test_GuidToString16()
        {
            var result=Guid.NewGuid().Tostring16();

            result.Length.ShouldBe(16);
        }

        [Fact]
        public void Test_GuidTolong19()
        {
            var result =Guid.NewGuid().Tolong19();
 
           Assert.IsType(typeof(long),result);
        }
    }
}