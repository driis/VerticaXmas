namespace Dec03
{
    public class Position
    {
        public Position(double lat, double lon)
        {
            Lat = lat;
            Lon = lon;
        }

        public double Lat { get; set; }
        public double Lon { get; set; }

        public override string ToString()
        {
            return $"{nameof(Lat)}: {Lat}, {nameof(Lon)}: {Lon}";
        }
    }
}