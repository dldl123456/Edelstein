using System.Drawing;
using Edelstein.Network.Packet;

namespace Edelstein.Service.Game.Fields
{
    public abstract class AbstractFieldObj : IFieldObj
    {
        public abstract FieldObjType Type { get; }
        
        public int ID { get; set; }
        public IField Field { get; set; }
        public Point Position { get; set; }
        
        public abstract IPacket GetEnterFieldPacket();
        public abstract IPacket GetLeaveFieldPacket();
    }
}