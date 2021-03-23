using Microsoft.EntityFrameworkCore;
using System;

namespace MigrationProduct.MySQLMilkoscan.Create
{
    public class CreaterTables
    {
        public void create()
        {
            try
            {
                var milkoscan = new ConnectionMilkoscan();
                milkoscan.Database.ExecuteSqlInterpolated($"TRUNCATE TABLE __efmigrationshistory");
                milkoscan.Database.Migrate();
            }
            catch(Exception e)
            {
                Log.WriteLine(e.Message);
            }
        }
    }
}
