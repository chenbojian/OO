using System.Collections.Generic;
using System.Linq;

namespace OO
{
    public class ParkingManager
    {
        private readonly ParkingBoy stand = new ParkingBoy();
        private readonly List<ParkingBoy> managedParkingBoys = new List<ParkingBoy>();
        public object Park(Car car)
        {
            return stand.Park(car);
        }

        public void Manage(params ParkingLot[] parkingLots)
        {
            stand.Manage(parkingLots);
        }

        public Car Pick(object token)
        {
            return  stand.Pick(token);
        }


        public void Manage(params ParkingBoy[] parkingBoys)
        {
            managedParkingBoys.AddRange(parkingBoys);
        }

        public object LetParkingBoyPark(Car car)
        {
            foreach (var parkingBoy in managedParkingBoys)
            {
                var token = parkingBoy.Park(car);
                if (token != null)
                {
                    return token;
                }
            }
            return null;
        }

        public Car LetParkingBoyPick(object token)
        {
            foreach (var parkingBoy in managedParkingBoys)
            {
                var car = parkingBoy.Pick(token);
                if (car != null)
                {
                    return car;
                }
            }
            return null;
        }
    }
}