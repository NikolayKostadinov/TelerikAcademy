namespace GSM
{
    using System;
using System.Collections.Generic;

    public class GSM
    {
        private static GSM iphone4S;

        private decimal price;
        private string owner;

        static GSM()
        {
            iphone4S = new GSM("iPhone4S", "Apple");
        }

        public GSM(string model, string manufacturer)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.CallHistory = new List<Call>(); 
        }

        public GSM(
            string model,
            string manufacturer,
            string owner,
            decimal price,
            Battery battery,
            Display display)
            : this(model, manufacturer, owner, price)
        {
            this.Battery = battery;
            this.Display = display;
        }

        public GSM(
            string model,
            string manufacturer,
            string owner,
            decimal price,
            string batModel,
            ushort hoursIdle,
            ushort hoursTalk,
            ushort displaySize,
            uint numberOfColors)
            : this(model, manufacturer, owner, price)
        {
            this.Battery = new Battery(batModel, hoursIdle, hoursTalk);
            this.Display = new Display(displaySize, numberOfColors);
        }

        private GSM(
            string model,
            string manufacturer,
            string owner,
            decimal price)
            : this(model, manufacturer)
        {
            this.Owner = owner;
            this.Price = price;
        }

        public static GSM Iphone4S
        {
            get
            {
                return iphone4S;
            }
        }

        public string Manufacturer { get; private set; }

        public string Model { get; private set; }

        public Display Display { get; set; }

        public Battery Battery { get; set; }

        public List<Call> CallHistory { get; set; }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value < 0m)
                {
                    throw new ArgumentOutOfRangeException("The price must be greater than or equal to 0!");
                }

                this.price = value;
            }
        }

        public string Owner
        {
            get
            {
                return this.owner;
            }

            set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentOutOfRangeException("You can't define empty owner!");
                }

                this.owner = value;
            }
        }

        public void AddCall(Call call)
        {
            this.CallHistory.Add(call);  
        }

        public void DeleteCall(Call call)
        {
            this.CallHistory.Remove(call); 
        }

        public void ClearCallHistory() 
        {
            this.CallHistory.Clear();
        }

        public double CalculateCallsDuration() 
        {
            // TODO: calculate call duration in minutes
            double sumDuration = 0;
            foreach (Call item in this.CallHistory)
            {
                sumDuration += item.Duration; 
            }

            sumDuration = Math.Ceiling((double)(sumDuration / 60));
            return sumDuration;
        }

        public decimal CalculateTotalPriceOfCalls(decimal pricePerMinute)
        {
            double callDuration = this.CalculateCallsDuration();
            return (decimal)callDuration * pricePerMinute;
        }

        public override string ToString()
        {
            return string.Format(
                "GSM manufactorer: {0}\n" +
                "GSM model: {1}\n" +
                "GSM owner: {2}\n" +
                "GSM price: {3:C2}\n" +
                "GSM battery parameters: \n{4,20}\n" +
                "GSM display parameters: \n{5,20}\n",
                this.Manufacturer,
                this.Model,
                this.Owner,
                this.Price,
                this.Battery.ToString(),
                this.Display.ToString());
        }
    }
}