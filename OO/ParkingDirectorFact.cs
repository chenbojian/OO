using Xunit;

namespace OO
{
    public class ParkingDirectorFact
    {
        [Fact]
        public void should_report_for_a_parking_manager_who_only_have_one_parking_lot()
        {
            var parkingManager = new ParkingManager();
            parkingManager.Manage(new ParkingLot(5));
            var parkingDirector = new ParkingDirector();

            Assert.Equal("M 0 5\n  P 0 5", parkingDirector.Report(parkingManager));
        }

        [Fact]
        public void should_report_for_a_parking_manager_who_only_have_some_parking_lots()
        {
            var parkingManager = new ParkingManager();
            parkingManager.Manage(new ParkingLot(5),new ParkingLot(4));
            var parkingDirector = new ParkingDirector();

            Assert.Equal("M 0 9\n  P 0 5\n  P 0 4", parkingDirector.Report(parkingManager));
        }

        [Fact]
        public void should_report_for_a_parking_manager_who_has_one_parking_lot_and_one_parking_boy_with_one_parking_lot()
        {
            var parkingManager = new ParkingManager();
            parkingManager.Manage(new ParkingLot(5));
            var parkingBoy = new ParkingBoy();
            parkingBoy.Manage(new ParkingLot(10));
            parkingManager.Manage(parkingBoy);
            var parkingDirector = new ParkingDirector();

            Assert.Equal("M 0 15\n  P 0 5\n  B 0 10\n    P 0 10", parkingDirector.Report(parkingManager));
        }

        [Fact]
        public void should_report_for_a_parking_manager_who_has_one_parking_lot_and_two_parking_boys_with_one_parking_lot()
        {
            var parkingManager = new ParkingManager();
            parkingManager.Manage(new ParkingLot(5));
            var parkingBoy = new ParkingBoy();
            parkingBoy.Manage(new ParkingLot(10));
            parkingManager.Manage(parkingBoy,new ParkingBoy());
            var parkingDirector = new ParkingDirector();

            Assert.Equal("M 0 15\n  P 0 5\n  B 0 10\n    P 0 10\n  B 0 0", parkingDirector.Report(parkingManager));
        }
    }
}