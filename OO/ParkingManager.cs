using System.Collections.Generic;
using System.Linq;

namespace OO
{
    public class ParkingManager
    {
        private readonly ParkingBoy stand = new ParkingBoy();
        private readonly List<ParkingBoy> managedParkingBoys = new List<ParkingBoy>();
        private readonly Park<ParkingBoy> park;
        private readonly Pick<ParkingBoy> pick = PickStrategy.NormalPick;

        public ParkingManager()
        {
            park = ParkStrategy.NormalPark;
        }

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
            return park(car, managedParkingBoys) ?? stand.Park(car);
        }

        public Car Pick(object token)
        {
            return  pick(token, managedParkingBoys) ?? stand.Pick(token);
        }

        public Statistic Statistic()
        {
            var statistics = new List<Statistic>();
            statistics.AddRange(stand.Statistic().children);
            statistics.AddRange(managedParkingBoys.Select(b => b.Statistic()));
            return new Statistic
            {
                What = "M",
                num = statistics.Sum(s=>s.num),
                sum = statistics.Sum(s=>s.sum),
                children = statistics
            };
        }
    }
}