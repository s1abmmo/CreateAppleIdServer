using CreateAppleIdServer.Models;
using CreateAppleIdServer.Services;

namespace CreateAppleIdServer.BackgroundServices
{
    public class MainBackgroundService : BackgroundService
    {
        private StoreDataModel _storeDataModel;
        private FileService _fileService;
        public MainBackgroundService(StoreDataModel storeDataModel, FileService fileService)
        {
            _storeDataModel = storeDataModel;
            _fileService = fileService;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(1000, stoppingToken);
                foreach (var regInfo in _storeDataModel.registrationInfomations)
                {
                    if ((DateTime.Now - regInfo.CreateAt).Seconds > 600)
                    {
                        _fileService.InsertCsv(regInfo);
                        _storeDataModel.registrationInfomations.Remove(regInfo);
                    }
                }

            }
        }
    }
}
