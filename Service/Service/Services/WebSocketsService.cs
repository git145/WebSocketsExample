using Service.Interfaces;
using System;
using System.Diagnostics;
using System.Net.WebSockets;
using System.Text;
using System.Threading; 

namespace Service.Services
{
    public class WebSocketsService : IWebSocketsService
    {
        private readonly WebSocket _webSocket;

        private bool _hasClient = true;

        private const string MESSAGE = "Hello from WebSockets!";

        private const int WAIT_TIME = 3000;

        public WebSocketsService(WebSocket webSocket)
        {
            _webSocket = webSocket;

            Initialise();
        }

        private bool Initialise()
        {
            bool isSuccessful = false;

            try
            {
                Thread threadSendMessage = new Thread(SendMessage);
                threadSendMessage.Start();

                Thread threadReceiveMessage = new Thread(ReceiveMessage);
                threadReceiveMessage.Start();

                while (true)
                {
                    if (!_hasClient)
                    { 
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            return isSuccessful;
        }

        private void SendMessage()
        {
            byte[] arraySegment = Encoding.UTF8.GetBytes(MESSAGE);

            while (true)
            {
                _webSocket.SendAsync(arraySegment, WebSocketMessageType.Text, true, CancellationToken.None);

                Thread.Sleep(WAIT_TIME);
            }
        }

        private void ReceiveMessage()
        {
            ReceiveMessageAsync();
        }

        private async void ReceiveMessageAsync()
        {
            byte[] buffer = new byte[1024 * 4];

            WebSocketReceiveResult result;

            while (_hasClient) 
            {
                result = await _webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

                if (result.CloseStatus.HasValue)
                {
                    _hasClient = false;
                }
            }
        }
    }
}
