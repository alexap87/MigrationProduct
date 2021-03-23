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
                Log.WriteLine("Exists");
                return true;
            }
            catch (Exception)
            {
                Log.WriteLine("No exists");
                return false;
            }
        }
        public static bool checkingPresenceColumn<T>(this ConnectionMilkoscan db) where T : class
        {
            try
            {
                if (db.Set<T>().Take(1000).Count() > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
