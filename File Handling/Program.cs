using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;//File handling purpose
namespace File_Handling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "newdemo.txt";
            using (FileStream fs = File.Create(filePath))
            {
                // File created successfully
                if (File.Exists(filePath))
                {
                    Console.WriteLine("File created successfully: " + filePath);
                }
                // File creation failed
                else
                {
                    Console.WriteLine("File creation failed.");
                }
            }
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.WriteLine("Hello, this is a demo file created today.");
                sw.WriteLine("This file is created to demonstrate file handling in C#.");
            }
            using (StreamReader sr = new StreamReader(filePath))
            {
                string content = sr.ReadToEnd();
                Console.WriteLine("File Content:");
                Console.WriteLine(content);
            }
            File.Delete(filePath);
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File deleted successfully: " + filePath);
            }
            else
            {
                Console.WriteLine("File deletion failed.");
            }
        }
    }
    //in C# we have following types of file handling classes:
    //1. StreamReader and StreamWriter: These classes are used for reading and writing text files.
    //2. BinaryReader and BinaryWriter: These classes are used for reading and writing binary files.
    //3. FileStream: This class is used for reading and writing files as a stream of bytes. example: FileStream fs = new FileStream("file.txt", FileMode.OpenOrCreate);
    //4. File: This class provides static methods for creating, copying, deleting, moving, and opening files, and helps in the creation of FileStream objects.
    //5. Directory: This class provides static methods for creating, moving, and enumerating through directories and subdirectories.
    //6. Path: This class provides methods for working with file and directory path strings.
    //These classes provide a comprehensive set of tools for file handling in C#.


    //below are the types of modes while working with files in C#:
    //read: Opens the file for reading only. An exception is thrown if the file does not exist.
    //write: Opens the file for writing only. If the file exists, it is overwritten. If the file does not exist, a new file is created.
    //append: Opens the file for writing only. If the file exists, the write operation appends data to the end of the file. If the file does not exist, a new file is created.
    //open: Opens the file if it exists. An exception is thrown if the file does not exist.
    //openorcreate: Opens the file if it exists; otherwise, a new file is created.
    //truncate: Opens the file for writing only and truncates the file to zero bytes. An exception is thrown if the file does not exist.
    //These modes are specified using the FileMode enumeration when creating a FileStream object.
}

