

using System.ComponentModel.DataAnnotations;

namespace MigrationProduct.Intake
{
    public class PredictionC
    {
        public int SampRef { get; set; }
        public short RepNoRef { get; set; }
        public int CompRef { get; set; }
        public double? Value { get; set; }
        public short? Flags { get; set; }
    }
}
