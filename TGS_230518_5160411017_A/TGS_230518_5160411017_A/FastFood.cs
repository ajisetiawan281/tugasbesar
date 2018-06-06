using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGS_230518_5160411017_A
{
    class FastFood
    {
        protected string category;
        protected int price;
        protected int calory;
        private string menuName;

        public string MenuName
        {
            get
            {
                return this.menuName;
            }
            set
            {
                this.menuName = value;
            }
        }

        public int Calory
        {
            get
            {
                return this.calory;
            }
            set
            {
                this.calory = value;
            }
        }

        public int Price
        {
            get
            {
                return this.price;
            }
            set
            {
                this.price = value;
            }
        }

        public string Category
        {
            get
            {
                return this.category;
            }
            set
            {
                this.category = value;
            }
        }

        public void PrintFFInfo()
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Kategori  :  " + this.Category);
            Console.WriteLine("Nama Menu :  " + this.MenuName);
            Console.WriteLine("Harga\t  :  Rp " + (object)this.Price);
            Console.WriteLine("Kalori\t  :  " + (object)this.Calory + " Calories");
        }
    }
}
