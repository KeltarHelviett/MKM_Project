using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKM_Labs
{
    static class MathUtils
    {
        public static List<double> EulerCromer(IEnumerable<double> xs, double y0, Func<double, double, double, double> f)
        {
            var ys = new List<double>();
            ys.Capacity = xs.Count();
            return null;
        }
    }
}
