using Microsoft.EntityFrameworkCore;
using MigrationProduct.Intake;
using MigrationProduct.MySQLMilkoscan;
using MigrationProduct.MySQLMilkoscan.Create;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MigrationProduct
{
    class MigratorIntakeMilkoscan: IMigrator
    {
        public void Run()
        {
            try
            {
                using (ConnectMilkoscanIntake Intakedb = new ConnectMilkoscanIntake())
                {
                    Console.WriteLine($"{new ConnectMilkoscanIntake().Prediction.Count()}");
                    using (ConnectionMilkoscan ServerPCdbSample = new ConnectionMilkoscan())
                    {
                        Console.WriteLine("Test connect");

                        int sampleIDMySQL;
                        int SampleIDMSSQL = Intakedb.Sample.OrderByDescending(s => s.SampNo).Take(1).ToList()[0].SampNo;
                        if(TestCheck.checkingPresenceColumn<SampleC>(new ConnectionMilkoscan()))
                        {
                            sampleIDMySQL = 
                                ServerPCdbSample.
                                sample.
                                OrderByDescending(s => s.SampNo).
                                Take(1).
                                ToList()[0].
                                SampNo;
                            Console.WriteLine("met1");
                        }
                        else
                        sampleIDMySQL = 0;
                        Console.WriteLine($"{sampleIDMySQL} \t\n {SampleIDMSSQL}");
                        if (sampleIDMySQL != SampleIDMSSQL)
                        {
                            Console.WriteLine("met2");
                            
                            Console.WriteLine(sampleIDMySQL.ToString());
                            Console.WriteLine(SampleIDMSSQL.ToString());
                            ServerPCdbSample.sample.AddRange(Intakedb.Sample.Where(s => s.SampNo > sampleIDMySQL).ToList());
                            ServerPCdbSample.SaveChanges();
                            ServerPCdbSample.Database.ExecuteSqlInterpolated($"DELETE FROM prediction WHERE SampRef >= {sampleIDMySQL}");
                            ServerPCdbSample.prediction.AddRange(Intakedb.Prediction.Where(p => p.SampRef >= sampleIDMySQL).ToList());
                            ServerPCdbSample.SaveChanges();
                            Console.WriteLine("Query done");
                        }
                        else
                        {
                            Console.WriteLine("No entry");
                        }
                    }
                    using (ConnectionMilkoscan ServerPCdbProduct = new ConnectionMilkoscan())
                    {
                        Console.WriteLine("Test connect");

                        int prodNoMySQL;
                        int ProdNoMSSQL = Intakedb.Product.OrderByDescending(p => p.ProdNo).Take(1).ToList()[0].ProdNo;
                        if (TestCheck.checkingPresenceColumn<ProductC>(new ConnectionMilkoscan()))
                        {
                            prodNoMySQL = 
                                ServerPCdbProduct.
                                product.
                                OrderByDescending(p => p.ProdNo).
                                Take(1).
                                ToList()[0].
                                ProdNo;
                            Console.WriteLine("met3");
                        }
                        else
                            prodNoMySQL = 0;
                        Console.WriteLine($"{prodNoMySQL} \t\n {ProdNoMSSQL}");
                        if (prodNoMySQL != ProdNoMSSQL)
                        {
                            Console.WriteLine("met4");
                            ServerPCdbProduct.product.AddRange(Intakedb.Product.Where(p => p.ProdNo > prodNoMySQL).ToList());
                            ServerPCdbProduct.SaveChanges();
                            Console.WriteLine("Writing");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                new CreaterTables().create();
                Console.WriteLine("Done");
            }
        }
    }
}
