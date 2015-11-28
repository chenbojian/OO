using System.Linq;
using Xunit;

namespace OO
{
    public class ParkingBoyFact
    {
        private readonly ParkingBoy parkingBoy;

        public ParkingBoyFact()
        {
            parkingBoy = new ParkingBoy();
        }

        [Fact]
        public void should_park_car_correctly()
        {
            var car = new Car();
            var parkingLot = new ParkingLot();
            parkingBoy.Manage(parkingLot);
            var token = parkingBoy.Park(car);
            Assert.Same(car, parkingLot.Pick(token));
        }

        [Fact]
        public void should_park_cars_sequencely()
        {
            var car = new Car();
            var fullParkingLot = new ParkingLot(0);
            var parkingLot = new ParkingLot();
            parkingBoy.Manage(fullParkingLot, parkingLot);
            var token = parkingBoy.Park(car);
            Assert.Same(car, parkingLot.Pick(token));
        }

        [Fact]
        public void should_be_able_to_pick_car()
        {
            parkingBoy.Manage(new ParkingLot());
            var car = new Car();
            var token = parkingBoy.Park(car);
            Assert.Same(car, parkingBoy.Pick(token));

        }

        [Fact]
        public void should_able_to_pick_car_in_second_parking_lots()
        {
            var secondParkingLot = new ParkingLot();
            parkingBoy.Manage(new ParkingLot(), secondParkingLot);
            var car = new Car();
            var ticket = secondParkingLot.Park(car);

            Assert.Same(car, parkingBoy.Pick(ticket));
        }
    }

}