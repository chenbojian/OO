using System.Collections.Generic;
using System.Linq;

namespace OO
{
    public class ParkingManager
    {
        private readonly ParkingBoy stand = new ParkingBoy();
        private readonly List<ParkingBoy> managedParkingBoys = new List<ParkingBoy>();

        public void Manage(params ParkingLot[] parkingLots)
        {
            stand.Manage(parkingLots);
        }

        public void Manage(params ParkingBoy[] parkingBoys)
        {
            managedParkingBoys.AddRange(parkingBoys);
        }

        public object Park(Car car)
        {
            foreach (var parkingBoy in managedParkingBoys)
            {
                var token = parkingBoy.Park(car);
                if (token != null)
                {
                    return token;
                }
            }
            return stand.Park(car);
        }

        public Car Pick(object token)
        {
            foreach (var parkingBoy in managedParkingBoys)
            {
                var car = parkingBoy.Pick(token);
                if (car != null)
                {
                    return car;
                }
            }
            return  stand.Pick(token);
        }
    }
}