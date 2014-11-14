using System;
using System.Collections.Generic;
using System.Linq;
namespace RestaurantManager.Models
{
    using System.Text;
    using RestaurantManager.Interfaces;
    public class Salad:Meal,ISalad
    {
        private const string textTitle = "~~~~~ SALADS ~~~~~";
        private const string textContainsPastaFormat = "Contains pasta: {0}";
        private const string textContainsPastaYes = "yes";
        private const string textContainsPastaNo = "no";
        public Salad(string initialName, decimal initialPrice, int initialCalories, int initialQuantityPerServing, int initialTimeToPrepare,bool initialContainsPasta)
            :base(initialName,initialPrice,initialCalories,initialQuantityPerServing,initialTimeToPrepare,false)
        {
            this.ContainsPasta = initialContainsPasta;
        }
        public bool ContainsPasta { get; private set; }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(textTitle);
            result.Append(base.ToString());
            result.AppendLine(string.Format(textContainsPastaFormat, this.ContainsPasta ? textContainsPastaYes : textContainsPastaYes));

            return result.ToString();
        }
        
    }
}
