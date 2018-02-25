using cqgis.extensions;
using cqgis.extensions.xunit;
using Xunit;

namespace Tests.UnitTest
{
    public class Test_Base64String
    {
        [Theory]
        [InlineData("123456")]
        [InlineData("cqgis.com")]
        [InlineData("123重庆市")]
        [InlineData("重庆市")]
        [InlineData("重庆市cqgis")]
        public void Test_Base64(string txt)
        {
            var basestring = txt.ToBase64String();
            basestring.Length.ShouldBe(t => t > 0);

            var des = basestring.Frombase64ToString();
            des.ShouldBe(txt);
        }

    }
}
