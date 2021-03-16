using System;

namespace MigrationProduct.Curd
{
    public class tblMfCdSampleC
    {
        public int SystemID { get; set; }
        public long SampleID { get; set; }
        public int InstrumentLogicalID { get; set; }
        public int SampleType { get; set; }
        public string? SampleNumber { get; set; }
        public int ProductLogicalID { get; set; }
        public int? AuditTrailID { get; set; }
        public DateTime? AnalysisStartUTC { get; set; }
        public DateTime? AnalysisEndUTC { get; set; }
        public DateTime? CreatedAtUTC { get; set; }
        public DateTime? ModifiedAtUTC { get; set; }
        public long? ModifiedBy { get; set; }
        public int RawDataStatus { get; set; }
        public int EventsStatus { get; set; }
        public int OutlierStatus { get; set; }
        public int ProductLimitsStatus { get; set; }
        public Guid? SampleinstrumentID { get; set; }
        public bool Obsolete { get; set; }
        public string? Signature { get; set; }
        public int? SignatureVersion { get; set; }
    }
}
