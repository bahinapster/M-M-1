using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM1
{
    class Customer
    {
        protected double arrivalTime;
        protected double serviceTime;

        public Customer(double arrivalTime, double serviceTime)
        {
            this.arrivalTime = arrivalTime;
            this.serviceTime = serviceTime;
        }

        public double ArrivalTime
        {
            get { return this.arrivalTime; }
        }

      

        public double ServiceTime
        {
            get { return this.serviceTime; }
        }
    }
}
