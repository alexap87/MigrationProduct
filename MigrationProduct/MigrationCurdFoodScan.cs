using MigrationProduct.Curd;
using MigrationProduct.MySQLMilkoscan;
using MigrationProduct.MySQLMilkoscan.Create;
using System;
using System.Linq;

namespace MigrationProduct
{
    class MigrationCurdFoodScan : IMigrator
    {
        public void Run()
        {
            try
            {
                using (ConnectionFoodscanCurd foodscandb = new ConnectionFoodscanCurd())
                {
                    using (ConnectionMilkoscan ServerPCdbPredicted = new ConnectionMilkoscan())
                    {
                        Log.WriteLine("fsprediction start of the survey");
                        long PredirectedIDMSSQL = foodscandb.
                            tblMfCdPredictedValue.
                            OrderByDescending(s => s.PredictedValueID).
                            Take(1).
                            ToList()[0].
                            PredictedValueID;
                        long predirectedIDMySQL;
                        if (TestCheck.checkingPresenceColumn<tblMfCdPredictedValueC>(new ConnectionMilkoscan()))
                            predirectedIDMySQL = ServerPCdbPredicted.
                                fsprediction.
                                OrderByDescending(s => s.PredictedValueID).
                                Take(1).ToList()[0].
                                PredictedValueID;
                        else
                            predirectedIDMySQL = 0;
                        if (PredirectedIDMSSQL != predirectedIDMySQL)
                        {
                            ServerPCdbPredicted.fsprediction.AddRange(
                                foodscandb.
                                tblMfCdPredictedValue.
                                Where(p => p.PredictedValueID > predirectedIDMySQL).ToList());
                            ServerPCdbPredicted.SaveChanges();
                            Log.WriteLine("Entry intakedb fsprediction");
                        }
                        else
                        {
                            Log.WriteLine("No entry intakedb fsprediction");
                        }
                    }
                    using (ConnectionMilkoscan ServerPCdbProduct = new ConnectionMilkoscan())
                    {
                        Log.WriteLine("fsproduct start of the survey");
                        long ProductIDMSSQL = foodscandb.
                            tblMfCdProduct.
                            OrderByDescending(p => p.ProductID).
                            Take(1).ToList()[0].
                            ProductID;
                        long productIDMySQL;
                        if (TestCheck.checkingPresenceColumn<tblMfCdProductC>(new ConnectionMilkoscan()))
                            productIDMySQL = ServerPCdbProduct.
                            fsproduct.
                            OrderByDescending(p => p.ProductID).
                            Take(1).
                            ToList()[0].
                            ProductID;
                        else
                            productIDMySQL = 0;
                        if (ProductIDMSSQL != productIDMySQL)
                        {
                            ServerPCdbProduct.fsproduct.AddRange(
                                foodscandb.
                                tblMfCdProduct.
                                Where(p => p.ProductID > productIDMySQL).ToList());
                            ServerPCdbProduct.SaveChanges();
                            Log.WriteLine("Entry intakedb fsproduct");
                        }
                        else
                        {
                            Log.WriteLine("No entry intakedb fsproduct");
                        }
                    }
                    using (ConnectionMilkoscan ServerPCdbSample = new ConnectionMilkoscan())
                    {
                        Log.WriteLine("fssample start of the survey");
                        long SampleIDMSSQL = foodscandb.
                            tblMfCdSample.
                            OrderByDescending(s => s.SampleID).
                            Take(1).
                            ToList()[0].
                            SampleID;
                        long sampleIDMySQL;
                        if (TestCheck.checkingPresenceColumn<tblMfCdSampleC>(new ConnectionMilkoscan()))
                            sampleIDMySQL = ServerPCdbSample.
                            fssample.
                            OrderByDescending(s => s.SampleID).
                            Take(1).
                            ToList()[0].
                            SampleID;
                        else
                            sampleIDMySQL = 0;
                        if (sampleIDMySQL != SampleIDMSSQL)
                        {
                            ServerPCdbSample.fssample.AddRange(
                                foodscandb.
                                tblMfCdSample.
                                Where(s => s.SampleID > sampleIDMySQL).
                                ToList());
                            ServerPCdbSample.SaveChanges();
                            Log.WriteLine("Entry intakedb fssample");
                        }
                        else
                        {
                            Log.WriteLine("No entry intakedb fssample");
                        }
                    }
                    using (ConnectionMilkoscan ServerPCdbSubSample = new ConnectionMilkoscan())
                    {
                        Log.WriteLine("fssubsample start of the survey");
                        long SubSampleIDMSSQL = foodscandb.
                            tblMfCdSubSample.
                            OrderByDescending(s => s.SubSampleID).
                            Take(1).
                            ToList()[0].
                            SubSampleID;
                        long subSampleIDMySQL;
                        if (TestCheck.checkingPresenceColumn<tblMfCdSubSampleC>(new ConnectionMilkoscan()))
                            subSampleIDMySQL = ServerPCdbSubSample.
                            fssubsample.
                            OrderByDescending(s => s.SubSampleID).
                            Take(1).
                            ToList()[0].
                            SubSampleID;
                        else
                            subSampleIDMySQL = 0;
                        if (subSampleIDMySQL != SubSampleIDMSSQL)
                        {
                            ServerPCdbSubSample.fssubsample.AddRange(
                                foodscandb.
                                tblMfCdSubSample.
                                Where(s => s.SubSampleID > subSampleIDMySQL).
                                ToList());
                            ServerPCdbSubSample.SaveChanges();
                            Log.WriteLine("Entry intakedb fsSubSample");
                        }
                        else
                        {
                            Log.WriteLine("No entry intakedb fsSubSample");
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
