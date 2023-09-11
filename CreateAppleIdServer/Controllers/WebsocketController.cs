using CreateAppleIdServer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;
using Newtonsoft.Json;
using CreateAppleIdServer.Interfaces;
using CreateAppleIdServer.Services;

namespace CreateAppleIdServer.Controllers
{
    public class WebsocketController : ControllerBase
    {
        private readonly StoreDataModel _storeData;
        private readonly IStoreDataService _storeDataService;
        public WebsocketController(StoreDataModel storeData, IStoreDataService storeDataService)
        {
            _storeData = storeData;
            _storeDataService = storeDataService;
        }

        [Route("/ws")]
        [HttpGet]
        public async Task Get()
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
                Console.WriteLine("new connect websocket");
                await Echo(webSocket, HttpContext.RequestAborted);
            }
            else
            {
                HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            }
        }

        public async Task Echo(WebSocket webSocket, CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await Task.Delay(50);
                List<VMThread> vmThreads = _storeDataService.GetVMIsChanged(_storeData);
                if (vmThreads.Count > 0)
                {
                    Console.WriteLine($"detect changed {vmThreads[0].Status}");
                    string jsonString = JsonConvert.SerializeObject(vmThreads);
                    byte[] profileListByte = System.Text.Encoding.ASCII.GetBytes(jsonString);
                    await webSocket.SendAsync(
                        new ArraySegment<byte>(profileListByte, 0, profileListByte.Length),
                        WebSocketMessageType.Text,
                        true,
                        CancellationToken.None);
                }
            }
        }

    }
}
