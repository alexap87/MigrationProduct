using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace MigrationProduct
{
    class LoggingService: ServiceBase
    {
        protected override void OnStart(string[] args)
        {
            new StartMigration().started();
        }
        protected override void OnStop()
        {
            new StartMigration().stoped();
        }
        protected override void OnPause()
        {
            base.OnPause();
        }
    }
}
