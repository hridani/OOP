using System;


namespace PCCatalog
{
    class GraphicCard : Component
    {
        public GraphicCard(string name, decimal price, string details = null)
            : base(name, price, details) { }
    }
    
    class Processor : Component
    {
        public Processor(string name, decimal price, string details = null)
            : base(name, price, details)
        {
        }
    }
    class Battery : Component
    {
        public Battery(string name, decimal price, string details = null)
            : base(name, price, details)
        {
        }
    }
}
