using System;
using System.Threading.Tasks;
using DotNetty.Common.Utilities;
using DotNetty.Transport.Channels;
using Edelstein.Network.Packet;

namespace Edelstein.Network
{
    public abstract class AbstractSocket : ISocket
    {
        public static readonly AttributeKey<ISocket> SocketKey = AttributeKey<ISocket>.ValueOf("Socket");

        private readonly IChannel _channel;

        public uint SeqSend { get; set; }
        public uint SeqRecv { get; set; }
        public bool EncryptData => true;
        
        public bool ReadOnlyMode { get; set; }

        public object LockSend { get; }
        public object LockRecv { get; }

        public AbstractSocket(IChannel channel, uint seqSend, uint seqRecv)
        {
            _channel = channel;
            SeqSend = seqSend;
            SeqRecv = seqRecv;
            LockSend = new object();
            LockRecv = new object();
        }

        public abstract Task OnPacket(IPacket packet);
        public abstract Task OnDisconnect();
        public abstract Task OnUpdate();
        public abstract Task OnException(Exception exception);

        public Task Disconnect()
            => _channel.DisconnectAsync();

        public async Task SendPacket(IPacket packet)
        {
            if (_channel.IsWritable)
                await _channel.WriteAndFlushAsync(packet);
        }
    }
}