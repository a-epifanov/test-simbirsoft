using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace TestTask
{
    class Program
    {
        
        static void Main(string[] args)
        {

            DirectoryInfo dirInfo = new DirectoryInfo(Environment.CurrentDirectory.ToString());
            foreach (FileInfo file in dirInfo.GetFiles("*.html")) 
            {
             
                file.Delete(); // очищаем имеющиеся файлы html в директории
            }
            List<string> dictionary = FileReader.LoadDictionary();
            Console.WriteLine("Processing...");         
            FileReader.ProcessText();
            Console.ReadKey();
        }
    }
}
