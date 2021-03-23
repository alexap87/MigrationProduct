using Microsoft.EntityFrameworkCore;
using MigrationProduct.Bottling;
using MigrationProduct.MySQLMilkoscan;
using MigrationProduct.MySQLMilkoscan.Create;
using System;
using System.Linq;

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
                            //serverbd.Database.ExecuteSqlInterpolated($"DELETE FROM textcomponent WHERE SampleIndex >= {sampleIndexMySQL}");

                            serverbd.result.AddRange(
                                bottlingdb.
                                Results.
                                Where(d => d.SampleIndex > sampleIndexMySQL).
                                ToList());

                            serverbd.textcomponent.AddRange(
                                bottlingdb.
                                TextComponents.
                                Include(p => p.Results).
                                Where(d => d.SampleIndex > sampleIndexMySQL).
                                ToList());

                            serverbd.doublecomponent.AddRange(
                                bottlingdb.
                                DoubleComponents.
                                Include(p => p.Results).
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
            catch (Exception e)
            {
                Log.WriteLine(e.Message);
                new CreaterTables().create();
            }
        }
    }
}
