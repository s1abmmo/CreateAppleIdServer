using CreateAppleIdServer.Interfaces;
using CreateAppleIdServer.Models;

namespace CreateAppleIdServer.Services
{
    public class VMThreadService : IVMThreadService
    {
        public VMThreadService() { }
        public void UpdateVMThread(SettingModel setting, StoreDataModel storeData)
        {
            foreach (var path in setting.CompressedFilePaths)
            {
                if (Directory.Exists(path))
                {
                    string[] filePaths = Directory.GetFiles(path);

                    foreach (string filePath in filePaths)
                    {
                        var fileName = Path.GetFileName(filePath);
                        var fileExtension = Path.GetExtension(filePath);
                        var i = storeData.vMThreads.FindIndex(vmT => vmT.VMPathArchiveFile == filePath);
                        Console.WriteLine($"{filePath} {fileName} {fileExtension}");
                        if (i == -1 && fileExtension == ".rar")
                        {
                            Console.WriteLine($"add {filePath} {fileName} {fileExtension}");
                            storeData.vMThreads.Add(new VMThread(storeData.vMThreads.Count.ToString(), fileName, filePath, setting.ExtractionDirectoryPath));
                        }
                    }
                }
            }
        }

        public async Task Run()
        {
            //Extract
            //Edit vmx
            //Run vmx
            //Waiting for stop
            //Loop
        }


    }
}
