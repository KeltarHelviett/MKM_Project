using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKM_Labs
{
    static class MathUtils
    {
        private static Tuple<List<double>, List<double>, List<double>, List<double>> EulerCromer(List<double> ts,
            double y0, double v0, Func<double, double, double, double> a, Func<double, double, double> e,
            Func<double, double, double> Vsr)
        {
            var ys = new List<double> { Capacity = ts.Count() };
            ys.Add(y0);
            var vs = new List<double> { Capacity = ts.Count() };
            vs.Add(v0 + Vsr(0, y0));
            var es = new List<double> { Capacity = ts.Count() };
            es.Add(e(y0, v0));
            for (int i = 0; i < ts.Count() - 1; ++i)
            {
                var deltat = ts[i + 1] - ts[i];
                vs.Add( vs[i] + deltat * a(ys[i], vs[i], deltat) + Vsr(i * deltat, ys[i]) );
                ys.Add( ys[i] + deltat * vs[i + 1] );
                es.Add( e(ys[i + 1], vs[i + 1]) );
            }
            return Tuple.Create(ts, ys, vs, es);
        }

        public static Tuple<List<double>, List<double>, List<double>, List<double>> EulerCromer(double t0, double endt,
            double steporn, bool isStep, double y0, double v0, Func<double, double, double, double> a, Func<double, double, double> e,
            Func<double, double, double> vsr)
        {
            if (!isStep)
                steporn = (endt - t0) / (steporn - 1);
            var ts = new List<double>();
            for (var i = 0; steporn * i <= endt; ++i)
                ts.Add(steporn * i);
            return EulerCromer(ts, y0, v0, a, e, vsr);
        }
    }
}
