using MigrationProduct.Bottling;
using MigrationProduct.Curd;
using MigrationProduct.Intake;
using System;
using System.Linq;
using System.Threading;

namespace MigrationProduct
{
    public class StartMigration
    {
        int CountBottling;
        int CountIntake;
        int CountCurd;
        bool enabled = true;
        public void started()
        {
            Thread bottling = new Thread(new ThreadStart(() =>
            {
                while (enabled)
                {
                    try
                    {
                        //Log.WriteLine("runable bottling");
                        if (new ConnectionMilkoscanBottling().DoubleComponents.Count() != CountBottling)
                        {
                            new MigratorBottlingMilkoscan().Run();
                            CountBottling = new ConnectionMilkoscanBottling().DoubleComponents.Count();
                        }
                    }
                    catch (Exception e)
                    {
                        Log.WriteLine($"Error migration: {e.Message}");
                    }
                    Thread.Sleep(5000);
                }
            }));
            Thread curd = new Thread(new ThreadStart(() =>
            {
                while (enabled)
                {
                    try
                    {
                        //Log.WriteLine("runable curd");
                        if (new ConnectionFoodscanCurd().tblMfCdPredictedValue.Count() != CountCurd)
                        {
                            new MigrationCurdFoodScan().Run();
                            CountCurd = new ConnectionFoodscanCurd().tblMfCdPredictedValue.Count();
                        }
                    }
                    catch (Exception e)
                    {
                        Log.WriteLine($"Error migration: {e.Message}");
                    }
                    Thread.Sleep(5000);
                }
            }));
            Thread intake = new Thread(new ThreadStart(() =>
            {
                while (enabled)
                {
                    try
                    {
                        //Log.WriteLine("runable intake");
                        if (new ConnectMilkoscanIntake().Prediction.Count() != CountIntake)
                        {
                            new MigratorIntakeMilkoscan().Run();
                            CountIntake = new ConnectMilkoscanIntake().Prediction.Count();
                        }
                    }
                    catch (Exception e)
                    {
                        Log.WriteLine($"Error migration: {e.Message}");
                    }
                    Thread.Sleep(5000);
                }
            }));
            bottling.Start();
            curd.Start();
            intake.Start();
        }
        public void stoped()
        {
            enabled = false;
        }
    }
}
