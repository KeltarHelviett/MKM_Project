using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKM_Labs
{
    static class MathUtils
    {
        public static Tuple<List<double>, List<double>, List<double>> AnaliticalAns(double t0, double endt, Func<double, double> fy, Func<double, double> fv)
        {
            var step = 100;
            var ts = new List<double>();

            for (int i = 0; i < step; ++i)
            {
                ts.Add(t0 + i * (endt - t0) / step);
            }
            var ys = new List<double> { Capacity = ts.Count() };
            var vs = new List<double> { Capacity = ts.Count() };
            for (int i = 0; i < step; ++i)
            {
                vs.Add(fy(ts[i]));
                ys.Add(fv(ts[i]));
            }
            return Tuple.Create(ts, ys, vs);
        }

        private static Tuple<List<double>, List<double>, List<double>> EulerCromer(List<double> ts,
            double y0, double v0, Func<double, double, double, double> f)
        {
            var ys = new List<double> {Capacity = ts.Count()};
            ys.Add(y0);
            var vs = new List<double> {Capacity = ts.Count()};
            vs.Add(v0);
            for (int i = 0; i < ts.Count() - 1; ++i)
            {
                var deltat = ts[i + 1] - ts[i];
                vs.Add(vs[i] + deltat * f(ys[i], vs[i], deltat));
                ys.Add(ys[i] + deltat * vs[i + 1]);
            }
            return Tuple.Create(ts, ys, vs);
        }

        public static Tuple<List<double>, List<double>, List<double>> EulerCromer(double t0, double endt,
            double steporn, bool isStep, double y0, double v0, Func<double, double, double, double> f)
        {
            if (!isStep)
                steporn = (endt - t0) / (steporn - 1);
            var ts = new List<double>();
            for (var i = 0; steporn * i <= endt; ++i)
                ts.Add(steporn * i); 
            return EulerCromer(ts, y0, v0, f);
        }
    }
}
