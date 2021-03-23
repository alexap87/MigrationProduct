

using System.ComponentModel.DataAnnotations.Schema;

namespace MigrationProduct.Bottling
{
    public class DoubleComponentsC
    {
        public short WorkstationID { get; set; }
        public int SampleIndex { get; set; }
        public byte IntakeNumerator { get; set; }
        public byte SyntheticNumerator { get; set; }
        public int CID { get; set; }
        public double? Value { get; set; }
        public short Status { get; set; }
        public double? ReferenceValue { get; set; }
        [ForeignKey("SampleIndex, IntakeNumerator, SyntheticNumerator, WorkstationID")]
        public virtual ResultsC Results { get; set; }
    }
}
