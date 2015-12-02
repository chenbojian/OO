using System;
using System.Collections.Generic;
using System.Linq;
using MoreLinq;

namespace OO
{
    public class ParkingBoy : IParkable, IPickable
    {
        private readonly List<ParkingLot> managedParkingLots = new List<ParkingLot>();
        private readonly Park<ParkingLot> park;
        private readonly Pick<ParkingLot> pick = PickStrategy.NormalPick;

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
            return pick(token, managedParkingLots);
        }

        public Statistic Statistic()
        {

            return new Statistic
            {
                What = "B",
                num = managedParkingLots.Sum(p => p.Capacity - p.EmptyNumber),
                sum = managedParkingLots.Sum(p => p.Capacity),
                children = managedParkingLots.Select(p => new Statistic
                {
                    What = "P",
                    num = p.Capacity - p.EmptyNumber,
                    sum = p.Capacity
                }).ToList()
            };

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