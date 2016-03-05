using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM1
{
    class Event
    {

        public static int ARRIVAL = 1;
        public static int DEPARTURE = 2;
        protected int _type;
        protected double _time;

        public Event(int type, double time)
        {
            this._type = type;
            this._time = time;
        }

        public int Type
        {
            get
            {
                return _type;
            }
        }

        public double Time
        {
            get
            {
                return _time;
            }
        }


    }
}
