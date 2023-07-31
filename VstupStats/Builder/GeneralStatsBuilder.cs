using System.Data;
using System.Json;
using VstupStats.Schema;

namespace VstupStats.Builder;

public class GeneralStatsBuilder : BuilderBase
{
    public static int ROW_INDEX = 1;
    public BuilderItem LoadTime
        => new BuilderStringItem(nameof(GeneralStatsSchema.LoadTime), valuePrefix: "Дата, час");
    public BuilderItem DegreeType
        => new BuilderStringItem(nameof(GeneralStatsSchema.DegreeType), valuePrefix: "Ступінь вищої освіти -");
    public BuilderItem StudyFormat
        => new BuilderStringItem(nameof(GeneralStatsSchema.StudyFormat), valuePrefix: "Форма здобуття освіти -");
    public BuilderItem Specialities
        => new BuilderStringArrayItem(nameof(GeneralStatsSchema.Specialities), valuePrefix: "Спеціальності -_Предметна спеціальність - _Спеціалізація предметної спеціальності -_Спеціалізації предметної спеціальності - _Спеціалізація - _Предметні спеціальності -_Спеціалізації -_Спеціальність - _Галузь знань - ");
    public BuilderItem StateOrderVolume
        => new BuilderIntItem(nameof(GeneralStatsSchema.StateOrderVolume), valuePrefix: "Суперобсяг державного замовлення -");

    public GeneralStatsBuilder()
    {
        Items = new List<BuilderItem>()
        {
            LoadTime, DegreeType, StudyFormat,
            Specialities, StateOrderVolume
        };
    }

    public override JsonValue RetrieveValue(DataRow row, BuilderItem item)
    {
        var details = row[0]?.ToString().Split('\n') ?? new string[0];
        var value = ParseMetaValue(details, item.ValuePrefix ?? string.Empty);
        var index = Items.IndexOf(item);
        return item.JsonValue(value);
    }

    private static string? ParseMetaValue(string[] details, string prefix)
    {
        var usedPrefix = prefix.Split("_").First(x => string.Join(' ', details).Contains(x));
        return details.FirstOrDefault(x => x.StartsWith(usedPrefix))?.Remove(0, usedPrefix.Length).Trim(' ', '.', '-');
    }
}
