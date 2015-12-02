using System.Collections.Generic;
using System.Linq;

namespace OO
{
    public class ParkingDirector
    {
        public string Report(ParkingManager parkingManager)
        {
            var statistic = parkingManager.Statistic();
            return Stringfy(statistic);
        }

        private string Stringfy(Statistic statistic)
        {
            var reportResult = "";
            reportResult += string.Format("{0} {1} {2}", statistic.What, statistic.num, statistic.sum);
            foreach (var child in statistic.children)
            {
                if (child.What == "P")
                {
                    reportResult += string.Format("\n  {0} {1} {2}", child.What, child.num, child.sum);
                }
                if (child.What == "B")
                {
                    reportResult += string.Format("\n  {0} {1} {2}", child.What, child.num, child.sum);
                    foreach (var childchild in child.children)
                    {
                        reportResult += string.Format("\n    {0} {1} {2}", childchild.What, childchild.num, childchild.sum);
                    }
                }

            }
            return reportResult;
        }
    }

    public class Statistic
    {
        public string What;
        public int num;
        public int sum;
        public List<Statistic> children;
    }
}