using System.Collections.Generic;
using MoreLinq;

namespace OO
{
    public class ParkingBoy
    {
        private readonly List<ParkingLot> managedParkingLots = new List<ParkingLot>();
        private readonly IParkability parkability;

        public ParkingBoy()
        {
            parkability = new NormalParkability();
        }

        private ParkingBoy(IParkability parkability)
        {
            this.parkability = parkability;
        }

        public void Manage(params ParkingLot[] parkingLots)
        {
            managedParkingLots.AddRange(parkingLots);
        }

        public object Park(Car car)
        {
            return parkability.Park(car, managedParkingLots);
        }

        public Car Pick(object token)
        {
            foreach (var parkingLot in managedParkingLots)
            {
                var car = parkingLot.Pick(token);
                if (car != null)
                {
                    return car;
                }
            }
            return null;
        }

        private class NormalParkability: IParkability
        {
            public object Park(Car car, IEnumerable<ParkingLot> parkingLots)
            {
                foreach (var parkingLot in parkingLots)
                {
                    var token = parkingLot.Park(car);
                    if (token != null)
                    {
                        return token;
                    }
                }
                return null;
            }
        }

        private class SmartParkability : IParkability
        {
            public object Park(Car car, IEnumerable<ParkingLot> parkingLots)
            {
                var mostEmptyParkingLot = parkingLots.MaxBy(p => p.EmptyNumber);
                return mostEmptyParkingLot == null ? null : mostEmptyParkingLot.Park(car);
            }
        }

        public static ParkingBoy SmartEvolution()
        {
            return new ParkingBoy(new SmartParkability());
        }

        public static ParkingBoy SuperEvolution()
        {
            return new ParkingBoy(new SuperParkability());
        }
    }

    public class SuperParkability : IParkability
    {
        public object Park(Car car, IEnumerable<ParkingLot> parkingLots)
        {
            var parkingLot = parkingLots.MaxBy(p => p.EmptyRate);
            return parkingLot == null ? null : parkingLot.Park(car);
        }
    }

    interface IParkability
    {
        object Park(Car car, IEnumerable<ParkingLot> parkingLots);
    }
}