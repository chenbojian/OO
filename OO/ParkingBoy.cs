using System;
using System.Collections.Generic;
using MoreLinq;

namespace OO
{
    public class ParkingBoy
    {
        private readonly List<ParkingLot> managedParkingLots = new List<ParkingLot>();
        private readonly Park park;

        public ParkingBoy()
        {
            park = NormalPark;
        }

        private ParkingBoy(Park park)
        {
            this.park = park;
        }

        public void Manage(params ParkingLot[] parkingLots)
        {
            managedParkingLots.AddRange(parkingLots);
        }

        public object Park(Car car)
        {
            return park(car, managedParkingLots);
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

        private static object NormalPark(Car car, IEnumerable<ParkingLot> parkingLots)
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

        private static object SmartPark(Car car, IEnumerable<ParkingLot> parkingLots)
        {
            var parkingLot = parkingLots.MaxBy(p => p.EmptyNumber);
            return parkingLot == null ? null : parkingLot.Park(car);
        }

        private static object SuperPark(Car car, IEnumerable<ParkingLot> parkingLots)
        {
            var parkingLot = parkingLots.MaxBy(p => p.EmptyRate);
            return parkingLot == null ? null : parkingLot.Park(car);
        }

        public static ParkingBoy SmartEvolution()
        {
            return new ParkingBoy(SmartPark);
        }

        public static ParkingBoy SuperEvolution()
        {
            return new ParkingBoy(SuperPark);
        }
    }

    internal delegate object Park(Car car, IEnumerable<ParkingLot> parkingLots);
}