using Microsoft.EntityFrameworkCore;
using MigrationProduct.Intake;
using MigrationProduct.MySQLMilkoscan;
using System;
using System.Linq;
using System.ServiceProcess;
using System.Threading;

namespace MigrationProduct
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceBase.Run(new LoggingService());
            Log.WriteLine("StartProgram.");
        }
    }
}
