using System;
using System.IO;

namespace Basic_C_Sharp
{
    public class FileOperationsDemo
    {
        public static void RunFileOperationsDemo()
        {
            string sourceFilePath = "source.txt";
            string copyFilePath = "copy_of_source.txt";
            string moveFilePath = "moved_source.txt";
            string directoryPath = "newDirectory";

            try
            {
                // Example 1: Writing content to a source file
                string content = "This is the source file content.";
                File.WriteAllText(sourceFilePath, content);
                Console.WriteLine("Content written to source file.");

                // Example 2: Copying the file
                File.Copy(sourceFilePath, copyFilePath, true); // true to overwrite if file exists
                Console.WriteLine("File copied to: " + copyFilePath);

                // Example 3: Moving the file
                File.Move(sourceFilePath, moveFilePath);
                Console.WriteLine("File moved to: " + moveFilePath);

                // Example 4: Creating a new directory
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                    Console.WriteLine("Directory created: " + directoryPath);
                }

                // Example 5: Moving a file into the new directory
                string movedFileInDirectory = Path.Combine(directoryPath, "moved_in_directory.txt");
                File.Move(moveFilePath, movedFileInDirectory);
                Console.WriteLine("File moved to directory: " + movedFileInDirectory);
            }
            catch (UnauthorizedAccessException ex)
            {
                // Handle exception for unauthorized access
                Console.WriteLine("Error: Unauthorized access to the file or directory.");
                Console.WriteLine(ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                // Handle exception when file is not found
                Console.WriteLine("Error: The file could not be found.");
                Console.WriteLine(ex.Message);
            }
            catch (DirectoryNotFoundException ex)
            {
                // Handle exception when directory is not found
                Console.WriteLine("Error: The directory could not be found.");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                // Handle any other unexpected exceptions
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
