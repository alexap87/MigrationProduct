using MigrationProduct.MySQLMilkoscan;
using System;
using System.Linq;

namespace MigrationProduct
{
    internal static class TestCheck
    {
        public static bool CheckTableExists<T>(this ConnectionMilkoscan db) where T: class
        {
            try
            {
                Console.WriteLine(db.Set<T>().Take(1000).Count());
                Console.WriteLine("yes");
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("no");
                return false;
            }
        }
        public static bool checkingPresenceColumn<T>(this ConnectionMilkoscan db) where T : class
        {
            if (db.Set<T>().Take(1000).Count() > 0)
                return true;
            else
                return false;
        }
    }
}
