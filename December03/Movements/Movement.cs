namespace Dec03
{
    public class Movement
    {
        public string Direction { get; set; }
        public double Value { get; set; }
        public string Unit { get; set; }

        public double ValueInMeters => Unit switch
        {
            "kilometer" => Value * 1000.0,
            "foot" => Value * 0.304800610,
            _ => Value
        };

        public double XDelta => Direction switch
        {
            "left" => -ValueInMeters,
            "right" => ValueInMeters,
            _ => 0
        };
        
        public double YDelta => Direction switch
        {
            "up" => ValueInMeters,
            "down" => -ValueInMeters,
            _ => 0
        };
    }
}