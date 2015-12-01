using System.Collections.Generic;
using MoreLinq;

namespace OO
{
    public interface IParkable
    {
        object Park(Car car);
    }

    public delegate object Park<in T>(Car car, IEnumerable<T> parkableObjs) where T : IParkable;

    public static class ParkStrategy 
    {
        public static object NormalPark(Car car, IEnumerable<IParkable> parkableObjs)
        {
            foreach (var parkableObj in parkableObjs)
            {
                var token = parkableObj.Park(car);
                if (token != null)
                {
                    return token;
                }
            }
            return null;
        }

        public static object SmartPark(Car car, IEnumerable<ParkingLot> parkingLots)
        {
            var parkingLot = parkingLots.MaxBy(p => p.EmptyNumber);
            return parkingLot == null ? null : parkingLot.Park(car);
        }

        public static object SuperPark(Car car, IEnumerable<ParkingLot> parkingLots)
        {
            var parkingLot = parkingLots.MaxBy(p => p.EmptyRate);
            return parkingLot == null ? null : parkingLot.Park(car);
        }
    }
}