using CreateAppleIdServer.Interfaces;
using CreateAppleIdServer.Models;

namespace CreateAppleIdServer.Services
{
    public class SettingService : ISettingService
    {
        public SettingService() { }
        public void AddCompressedFilePath(SettingModel setting, string compressedFilePath)
        {
            Console.WriteLine("AddCompressedFilePath");
            if (setting.CompressedFilePaths.FindIndex(f => f == compressedFilePath) != -1)
            {
                throw new ArgumentException("Exists compressed file path");
            }

            setting.CompressedFilePaths.Add(compressedFilePath);
        }
    }
}
