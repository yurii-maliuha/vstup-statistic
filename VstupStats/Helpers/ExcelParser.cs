using ExcelDataReader;
using System.Data;
using VstupStats.Builder;
using JsonObject = System.Json.JsonObject;

namespace VstupStats.Helpers;

public class ExcelParser
{
    public IList<JsonObject>? Parse(Stream stream)
    {
        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

        using var reader = ExcelReaderFactory.CreateReader(stream);

        var dsr = reader.AsDataSet();
        DataTable table = dsr.Tables[0];
        if (table == null)
        {
            return null;
        }

        JsonObject generalStats = new JsonObject();
        var participants = new List<JsonObject>();
        for (int j = 0; j < table.Rows.Count; j++)
        {
            DataRow row = table.Rows[j];
            if (j == GeneralStatsBuilder.ROW_INDEX)
            {
                //var details = row[0]?.ToString().Split('\n');
                var generalStatsBuilder = new GeneralStatsBuilder();
                foreach (var columnItem in generalStatsBuilder.Items)
                {
                    var value = generalStatsBuilder.RetrieveValue(row, columnItem);
                    generalStats.Add(columnItem.Key, value);
                    //generalStats.Add(key, _statMetaJsonResolver[key](details));
                }

                //fileName = $"{ParseMetaValue(details, "Ідентифікатор широкого конкурсу -")?.ToLower()}.json" ?? fileName;
            }

            if (j >= ParticipantBuilder.ROW_START_INDEX)
            {
                var participant = new JsonObject();
                var participantBuilder = new ParticipantBuilder();

                foreach (var columnItem in participantBuilder.Items)
                {
                    //var value = row[_participantJsonResolver.Keys.ToList().IndexOf(columnKey)];
                    //participant.Add(columnKey, _participantJsonResolver[columnKey](value));
                    var value = participantBuilder.RetrieveValue(row, columnItem);
                    participant.Add(columnItem.Key, value);
                }

                participant.Add(nameof(generalStats), generalStats);
                participants.Add(participant);
            }
        }

        return participants;
    }
}
