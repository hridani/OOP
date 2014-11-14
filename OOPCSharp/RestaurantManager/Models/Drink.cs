namespace RestaurantManager.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using RestaurantManager.Interfaces;

    class Drink : Recipe, IDrink, IRecipe
    {

        private const int maxCalories = 100;
        private const int maxTimeToPrepare = 20;
        private const string textTitle = "~~~~~ DRINKS ~~~~~";
        private const string textCarbonatedFormat = "Carbonated: {0}";
        private const string textCarbonatedYes = "yes";
        private const string textCarbonatedNo = "no";

        public Drink(string initialName, decimal initialPrice, int initialCalories,int quantityPerServing, int initialTimeToPrepare, bool initialIsCarbonated)
            : base(initialName, initialPrice, CheckCalories(initialCalories),quantityPerServing, CheckTimeToPrepare(initialTimeToPrepare),MetricUnit.Milliliters)
        {
            this.IsCarbonated = initialIsCarbonated;
        }
        public bool IsCarbonated { get; private set; }

        private static int CheckCalories(int initialCalories)
        {
            Validation.CheckForValueIsGreaterRange(initialCalories, maxCalories, "calories");
            return initialCalories;
        }
        private static int CheckTimeToPrepare(int initialTimeToPrepare)
        {
            Validation.CheckForValueIsGreaterRange(initialTimeToPrepare, maxTimeToPrepare, "time to prepare");
            return initialTimeToPrepare;
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(textTitle);
            result.AppendLine(base.ToString());
            result.AppendLine(string.Format(textCarbonatedFormat, this.IsCarbonated ? textCarbonatedYes : textCarbonatedNo));
            
            return result.ToString();
        }
    }
}
