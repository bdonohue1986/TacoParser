namespace LoggingKata
{
    
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");

            var cells = line.Split(',');

            if (cells.Length < 3)
            {
                logger.LogError("less than 3 items, Can not complete.");
                return null; 
            }
            var latitude = double.Parse(cells[0]);
            var longitude = double.Parse(cells[1]);
            var Name = cells[2];


            var point = new Point();
            point.Latitude = latitude;
            point.Longitude = longitude;    
            var tacobell = new TacoBell();
            tacobell.Name= Name;
            tacobell.Location = point;
            

            return tacobell;
        }
    }
}