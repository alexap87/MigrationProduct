using System;
using System.IO;

namespace MigrationProduct
{
    public static class Log
    {
        public static void WriteLine(string message)
        {
            /*string path = @"c:\\MigrationMSSQL\log_migration";
            if (!File.Exists(path))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path));
            }
            File.AppendAllText(path, $"{DateTime.Now.ToString()} : {message} {Environment.NewLine}");*/
            Console.WriteLine($"{DateTime.Now.ToString()} : {message} {Environment.NewLine}");
        }
    }
}
