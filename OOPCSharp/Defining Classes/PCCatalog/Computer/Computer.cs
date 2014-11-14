using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCCatalog
{
    class Computer
    {
        private string name;
        private List<Component> components;
        public string Name
        {  
            get { return this.name; }
            set { this.name = value; } 
        }
        
        public List<Component> Components
        {
            get { return this.components; }
            set
            {
                if (null == value) throw new ArgumentNullException("Computer components can not be null!");
                this.components = value;
            }
        }

        public decimal Price 
        { 
            get { return this.Components.Sum(pr => pr.Price); }
        }
        
        public Computer(string name)
        {
            this.Name = name;
            this.Components = new List<Component>();
        }
       
        public Computer(string name, List<Component> components)
            : this(name)
        {
            this.Components = components;
        }

        public override string ToString()
        {
            StringBuilder outstr = new StringBuilder();

            outstr.AppendLine("Name: " + this.Name);
            outstr.AppendLine("Price: " + this.Price.ToString("F"));
            foreach (Component component in this.Components)
            {
                outstr.AppendLine(component.ToString());
            }
            outstr.AppendLine();
            return outstr.ToString();
        }
    }
}
