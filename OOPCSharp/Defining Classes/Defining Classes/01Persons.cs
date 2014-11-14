using System;

class Person
{
    private string name ;
    private int age;
    private string email;

    public string Name 
    {
        get { return this.name; }
        set
        {
            if(String.IsNullOrEmpty(value)) 
               throw new ArgumentNullException("Name is empty!");
            this.name=value;
         }
    }
   
    public int Age 
    { 
        get { return this.age; }
      
        set 
        {
            if (value < 1 || value > 100)
             throw new ArgumentOutOfRangeException("Age must be [1,100]!");
            this.age = value;
         }
      }

    public string Email
    { 
        get
        {
            return this.email;
        } 
        set
        {
            if (value!=null && !value.Contains("@"))
                 throw new ArgumentException("Not a valid e-mail address!");
            this.email = value;
        }
    }
   
    public Person(string nameStr, int age, string email)
    {
         this.Name=nameStr;
         this.Age=age;
         this.Email = email;
    }
    public Person(string name, int age)
        : this(name, age, null)
    {}

    public override string ToString()
    {
        if(String.IsNullOrEmpty(this.Email))
        {
            return String.Format("Person: {0}\nage: {1}", this.Name, this.Age);
        }
        else
        {
            return String.Format("Person: {0}\nage: {1}\nemail: {2}",this.Name, this.Age,this.Email);
        }
        
    }
}


    class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person("Dani",45, "123@abv.bg");
            Person person2 = new Person("Pavel", 34);
           // Person person3 = new Person("Ivan", 101);
           
            Console.WriteLine(person1);
            Console.WriteLine(person2);
        }
    }

