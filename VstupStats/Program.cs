
using System.Json;
using VstupStats.Helpers;

var downloader = new FileDownloader();
var excelParser = new ExcelParser();
const int MAX_PAGE = 51;
const int YEAR = 2023;

var participants = new JsonArray();

Console.WriteLine();

for (int i = 1; i <= MAX_PAGE; i++)
{
    var id = i.ToString("00");

    var excelDocumentStream = await downloader.DownloadFile(id);

    if (excelDocumentStream == null)
    {
        continue;
    }

    try
    {
        var documentParticipants = excelParser.Parse(excelDocumentStream) ?? new List<JsonObject>();
        participants.AddRange(documentParticipants);

        string currDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string filePath = Path.Combine(currDirectory, @$"..\..\..\Data\{YEAR}-{i}.json");
        File.WriteAllText(filePath, participants.ToString());
    }
    catch (Exception ex)
    {
        Console.WriteLine($" [*] ---------- ERROR for {id} " + ex.Message);
        continue;
    }

    Console.WriteLine($" [*]: {id} parsed");
    Thread.Sleep(5 * 1000);
}


Console.WriteLine($" [*]: Finished. Press Enter to exit.");
Console.ReadLine();

