using cqgis.extensions;
using cqgis.extensions.xunit;
using Tests;
using Xunit;

namespace Tests
{
    public class TestEnumExtension
    {
        [Theory]
        [InlineData(TestEnumEntity.Test1,"测试1")]
        [InlineData(TestEnumEntity.Test2, "测试2")]
        public void Test_ToChinese(TestEnumEntity value,string chinese)
        {
            value.ToChinese().ShouldBe(chinese);
        }
    }
}