using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using cqgis.extensions;
using cqgis.extensions.data;
using Xunit;
using cqgis.extensions.xunit;
using Xunit.Abstractions;

namespace Tests
{
    public class TestString
    {
        private readonly ITestOutputHelper _output;

        public TestString(ITestOutputHelper output)
        {
            _output = output;
        }

        [Theory]
        [InlineData("123", false)]
        [InlineData("", true)]
        [InlineData(null, true)]
        public void Test_IsNullorEmpty(string value, bool result)
        {
            value.IsNullorEmpty().ShouldBe(result);
        }

        [Theory]
        [InlineData("123", "123cqgis")]
        [InlineData("123cqgis", "123cqgis")]
        [InlineData("cqgis123c", "cqgis123ccqgis")]
        public void Test_LastWithString(string value, string actual)
        {
            value.LastWithString("cqgis").ShouldBe(actual);
        }

        [Theory]
        [InlineData("123", "cqgis123")]
        [InlineData("cqgis123", "cqgis123")]
        [InlineData("cqgis123ccqgis", "cqgis123ccqgis")]
        public void Test_StartWithString(string value, string actual)
        {
            value.StartWithString("cqgis").ShouldBe(actual);
        }

        [Theory]
        [InlineData("123", 123)]
        [InlineData("123abf", int.MinValue)]
        public void Test_ToInt(string str, int value)
        {
            str.ToInt().ShouldBe(value);
        }

        [Theory]
        [InlineData("123", 123)]
        [InlineData("123abf", null)]
        [InlineData("", null)]
        public void Test_ToNullableInt(string str, int? value)
        {
            str.ToNullableInt().ShouldBe(value);
        }





        [Theory]
        [InlineData("123", 123.0)]
        [InlineData("123abf", double.NaN)]
        public void Test_Todouble(string str, double value)
        {
            str.ToDouble().ShouldBe(value);
        }


        [Theory]
        [InlineData("123", 123.0)]
        [InlineData("123abf", null)]
        [InlineData("", null)]
        public void Test_ToNullabledouble(string str, double? value)
        {
            str.ToNullableDouble().ShouldBe(value);
        }


        [Theory]
        [InlineData("123", 123.0f)]
        [InlineData("123abf", float.NaN)] 
        public void Test_Tofloat(string str, float value)
        {
            str.ToFloat().ShouldBe(value);
        }


        [Theory]
        [InlineData("123", 123.0f)]
        [InlineData("123abf", null)]
        [InlineData("", null)]
        public void Test_TofloatNullable(string str, float? value)
        {
            str.ToNullableFloat().ShouldBe(value);
        }



        [Fact]
        public void Test_ToDateTime()
        {
            "2014-07-24".ToDateTime().ShouldBe(new DateTime(2014, 07, 24));
            "2014-07-24 00:00:00".ToDateTime().ShouldBe(new DateTime(2014, 07, 24));
            "afdfds".ToDateTime().ShouldBe(DateTime.MinValue);
        }

        [Fact]
        public void Test_ToDateTimeNullable()
        {
            "2014-07-24".ToNullableDateTime().ShouldBe(new DateTime(2014, 07, 24));
            "2014-07-24 00:00:00".ToNullableDateTime().ShouldBe(new DateTime(2014, 07, 24));
            "afdfds".ToNullableDateTime().ShouldBe(t => t == null);
            "".ToNullableDateTime().ShouldBe(t => t == null);
        }



        [Theory]
        [InlineData("None", TestEnumEntity.None)]
        [InlineData("Test1", TestEnumEntity.Test1)]
        [InlineData("Testfff2", TestEnumEntity.None)]
        [InlineData("afdf", default(TestEnumEntity))]
        public void Test_ToEnum(string @string, TestEnumEntity actual)
        {
            @string.ToEnum<TestEnumEntity>().ShouldBe(actual);
        }


        [Theory]
        [InlineData("无", TestEnumEntity.None)]
        [InlineData("测试1", TestEnumEntity.Test1)]
        [InlineData("Testfff2", TestEnumEntity.None)]
        [InlineData("afdf", default(TestEnumEntity))]
        public void Test_ToEnumFromChinese(string @string, TestEnumEntity actual)
        {
            @string.ToEnumFromChinese<TestEnumEntity>().ShouldBe(actual);
        }


        [Theory]
        [InlineData("123", false)]
        [InlineData("true", true)]
        [InlineData("True", true)]
        [InlineData("false", false)]
        [InlineData("False", false)]
        public void Test_Tobool(string str, bool value)
        {
            str.ToBool().ShouldBe(value);
        }


        [Theory]
        [InlineData("123", null)]
        [InlineData("true", true)]
        [InlineData("True", true)]
        [InlineData("false", false)]
        [InlineData("False", false)]
        [InlineData("", null)]
        public void Test_ToboolNullable(string str, bool? value)
        {
            str.ToNullableBool().ShouldBe(value);
        }





        private static IEnumerable<object[]> InputData()
        {
            var datas = new List<object[]>
            {
                new object[] {new string[0], "", ""},
                new object[] {new string[0], ",", ""},
                new object[] {new[] {"a"}, "", "a"},
                new object[] {new[] {"a"}, ",", "a"},
                new object[] {new[] {"a", "b", "c"}, "", "abc"},
                new object[] {new[] {"a", "B", "C"}, ",", "a,B,C"}
            };


            return datas;
        }

        [Theory]
        [MemberData(nameof(InputData))]
        public void JoinWith(string[] strings, string symbol, string actual)
        {
            strings.JoinWith(symbol).ShouldBe(actual);
        }


        [Fact]
        public void Test_ToStringList()
        {
            var souce = new[] { 1, 2, 3, 4 };
            var result = souce.ToStringList();

            result.Count.ShouldBe(4);
            for (int i = 0; i < souce.Length; i++)
            {
                result[i].ShouldBe(souce[i].ToString());
            }
        }


        [Theory]
        [InlineData("1", "1", 1)]
        [InlineData("1", "2", 0)]
        public void Test_Cast(string value, string equalvalue, int actual)
        {
            int result = 0;
            void Action() => result++;

            value.Cast(equalvalue, Action);
            result.ShouldBe(actual);
        }



        [Theory]
        [InlineData("1232", 0)]
        [InlineData("", 1)]
        [InlineData(null, 1)]
        public void Test_CheckIsNullOrEmpty(string Paras, int actual)
        {
            int result = 0;
            try
            {
                Paras.CheckIsNullOrEmpty(nameof(Paras));
            }
            catch (ArgumentNullException e)
            {
                e.ParamName.ShouldBe(nameof(Paras));
                result++;
            }
            result.ShouldBe(actual);
        }


        [Theory]
        [InlineData("1232", 0)]
        [InlineData(null, 1)]
        public void Test_CheckIsNull(object param, int actual)
        {
            int result = 0;
            try
            {
                param.CheckIsNull(nameof(param));
            }
            catch (ArgumentNullException e)
            {
                e.ParamName.ShouldBe(nameof(param));
                result++;
            }
            result.ShouldBe(actual);
        }



        [Theory]
        [InlineData("Abcdefg","abc",StringComparison.OrdinalIgnoreCase,true)]
        [InlineData("Abcdefg", "cde", StringComparison.OrdinalIgnoreCase, true)]
        [InlineData("Abcdefg", "abc", StringComparison.CurrentCulture, false)]
        public void Test_ContainsStringValue(string str, string value, StringComparison sc, bool actual)
        {
            str.ContainsStringValue(value,sc).ShouldBe(actual);
        }


        [Theory]
        [InlineData(@"C:\",true)]
        [InlineData(@"C:\123", true)]
        [InlineData(@"C:\123\123.txt", true)]
        [InlineData(@"foldername", false)]
        [InlineData(@"\foldername", false)]
        [InlineData(@"\foldername\123.txt", false)]
        public void Test_IsAbsFilePath(string str, bool actual)
        {
           _output.WriteLine(str);
            str.IsAbsFilePath().ShouldBe(actual);
        }


        [Theory]
        [InlineData(@"c:\1\2\3.txt",@"c:\","1","2","3.txt")]
        [InlineData(@"c:\1\2\3.txt", @"c:\1\2\", "3.txt")]
        [InlineData(@"c:\1\2\3.txt", @"c:\1", @"\2\3.txt")]
        [InlineData(@"c:\1\2\3.txt", @"c:\1\2\3.txt")]
        public void Test_PathCombine_paths(string actual, params string[] paths)
        {
            FileExtension.CombineWithOutAbsPath(paths).ShouldBe(actual);
        }


        [Theory]
        [InlineData(@"c:\1\2\3.txt", @"c:\", "1", "2", "3.txt")]
        [InlineData(@"c:\1\2\3.txt", @"c:\1\2\", "3.txt")]
        [InlineData(@"c:\1\2\3.txt", @"c:\1", @"\2\3.txt")]
        [InlineData(@"c:\1\2\3.txt", @"c:\1\2\3.txt")]
        public void Test_PathCombine(string actual,string rootpath,  params string[] paths)
        {
           rootpath.CombineWithOutAbsPath(paths).ShouldBe(actual);
        }

        [Fact]
        public void Test_Path_absPathException()
        {
            var rootpath = @"c:\1";
            var paths = new string[]
            {
                @"D:\1\1.txt"
            };

            var exception= Assert.Throws<FriendlyException>(() =>
            {
                rootpath.CombineWithOutAbsPath(paths);
            });

            _output.WriteLine(exception.Message);
        }

    }
}