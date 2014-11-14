using System;
using System.Text;
public class Battery
{
    private string batteryType;
    private float batteryLife;

    public string BatteryType 
    { 
        get 
        {
            return this.batteryType;
        }
        set
        {
            if (String.IsNullOrEmpty(value))
               throw new ArgumentNullException("Invalid value for battery type!");
            this.batteryType = value;
            
        }
    }
    public float BatteryLife
    {
        get { return this.batteryLife; }

        set
        {
            if (value < 0)
                throw new ArgumentException("Battery hours can not be negative");
            this.batteryLife = value;
        }
    }

    public Battery(string type)
    {
        this.BatteryType = type;
    }

    public Battery (string type, float life) :this(type)
    {
        this.BatteryLife = life;
    }
    
    public override string ToString()
    {
       StringBuilder outputStr = new StringBuilder();
        if(!String.IsNullOrEmpty(this.BatteryType))
                outputStr.AppendLine("battery: " + this.BatteryType);
        if (this.BatteryLife > 0)
        {
            outputStr.AppendLine("battery life: " +this.BatteryLife + "hours");
        }
        return outputStr.ToString();
    }
}

public class Laptop
{
    private string model;
    private string manufacturer;
    private string processor;
    private string ram;
    private string graphicsCard;
    private string hdd;
    private string screen;
    private decimal price;
    private Battery battery;

    public string Model 
    { 
        get { return this.model ;} 
        set
        {
            if (String.IsNullOrEmpty(value))
               throw new ArgumentNullException("Model:Invalid value!");
            this.model = value;
        }
    }
    public string Manifacturer
    {
        get { return this.manufacturer; }
        set
        {
            if (String.IsNullOrEmpty(value))
                throw new ArgumentNullException("Manifacturer:Invalid value!");
            this.manufacturer = value;
        }
    }
    public string Processor
    {
        get { return this.processor; }
        set
        {
            if (String.IsNullOrEmpty(value))
                throw new ArgumentNullException("Processor:Invalid value!");
            this.processor = value;
        }
    }
    public string Ram
    {
        get { return this.ram; }
        set
        {
            if (String.IsNullOrEmpty(value))
                throw new ArgumentNullException("Ram:Invalid value!");
            this.ram = value;
        }
    }
    public string Hdd
    {
        get { return this.hdd; }
        set
        {
            if (String.IsNullOrEmpty(value))
                throw new ArgumentNullException("Hdd:Invalid value!");
            this.hdd = value;
        }
    }
    public string GraphicsCard
    {
        get { return this.graphicsCard; }
        set
        {
            if (String.IsNullOrEmpty(value))
                throw new ArgumentNullException("GraphicsCard:Invalid value!");
            this.graphicsCard = value;
        }
    }
    public string Screen
    {
        get { return this.screen; }
        set
        {
            if (String.IsNullOrEmpty(value))
                throw new ArgumentNullException("Screen:Invalid value!");
            this.screen = value;
        }
    }

    public decimal Price
    {
        get { return this.price; }
        set
        {
            if (value < 0)
                throw new ArgumentException("Price can not be negative!");
            this.price = value;
        }
    }
    public Battery Battery 
    {
        get { return this.battery; }
        set { this.battery = value; }
    }

    public Laptop ( string model, decimal price)
    {
        this.Model = model;
        this.Price = price;
    }
    
    public Laptop(string model,decimal price, string manufacturer=null,string processor=null,
        string ram = null,string graphicsCard=null,string hdd = null,string screen=null, Battery battery=null)
        : this(model, price)
        {
            this.Manifacturer = manufacturer;
            this.Processor = processor;
            this.Ram = ram;
            this.Hdd = hdd;
            this.GraphicsCard = graphicsCard;
            this.Screen = screen;
            this.Battery = battery;
        }
    

    public override string ToString()
    {
        StringBuilder outStr = new StringBuilder();
        outStr.AppendLine("model: " + this.Model);
        if (this.Manifacturer != null)
        {
            outStr.AppendLine("manufacturer: " + this.Manifacturer);
        }
        if (this.Processor != null)
        {
            outStr.AppendLine("processor: " + this.Processor);
        }
        if (this.Ram != null)
        {
            outStr.AppendLine("RAM: " + this.Ram);
        }
        if (this.Screen != null)
        {
            outStr.AppendLine("screen: " + this.Screen);
        }
        if (this.Hdd != null)
        {
            outStr.AppendLine("HDD: " + this.Hdd);
        }
        
        if (this.Battery != null)
        {
            outStr.Append(this.Battery.ToString());
        }
        outStr.AppendLine("price: " + this.Price.ToString("F") + " lv.");
        return outStr.ToString();
    } 
}

class LaptopShop
 {
        static void Main(string[] args)
        {
             Battery firstBattery = new Battery("Li-Ion, 4-cells, 2550 mAh", (float)4.5);
             Laptop firstLaptop = new Laptop("Lenovo Yoga 2 Pro", (decimal)869.88, "Lenovo", "Intel Core i5-4210U (2-core, 1.70 - 2.70 GHz, 3MB cache)", "8 GB", "Intel HD Graphics 4400","128GB SSD", "13.3\" (33.78 cm) – 3200 x 1800 (QHD+), IPS sensor display",firstBattery);
             Laptop secondLaptop = new Laptop("HP 250 G2", (decimal)699);
             Console.WriteLine(firstLaptop.ToString());
             Console.WriteLine(secondLaptop.ToString());
        }
}


