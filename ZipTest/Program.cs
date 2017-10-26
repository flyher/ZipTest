using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICSharpCode.SharpZipLib.BZip2;
using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Encryption;
using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.LZW;
using ICSharpCode.SharpZipLib.Tar;

using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;

using System.IO;

namespace ZipTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // BAG
            string[] part1 = new string[] { "", "te","TE","#"};
            string[] part2 = new string[] { "", "st","ST","99"};
            string[] part3 = new string[] { "", "123", "321", "2981", "3122","#"};
            string[] part4 = new string[] { "", "#"};
            ZipFileTest zft = new ZipFileTest();
            RarFileTest rft = new RarFileTest();
            string basepwd = "";

            //rft.ExtractRar(@"1.zip", "111", "test");
            //rft.ExtractRAR(@"1.zip", "111", "test");
            //FileStream fs = new FileStream(@"test.rar", FileMode.Open);
            //byte[] bytes = new byte[fs.Length];
            //fs.Read(bytes, 0, bytes.Length);
            //fs.Close();
            //Stream stream = new MemoryStream(bytes);

            for (int i = 0; i < part1.Length; i++)
            {
                for (int j = 0; j < part2.Length; j++)
                {
                    for (int l = 0; l < part3.Length; l++)
                    {
                        for (int m = 0; m < part4.Length; m++)
                        {
                            string pwd = part1[i] + part2[j] + part3[l] + part4[m];
                            if (pwd.Length <= 0)
                            {
                                continue;
                            }
                            //if(zft.ExtractZipFile(@"test.zip", pwd, "test"))
                            //if (rft.ExtractRAR(@"1.rar", pwd, "test"))
                            //if (rft.CheckRAR(stream, pwd))
                            if (rft.CheckRARByPath(@"test.zip", pwd))
                            {
                                basepwd = pwd;
                                Console.WriteLine("right:" + pwd);
                                break;
                            }
                            else
                            {
                                basepwd = "null";
                                Console.WriteLine(pwd);
                            }
                        }
                    }
                }

            }

            Console.WriteLine("done");
            Console.ReadLine();
        }
    }
}
