using Xunit;

namespace OO
{
    public class SmartParkingBoyFact
    {
        private readonly ParkingBoy smartParkingBoy;

        public SmartParkingBoyFact()
        {
            smartParkingBoy = ParkingBoy.SmartEvolution();
        }

        [Fact]
        public void should_park_car_correctly()
        {
            var car = new Car();
            var parkingLot = new ParkingLot();
            smartParkingBoy.Manage(parkingLot);
            var token = smartParkingBoy.Park(car);
            Assert.Same(car, parkingLot.Pick(token));
        }

        [Fact]
        public void should_park_cars_to_most_empty_parkinglot()
        {
            var car = new Car();
            var parkingLot = new ParkingLot(3);
            var moreEmptyParkingLot = new ParkingLot(4);
            smartParkingBoy.Manage(parkingLot, moreEmptyParkingLot);
            var token = smartParkingBoy.Park(car);
            Assert.Same(car, moreEmptyParkingLot.Pick(token));
        }

        [Fact]
        public void should_be_able_to_pick_car()
        {
            smartParkingBoy.Manage(new ParkingLot());
            var car = new Car();
            var token = smartParkingBoy.Park(car);
            Assert.Same(car, smartParkingBoy.Pick(token));

        }

        [Fact]
        public void should_able_to_pick_car_in_second_parking_lots()
        {
            var secondParkingLot = new ParkingLot();
            smartParkingBoy.Manage(new ParkingLot(), secondParkingLot);
            var car = new Car();
            var ticket = secondParkingLot.Park(car);

            Assert.Same(car, smartParkingBoy.Pick(ticket));
        }

        [Fact]
        public void should_be_able_to_park_car_when_two_same_empty_parkinglots()
        {
            smartParkingBoy.Manage(new ParkingLot(5), new ParkingLot(5));
            var car = new Car();
            var token = smartParkingBoy.Park(car);
            Assert.Same(car, smartParkingBoy.Pick(token));
            
        }
    }
} 
