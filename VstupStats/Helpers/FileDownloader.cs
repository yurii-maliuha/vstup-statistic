namespace VstupStats.Helpers
{
    public class FileDownloader
    {
        private const string _basePath = "https://registry.edbo.gov.ua";
        public async Task<Stream> DownloadFile(string path)
        {
            var httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri(_basePath);
            var url = $"/files/go/25.07.2023/B{path}d.xlsx";
            var response = await httpClient.GetByteArrayAsync(url);

            Console.WriteLine($" [*]: File downloaded: ${url}, stream length {response?.Length}");

            var ms = new MemoryStream(response);
            ms.Seek(0, SeekOrigin.Begin);
            return ms;
        }
    }
}
