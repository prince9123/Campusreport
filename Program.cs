using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace campusReport_1
{
    public class Program
    {
        static void Main()
        {
            string workingDirectory = @"C:\Users\PRINCE\Desktop\campusreport";
            //Console.Read();
            string fileName = " ";

            string[] filePaths = Directory.GetFiles(workingDirectory);
            //Console.WriteLine(filePaths);

            for (int i = 0; i < filePaths.Length; i++)
            {
                XmlTextReader res = new XmlTextReader(filePaths[i]);
                while (res.Read())
                {
                    if (res.Name == "DataSet" && res.IsStartElement())
                    {
                        fileName = res.GetAttribute("Name");
                        Console.WriteLine(fileName);
                    }
                    if (res.Name == "CommandText")
                    {
                        // Folder, where a file is created.  
                        // Make sure to change this folder to your own folder  
                        string folder = @"C:\Users\PRINCE\Desktop\Output\";
                        folder += fileName +".txt";

                       //Console.WriteLine(res.ReadString());
                        /*using StreamWriter sw = new StreamWriter(@"C:\Users\PRINCE\Desktop\Output\OutputFile.txt");
                        sw.WriteLine(res.Value); ;*/
                        using (FileStream fs = new FileStream(folder, FileMode.Append, FileAccess.Write))
                        using (StreamWriter sw = new StreamWriter(fs))
                        {
                            sw.WriteLine(res.ReadString());
                        }
                    }
                }
            }
        }
    }
}
// Write array of strings to a file using WriteAllLines.  
// If the file does not exists, it will create a new file.  
// This method automatically opens the file, writes to it, and closes file  
//File.WriteAllLines(folder, authors);
//Console.WriteLine(authors);