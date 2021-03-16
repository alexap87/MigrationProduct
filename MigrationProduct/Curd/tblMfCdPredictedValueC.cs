

namespace MigrationProduct.Curd
{
    public class tblMfCdPredictedValueC
    {
        public int SystemID { get; set; }
        public long PredictedValueID { get; set; }
        public long SubSampleID { get; set; }
        public int ParameterLogicalID { get; set; }
        public int Type { get; set; }
        public int AggregationType { get; set; }
        public string? TextResult { get; set; }
        public double? DoubleResult { get; set; }
        public int DataType { get; set; }
        public int? Unit { get; set; }
        public int OutlierStatus { get; set; }
        public int ProductLimitsStatus { get; set; }
        public double? RawResult { get; set; }
        public bool IsSigned { get; set; }
    }
}
