using System;
using System.Collections.Generic;

namespace OO
{
    public class ParkingLot
    {
        private readonly Dictionary<object, Car> carDict = new Dictionary<object, Car>();
        private int capacity;

        public ParkingLot(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException("capacity");
            }
            this.capacity = capacity;
        }

        public ParkingLot()
        {
            capacity = int.MaxValue;
        }

        public int EmptyNumber
        {
            get
            {
                return capacity - carDict.Count;                
            }
        }

        public double EmptyRate
        {
            get { return (double) EmptyNumber / capacity; }
        }

        public object Park(Car car)
        {
            if (carDict.Count >= capacity)
            {
                return null;
            }
            var token = new object();
            carDict.Add(token, car);
            return token;
        }

        public Car Pick(object token)
        {
            Car car;
            try
            {
                car = carDict.TryGetValue(token, out car) ? car : null;
                carDict.Remove(token);
            }
            catch (ArgumentNullException)
            {
                return null;
            }
            
            return car;
        }
    }
}