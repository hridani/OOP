namespace RestaurantManager.Models
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using RestaurantManager.Interfaces;
    public abstract class Recipe : IRecipe
    {
        private const string nameAndPriceRecepeFormat = "==  {0} == ${1:F2}";
        private const string quantityAbdCaloriesFormat = "Per serving: {0} {1}, {2} kcal";
        private const string timeToPrepereFormat = "Ready in {0} minutes";
        private const string unitMilliliters = "ml";
        private const string unitGrams = "g";

        private string name;
        private decimal price;
        private int calories;
        private int quantityPerServing;
        private int timeToPrepare;

        public Recipe(string initialName, decimal initialPrice, int initialCalories,
                    int initialQuantityPerServing, int initialTimeToPrepare,MetricUnit initialUnit)
        {
            this.Name = initialName;
            this.Price = initialPrice;
            this.Calories = initialCalories;
            this.QuantityPerServing = initialQuantityPerServing;
            this.TimeToPrepare = initialTimeToPrepare;
            this.Unit = initialUnit;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                Validation.CheckForNullOrEmptyString(value, "restorant name");
                this.name = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            private set
            {
                Validation.CheckForNegativeDecimal(value, "price");
                this.price = value;
            }
        }

        public int Calories
        {
            get
            {
                return this.calories;
            }
            protected set
            {
                Validation.CheckForNegativeInt(value, "calories");
                this.calories = value;
            }
        }

        public int QuantityPerServing
        {
            get
            {
                return this.quantityPerServing;
            }
            private set
            {
                Validation.CheckForNegativeInt(value, "quantityPerServing");
                this.quantityPerServing = value;
            }
        }
        public MetricUnit Unit { get; private set; }

        public int TimeToPrepare
        {
            get
            {
                return this.timeToPrepare;
            }
            private set
            {
                Validation.CheckForNegativeInt(value, "timeToPrepare");
                this.timeToPrepare = value;
            }
        }
        public override string ToString()
        {
            StringBuilder result=new StringBuilder();
            string unitAsString = (this.Unit==MetricUnit.Milliliters) ? unitMilliliters:  unitGrams;
            result.AppendLine(string.Format(nameAndPriceRecepeFormat,this.Name,this.Price));
            result.AppendLine(string.Format(quantityAbdCaloriesFormat,this.QuantityPerServing,
                                            unitAsString,this.Calories));
            result.Append(string.Format(timeToPrepereFormat,this.timeToPrepare));
            return result.ToString();
        }
    }
}
