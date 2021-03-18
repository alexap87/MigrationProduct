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
                    using (ConnectionMilkoscan ServerPCdbSample = new ConnectionMilkoscan())
                    {
                        Log.WriteLine("sample start of the survey");
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
                        }
                        else
                        sampleIDMySQL = 0;
                        if (sampleIDMySQL != SampleIDMSSQL)
                        {
                            Log.WriteLine("Entry intakedb sample");
                            ServerPCdbSample.sample.AddRange(Intakedb.Sample.Where(s => s.SampNo > sampleIDMySQL).ToList());
                            ServerPCdbSample.SaveChanges();
                            ServerPCdbSample.Database.ExecuteSqlInterpolated($"DELETE FROM prediction WHERE SampRef >= {sampleIDMySQL}");
                            ServerPCdbSample.prediction.AddRange(Intakedb.Prediction.Where(p => p.SampRef >= sampleIDMySQL).ToList());
                            ServerPCdbSample.SaveChanges();
                        }
                        else
                        {
                            Log.WriteLine("No entry intakedb sample");
                        }
                    }
                    using (ConnectionMilkoscan ServerPCdbProduct = new ConnectionMilkoscan())
                    {
                        Log.WriteLine("product start of the survey");
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
                        }
                        else
                            prodNoMySQL = 0;
                        if (prodNoMySQL != ProdNoMSSQL)
                        {
                            ServerPCdbProduct.product.AddRange(Intakedb.Product.Where(p => p.ProdNo > prodNoMySQL).ToList());
                            ServerPCdbProduct.SaveChanges();
                            Log.WriteLine("Entry intakedb product");
                        }
                        else 
                        {
                            Log.WriteLine("No entry intakedb product");
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
