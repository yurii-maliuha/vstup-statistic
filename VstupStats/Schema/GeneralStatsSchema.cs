namespace VstupStats.Schema
{
    public class GeneralStatsSchema
    {
        public string? LoadTime { get; set; }
        public string? DegreeType { get; set; }
        public string? StudyFormat { get; set; }
        public IEnumerable<string>? Specialities { get; set; }
        public int StateOrderVolume { get; set; }
    }
}
