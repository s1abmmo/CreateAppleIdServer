namespace CreateAppleIdServer.Models
{
    public class MyAppSettingModel
    {
        public string[] TargetPathsFolder { get; set; }
        public string[] VitualMachineArchived { get;set; }
        public MyAppSettingModel()
        {
            TargetPathsFolder = new string[] { };
            VitualMachineArchived = new string[] { };
        }
    }
}
