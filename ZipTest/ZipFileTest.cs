using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;
using System.IO;

namespace ZipTest
{
    public class ZipFileTest
    {
        public bool ExtractZipFile(string path, string password, string outFolder)
        {
            ZipFile zf = null;
            try
            {
                FileStream fs = File.OpenRead(path);
                zf = new ZipFile(fs);
                zf.Password = password;
                foreach (ZipEntry item in zf)
                {
                    if (!item.IsFile)
                    {
                        continue;
                    }
                    String entryFileName = item.Name;
                    byte[] buffer = new byte[4096];
                    Stream zipStream = zf.GetInputStream(item);
                    String fullZipToPath = Path.Combine(outFolder, entryFileName);
                    string directoryName = Path.GetDirectoryName(fullZipToPath);
                    if (directoryName.Length > 0)
                        Directory.CreateDirectory(directoryName);

                    using (FileStream streamWriter = File.Create(fullZipToPath))
                    {
                        StreamUtils.Copy(zipStream, streamWriter, buffer);
                    }
                }
                return true;
            }
            catch (Exception error)
            {
                return false;
            }
            finally{
                if (zf != null)
                {
                    zf.IsStreamOwner = true; // Makes close also shut the underlying stream
                    zf.Close(); // Ensure we release resources
                }
            }
        }
    }
}
