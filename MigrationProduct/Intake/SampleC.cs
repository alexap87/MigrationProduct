using System;

namespace MigrationProduct.Intake
{
    public class SampleC
    {
        public int SampNo { get; set; }
        public string SampleId { get; set; }
        public int ProdRef { get; set; }
        public int ZeroRef { get; set; }
        public short NoOfReps { get; set; }
        public short Kind { get; set; }
        public DateTime DateTime { get; set; }
        public double DilutionFactor { get; set; }
        public double SampleWeight { get; set; }
        public bool Excluded { get; set; }
        public int Flags { get; set; }
        public string Remark { get; set; }
        public string UDF1 { get; set; }
        public string UDF2 { get; set; }
        public string UDF3 { get; set; }
        public string UDF4 { get; set; }
    }
}
