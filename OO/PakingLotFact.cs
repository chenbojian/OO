using System;
using Xunit;

namespace OO
{
    public class PakingLotFact
    {
        private readonly ParkingLot parkingLot;

        public PakingLotFact()
        {
            parkingLot = new ParkingLot();
        }

        [Fact]
        public void should_pick_car_after_park_car_as_a_parking_lot()
        {
            var car = new Car();
            var token = parkingLot.Park(car);
            Assert.Same(car, parkingLot.Pick(token));
        }

        [Fact]
        public void should_pick_two_cars_sequence_after_park_them()
        {
            var car = new Car();
            var anotherCar = new Car();
            var carToken = parkingLot.Park(car);
            var anotherCarToken = parkingLot.Park(anotherCar);
            Assert.Same(car, parkingLot.Pick(carToken));
            Assert.Same(anotherCar, parkingLot.Pick(anotherCarToken));
        }

        [Fact]
        public void should_not_pick_the_car_after_pick()
        {
            var car = new Car();
            var token = parkingLot.Park(car);
            parkingLot.Pick(token);
            Assert.Null(parkingLot.Pick(token));
        }

        [Fact]
        public void should_not_pick_car_if_token_is_not_correct()
        {
            parkingLot.Park(new Car());
            Assert.Null(parkingLot.Pick(null));
        }

        [Fact]
        public void should_return_null_if_try_park_to_full_parkinglot()
        {
            var fullParkingLot = new ParkingLot(1);
            fullParkingLot.Park(new Car());

            Assert.Null(fullParkingLot.Park(new Car()));
        }

        [Fact]
        public void should_able_to_park_a_car_after_pick_a_car()
        {
            var fullParkingLot = new ParkingLot(1);
            fullParkingLot.Pick(fullParkingLot.Park(new Car()));

            Assert.NotNull(fullParkingLot.Park(new Car()));
        }

        [Fact]
        public void should_not_have_a_negative_capacity_parkinglot()
        {
            Assert.Throws(typeof (ArgumentOutOfRangeException), () => new ParkingLot(-1));
        }
    }
}
