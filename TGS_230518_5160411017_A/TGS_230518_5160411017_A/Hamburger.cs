using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGS_230518_5160411017_A
{
    class Hamburger : FastFood
    {
        private int nMeat;
        private string meatType;
        private string extraFiller;
        public int extra;

        public string ExtraFiller
        {
            get
            {
                return this.extraFiller;
            }
            set
            {
                this.extraFiller = value;
            }
        }

        public string MeatType
        {
            get
            {
                return this.meatType;
            }
            set
            {
                this.meatType = value;
            }
        }

        public int NMeat
        {
            get
            {
                return this.nMeat;
            }
            set
            {
                this.nMeat = value;
            }
        }

        public Hamburger(int nMeat, string meatType, string extraFiller, int calory)
        {
            this.NMeat = nMeat;
            this.MeatType = meatType;
            this.ExtraFiller = extraFiller;
            this.MenuName = this.GenerateBurgerName(nMeat, meatType, extraFiller);
            this.Category = this.GetType().Name;
            this.Price = this.SetPriceForBurger(nMeat, meatType, extraFiller);
            this.Calory = calory;
        }

        public string GenerateBurgerName(int nMeat, string meatType, string extraFiller)
        {
            StringBuilder builder = new StringBuilder();
            base.category = "Hamburger";
            switch (nMeat)
            {
                case 1:
                    builder.Append("Regular ");
                    break;

                case 2:
                    builder.Append("Double ");
                    break;

                case 3:
                    builder.Append("Triple ");
                    break;
            }
            string _meatType = meatType.ToUpper();
            if (_meatType == "Beef")
            {
                builder.Append("Beef ");
            }
            else if (_meatType == "Chicken")
            {
                builder.Append("Chicken ");
            }
            else if (_meatType == "Fish")
            {
                builder.Append("Fish ");
            }
            else
            {
                builder.Append("Burger ");
            }

            if (extraFiller != string.Empty)
            {
                string[] hasil;
                char[] pemisah = new char[] { ',' };

                hasil = extraFiller.Split(pemisah, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < hasil.Length; i++)
                {
                    if (i == 0)
                    {
                        builder.Append("with " + hasil[i]);
                    }
                    else if (i == (hasil.Length - 1))
                    {
                        builder.Append(" and " + hasil[i]);
                    }
                    else
                    {
                        builder.Append(", " + hasil[i]);
                    }
                }
            }
            return builder.ToString();
        }

        public int SetPriceForBurger(int nMeat, string meatType, string extraFiller)
        {
            int harga;

            if (meatType == "Beef")
            {
                harga = 10000;
            }
            else if (meatType == "Chicken")
            {
                harga = 5000;
            }
            else
            {
                harga = 8000;
            }
            string[] filler = extraFiller.Split(',');
            if (extraFiller == "")
            {
                extra = 0;
            }
            else
            {

                for (int i = 0; i < filler.Length; i++)
                {
                    if (filler[i] == "Mushroom" || filler[i] == "mushroom")
                    {
                        extra += 3000;

                    }
                    else if (filler[i] == "Cheese" || filler[i] == "cheese")
                    {
                        extra += 5000;
                    }
                    else if (filler[i] == "Egg" || filler[i] == "egg")
                    {
                        extra += 2500;
                    }

                }
            }
            base.price = (nMeat * harga) + extra;
            return base.price;
        }
    }
}
