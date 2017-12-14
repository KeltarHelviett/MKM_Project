using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MKM_Labs.ViewModels.ProbabilityTheory
{
    class ProbabilityTheoryViewModel: INotifyPropertyChanged
    {
        #region PublicProperties

        private int n = 3;

        public int N
        {
            get { return n; }
            set
            {
                n = value;
                OnPropertyChanged(nameof(N));
            }
        }

        private double r = 3;

        public double R
        {
            get { return r; }
            set
            {
                r = value;
                OnPropertyChanged(nameof(R));
            }
        }

        private int cec = 3;

        public int CEC
        {
            get { return cec; }
            set
            {
                cec = value;
                OnPropertyChanged(nameof(CEC));
            }
        }

        private int _gec = 3;

        public int GEC
        {
            get { return _gec; }
            set
            {
                _gec = value;
                OnPropertyChanged(nameof(GEC));
            }
        }

        private double ca = 3;

        public double CA
        {
            get { return ca; }
            set
            {
                ca = value;
                OnPropertyChanged(nameof(CA));
            }
        }

        private double ga = 3;

        public double GA
        {
            get { return ga; }
            set
            {
                ga = value;
                OnPropertyChanged(nameof(GA));
            }
        }

        private double cea = 3;

        public double CEA
        {
            get { return cea; }
            set
            {
                cea = value;
                OnPropertyChanged(nameof(CEA));
            }
        }

        private double gea = 3;

        public double GEA
        {
            get { return gea; }
            set
            {
                gea = value;
                OnPropertyChanged(nameof(GEA));
            }
        }

        #endregion

        public void CalculateClassicTask()
        {
            var rnd = new Random();
            cea = 0;
            for (var i = 0; i < CEC; ++i)
            {
                var remaining = N;
                var boxes = Enumerable.Repeat(0, N).ToList();
                while (remaining != 0)
                {
                    for (var j = 0; j < N; ++j)
                    {
                        var rndNumber = rnd.Next(0, remaining + 1);
                        remaining -= rndNumber;
                        boxes[j] = rndNumber;
                    }
                }
                if (boxes.Count(s => s == 0) == 1)
                    cea++;
            }
            CEA = cea / CEC;
        }

        public void CalculateGeometryTask()
        {
            var rnd = new Random();
            gea = 0;
            for (var i = 0; i < GEC; ++i)
            {
                var angle = rnd.NextDouble() * (2 * Math.PI);
                var distance = rnd.NextDouble() * (5 * r);
                if (5 * r >= distance && distance >= 4 * r) gea++;
                else if (3 * r >= distance && distance >= 2 * r) gea++;
                else if (distance <= r) gea++;
            }
            GEA = gea / GEC;
            GA = 3.0 / 5;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
