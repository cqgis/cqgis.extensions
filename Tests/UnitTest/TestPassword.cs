using System.Threading;
using cqgis.extensions;
using Xunit;
using cqgis.extensions.xunit;

namespace Tests
{
    public class TestPassword
    {
        [Theory]
        [InlineData("123", "20-2C-B9-62-AC-59-07-5B-96-4B-07-15-2D-23-4B-70")]
        [InlineData("cqgis", "CE-2B-D9-0C-E9-93-A9-3C-1A-FA-FB-C4-5C-AE-71-A0")]
        public void Test_Md5(string value, string actual)
        {
            value.MD5().ShouldBe(actual);
        }


        [Fact] 
        public void Test_Des()
        {
            var key = "cqgis";
            var value = "testpassword";

            var pas = value.EncryptDes(key);
            pas.ShouldBe(t=>t!=value);
            var desvalue = pas.DecryptDes(key);

            value.ShouldBe(desvalue);
        }
    }
}