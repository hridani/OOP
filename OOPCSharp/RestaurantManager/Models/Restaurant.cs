namespace RestaurantManager
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using RestaurantManager.Interfaces;
    public class Restaurant : IRestaurant
    {
        private const string noRecipesAsText = "No recipes... yet";
        private const string nameAndLocationFormat = "***** {0} - {1} *****";

        private string name;
        private string location;
        private IList<IRecipe> recipes;
        public Restaurant(string initialName, string initialLocation)
        {
            this.Name = initialName;
            this.Location = initialLocation;
            this.recipes = new List<IRecipe>();
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Restorant name must be positive.", "name");
                }
                this.name = value;
            }
        }

        public string Location
        {
            get
            {
                return this.location;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Location must be positive.", "location");
                }
                this.location = value;
            }
        }

        public IList<Interfaces.IRecipe> Recipes
        {
            get { return this.recipes; }
        }

        public void AddRecipe(IRecipe recipe)
        {
            if (recipe != null)
            {
                this.recipes.Add(recipe);
            }
        }

        public void RemoveRecipe(Interfaces.IRecipe recipe)
        {
            this.recipes.Remove(recipe);
        }

        public string PrintMenu()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(string.Format(nameAndLocationFormat, this.Name, this.Location));
            if (this.recipes.Count == 0)
            {
                result.Append(noRecipesAsText);
            }
            else 
            {
                var orderRecipes = this.Recipes.GroupBy(r => r.GetType()).ToList();
                
                var sortdedRecipes = this.Recipes.OrderBy(r => r.Name);
                foreach (var recipe in sortdedRecipes)
                {
                    result.Append(recipe.ToString());
                }
            }

            return result.ToString();
        }
    }
}
