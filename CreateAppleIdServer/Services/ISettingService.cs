using CreateAppleIdServer.Models;

namespace CreateAppleIdServer.Services
{
    public interface ISettingService
    {
        public void AddCompressedFilePath(SettingModel setting, string compressedFilePath);
    }
}
