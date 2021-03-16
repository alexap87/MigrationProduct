using System;

namespace MigrationProduct.Curd
{
    class tblMfCdProductC
    {
        public int SystemID { get; set; }
        public long ProductID { get; set; }
        public int ProductLogicalID { get; set; }
        public int NetworkID { get; set; }
        public int InstrumentTypeID { get; set; }
        public int ProductType { get; set; }
        public int? ProductGroupID { get; set; }
        public int? ProductIconID { get; set; }
        public string Name { get; set; }
        public string? ProductCode { get; set; }
        public string? Description { get; set; }
        public int? SampleType { get; set; }
        public long? InstrumentGroupLogicalID { get; set; }
        public bool Active { get; set; }
        public bool? Valid { get; set; }
        public bool AdvancedPredictionModels { get; set; }
        public bool AdvancedInstruments { get; set; }
        public bool AdvancedProductLimits { get; set; }
        public int PredictionMode { get; set; }
        public int? HierarchyFileID { get; set; }
        public bool SpecificSlopeIntercept { get; set; }
        public long? NameTranslationID { get; set; }
        public int Version { get; set; }
        public Guid? GUID { get; set; }
        public DateTime CreatedAtUTC { get; set; }
        public DateTime? ModifiedAtUTC { get; set; }
        public bool Obsolete { get; set; }
        public bool Latest { get; set; }
        public long? CreatedBy { get; set; }
        public long? ModifiedBy { get; set; }
    }
}
