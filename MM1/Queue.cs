using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM1
{
    class Queue
    {
        protected List<Customer> customers = new List<Customer>();
        protected double tempsWaiting = 0.0;
        protected double tempsWaiting2 = 0.0;
        protected double tempsService = 0.0;
        protected double tempsService2 = 0.0;
        protected int number = 0;
        protected double surface = 0.0;
        protected double time = 0.0;

        public int Size
        {
            get
            {
                return this.customers.Count;
            }
        }
    
        public void addCustomer(Customer customer)
        {
            int customersCount = this.customers.Count;
            double arrivalTime = customer.ArrivalTime;
            this.surface += (double)customersCount * (arrivalTime - this.time);
            this.time = arrivalTime;
            this.customers.Add(customer);
        }

        public Customer removeCustomer(double currentTime)
        {
            Customer customer = (Customer)this.customers.ElementAt(0);
            this.tempsService += currentTime - customer.ArrivalTime;
            this.tempsService2 += (currentTime - customer.ArrivalTime) * (currentTime - customer.ArrivalTime);
            this.tempsWaiting += currentTime - customer.ArrivalTime - customer.ServiceTime;
            this.tempsWaiting2 += (currentTime - customer.ArrivalTime - customer.ServiceTime) * (currentTime - customer.ArrivalTime - customer.ServiceTime);
            ++this.number;
            int size = this.customers.Count;
            this.surface += (double)size * (currentTime - this.time);
            this.time = currentTime;
            this.customers.RemoveAt(0);
            return customer;
        }

        public Customer getCustomerAt(int index)
        {
            return (Customer)customers.ElementAt(index);
        }

        public double getMeanWaitingTime()
        {
            return tempsWaiting / (double)number;
        }

        public double getMeanStayingTime()
        {
            return tempsService / (double)number;
        }

        public double getVarianceWaitingTime()
        {
            return (tempsWaiting2 - (tempsWaiting * tempsWaiting) / (double)number) / (double)(number - 1);
        }

        public double getVarianceStayingTime()
        {
            return (tempsService2 - tempsService * tempsService / (double)number) / (double)(number - 1);
        }

        public double getMeanNumberOfCustomers()
        {
            return surface / time;
        }

        public int getTotalNumberOfCustomers()
        {
            return number;
        }


        public List<Customer> Customers()
        {
            return customers;
        }
    }
}
