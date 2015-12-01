using System.Collections.Generic;

namespace OO
{
    public interface IPickable
    {
        Car Pick(object token);
    }

    public delegate Car Pick<in T>(object token, IEnumerable<T> pickableObjs) where T : IPickable;

    public static class PickStrategy
    {
        public static Car NormalPick(object token, IEnumerable<IPickable> pickableObjs)
        {
            foreach (var pickableObj in pickableObjs)
            {
                var car = pickableObj.Pick(token);
                if (car != null)
                {
                    return car;
                }
            }
            return null;
        }
    }
}