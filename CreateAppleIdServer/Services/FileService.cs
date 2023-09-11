using CreateAppleIdServer.Enums;
using CreateAppleIdServer.Models;
using System.Diagnostics;
using System.IO;

namespace CreateAppleIdServer.Services
{
    public class FileService : IFileService
    {
        private readonly string pathCsv = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "export.csv");
        public FileService() { }
        public void InsertCsv(RegistrationInfomation regInfo)
        {
            string result = "";

            if (regInfo.FinishStep == FinishStepEnum.CreateInfo)
            {
                return;
            }

            if (regInfo.FinishStep == FinishStepEnum.Register)
            {
                result = "Not complete Review & Download";
            }

            if (regInfo.FinishStep == FinishStepEnum.ReviewDownload)
            {
                result = "Complete";
            }

            string content = $"\"{regInfo.VMName}\",\"{regInfo.CreateAt}\",\"{regInfo.FirstName}\",\"{regInfo.LastName}\",\"{regInfo.NameAppleId}\",\"{regInfo.Password}\",\"{regInfo.Phone}\",\"{regInfo.MacPassword}\",\"{regInfo.Street}\",\"{regInfo.City}\",\"{regInfo.PostCode}\",\"{regInfo.AreaCode}\",\"{regInfo.KeywordSearch}\",\"{regInfo.DayOfBirth}/{regInfo.MonthOfBirth}/{regInfo.YearOfBirth}\",\"{result}\"{Environment.NewLine}";
            File.AppendAllText(pathCsv, content);
            Console.WriteLine($"write csv {regInfo.VMName}");
        }

        public void ExtractRarFile(string winrarPath, string compressedFile, string directoryToExtract)
        {
            Process p = new Process();
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.FileName = winrarPath;
            p.StartInfo.Arguments = "x -r -y \"" + compressedFile + "\" * \"" + directoryToExtract + "\"";
            p.Start();
            p.WaitForExit();
        }

        public void EditVmxFile(string directoryExtractedPath)
        {
            string searchPattern = "*.vmx";
            string[] vmxFiles = Directory.GetFiles(directoryExtractedPath, searchPattern);

            if (vmxFiles.Any())
            {
                var lines = File.ReadAllLines(vmxFiles[0]).ToList();
                for (int i = 0; i < lines.Count; i++)
                {
                    if (lines[i].Contains(""))
                    {
                        lines[i] = "";
                    }
                }
                File.WriteAllLines(directoryExtractedPath, lines);
            }
            else
            {
                throw new Exception("Not found vmx file");
            }
        }

        public async Task RunVM(string vmDirPath)
        {
            Process p = new Process();
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = vmDirPath;
            p.StartInfo.Arguments = "start \"" + vmDirPath + "\" nogui";
            p.Start();
            await p.WaitForExitAsync();
        }

        public async Task KillVM(string vmDirPath)
        {
            Process p = new Process();
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = vmDirPath;
            p.StartInfo.Arguments = "suspend hard \"" + vmDirPath + "\"";
            p.Start();
            await p.WaitForExitAsync();
        }

    }
}
