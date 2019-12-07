using Dec03;
using NUnit.Framework;

namespace Movements.Test
{
    public class SantaPathTests
    {
        private const double Tolerance = 0.000001;

        [Test]
        public void Move_AsExample_MatchesExpected()
        {
            var begin = new Position(71.639566053691, -51.1902823595313);
            var expected = new Position(71.572192407382, -50.9050972077072); 
            var moves = new[] {
                new Movement {Direction = "right", Unit = "meters", Value = 10000}, 
                new Movement {Direction = "down", Unit = "meters", Value = 7500}
            };

            var path = new SantaPath {CanePosition = begin, SantaMovements = moves};
            var newPosition = path.CalculateNewPosition();
            
            Assert.That(newPosition.Lat, Is.EqualTo(expected.Lat).Within(Tolerance));
            Assert.That(newPosition.Lon, Is.EqualTo(expected.Lon).Within(Tolerance));
        }
    }
}