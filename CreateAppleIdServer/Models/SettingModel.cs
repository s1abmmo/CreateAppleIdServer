namespace CreateAppleIdServer.Models
{
    public class SettingModel
    {
        public List<string> CompressedFilePaths { get; set; } = new List<string>();
        public string ExtractionDirectoryPath { get; set; } = string.Empty;
        public SettingModel()
        { }
    }
}
