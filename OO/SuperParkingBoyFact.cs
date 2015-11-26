using Xunit;

namespace OO
{
    public class SuperParkingBoyFact
    {
         
        private readonly ParkingBoy superParkingBoy;

        public SuperParkingBoyFact()
        {
            superParkingBoy = ParkingBoy.SuperEvolution();
        }

        [Fact]
        public void should_park_car_correctly()
        {
            var car = new Car();
            var parkingLot = new ParkingLot();
            superParkingBoy.Manage(parkingLot);
            var token = superParkingBoy.Park(car);
            Assert.Same(car, parkingLot.Pick(token));
        }

        [Fact]
        public void should_park_cars_to_max_empty_rate_parkinglot()
        {
            var car = new Car();
            var parkingLot = new ParkingLot(5);
            var moreEmptyRateParkingLot = new ParkingLot(3);
            parkingLot.Park(new Car());
            superParkingBoy.Manage(parkingLot, moreEmptyRateParkingLot);
            var token = superParkingBoy.Park(car);
            Assert.Same(car, moreEmptyRateParkingLot.Pick(token));
        }

        [Fact]
        public void should_be_able_to_pick_car()
        {
            superParkingBoy.Manage(new ParkingLot());
            var car = new Car();
            var token = superParkingBoy.Park(car);
            Assert.Same(car, superParkingBoy.Pick(token));

        }

        [Fact]
        public void should_able_to_pick_car_in_second_parking_lots()
        {
            var secondParkingLot = new ParkingLot();
            superParkingBoy.Manage(new ParkingLot(), secondParkingLot);
            var car = new Car();
            var ticket = secondParkingLot.Park(car);

            Assert.Same(car, superParkingBoy.Pick(ticket));
        }

        [Fact]
        public void should_be_able_to_park_car_when_two_same_empty_rate_parkinglots()
        {
            superParkingBoy.Manage(new ParkingLot(5), new ParkingLot(5));
            var car = new Car();
            var token = superParkingBoy.Park(car);
            Assert.Same(car, superParkingBoy.Pick(token));
            
        }
    }
}