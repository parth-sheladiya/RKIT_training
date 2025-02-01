using System;
using System.IO;

public static class FileInfoManager
{
    // Method to display file info
    public static void DisplayFileInfo(string filePath)
    {
        try
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found.");
                return;
            }

            var fileInfo = new FileInfo(filePath);
            Console.WriteLine("File Info:");
            Console.WriteLine($"File Name: {fileInfo.Name}");
            Console.WriteLine($"Extension: {fileInfo.Extension}");
            Console.WriteLine($"Size: {fileInfo.Length} bytes");
            Console.WriteLine($"Last Access Time: {fileInfo.LastAccessTime}");
            Console.WriteLine($"Creation Time: {fileInfo.CreationTime}");
            Console.WriteLine($"Last Write Time: {fileInfo.LastWriteTime}");
            Console.WriteLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error displaying file info: {ex.Message}");
        }
    }
}
