namespace RestaurantManager.Models
{
    using RestaurantManager.Interfaces;
    using System.Text;
    public abstract class Meal : Recipe, IMeal
    {
        private const string isVeganText = "[VEGAN] ";
        public Meal(string initialName, decimal initialPrice, int initialCalories, int quantityPerServing, int initialTimeToPrepare, bool initialVegan)
            : base(initialName, initialPrice, initialCalories, quantityPerServing, initialTimeToPrepare, MetricUnit.Grams)
        {
            this.IsVegan = initialVegan;
        }

        public bool IsVegan{get; private set;}
       
        public void ToggleVegan()
        {
            this.IsVegan = !this.IsVegan;
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            if (this.IsVegan)
            {
                result.Append(isVeganText);
            }
            result.AppendLine(base.ToString());
            return result.ToString();
        }

        
    }
}
