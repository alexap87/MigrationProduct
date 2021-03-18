using System;
using MigrationProduct.MySQLMilkoscan;
using MigrationProduct.Bottling;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MigrationProduct.MySQLMilkoscan.Create;

namespace MigrationProduct
{
    class MigratorBottlingMilkoscan : IMigrator
    {
        public void Run()
        {
            try
            {
                using (ConnectionMilkoscanBottling bottlingdb = new ConnectionMilkoscanBottling())
                {
                    using (ConnectionMilkoscan serverbd = new ConnectionMilkoscan())
                    {
                        Log.WriteLine("doublecomponents start of the survey");
                        int SampleIndexMSSQL = bottlingdb.
                            DoubleComponents.
                            OrderByDescending(d => d.SampleIndex).
                            ToList()[0].
                            SampleIndex;
                        int sampleIndexMySQL;
                        if (TestCheck.checkingPresenceColumn<DoubleComponentsC>(new ConnectionMilkoscan()))
                        {
                            sampleIndexMySQL = serverbd.
                            doublecomponent.
                            OrderByDescending(d => d.SampleIndex).
                            ToList()[0].
                            SampleIndex;
                        }
                        else
                            sampleIndexMySQL = 0;
                        if (sampleIndexMySQL != SampleIndexMSSQL)
                        {
                            serverbd.Database.ExecuteSqlInterpolated($"DELETE FROM doublecomponent WHERE SampleIndex >= {sampleIndexMySQL}");
                            serverbd.doublecomponent.AddRange(
                                bottlingdb.
                                DoubleComponents.
                                Where(d => d.SampleIndex > sampleIndexMySQL).
                                ToList());
                            serverbd.SaveChanges();
                            Log.WriteLine("Entry intakedb doublecomponents");
                        }
                        else
                        {
                            Log.WriteLine("No entry intakedb doublecomponents");
                        }
                    }
                    using (ConnectionMilkoscan serverbd = new ConnectionMilkoscan())
                    {
                        Log.WriteLine("textcomponents start of the survey");
                        int SampleIndexMSSQL = bottlingdb.
                            TextComponents.
                            OrderByDescending(d => d.SampleIndex).
                            ToList()[0].
                            SampleIndex;
                        int sampleIndexMySQL;
                        if (TestCheck.checkingPresenceColumn<TextComponentsC>(new ConnectionMilkoscan()))
                        {
                            sampleIndexMySQL = serverbd.
                            textcomponent.
                            OrderByDescending(d => d.SampleIndex).
                            ToList()[0].
                            SampleIndex;

                        }
                        else
                            sampleIndexMySQL = 0;
                        
                        if (sampleIndexMySQL != SampleIndexMSSQL)
                        {
                            serverbd.Database.ExecuteSqlInterpolated($"DELETE FROM textcomponent WHERE SampleIndex >= {sampleIndexMySQL}");
                            serverbd.textcomponent.AddRange(
                                bottlingdb.
                                TextComponents.
                                Where(d => d.SampleIndex > sampleIndexMySQL).
                                ToList());
                            serverbd.SaveChanges();
                            Log.WriteLine("Entry intakedb textcomponents");
                        }
                        else
                        {
                            Log.WriteLine("No entry intakedb textcomponents");
                        }
                    }
                }
            }
            catch(Exception e)
            {
                Log.WriteLine(e.Message);
                new CreaterTables().create();
            }
        }
    }
}
