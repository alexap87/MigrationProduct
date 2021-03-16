

namespace MigrationProduct.Intake
{
    public class ProductC
    {
        public int ProdNo { get; set; }
        public string Name { get; set; }
        public bool? CurVersion { get; set; }
        public bool? Protected { get; set; }
        public short? UsabilityLevel { get; set; }
        public short? NoOfComps { get; set; }
        public short? NoOfCols { get; set; }
        public short? IconNo { get; set; }
        public int? IconPos { get; set; }
        public short? Replicates { get; set; }
        public short? PumpStrokes { get; set; }
        public short? Viscosity { get; set; }
        public bool? Preflush { get; set; }
        public short? PipetteShake { get; set; }
        public bool? ReducedVolume { get; set; }
        public short? CleaningTemperature { get; set; }
        public short? CleaningIntensity { get; set; }
        public short? PurgeAlarmTimeout { get; set; }
        public short? PilotMode { get; set; }
        public short? PilotMeanMax { get; set; }
        public short? CurNoOfPilots { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public string ProdDate { get; set; }
        public int? OrigProdRef { get; set; }
        public bool? UseDilution { get; set; }
        public double? DilutionFactorMin { get; set; }
        public double? DilutionFactorIdeal { get; set; }
        public double? DilutionFactorMax { get; set; }
        public double? SampleWeightMin { get; set; }
        public double? SampleWeightideal { get; set; }
        public double? SampleWeightMax { get; set; }
        public short? PcaFailMode { get; set; }
        public bool? AllowCheckSampleDefinition { get; set; }
        public bool? HideAllGH { get; set; }
        public int InstrumentType { get; set; }
    }
}
