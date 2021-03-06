﻿using System;
using System.Diagnostics;

namespace MM1
{
    class Program
    {

        protected double _lambda;
        protected double _mu;
        Random rnd = new Random();
        static int app = 1;

        public Program(double lambda, double mu)
        {
            this._lambda = lambda;
            this._mu = mu;
        }

        public void simulation(double simLength , int app)
        {
            Queue queue = new Queue();
            FES fes = new FES();
            double time = 0.0;

            // Starting counter
            var stopwatch = Stopwatch.StartNew();


            // Adding event
            fes.addEvent(new Event(Event.ARRIVAL, this.exp(this._lambda)));
            double serviceTime = 1 / _mu;
            while (time < simLength)
            {
                Event e = fes.nextEvent();
                time = e.Time;
                switch (e.Type)
                {
                    case 1:
                        fes.addEvent(new Event(Event.ARRIVAL, time + this.exp(this._lambda)));
                        if (app == 1)
                            serviceTime = this.exp(this._mu);
                        queue.addCustomer(new Customer(time, serviceTime));
                        if (queue.Size != 1) break;
                        fes.addEvent(new Event(Event.DEPARTURE, time + serviceTime));
                        break;

                    case 2:
                        queue.removeCustomer(time);
                        if (queue.Size <= 0) break;
                        serviceTime = queue.getCustomerAt(0).ServiceTime;
                        fes.addEvent(new Event(Event.DEPARTURE, time + serviceTime));
                        break;
                }
            }
            stopwatch.Stop();

            Console.WriteLine("=============== Simulation Report =================");
            Console.WriteLine("Calculation time: " + stopwatch.ElapsedMilliseconds + " milliseconds");
            Console.WriteLine("Mean waiting time: " + queue.getMeanWaitingTime()+"");
            Console.WriteLine("Var waiting time: " + queue.getVarianceWaitingTime()+"");
            Console.WriteLine("Mean staying time: " + queue.getMeanStayingTime());
            Console.WriteLine("Var staying time: " + queue.getVarianceStayingTime());
            Console.WriteLine("Mean number of customers: " + queue.getMeanNumberOfCustomers());
            Console.WriteLine("Total number of served customers during simulation: " + queue.getTotalNumberOfCustomers());
            
            Console.ReadKey();
        }

        public double exp(double taux)
        {
            return (- Math.Log(rnd.NextDouble()) / taux);
        }

       

        static void Main(string[] args)
        {

            Console.WriteLine("Please select 1 for MM1 or 2 for MD1 : ");
            app = int.Parse(Console.ReadLine());

            Console.WriteLine("enter the value of lambda : ");
            double lambda = double.Parse(Console.ReadLine());

            Console.WriteLine("enter the value of mu : ");
            double mu = double.Parse(Console.ReadLine());

            Console.WriteLine("enter the simulation time : ");
            double duration = double.Parse(Console.ReadLine());
            
            Program s = new Program(lambda, mu);
            s.simulation(duration,app);
            Console.ReadKey();
        }
       
    }
}
