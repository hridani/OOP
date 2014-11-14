using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Models
{
    using RestaurantManager.Interfaces;
    public class Dessert : Meal, IDessert
    {
         private const string textTitle = "~~~~~ DESSERTS ~~~~~";
         private const string typeTextFormat = "Type: {0}";
         private const string noSugarText = "[NO SUGAR] ";
        public Dessert(string initialName, decimal initialPrice, int initialCalories, int initialQuantityPerServing, int initialTimeToPrepare, bool initialIsVegan)
            : base(initialName, initialPrice, initialCalories, initialQuantityPerServing, initialTimeToPrepare, initialIsVegan)
        {
            this.WithSugar = true;
            if(initialIsVegan==true)
            {
                this.WithSugar = false;
            }
    
        }
         public bool WithSugar{get; private set;}
        
         public void ToggleSugar()
         {
             this.WithSugar = !this.WithSugar;
         }

         public override string ToString()
         {
             StringBuilder result = new StringBuilder();
             result.AppendLine(textTitle);
             if(!this.WithSugar)
             {
                 result.Append(noSugarText);
             }
             result.Append(base.ToString());
            
             return result.ToString();
         }
    }
}
