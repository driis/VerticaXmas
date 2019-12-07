using System;
using System.Collections.Generic;
using System.Linq;

namespace Dec03
{
    public class SantaPath
    {
        public string Id { get; set; }
        public Position CanePosition { get; set; }
        public IReadOnlyCollection<Movement> SantaMovements { get; set; }


        public Position CalculateNewPosition()
        {
            double xDelta = SantaMovements.Sum(x => x.XDelta);
            double yDelta = SantaMovements.Sum(x => x.YDelta);
            const double earth = 6378.137; // radius of the earth in kilometer
            double m = 1.0 / (2.0 * Math.PI / 360.0 * earth) / 1000.0;  // 1 meter in degree
            var newLat = CanePosition.Lat + yDelta * m;
            var newLon = CanePosition.Lon + xDelta * m / Math.Cos(CanePosition.Lat * (Math.PI / 180));
            return new Position(newLat,newLon);
        }
    }
}