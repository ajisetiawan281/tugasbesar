using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGS_230518_5160411017_A
{
    class Pizza : FastFood
    {
        private string topping;
        private string crust;
        private string size;
        private string pizzaName;

        public string PizzaName
        {
            get
            {
                return this.pizzaName;
            }
            set
            {
                this.pizzaName = value;
            }
        }

        public string Size
        {
            get
            {
                return this.size;
            }
            set
            {
                this.size = value;
            }
        }

        public string Crust
        {
            get
            {
                return this.crust;
            }
            set
            {
                this.crust = value;
            }
        }

        public string Topping
        {
            get
            {
                return this.topping;
            }
            set
            {
                this.topping = value;
            }
        }

        public Pizza(string menuName, string topping, string crust, string size, int calory)
        {
            this.PizzaName = menuName;
            this.Topping = topping;
            this.Crust = crust;
            this.Size = size;
            this.MenuName = this.GeneratePizzaName(this.PizzaName, crust, size);
            this.Category = this.GetType().Name;
            this.Price = this.SetPriceForPizza(topping, crust, size);
            this.Calory = calory;



        }

        public string GeneratePizzaName(string menuName, string crust, string size)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(size + " " + crust + " " + menuName + " pizza");
            return stringBuilder.ToString();
        }

        public int SetPriceForPizza(string topping, string crust, string size)
        {
            string[] hasil;
            char[] pemisah = new char[] { ',' };
            int jumlahTopping = 0;
            int hargaSize = 0;
            int hargaCrust = 0;
            int hargaTopping = 0;

            hasil = topping.Split(pemisah, StringSplitOptions.RemoveEmptyEntries);

            foreach (string penampung in hasil)
            {
                ++jumlahTopping;
            }

            if (size == "Personal" || size == "personal")
            {
                hargaSize = 20000;
            }
            else if (size == "Medium" || size == "medium")
            {
                hargaSize = 40000;
            }
            else if (size == "Large" || size == "large")
            {
                hargaSize = 70000;
            }

            if (crust == "Simple" || crust == "simple")
            {
                hargaCrust = 9000;
            }
            else if (crust == "Cheese" || crust == "cheese")
            {
                hargaCrust = 15000;
            }
            else if (crust == "Sausage" || crust == "sausage")
            {
                hargaCrust = 30000;
            }

            if (jumlahTopping == 1)
            {
                hargaTopping = 20000;
            }
            else if (jumlahTopping == 2)
            {
                hargaTopping = 25000;
            }
            else if (jumlahTopping == 3)
            {
                hargaTopping = 30000;
            }
            else
            {
                hargaTopping = 50000;
            }

            price = hargaSize + hargaCrust + hargaTopping;

            return base.price;
        }

        public void PrintPizzaInfo()
        {
            this.PrintFFInfo();
            StringBuilder stringBuilder = new StringBuilder();
            if (this.topping != string.Empty)
            {
                string[] strArray = this.topping.Split(',');
                for (int index = 0; index < strArray.Length; ++index)
                {
                    if (index == 0)
                        stringBuilder.Append(strArray[index]);
                    else if (index == strArray.Length - 1)
                        stringBuilder.Append(" dan" + strArray[index]);
                    else
                        stringBuilder.Append("," + strArray[index]);
                }
            }
            Console.WriteLine("Topping   :  " + stringBuilder.ToString());
        }
    }
}
