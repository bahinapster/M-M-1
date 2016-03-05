using System;
using System.Collections.Generic;
using System.Linq;


namespace MM1
{
    class FES
    {
        protected List<Event> events = new List<Event>();
        public void addEvent(Event newEvent)
        {
            int insertIndex = 0;
            foreach (var item in events)
            {
                if (item.Time > newEvent.Time) break;
                ++insertIndex;
            }
            this.events.Insert(insertIndex, newEvent);
        }


        public Event nextEvent()
        {
            Event _event = (Event)this.events.ElementAt(0);
            this.events.RemoveAt(0);
            return _event;
        }

    }
}
