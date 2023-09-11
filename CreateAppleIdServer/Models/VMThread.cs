using CreateAppleIdServer.Enums;

namespace CreateAppleIdServer.Models
{
    public class VMThread
    {
        public string VMId { get; set; }
        public string VMName { get; set; }
        public string VMPathArchiveFile { get; set; }
        public string VMPathExtractFolder { get; set; }
        public bool IsChanged { get; set; } = true;
        public VMThreadStatusEnum Status { get; set; } = VMThreadStatusEnum.Stopped;
        public bool Selected { get; set; } = false;
        public VMThread(string vMId, string vMName, string vMPathArchiveFile, string vMPathExtractFolder)
        {
            VMId = vMId;
            VMName = vMName;
            VMPathArchiveFile = vMPathArchiveFile;
            VMPathExtractFolder = vMPathExtractFolder;
        }

    }
}
