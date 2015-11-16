using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centrala
{
    public enum eventType { In, Out };
    class Event
    {
        int streamNo;
        eventType type;
        public Event(int streamNo, eventType type)
        {
            this.type = type;
            this.streamNo = streamNo;
        }
        public eventType Type()
        {
            return type;
        }
        public int streamNumber()
        {
            return streamNo;
        }
        public static Event InEvent(int streamNo)
        {
            return new Event(streamNo, eventType.In);
        }
        public static Event OutEvent(int streamNo)
        {
            return new Event(streamNo, eventType.Out);
        }
        
    }
}
