using System;
using System.Collections.Generic;
using MoreLinq;

namespace OO
{
    public class ParkingBoy : IParkable
    {
        private readonly List<ParkingLot> managedParkingLots = new List<ParkingLot>();
        private readonly Park<ParkingLot> park;

        public ParkingBoy()
        {
            park = ParkStrategy.NormalPark;
        }

        private ParkingBoy(Park<ParkingLot> park)
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

        public static ParkingBoy SmartEvolution()
        {
            return new ParkingBoy(ParkStrategy.SmartPark);
        }

        public static ParkingBoy SuperEvolution()
        {
            return new ParkingBoy(ParkStrategy.SuperPark);
        }
    }
}