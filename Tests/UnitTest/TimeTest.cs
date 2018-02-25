using System;
using System.Collections.Generic;
using cqgis.extensions;
using Xunit;
using cqgis.extensions.xunit;
using Xunit.Abstractions;

namespace Tests
{
    public class TimeTest
    {
        private readonly ITestOutputHelper _output;

        public TimeTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Test_Normal()
        {
            var time1 = new DateTime(2017, 5, 5, 10, 30, 0, 10);
            var time2 = new DateTime(2017, 5, 5, 10, 30, 0, 0);
            time1.Normal().ShouldBe(time2);
        }


        private static IEnumerable<object[]> TimeTestData()
        {
            return new[]
            {
                new Object[]{new DateTime(2017, 5, 5, 10, 30, 0, 10), true,"2017-05-05 10:30:00.010"},
                new Object[]{new DateTime(2017, 5, 5, 10, 30, 0, 10), false,"2017-05-05 10:30:00"},
            };
        }

        [Theory]
        [MemberData(nameof(TimeTestData))]
        public void Test_ToFormatString(DateTime time, bool includeMilliSecond, string actual)
        {
            time.ToFormatString(includeMilliSecond).ShouldBe(actual);
        }

        [Fact]
        public void Test_SecValue()
        {
            var time = new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Local);

            var value = time.ToSecValue();
            var fromtime = value.FromSecTime();

            _output.WriteLine(value.ToString());

            //time.ShouldBe(t => t != fromtime); 
            time.ShouldBe(fromtime.ToLocalTime());

            //fromtime.ShouldBe(946656000.FromSecTime());
            //value.ShouldBe(946656000L);

        }


    }
}