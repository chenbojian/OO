using Xunit;

namespace OO
{
    public class ParkingManagerFact
    {
        private readonly ParkingManager parkingManager;

        public ParkingManagerFact()
        {
            parkingManager = new ParkingManager();
        }

        [Fact]
        public void should_park_car_correctly()
        {
            var car = new Car();
            var parkingLot = new ParkingLot();
            parkingManager.Manage(parkingLot);
            var token = parkingManager.Park(car);
            Assert.Same(car, parkingLot.Pick(token));
        }

        [Fact]
        public void should_able_to_park_cars()
        {
            var car = new Car();
            parkingManager.Manage(new ParkingLot(), new ParkingLot());
            var token = parkingManager.Park(car);
            Assert.Same(car, parkingManager.Pick(token));
        }

        [Fact]
        public void should_be_able_to_pick_car()
        {
            parkingManager.Manage(new ParkingLot());
            var car = new Car();
            var token = parkingManager.Park(car);
            Assert.Same(car, parkingManager.Pick(token));

        }

        [Fact]
        public void should_able_to_pick_car_in_second_parking_lots()
        {
            var secondParkingLot = new ParkingLot();
            parkingManager.Manage(new ParkingLot(), secondParkingLot);
            var car = new Car();
            var ticket = secondParkingLot.Park(car);

            Assert.Same(car, parkingManager.Pick(ticket));
        }

        [Fact]
        public void should_able_to_let_his_parking_boy_to_park_car()
        {
            var parkingBoy = new ParkingBoy();
            var parkingLot = new ParkingLot();
            parkingBoy.Manage(parkingLot);
            parkingManager.Manage(parkingBoy);
            var car = new Car();
            var token = parkingManager.Park(car);
            Assert.Same(car, parkingBoy.Pick(token));
        }

        [Fact]
        public void should_able_to_let_his_parking_boy_to_pick_car()
        {
            var parkingBoy = new ParkingBoy();
            var parkingLot = new ParkingLot();
            parkingBoy.Manage(parkingLot);
            parkingManager.Manage(parkingBoy);
            var car = new Car();
            var token = parkingBoy.Park(car);
            Assert.Same(car, parkingManager.Pick(token));
        }

        [Fact]
        public void should_able_to_let_his_parking_boy_who_has_availible_parking_lot_to_park_cars()
        {
            var parkingBoy = new ParkingBoy();
            var smartParkingBoy = ParkingBoy.SmartEvolution();
            parkingBoy.Manage(new ParkingLot(1));
            smartParkingBoy.Manage(new ParkingLot(1));

            parkingManager.Manage(parkingBoy, smartParkingBoy);

            var car = new Car();
            parkingBoy.Park(new Car());
            var tokenOfParkingBoy = parkingManager.Park(car);
            Assert.Same(car, smartParkingBoy.Pick(tokenOfParkingBoy));
        }

    }
}