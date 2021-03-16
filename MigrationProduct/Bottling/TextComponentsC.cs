

namespace MigrationProduct.Bottling
{
    public class TextComponentsC
    {
        public short WorkstationID { get; set; }
        public int SampleIndex { get; set; }
        public byte IntakeNumerator { get; set; }
        public byte SyntheticNumerator { get; set; }
        public int CID { get; set; }
        public string? Value { get; set; }
        public short? Status { get; set; }
    }
}
