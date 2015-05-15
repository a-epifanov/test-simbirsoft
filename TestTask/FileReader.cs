using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TestTask
{
    public static class FileReader
    {
        
        static List<string> dictionary = new List<string>();
        public static List<string> LoadDictionary() //Загрузка словаря в коллекцию
        {

            
            StreamReader file = null;
            Console.WriteLine("Reading the contents from the dictionary");
            try
            {
               file = new StreamReader("dictionary.txt", Encoding.GetEncoding(1251)); 
               string read = null;
               while ((read = file.ReadLine()) != null)
               {
                   dictionary.Add(read);
                   
               }
               
            }

            catch (FileNotFoundException)
            {
                Console.WriteLine("File doesn't exist");
            }
            finally
            {
                Console.WriteLine("Dictionary processed");
                if (file != null)
                {
                    file.Close();
                }
            }
            return dictionary;
        }


        public static void ProcessText()
        {
           
            StreamReader file = null;
            Console.WriteLine("Reading the contents from the file");
            try
            {
                file = new StreamReader("text.txt", Encoding.GetEncoding(1251));
                string read = null;
                while ((read = file.ReadLine()) != null)
                {

                    foreach (string s in dictionary)
                    {
                       if (read.Contains(s))
                        {
                            read =read.Insert(read.IndexOf(s) + s.Length, "</b></i>");
                            read = read.Insert(read.IndexOf(s), "<b><i>");
                          
                        }
                    }
                    Console.WriteLine(read);
                    FileWriter.SendStringToFile(read, "result.html");
                }

             

            }

            catch (FileNotFoundException)
            {
                Console.WriteLine("File doesn't exist");
            }
            finally
            {
                Console.WriteLine("text processed");
                if (file != null)
                {
                    file.Close();
                }
            }
        }
    }
}
