using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TestTask
{
    public static class FileWriter

    {
        static int nameiterator = 0;
        static int stringiterator=0 ;

        public const int maxstringNumber = 3;
        public static void CreateFile(string fileName)
        {
            
            FileInfo fi = new FileInfo(@fileName);
            FileStream fstr = fi.Create();
            fstr.Close();
        }

        public static void DeleteFile(string fileName)
        {
            FileInfo fi = new FileInfo(@fileName);
            fi.Delete();
        }

        public static void SendStringToFile(string str,string fileName)
        {
            
            
            fileName = fileName.Substring(0,fileName.Length-4) + nameiterator.ToString() + ".html";
            FileInfo f = null;
            try
            {
                f = new FileInfo(fileName);
            }
            catch (Exception)
            {

                CreateFile(fileName);
            }
            StreamWriter w = f.AppendText();
            w.WriteLine("<br>"+str+"</br>");
            stringiterator++;
            if (stringiterator == maxstringNumber)
            {
                nameiterator++;
                stringiterator = 0;
            }
            w.Close();
        }

    }
}
