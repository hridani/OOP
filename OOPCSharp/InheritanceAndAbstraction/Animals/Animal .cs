namespace Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public enum Gender
    {
        Female,
        Male
    }
   
    public abstract class Animal
    {
        private string name;
        private int age;
        //private Gender gender;

        public Animal(string name, int age, Gender gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The Name can not be null or empty!");
                }
                this.name = value;
            }
        }
        
        public int Age
        {
            get 
            { 
                return this.age; 
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Age can not be negative!");
                }
                this.age = value;
            }
        }

        public Gender Gender { get; private set; }
        public virtual string GetKindAnimal()
        {
            return "animal";
        }
          
       public override GetT
        public abstract void ProduceSound();
    }
}
