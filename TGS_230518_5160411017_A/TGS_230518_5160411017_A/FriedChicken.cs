using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGS_230518_5160411017_A
{
    class FriedChicken : FastFood
    {
        private string partOfChicken;
        private bool isSpicy;

        public bool IsSpicy
        {
            get
            {
                return this.isSpicy;
            }
            set
            {
                this.isSpicy = value;
            }
        }

        public string PartOfChicken
        {
            get
            {
                return this.partOfChicken;
            }
            set
            {
                this.partOfChicken = value;
            }
        }

        public FriedChicken(string partOfChicken, bool isSpicy, int calory)
        {
            this.PartOfChicken = partOfChicken;
            this.IsSpicy = isSpicy;
            this.MenuName = this.GenerateFCName(this.PartOfChicken, this.IsSpicy);
            this.Category = this.GetType().Name;
            this.Price = this.SetPriceForFC(partOfChicken, isSpicy);
            this.Calory = calory;
        }

        public string GenerateFCName(string partOfChicken, bool isSpicy)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (this.IsSpicy)
                stringBuilder.Append("Spicy ");
            stringBuilder.Append(partOfChicken + " Fried Chicken");
            this.MenuName = stringBuilder.ToString();
            return this.MenuName;
        }

        public int SetPriceForFC(string partOfChicken, bool isSpicy)
        {

            if (isSpicy == true)
            {
                if (partOfChicken == "Tight")
                {
                    this.price = 23000;
                }
                else if (partOfChicken == "Rib")
                {
                    this.price = 25000;
                }
                else if (partOfChicken == "Drum Stick")
                {
                    this.price = 18000;
                }
                else
                {
                    this.price = 15000;
                }
            }
            else
            {
                if (partOfChicken == "Tight")
                {
                    this.price = 20000;
                }
                else if (partOfChicken == "Rib")
                {
                    this.price = 22000;
                }
                else if (partOfChicken == "Drum Stick")
                {
                    this.price = 15000;
                }
                else
                {
                    this.price = 12000;
                }
            }
            return this.price;
        }
    }
}
