using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SevenZip;
using System.IO;

namespace ZipTest
{
    public class RarFileTest
    {
        public bool ExtractRAR(string path, string password, string destination)
        {
            //SevenZipCompressor.SetLibraryPath(@"C:\Program Files\7-Zip\7z.dll");
            // 指定7z动态库文件路径，默认是"7z.dll"  
            SevenZipBase.SetLibraryPath(@"7z.dll");

            using (SevenZipExtractor extractor = new SevenZipExtractor(path, password))
            {
                if (extractor.Check())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            //var extractor = new SevenZipExtractor(path,password);
            //try
            //{
            //    //extractor.Extracting += (sender, eventArgs) =>
            //    //{
            //    //    Console.WriteLine("OnExtracting");
            //    //};
            //    //Console.WriteLine("测试密码:" + password);
            //    //Console.Write(extractor.FilesCount + "|" + extractor.PackedSize);
            //    // 文件数量（文件夹也算）  
            //    //Console.WriteLine(extractor.FilesCount);
            //    // 压缩包字节数  
            //    //Console.WriteLine(extractor.PackedSize);
            //    // 压缩文件属性  
            //    //foreach (var fileProp in extractor.ArchiveProperties)
            //    //{
            //    //    Console.Write(fileProp.ToString());
            //    //}
            //    //// 遍历文件名  
            //    //foreach (var fileName in extractor.ArchiveFileNames)
            //    //{
            //    //    Console.Write(fileName);
            //    //}
            //    //// 遍历文件数据  
            //    //foreach (var fileData in extractor.ArchiveFileData)
            //    //{
            //    //    Console.Write(fileData.ToString());
            //    //}

            //    // 是否使用的固实压缩  
            //    //Console.WriteLine(extractor.IsSolid);
            //    // 解压后的大小  
            //    //Console.WriteLine(extractor.UnpackedSize);


            //    //extractor.ExtractArchive(destination);
            //    return true;
            //}
            //catch(Exception err)
            //{
            //    return false;
            //}

        }

        /// <summary>
        /// check zip or rar password by stream
        /// </summary>
        /// <param name="stream">the zip/rar file stream</param>
        /// <param name="password">password for this file</param>
        /// <returns></returns>
        public bool CheckRARByStream(Stream stream, string password)
        {
            // 指定7z动态库文件路径，默认是"7z.dll"  
            SevenZipBase.SetLibraryPath(@"7z.dll");


            using (SevenZipExtractor extractor = new SevenZipExtractor(stream, password))
            {
                if (extractor.Check())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// check zip or rar password by file path
        /// </summary>
        /// <param name="path"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool CheckRARByPath(string path, string password)
        {
            SevenZipBase.SetLibraryPath(@"7z.dll");
            using (SevenZipExtractor extractor = new SevenZipExtractor(path, password))
            {
                if (extractor.Check())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
