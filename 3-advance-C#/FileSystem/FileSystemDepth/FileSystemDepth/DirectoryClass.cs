using System;
using System.IO;

namespace FileSystemDepth
{
    public class DirectoryClass
    {
        public static void RunAllOperations(string path, string newDir)
        {
            // 1. Create a directory
            CreateDirectory(path);

            // 2. Check if directory exists
            CheckDirectoryExists(path);

            // 3. List subdirectories
            ListSubDirectories(path);

            // 4. Rename directory
            RenameDirectory(path, newDir);

            // 5. List files in the renamed directory
            ListFiles(newDir);
        }



        // create directory
        public static void CreateDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                Console.WriteLine("Directory created successfully.");
            }
            else
            {
                Console.WriteLine("Directory already exists.");
            }
        }

        // check directory is exists or not
        public static void CheckDirectoryExists(string path)
        {
            if (Directory.Exists(path))
            {
                Console.WriteLine("Directory already exists.");
            }
            else
            {
                Console.WriteLine("Directory doesn't exist.");
            }
        }
        // list sub directory
        public static void ListSubDirectories(string path)
        {
            if (Directory.Exists(path))
            {
                string[] subDirs = Directory.GetDirectories(path);
                Console.WriteLine("Subdirectories:");
                foreach (var subdir in subDirs)
                {
                    Console.WriteLine(subdir);
                }
            }
            else
            {
                Console.WriteLine("Directory doesn't exist.");
            }
        }
        // rename directory
        public static void RenameDirectory(string oldPath, string newPath)
        {
            if (Directory.Exists(oldPath))
            {
                Directory.Move(oldPath, newPath);
                Console.WriteLine($"Directory renamed to {newPath}");
            }
            else
            {
                Console.WriteLine("Directory does not exist.");
            }
        }

        // list file in directory
        public static void ListFiles(string path)
        {
            if (Directory.Exists(path))
            {
                string[] files = Directory.GetFiles(path);
                Console.WriteLine("Files in directory:");
                foreach (string file in files)
                {
                    Console.WriteLine(file);
                }
            }
            else
            {
                Console.WriteLine("Directory does not exist.");
            }
        }
    }
}
