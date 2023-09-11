using CreateAppleIdServer.Models;
using CreateAppleIdServer.Services;

namespace CreateAppleIdServer.BackgroundServices
{
    public class MainBackgroundService : BackgroundService
    {
        private StoreDataModel _storeData;
        private FileService _fileService;
        private IVMThreadService _vmThreadService;
        private SettingModel _setting;
        public MainBackgroundService(StoreDataModel storeData,
            FileService fileService,
            IVMThreadService vmThreadService,
            SettingModel myAppSetting)
        {
            _storeData = storeData;
            _fileService = fileService;
            _vmThreadService = vmThreadService;
            _setting = myAppSetting;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(1000, stoppingToken);
                foreach (var regInfo in _storeData.registrationInfomations)
                {
                    if ((DateTime.Now - regInfo.CreateAt).Seconds > 600)
                    {
                        _fileService.InsertCsv(regInfo);
                        _storeData.registrationInfomations.Remove(regInfo);
                    }
                }

                _vmThreadService.UpdateVMThread(_setting, _storeData);

            }
        }
    }
}
