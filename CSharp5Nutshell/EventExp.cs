using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp5Nutshell
{
    //Information conveying
    public class PriceChangedEventArgs : System.EventArgs
    {
        public readonly decimal LastPrice;
        public readonly decimal NewPrice;

        public PriceChangedEventArgs(decimal lastprice, decimal newprice)
        {
            LastPrice = lastprice;
            NewPrice = newprice;
        }
    }
    //
    public class Stock
    {
        string symbol;
        decimal price;
        public static event EventHandler<PriceChangedEventArgs> PriceChanged;

        public Stock(string symbol, decimal price)
        {
            this.symbol = symbol;
            this.price = price;
        }
        protected virtual void OnPriceChanged(PriceChangedEventArgs e)
        {
            if (PriceChanged != null)
            {
                PriceChanged(this,e);
            }
        }

        public decimal Price
        {   
            get { return price; }
            set
            {
                if (price == value) { return; }
                decimal oldprice = price;
                price = value;
                OnPriceChanged(new PriceChangedEventArgs(oldprice,price));
            }
        }
        

    }

    class EventExp
    {
        static Func<string, string, int> totalLength = (x1, x2) => { return x1.Length + x2.Length; };
        public static void stock_PriceChanged(object sender, PriceChangedEventArgs e)
        {   
                Console.WriteLine("Changed");
        }

        Func<int> OutsideVar()
        {
            int seed = 0;
            return () => { return seed++; };
        }
        Func<int> LocalVar()
        {
            return () =>
            {
                int seed = 0;
                return seed++;
            };
        }

        static void Main1(string[] args)
        {
            Stock a = new Stock("TEST",11M);
            Stock.PriceChanged += stock_PriceChanged; // stock_PriceChanged is a subscriber
            a.Price = 10M;
            a.Price = 111M;
            Console.WriteLine(totalLength("Hello", "World"));
            EventExp e1 = new EventExp();
            Func<int> outsideVar1 = e1.OutsideVar();
            Console.WriteLine(outsideVar1());
            Console.WriteLine(outsideVar1());
            EventExp e2 = new EventExp();
            Func<int> outsideVar2 = e2.OutsideVar();
            Console.WriteLine(outsideVar2());

            Console.ReadLine();
        }
        
    }
}
