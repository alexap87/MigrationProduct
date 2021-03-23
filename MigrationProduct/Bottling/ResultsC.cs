using System;
using System.Collections.Generic;

namespace MigrationProduct.Bottling
{
    public class ResultsC
    {
        public short WorkstationID { get; set; }
        public int SampleIndex { get; set; }
        public byte IntakeNumerator { get; set; }
        public byte SyntheticNumerator { get; set; }
        public DateTime ResultTime { get; set; }
        public bool Export { get; set; }
        public bool SaveForever { get; set; }
        public bool StoreOnServer { get; set; }
        public string Comments { get; set; }
        public short Status { get; set; }
        public byte ResultType { get; set; }
        public byte ResultSubType { get; set; }
        public int SetupIndex { get; set; }
        public int JobIndex { get; set; }
        public int Numerator { get; set; }
        public int Position { get; set; }
        public int RackID { get; set; }
        public int OriginalJobIndex { get; set; }
        public short IsMosaicUploaded { get; set; }
        public short IsModified { get; set; }
        public Guid InstrumentSampleID { get; set; }
        public short IsLinkDiagnosticUploaded { get; set; }

        public virtual ICollection<DoubleComponentsC> DoubleComponents { get; set; }
        public virtual ICollection<TextComponentsC> TextComponents { get; set; }
    }
}
