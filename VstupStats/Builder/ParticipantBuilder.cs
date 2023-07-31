using VstupStats.Schema;

namespace VstupStats.Builder;

public class ParticipantBuilder : BuilderBase
{
    public static int ROW_START_INDEX = 4;
    public BuilderItem RankNumber
        => new BuilderIntItem(nameof(ParticipantSchema.RankNumber));
    public BuilderItem FullName
        => new BuilderStringItem(nameof(ParticipantSchema.FullName));
    public BuilderItem AverageGrade
        => new BuilderFloatItem(nameof(ParticipantSchema.AverageGrade));
    public BuilderItem GradeDetails
         => new BuilderStringItem(nameof(ParticipantSchema.GradeDetails));
    public BuilderItem Priority
         => new BuilderIntItem(nameof(ParticipantSchema.Priority));
    public BuilderItem Institution
        => new BuilderStringItem(nameof(ParticipantSchema.Institution));
    public BuilderItem RequiresInterview
        => new BuilderBoolItem(nameof(ParticipantSchema.RequiresInterview));
    public BuilderItem? Quota
        => new BuilderStringItem(nameof(ParticipantSchema.Quota));

    public ParticipantBuilder()
    {
        Items = new List<BuilderItem>()
        {
            RankNumber, FullName, AverageGrade, GradeDetails,
            Priority, Institution, RequiresInterview, Quota
        };
    }


}
