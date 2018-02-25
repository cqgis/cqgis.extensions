using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cqgis.extensions;
using cqgis.extensions.xunit;
using Xunit;
namespace Tests.UnitTest
{
    public class Test_ListExtension
    {

        [Fact]
        public void Test_Shuffle()
        {
            var datas = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                datas.Add(i);
            }

            datas.Shuffle();

            datas.Count.ShouldBe(100);

            var flag = false;
            for (int i = 0; i < 100; i++)
            {
                if (datas[i] != i)
                    flag = true;
            }

            flag.ShouldBe(true
                );

        }


    }
}
