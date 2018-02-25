using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cqgis.extensions.data;

namespace cqgis.extensions
{
    /// <summary>
    /// cqgis: 文件扩展方法
    /// </summary>
    public static class FileExtension
    {
        private static readonly Dictionary<string, string> mimetypes = new Dictionary<string, string>()
        {
            { "ez","application/andrew-inset                         "},
            { "hqx","application/mac-binhex40                        "},
            { "cpt","application/mac-compactpro                      "},
            { "doc","application/msword                              "},
            { "bin","application/octet-stream                        "},
            { "dms","application/octet-stream                        "},
            { "lha","application/octet-stream                        "},
            { "lzh","application/octet-stream                        "},
            { "exe","application/octet-stream                        "},
            { "class","application/octet-stream                      "},
            { "so","application/octet-stream                         "},
            { "dll","application/octet-stream                        "},
            { "oda","application/oda                                 "},
            { "pdf","application/pdf                                 "},
            { "ai","application/postscript                           "},
            { "eps","application/postscript                          "},
            { "ps","application/postscript                           "},
            { "smi","application/smil                                "},
            { "smil","application/smil                               "},
            { "mif","application/vnd.mif                             "},
            { "xls","application/vnd.ms-excel                        "},
            { "ppt","application/vnd.ms-powerpoint                   "},
            { "wbxml","application/vnd.wap.wbxml                     "},
            { "wmlc","application/vnd.wap.wmlc                       "},
            { "wmlsc","application/vnd.wap.wmlscriptc                "},
            { "bcpio","application/x-bcpio                           "},
            { "vcd","application/x-cdlink                            "},
            { "pgn","application/x-chess-pgn                         "},
            { "cpio","application/x-cpio                             "},
            { "csh","application/x-csh                               "},
            { "dcr","application/x-director                          "},
            { "dir","application/x-director                          "},
            { "dxr","application/x-director                          "},
            { "dvi","application/x-dvi                               "},
            { "spl","application/x-futuresplash                      "},
            { "gtar","application/x-gtar                             "},
            { "hdf","application/x-hdf                               "},
            { "js","application/x-javascript                         "},
            { "skp","application/x-koan                              "},
            { "skd","application/x-koan                              "},
            { "skt","application/x-koan                              "},
            { "skm","application/x-koan                              "},
            { "latex","application/x-latex                           "},
            { "nc","application/x-netcdf                             "},
            { "cdf","application/x-netcdf                            "},
            { "sh","application/x-sh                                 "},
            { "shar","application/x-shar                             "},
            { "swf","application/x-shockwave-flash                   "},
            { "sit","application/x-stuffit                           "},
            { "sv4cpio","application/x-sv4cpio                       "},
            { "sv4crc","application/x-sv4crc                         "},
            { "tar","application/x-tar                               "},
            { "tcl","application/x-tcl                               "},
            { "tex","application/x-tex                               "},
            { "texinfo","application/x-texinfo                       "},
            { "texi","application/x-texinfo                          "},
            { "tr","application/x-troff                              "},
            { "roff","application/x-troff                            "},
            { "man","application/x-troff-man                         "},
            { "me","application/x-troff-me                           "},
            { "ms","application/x-troff-ms                           "},
            { "ustar","application/x-ustar                           "},
            { "src","application/x-wais-source                       "},
            { "xhtml","application/xhtml+xml                         "},
            { "xht","application/xhtml+xml                           "},
            { "zip","application/zip                                 "},
            { "au","audio/basic                                      "},
            { "snd","audio/basic                                     "},
            { "mid","audio/midi                                      "},
            { "midi","audio/midi                                     "},
            { "kar","audio/midi                                      "},
            { "mpga","audio/mpeg                                     "},
            { "mp2","audio/mpeg                                      "},
            { "mp3","audio/mpeg                                      "},
            { "aif","audio/x-aiff                                    "},
            { "aiff","audio/x-aiff                                   "},
            { "aifc","audio/x-aiff                                   "},
            { "m3u","audio/x-mpegurl                                 "},
            { "ram","audio/x-pn-realaudio                            "},
            { "rm","audio/x-pn-realaudio                             "},
            { "rpm","audio/x-pn-realaudio-plugin                     "},
            { "ra","audio/x-realaudio                                "},
            { "wav","audio/x-wav                                     "},
            { "pdb","chemical/x-pdb                                  "},
            { "xyz","chemical/x-xyz                                  "},
            { "bmp","image/bmp                                       "},
            { "gif","image/gif                                       "},
            { "ief","image/ief                                       "},
            { "jpeg","image/jpeg                                     "},
            { "jpg","image/jpeg                                      "},
            { "jpe","image/jpeg                                      "},
            { "png","image/png                                       "},
            { "tiff","image/tiff                                     "},
            { "tif","image/tiff                                      "},
            { "djvu","image/vnd.djvu                                 "},
            { "djv","image/vnd.djvu                                  "},
            { "wbmp","image/vnd.wap.wbmp                             "},
            { "ras","image/x-cmu-raster                              "},
            { "pnm","image/x-portable-anymap                         "},
            { "pbm","image/x-portable-bitmap                         "},
            { "pgm","image/x-portable-graymap                        "},
            { "ppm","image/x-portable-pixmap                         "},
            { "rgb","image/x-rgb                                     "},
            { "xbm","image/x-xbitmap                                 "},
            { "xpm","image/x-xpixmap                                 "},
            { "xwd","image/x-xwindowdump                             "},
            { "igs","model/iges                                      "},
            { "iges","model/iges                                     "},
            { "msh","model/mesh                                      "},
            { "mesh","model/mesh                                     "},
            { "silo","model/mesh                                     "},
            { "wrl","model/vrml                                      "},
            { "vrml","model/vrml                                     "},
            { "css","text/css                                        "},
            { "html","text/html                                      "},
            { "htm","text/html                                       "},
            { "asc","text/plain                                      "},
            { "txt","text/plain                                      "},
            { "rtx","text/richtext                                   "},
            { "rtf","text/rtf                                        "},
            { "sgml","text/sgml                                      "},
            { "sgm","text/sgml                                       "},
            { "tsv","text/tab-separated-values                       "},
            { "wml","text/vnd.wap.wml                                "},
            { "wmls","text/vnd.wap.wmlscript                         "},
            { "etx","text/x-setext                                   "},
            { "xsl","text/xml                                        "},
            { "xml","text/xml                                        "},
            { "mpeg","video/mpeg                                     "},
            { "mpg","video/mpeg                                      "},
            { "mpe","video/mpeg                                      "},
            { "qt","video/quicktime                                  "},
            { "mov","video/quicktime                                 "},
            { "mxu","video/vnd.mpegurl                               "},
            { "avi","video/x-msvideo                                 "},
            { "movie","video/x-sgi-movie                             "},
            { "ice","x-conference/x-cooltalk                         "},
        };

        /// <summary>
        ///cqgis:  获取某个文件的mime type
        /// </summary> 
        /// <param name="filename"></param>
        /// <param name="defaultMimetype">默认的类型，没有后缀名或不存在的特殊的后缀名</param>
        /// <returns></returns>
        public static string GetMimetype(this string filename, string defaultMimetype = "application/octet-stream")
        {
            var extension = filename.GetFileExtension()?.Trim().ToLower();
            if (extension.IsNullorEmpty()) return defaultMimetype;

            Debug.Assert(extension != null, "extension != null");

            if (extension.StartsWith(".")) extension = extension.Substring(1, extension.Length - 1);

            if (mimetypes.ContainsKey(extension))
                return mimetypes[extension].ToLower().Trim();
            return defaultMimetype;
        }


        /// <summary>
        /// cqgis: 如果文件不存在，抛出异常
        /// </summary>
        /// <param name="filefullpath"></param>
        /// <param name="usefriendlyException"></param>
        public static void ThrowExceptionWhenIsNotExist(this string filefullpath, bool usefriendlyException = false)
        {
            if (File.Exists(filefullpath))
                return;

            if (usefriendlyException)
                throw new FriendlyException("给定的文件不存在");


            throw new FileNotFoundException($"文件{filefullpath}不存在");
        }


        /// <summary>
        /// cqgis: 判断文件是否存在
        /// </summary>
        /// <param name="filefullpath"></param>
        /// <returns></returns>
        public static bool IsExist(this string filefullpath)
        {
            return File.Exists(filefullpath);
        }

        /// <summary>
        /// cqgis: 返回文件的名字包含扩展名
        /// </summary>
        /// <param name="filefullpath"></param>
        /// <returns></returns>
        public static string GetFileName(this string filefullpath)
        {
            return Path.GetFileName(filefullpath);
        }

        /// <summary>
        /// cqgis: 返回文件的名字包含扩展名
        /// </summary>
        /// <param name="filefullpath"></param>
        /// <returns></returns>
        public static string GetFileNameWithOutExtension(this string filefullpath)
        {
            return Path.GetFileNameWithoutExtension(filefullpath);
        }


        /// <summary>
        /// cqgis: 返回文件的扩展名
        /// </summary>
        /// <param name="filefullpath"></param>
        /// <returns></returns>
        public static string GetFileExtension(this string filefullpath)
        {
            return Path.GetExtension(filefullpath);
        }


        /// <summary>
        /// cqgis: 合并路径，并且不允许传入的被合并路径中有绝对路径存在
        /// </summary>
        /// <param name="path"></param>
        /// <param name="paths"></param>
        /// <returns></returns>
        public static string CombineWithOutAbsPath(this string path, params string[] paths)
        {
            if (paths == null || paths.Length == 0)
                return path;


            var allpath = new List<string>() { path };
            allpath.AddRange(paths);

            return CombineWithOutAbsPath(allpath.ToArray());

        }



        /// <summary>
        /// cqgis: 合并路径，除了第一个路径，其它不允许传入的被合并路径中有绝对路径存在
        /// </summary>
        /// <param name="paths"></param>
        /// <returns></returns>
        public static string CombineWithOutAbsPath(params string[] paths)
        {
            if (paths == null || paths.Length == 0)
                return string.Empty;

            for (int i = 1; i < paths.Length; i++)
            {
                var p = paths[i];

                if (p.IsAbsFilePath())
                    throw new FriendlyException($"不支持绝对路径:{p}");

                while (p.StartsWith("\\"))  //处理 \\foldername   情况
                {
                    p = p.Substring(1, p.Length - 1);
                }
                paths[i] = p;
            }


            return Path.Combine(paths);

        }



        /// <summary>
        /// cqgis: 给定的文件路径是否是 绝对路径
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static bool IsAbsFilePath(this string filepath)
        {
            return Path.IsPathRooted(filepath) && !filepath.StartsWith(@"\"); //"\\123\123"这类unc路径，Path.IsPathRooted,因此需加头字符串的判断

        }

    }
}
