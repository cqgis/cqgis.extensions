using System;
using System.Collections.Generic;
using System.Text;
using cqgis.extensions;
using cqgis.extensions.xunit;
using Xunit;

namespace Tests.UnitTest
{
    public  class Test_FileExtension
    {
        [Theory]
        [InlineData(@"X:\200.LAB\cqgis.extensions\cqgis.aspnetcore.extensions\cqgis.extensions.sln", "cqgis.extensions.sln")]
        [InlineData(@"cqgis.aspnetcore.extensions\cqgis.extensions.sln", "cqgis.extensions.sln")]
        [InlineData(@"cqgis.extensions.sln", "cqgis.extensions.sln")]
        public void Test_GetFileName(string fullpath,string filenameExtension)
        {
            fullpath.GetFileName().ShouldBe(filenameExtension);
        }

        [Theory]
        [InlineData(@"X:\200.LAB\cqgis.extensions\cqgis.aspnetcore.extensions\cqgis.extensions.sln", "cqgis.extensions")]
        [InlineData(@"cqgis.aspnetcore.extensions\cqgis.extensions.sln", "cqgis.extensions")]
        [InlineData(@"cqgis.extensions.sln", "cqgis.extensions")]
        public void Test_GetFileNameWithOutExtension(string fullpath, string filenameExtension)
        {
            fullpath.GetFileNameWithOutExtension().ShouldBe(filenameExtension);
        } 

        [Theory]
        [InlineData(@"X:\200.LAB\cqgis.extensions\cqgis.aspnetcore.extensions\cqgis.extensions.sln", ".sln")]
        [InlineData(@"cqgis.aspnetcore.extensions\cqgis.extensions.sln", ".sln")]
        [InlineData(@"cqgis.extensions.sln", ".sln")]
        public void Test_GetFileExtension(string fullpath, string filenameExtension)
        {
            fullpath.GetFileExtension().ShouldBe(filenameExtension);
        }



        [Theory]
        [InlineData(@"X:\200.LAB\cqgis.extensions\cqgis.aspnetcore.extensions\cqgis.extensions.pdf", "application/pdf", "")]
        [InlineData(@"cqgis.aspnetcore.extensions\cqgis.extensions.pdf123", "application/octet-stream", "")]
        [InlineData(@"cqgis.extensions.pdf123", "application/pdf123","application/pdf123")]
        public void Test_GetMimeType(string fullpath, string mimetype,string defaultmimetype)
        {
            if (defaultmimetype.IsNullorEmpty())
            {
                fullpath.GetMimetype().ShouldBe(mimetype);
            }
            else
            {
                fullpath.GetMimetype(defaultmimetype).ShouldBe(mimetype);
            }
        }
    }
}
