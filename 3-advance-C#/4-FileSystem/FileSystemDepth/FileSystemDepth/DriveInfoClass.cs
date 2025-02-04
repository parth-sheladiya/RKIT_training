using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileSystemDepth
{
    /// <summary>
    /// drive info class
    /// </summary>
    public class DriveInfoClass
    {
        public static void RunAllDriveInfoClass()
        {
            LearnDriveInfoClass();
        }

        /// <summary>
        /// all drive related information 
        /// </summary>
        public static void LearnDriveInfoClass()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach(DriveInfo drive in drives)
            {
                Console.WriteLine($"drive name is : {drive.Name} "  );
                Console.WriteLine($"drive type is : {drive.DriveType}");

                if(drive.IsReady)
                {
                    
                    Console.WriteLine($"Volume Label: {drive.VolumeLabel}");
                    Console.WriteLine($"Available Free Space: {drive.AvailableFreeSpace / (1024 * 1024)} MB");
                    Console.WriteLine($"Total Size: {drive.TotalSize / (1024 * 1024)} MB");
                    Console.WriteLine($"Root Directory: {drive.RootDirectory}");
                }
                else
                {
                    Console.WriteLine("Drive is not ready");
                }
            }
        }
    }
}
