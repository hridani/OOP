using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalacticGPSTask
{
    public enum  Planet
    {
        Mercury, Venus, Earth, Mars, Jupiter, Saturn, Uranus, Neptune
    }
    public struct Location
    {
        private double latitude;
        private double longitude;
        private Planet namePlanet;
        
        public double Latitude 
        {
            get { return this.latitude; }
            set { this.latitude = value; } 
        }
        
        public double Longitude
        {
            get { return this.longitude; }
            set { this.longitude = value; }
        }
        
        public Planet NamePlanet
        {
            get { return this.namePlanet; }
            set { this.namePlanet = value; }
        }

        public Location(double latitude, double longitude, Planet planet)
        {
            this.latitude = latitude;
            this.longitude = longitude;
            this.namePlanet = planet;
        }
       
        public override string ToString()
        {
            return string.Format("{0} ,{1} - {2}", this.Latitude, this.Longitude, this.NamePlanet);
        }
    }
    
    
    class GalacticGPS
    {
        static void Main(string[] args)
        {
            Location home = new Location(18.037986, 28.870097, Planet.Earth);
            Console.WriteLine(home);
        }
    }
}
