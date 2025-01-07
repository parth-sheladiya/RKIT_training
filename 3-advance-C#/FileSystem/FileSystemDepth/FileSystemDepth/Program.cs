
using System;
using System.IO;
namespace FileSystemDepth
{
    class Program
    {
        public static void Main(string[] args)
        {
            // path for diractory
            string path = @"F:\parth-415\RKIT_training-main\3-advance-C#\SampleDiractoryExampleTesting";

            // 1. create directory
            #region create directory
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                Console.WriteLine("directory created sucessfully");

            }
            else
            {
                Console.WriteLine("directory already exists");
            }
            #endregion

            // 2. directory is exist or not check
            if (Directory.Exists(path))
            {
                Console.WriteLine("directory is already exists");
            }
            else
            {
                Console.WriteLine("directory does't exists");
            }

            // 3 list of files in directory 
            if (Directory.Exists(path))
            {
                string[] subDirs = Directory.GetDirectories(path);
                foreach (var subdir in subDirs)
                {
                    Console.WriteLine(subdir + " " + path);
                }
            }
            else
            {
                Console.WriteLine("directory doesn't exists");
            }
            string newDir = @"F:\parth-415\RKIT_training-main\3-advance-C#\NewSampleDiractoryExampleTesting";
            // 4 rename directory path
            if (Directory.Exists(path))
            {
                
                Directory.Move(path, newDir);
                Console.WriteLine($"Directory renamed to {newDir}");
            }
            else
            {
                Console.WriteLine("directory not exists");
            }

            // this is commented because they will be delete at a runtime.
            // 5 delete directory 
            //if(Directory.Exists (newDir))
            //{
            //    Directory.Delete(newDir);
            //}
            //else
            //{
            //    Console.WriteLine("directory not exists");
            //}

            // 6 . list file in directory 
            if(Directory.Exists(newDir))
            {
                string[] files = Directory.GetFiles(newDir);

                Console.WriteLine("Files in directory:");
                
                foreach (string file in files)
                {
                    Console.WriteLine(file);
                }
            }
        }
    }
}