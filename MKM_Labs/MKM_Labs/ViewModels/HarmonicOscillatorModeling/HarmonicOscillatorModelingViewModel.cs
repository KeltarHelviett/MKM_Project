using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MKM_Labs.ViewModels.HarmonicOscillatorModeling
{
    class HarmonicOscillatorModelingViewModel: INotifyPropertyChanged
    {
        #region PublicProperties

        private double omega = 1;

        public double Omega
        {
            get { return omega; }
            set
            {
                omega = value;
                rigidity = omega * mass;
                gerc = omega / (2 * Math.PI);
                OnPropertyChanged(nameof(Gerc));
                OnPropertyChanged(nameof(Rigidity));
                OnPropertyChanged(nameof(Omega));
            }
        }

        private double gerc = 1 / (2 * Math.PI);

        public double Gerc
        {
            get { return gerc; }
            set
            {
                gerc = value;
                omega = gerc * 2 * Math.PI;
                rigidity = omega * mass;
                OnPropertyChanged(nameof(Gerc));
                OnPropertyChanged(nameof(Rigidity));
                OnPropertyChanged(nameof(Omega));
            }
        }

        private double friction = 0.2;

        public double Friction
        {
            get { return friction; }
            set
            {
                friction = value;
                OnPropertyChanged(nameof(Friction));
            }
        }

        private double rigidity = 1;

        public double Rigidity
        {
            get { return rigidity; }
            set
            {
                rigidity = value;
                omega = rigidity / mass;
                gerc = omega / (2 * Math.PI);
                OnPropertyChanged(nameof(Rigidity));
                OnPropertyChanged(nameof(Omega));
                OnPropertyChanged(nameof(Gerc));
            }
        }

        private double mass = 1;

        public double Mass
        {
            get { return mass; }
            set
            {
                mass = value;
                Omega = rigidity / mass;
                gerc = omega / (2 * Math.PI);
                OnPropertyChanged(nameof(mass));
                OnPropertyChanged(nameof(Omega));
                OnPropertyChanged(nameof(Gerc));
            }
        }

        private double n = 10;

        public double N
        {
            get { return n; }
            set
            {
                if (n == value)
                    return;
                n = value;
                OnPropertyChanged(nameof(N));
            }
        }

        private double step = 0.25;

        public double Step
        {
            get { return step; }
            set
            {
                if (step == value)
                    return;
                step = value;
                OnPropertyChanged(nameof(Step));
            }
        }

        private bool isStep = true;

        public bool IsStep
        {
            get { return isStep; }
            set
            {
                if (isStep == value)
                    return;
                isStep = value;
                OnPropertyChanged(nameof(IsStep));
            }
        }

        private bool isN = false;

        public bool IsN
        {
            get { return isN; }
            set
            {
                if (isN == value)
                    return;
                isN = value;
                OnPropertyChanged(nameof(IsN));
            }
        }

        private double endTime = 10;

        public double EndTime
        {
            get { return endTime; }
            set
            {
                if (endTime == value)
                    return;
                endTime = value;
                OnPropertyChanged(nameof(endTime));
            }
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Calculate()
        {
            var steporn = step;
            if (!IsStep) steporn = N;

            var A = 4.0;
            var omega = 1.0;
            var t = 0.0;

            Func<double, double, double, double> Fa = delegate (double x, double v, double dt)
            {
                double omega_2 = Rigidity / Mass;
                double gamma = Friction;
                t += dt;

                return -omega_2 * x - gamma * v + A * Math.Cos(omega * t);
            };

            Func<double, double, double> Fe = delegate (double x, double v)
            {
                return (Mass*v*v + Rigidity*x*x)/2;
            };

            Func<double, double, double> Vsr = delegate (double lt, double alfa) { return 0; };

            var Res = MKM_Labs.MathUtils.EulerCromer(0, EndTime, steporn, IsStep, 0, 50, Fa, Fe, Vsr);
            (new MKM_Labs.Views.HarmonicOscillatorModeling.HarmonicOscillatorModelingResultView(Res)).Show();
        }

        public void Animate()
        {
            var A = 4.0;
            var omega = 1.0;
            var t = 0.0;

            Func<double, double, double, double> Fa = delegate (double x, double v, double dt)
            {
                double omega_2 = Rigidity / Mass;
                double gamma = Friction;
                t += dt;

                return -omega_2 * x - gamma * v + A * Math.Cos(omega * t);
            };

            (new MKM_Labs.Views.HarmonicOscillatorModeling.HarmonicOscillatorModelingAnimationView(0, 50, Fa)).Show();
        }
    }
}
