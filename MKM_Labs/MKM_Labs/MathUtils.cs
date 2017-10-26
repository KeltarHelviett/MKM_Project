using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKM_Labs
{
    static class MathUtils
    {
        public static Tuple<List<double>, List<Tuple<double, double>>, List<Tuple<double, double>>> AnaliticalAns(double t0, double endt, double steporn, bool isStep,
            Func<double, Tuple<double, double>> fy, Func<double, Tuple<double, double>> fv)
        {
            if (!isStep)
                steporn = (endt - t0) / (steporn - 1);

            var ts = new List<double>();

            for (var i = 0; steporn * i <= endt; ++i)
                ts.Add(steporn * i);

            var cs = new List<Tuple<double, double>> { Capacity = ts.Count() };
            var vs = new List<Tuple<double, double>> { Capacity = ts.Count() };
            for (int i = 0; i < ts.Count; ++i)
            {
                

                var c = fy(ts[i]);
                if (c.Item1 < 0)
                {
                    vs.Add(new Tuple<double, double>(0, 0));
                    cs.Add(new Tuple<double, double>(0, cs[i - 1].Item2));
                }
                cs.Add(c);
                vs.Add(fv(ts[i]));
            }
            return Tuple.Create(ts, cs, vs);
        }

        private static Tuple<List<double>, List<double>, List<double>> EulerCromer(List<double> ts,
            double y0, double v0, Func<double, double, double, double> f, bool isV)
        {
            var ys = new List<double> {Capacity = ts.Count()};
            ys.Add(y0);
            var vs = new List<double> {Capacity = ts.Count()};
            vs.Add(v0);
            for (int i = 0; i < ts.Count() - 1; ++i)
            {
                var deltat = ts[i + 1] - ts[i];
                vs.Add(vs[i] + deltat * f(ys[i], vs[i], deltat));

                var h = ys[i] + deltat * vs[i + 1];
                if (h < 0 && isV) h = 0;
                ys.Add(h);
            }
            return Tuple.Create(ts, ys, vs);
        }

        public static Tuple<List<double>, List<Tuple<double, double>>, List<Tuple<double, double>>> EulerCromer(double t0, double endt,
            double steporn, bool isStep, double y0, double v0y, double x0, double v0x, 
            Func<double, double, double, double> fx, Func<double, double, double, double> fy)
        {
            if (!isStep)
                steporn = (endt - t0) / (steporn - 1);
            var ts = new List<double>();
            for (var i = 0; steporn * i <= endt; ++i)
                ts.Add(steporn * i); 
            var y = EulerCromer(ts, y0, v0y, fy, true);
            var x = EulerCromer(ts, x0, v0x, fx, false);

            var cs = new List<Tuple<double, double>> { Capacity = ts.Count() };
            var vs = new List<Tuple<double, double>> { Capacity = ts.Count() };

            for (int i = 0; i < ts.Count; ++i)
            {
                cs.Add(new Tuple<double, double>(x.Item2[i], y.Item3[i]));
                vs.Add(new Tuple<double, double>(x.Item2[i], y.Item3[i]));
            }

            return Tuple.Create(x.Item1, cs, vs);
        }
    }
}
