using Microsoft.EntityFrameworkCore;
using MigrationProduct.Intake;
using MigrationProduct.MySQLMilkoscan;
using System;
using System.Linq;
using System.Threading;

namespace MigrationProduct
{
    class Program
    {
        static void Main(string[] args)
        {
            StartMigration start = new StartMigration();
            /*Thread loggerThread = new Thread(new ThreadStart(start.started));
            loggerThread.Start();*/
            start.started();
            var pressed = Console.ReadKey();
            if (pressed.Key == ConsoleKey.F10)
                start.stoped();
        }
    }
}
