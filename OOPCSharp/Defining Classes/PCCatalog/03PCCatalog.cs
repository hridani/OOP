using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCCatalog
{
    class PCCatalogueClass
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("bg-BG");

            Component batteryLiON = new Battery("4-cell Li-Ion", (decimal)23.45);
            Component vcardRadeon = new GraphicCard("AMD Radeon R5 M230", (decimal)302.98, "2GB own memory ");
            Component vcardGeForce = new GraphicCard("Nvidia GeForce GTX 850M", (decimal)99.99, "play 3D");
            Component procIntel = new Processor("Intel Core I7-4500U", (decimal)199.34, "1.8GHr/3.0GHr");
            Component procAMD = new Processor("AMD Quad-Core A8-4500", (decimal)67.89, "1.8Ghr");
            Computer LenovoB50 = new Computer("Lenovo B50-70 59-421088", new List<Component>() { batteryLiON, vcardRadeon, procIntel });
            
            Computer HPBroBook = new Computer("HP ProBook 455 HOW30");
            HPBroBook.Components.Add(vcardGeForce);
            HPBroBook.Components.Add(procAMD);
            List<Computer> computers = new List<Computer>() { LenovoB50, HPBroBook };
            computers.OrderBy(pr=>pr.Price).ToList().ForEach(c => Console.WriteLine(c.ToString()));

        }
    }
}
