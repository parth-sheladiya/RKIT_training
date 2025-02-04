using System;

namespace FileSystemDepth
{
    class Program
    {
        public static void Main(string[] args)
        {
            string path = @"F:\parth-415\RKIT_training-main\3-advance-C#\SampleDiractoryExampleTesting";
            string newDir = @"F:\parth-415\RKIT_training-main\3-advance-C#\NewSampleDiractoryExampleTesting";

            #region directory class
             // DirectoryClass.RunAllOperations(path, newDir);
            #endregion

            #region drive info class
            DriveInfoClass.RunAllDriveInfoClass();
            #endregion

            #region file stream class
           // FileStreamClass.RunFileStreamClass();
            #endregion
        }
    }
}
