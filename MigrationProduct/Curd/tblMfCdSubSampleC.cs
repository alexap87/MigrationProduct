

namespace MigrationProduct.Curd
{
    class tblMfCdSubSampleC
    {
        public int SystemID { get; set; }
        public long SubSampleID { get; set; }
        public long SampleID { get; set; }
        public long? ParentSubSampleID { get; set; }
        public int? SequenceNumber { get; set; }
        public int SubSampleNumber { get; set; }
        public int Level { get; set; }
        public int Info { get; set; }
        public string? Comment { get; set; }
        public bool IsLeaf { get; set; }
        public int RawDataStatus { get; set; }
        public int EventsStatus { get; set; }
        public int OutlierStatus { get; set; }
        public int ProductLimitsStatus { get; set; }
        public int Quality { get; set; }
    }
}
