using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            

            logger.LogInfo("Log initialized");

          
            var lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"Lines: {lines[0]}");

          
            var parser = new TacoParser();

          
            var locations = lines.Select(line =>parser.Parse(line)).ToArray();

            ITrackable tacobell1 = null;
            ITrackable tacobell2 = null;
            double Distance = 0;
          
            for(int i = 0; i < locations.Length; i++)
            {
               var LocA=locations[i];
                var corA = new GeoCoordinate();
                corA.Latitude = LocA.Location.Latitude;
                corA.Longitude = LocA.Location.Longitude;

                for(int j=0; j < locations.Length; j++)
                {
                    var LocB = locations[j];
                    var corB = new GeoCoordinate();
                    corB.Latitude = LocB.Location.Latitude;
                    corB.Longitude = LocB.Location.Longitude;

                    if( corA.GetDistanceTo(corB) > Distance)
                    {
                        Distance = corA.GetDistanceTo(corB);
                        tacobell1 = LocA;
                        tacobell2 = LocB;
                    }
                }

            }

            logger.LogInfo($"The two furthest Locatons are {tacobell1.Name} and {tacobell2.Name}");

    

            
        }
    }
}
