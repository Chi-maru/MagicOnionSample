using Grpc.Core;
using MagicOnion.Client;
using Application.Shared.Services;
using UnityEngine;

namespace Application
{
    public class ApplicationController : MonoBehaviour
    {
        private Channel _channel;
        private IApplicationService _service;

        void Awake()
        {
            _channel = new Channel("localhost", 5013, ChannelCredentials.Insecure);
            _service = MagicOnionClient.Create<IApplicationService>(_channel);
        }

        async void Start()
        {
            var x = Random.Range(0, 1000);
            var y = Random.Range(0, 1000);
            var result = await _service.SumAsync(x, y);
            Debug.Log($"Result: {result}");
        }

        async void OnDestroy()
        {
            if (_channel != null)
            {
                await _channel.ShutdownAsync();
            }
        }
    }
}
