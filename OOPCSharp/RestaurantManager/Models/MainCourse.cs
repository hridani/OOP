namespace RestaurantManager.Models
{
    using System.Text;
    using RestaurantManager.Interfaces;
    public class MainCourse : Meal, IMainCourse
    {
        private const string textTitle = "~~~~~ MAIN COURSES ~~~~~";
        private const string typeTextFormat = "Type: {0}";

        public MainCourse(string initialName, decimal initialPrice, int initialCalories, int initialQuantityPerServing, int initialTimeToPrepare, bool initialIsVegan, string initialType)
            : base(initialName, initialPrice, initialCalories, initialQuantityPerServing, initialTimeToPrepare, initialIsVegan)
        {
            this.Type = this.GetMainCourseType(initialType);
        }
        public MainCourseType Type { get; private set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(textTitle);
            result.Append(base.ToString());
            result.Append(string.Format(typeTextFormat, this.Type.ToString()));
            return result.ToString();
        }
        private MainCourseType GetMainCourseType(string type)
        {
            switch (type)
            {
                case "Soup":
                    return MainCourseType.Soup;
                case "Entree":
                    return MainCourseType.Entree;
                case "Pasta":
                    return MainCourseType.Pasta;
                case "Side":
                    return MainCourseType.Side;
                case "Meat":
                    return MainCourseType.Meat;
                default:
                    return MainCourseType.Other;
            }
        }
    }
}
