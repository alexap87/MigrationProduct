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

            Thread Bottling = new Thread(new ThreadStart(() =>
                {
                    while (enabled)
                    {
                        try
                        {
                            Console.WriteLine($"1 flow {new ConnectionMilkoscanBottling().DoubleComponents.Count()} \n {CountBottling} \n");
                            if (new ConnectionMilkoscanBottling().DoubleComponents.Count() != CountBottling)
                            {
                                new MigratorBottlingMilkoscan().Run();
                                CountBottling = new ConnectionMilkoscanBottling().DoubleComponents.Count();
                            }
                        }


                        catch (Exception e)
                        {
                            Console.WriteLine($"Error migration: {e.Message}");
                        }
                        Thread.Sleep(5000);
                    }
                }));
            Thread Curd = new Thread(new ThreadStart(() =>
            {
                while (enabled)
                {
                    try
                    {
                        Console.WriteLine($"2 flow {new ConnectionFoodscanCurd().tblMfCdPredictedValue.Count()} \n {CountCurd} \n");
                        if (new ConnectionFoodscanCurd().tblMfCdPredictedValue.Count() != CountCurd)
                        {
                            new MigrationCurdFoodScan().Run();
                            CountCurd = new ConnectionFoodscanCurd().tblMfCdPredictedValue.Count();
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Error migration: {e.Message}");
                    }
                    Thread.Sleep(5000);
                }
            }));
            Thread Intake = new Thread(new ThreadStart(() =>
            {
                while (enabled)
                {
                    try
                    {
                        Console.WriteLine($"3 flow {new ConnectMilkoscanIntake().Prediction.Count()} \n {CountIntake} \n");
                        if (new ConnectMilkoscanIntake().Prediction.Count() != CountIntake)
                        {
                            new MigratorIntakeMilkoscan().Run();
                            CountIntake = new ConnectMilkoscanIntake().Prediction.Count();
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Error migration: {e.Message}");
                    }
                }
                Thread.Sleep(5000);
            }));
            Curd.Start();
            Intake.Start();
            Bottling.Start();


        }
        public void stoped()
        {
            enabled = false;
        }
    }
}
