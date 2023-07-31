namespace VstupStats.Schema;

public class ParticipantSchema
{
    public int RankNumber { get; set; }
    public string FullName { get; set; }
    public float AverageGrade { get; set; }
    public string GradeDetails { get; set; }
    public int Priority { get; set; }
    public string Institution { get; set; }

    public bool RequiresInterview { get; set; }
    public string? Quota { get; set; }
}
