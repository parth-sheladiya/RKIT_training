using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace FileSystemDepth
{
    ////normally 1 char has occupy 2 byte 
    ///
    /// <summary>
    /// it is use to handle a binary data 
    /// file mode 
    /// file access
    /// file size
    /// example for image,music,video, raw data
    /// 
    /// </summary>
    public class FileStreamClass
    {
        // main method for FileStreamClass
        public static void RunFileStreamClass()
        {
            // call method for LearnFileStreamClass
            LearnFileStreamClass();
        }
        public static void LearnFileStreamClass()
        {
            // create file
            string filePath = "test.txt";

            // data write in file
            byte[] data = Encoding.UTF8.GetBytes("hello stream rtbhpoiearw ie rejpioare p;iojfrgbaer pjofbae piojbfa piofba");

            // use using 3 parameter 
            // path
            // mode : create
            // access : write
            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                fs.Write(data, 0, data.Length);
                // it is optional
                // using flush keyword
                //fs.Flush();

                // message 
                Console.WriteLine("data can write in text file");
            }
                
            // data read in text file
            // 3 parameter 
            // path 
            // mode : open
            // access : read
            using(FileStream fs = new FileStream(filePath , FileMode.Open ,FileAccess.Read ))
            {
                // create array 
                byte[] buffer = new byte[8];
                // read data
                int bytesRead = fs.Read(buffer, 0, buffer.Length);
                // convert to string
                string fileContent = Encoding.UTF8.GetString(buffer,0,bytesRead);
                // success message
                Console.WriteLine("data read successfully");
                // file size 
                Console.WriteLine($"File ka size: {fs.Length} bytes");
                // file content
                Console.WriteLine($"filecontent: {fileContent}");
                Console.WriteLine($"File current position: {fs.Position}");


            }

        }
    }
}
