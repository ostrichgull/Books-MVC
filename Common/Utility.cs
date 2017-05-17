using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace Books.Common
{
    public class Utility
    {
        public static byte[] GetImage(HttpPostedFileBase image)
        {
            string fileName;
            byte[] bytes;
            int bytesToRead;
            int numBytesRead;

            fileName = Path.GetFileName(image.FileName);
            bytes = new byte[image.ContentLength];

            bytesToRead = (int)image.ContentLength;
            numBytesRead = 0;

            while (bytesToRead > 0)
            {
                int n = image.InputStream.Read(bytes, numBytesRead, bytesToRead);

                if (n == 0) break;

                numBytesRead += n;

                bytesToRead -= n;
            }

            return bytes;
        }
    }
}