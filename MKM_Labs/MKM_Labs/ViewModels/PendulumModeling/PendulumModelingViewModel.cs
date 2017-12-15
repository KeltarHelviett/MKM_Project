using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MKM_Labs.ViewModels.PendulumModeling
{
    class PendulumModelingViewModel: INotifyPropertyChanged
    {

        #region PublicProperties

        private bool isSmallAngleEquation = true;

        public bool IsSmallAngleEquation
        {
            get { return isSmallAngleEquation; }
            set
            {
                isSmallAngleEquation = value;
                OnPropertyChanged(nameof(IsSmallAngleEquation));
            }
        }

        private bool isAnyAngleEquation;

        public bool IsAnyAngleEquation
        {
            get { return isAnyAngleEquation; }
            set
            {
                isAnyAngleEquation = value;
                OnPropertyChanged(nameof(IsAnyAngleEquation));
            }
        }

        private double barLength = 1; // Длина стержня L

        public double BarLength
        {
            get { return barLength; }
            set
            {
                barLength = value;
                OnPropertyChanged(nameof(BarLength));
            }
        }

        private double initialSpeed = 2; // Нач. скорость V₀

        public double InitialSpeed
        {
            get { return initialSpeed; }
            set
            {
                initialSpeed = value;
                OnPropertyChanged(nameof(InitialSpeed));
            }
        }

        private double initialAngle = 3; // Нач. угол θ₀

        public double InitialAngle
        {
            get { return initialAngle; }
            set
            {
                initialAngle = value;
                OnPropertyChanged(nameof(InitialAngle));
            }
        }

        private double mass = 3;

        public double Mass
        {
            get { return mass; }
            set
            {
                mass = value;
                OnPropertyChanged(nameof(Mass));
            }
        }

        private double constU = 3; // Постоянная компонента скорости среды U_const

        public double ConstU
        {
            get { return constU; }
            set
            {
                constU = value;
                OnPropertyChanged(nameof(ConstU));
            }
        }

        private double initialEnvSpeed = 3; // U₀ нач. скорость среды

        public double InitialEnvSpeed
        {
            get { return initialEnvSpeed; }
            set
            {
                initialEnvSpeed = value;
                OnPropertyChanged(nameof(InitialEnvSpeed));
            }
        }

        private double harmonicFrequency = 8; // Ω₀ переменная (гармоническая) частота

        public double HarmonicFrequency
        {
            get { return harmonicFrequency; }
            set
            {
                harmonicFrequency = value;
                OnPropertyChanged(nameof(HarmonicFrequency));
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
            double g = 9.81;

            Func<double, double, double, double> Fa = delegate (double alfa, double w, double dt)
            {
                if (IsAnyAngleEquation) { return -g / barLength * Math.Sin(alfa); }
                else { return -g / barLength * alfa; }
            };

            Func<double, double, double> Fe = delegate (double alfa, double w)
            {
                return Mass * g * barLength*( 1 - Math.Cos(alfa) ) + Mass * BarLength * BarLength / 2 * w*w;
            };

            Func<double, double, double> Vsr = delegate (double t, double alfa)
            {
                return (ConstU + initialEnvSpeed*Math.Cos(HarmonicFrequency* t)) * Math.Cos(alfa) / barLength;
            };

            var Res = MKM_Labs.MathUtils.EulerCromer(0, EndTime, steporn, IsStep, InitialAngle, InitialSpeed, Fa, Fe, Vsr);
            (new MKM_Labs.Views.PendulumModeling.PendulumModelingResultView(Res)).Show();
        }

        //public void Animate()
        //{
        //    var A = 4.0;
        //    var omega = 1.0;
        //    var t = 0.0;

        //    Func<double, double, double, double> Fa = delegate (double x, double v, double dt)
        //    {
        //        double omega_2 = Rigidity / Mass;
        //        double gamma = Friction;
        //        t += dt;

        //        return -omega_2 * x - gamma * v + A * Math.Cos(omega * t);
        //    };

        //    (new MKM_Labs.Views.HarmonicOscillatorModeling.HarmonicOscillatorModelingAnimationView(0, 50, Fa)).Show();
        //}

    }
}
