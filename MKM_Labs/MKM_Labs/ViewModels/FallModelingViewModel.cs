using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MKM_Labs.Views;

namespace MKM_Labs.ViewModels
{
    class ExperimentItem
    {
        public List<Tuple<List<double>, List<double>, List<double>>> Solutions { set; get; }
        public string Content;
    }

    class FallModelingViewModel: INotifyPropertyChanged
    {

        #region PublicProperties

        private double height = 100;

        public double Height
        {
            get { return height; }
            set
            {
                if (value == height)
                    return;
                height = value;
                OnPropertyChanged(nameof(Height));
            }
        }

        private double volume = 10;

        public double Volume
        {
            get { return volume; }
            set
            {
                if (value == volume)
                    return;
                volume = value;
                OnPropertyChanged(nameof(Volume));
            }
        }

        private double densityEnv = 1000;

        public double DensityEnv
        {
            get { return densityEnv; }
            set
            {
                if (value == densityEnv)
                    return;
                densityEnv = value;
                OnPropertyChanged(nameof(DensityEnv));
            }
        }

        private double initialSpeed = 0;

        public double InitialSpeed
        {
            get { return initialSpeed; }
            set
            {
                if (value == initialSpeed)
                    return;
                initialSpeed = value;
                OnPropertyChanged(nameof(InitialSpeed));
            }
        }

        private double initialTime = 0;

        public double InitialTime
        {
            get { return initialTime; }
            set
            {
                if (value == initialTime)
                    return;
                initialTime = value;
                OnPropertyChanged(nameof(InitialTime));
            }
        }

        private double endTime = 10;

        public double EndTime
        {
            get { return endTime; }
            set
            {
                if (value == endTime)
                    return;
                endTime = value;
                OnPropertyChanged(nameof(EndTime));
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

        private double gravity = 9.81;

        public double Gravity
        {
            get { return gravity; }
            set
            {
                if (gravity == value)
                    return;
                gravity = value;
                OnPropertyChanged(nameof(Gravity));
            }
        }

        private double archimedeStrength = 0;
        
        public double ArchimedeStrength
        {
            get { return archimedeStrength; }
            set
            {
                if (archimedeStrength == value)
                    return;
                archimedeStrength = value;
                OnPropertyChanged(nameof(ArchimedeStrength));
            }
        }

        private double linearSpeed = 0;

        public double LinearSpeed
        {
            get { return linearSpeed; }
            set
            {
                if (linearSpeed == value)
                    return;
                linearSpeed = value;
                OnPropertyChanged(nameof(LinearSpeed));
            }
        }

        private double squareSpeed = 0;

        public double SquareSpeed
        {
            get { return squareSpeed; }
            set
            {
                if (squareSpeed == value)
                    return;
                squareSpeed = value;
                OnPropertyChanged(nameof(SquareSpeed));
            }
        }

        private bool isArchimede = false;

        public bool IsArchimede
        {
            get { return isArchimede; }
            set
            {
                if (isArchimede == value)
                    return;
                isArchimede = value;
                OnPropertyChanged(nameof(IsArchimede));
            }
        }

        private bool isLinear = false;

        public bool IsLinear
        {
            get { return isLinear; }
            set
            {
                isLinear = value;
                if (isLinear)
                    IsSquare = false;
                OnPropertyChanged(nameof(IsLinear));
            }
        }

        private bool isSquare = false;

        public bool IsSquare
        {
            get { return isSquare; }
            set
            {
                isSquare = value;
                if (isSquare)
                    IsLinear = false;
                OnPropertyChanged(nameof(IsSquare));
            }
        }

        private double mass = 0.3;

        public double Mass
        {
            get { return mass; }
            set
            {
                if (mass == value)
                    return;
                mass = value;
                OnPropertyChanged(nameof(Mass));
            }
        }

        private ObservableCollection<ExperimentItem> experimentsItems = new ObservableCollection<ExperimentItem>();

        public ObservableCollection<ExperimentItem> ExperimentItems
        {
            get { return experimentsItems; }
            set
            {
                if (value == experimentsItems)
                    return;
                experimentsItems = value;
                OnPropertyChanged(nameof(ExperimentItems));
            }
        }


        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region PublicMethods

        public void Calculate()
        {
            var steporn = step;
            if (!IsStep) steporn = N;

            Func<double, double, double, double> f = delegate (double y, double v, double dt) {
                var tmp = (1 + y/64000000) * (1 + y / 64000000);

                double res = -Gravity / tmp;
                if (IsArchimede)
                {
                    res += DensityEnv * Volume / (Mass) * Gravity;
                }

                if (IsLinear)
                {
                    res -= LinearSpeed * v / Mass;
                }

                if (IsSquare)
                {
                    res -= SquareSpeed * Math.Abs(v) * v / Mass;
                }

                return res;
            };

            var Res = MKM_Labs.MathUtils.EulerCromer(InitialTime, EndTime, steporn, IsStep, Height, InitialSpeed, f);

            if ( IsArchimede && !IsLinear && !IsSquare )
            {
                var newg = Gravity * (1 - DensityEnv * Volume / Mass);
                Func<double, double> fy = delegate (double t) {
                    
                    return Height + InitialSpeed*t - (newg /2)*t*t;
                };

                Func<double, double> fv = delegate (double t) {
                    return InitialSpeed - newg * t;
                };

                var analiticalAns = MKM_Labs.MathUtils.AnaliticalAns(InitialTime, EndTime, steporn, IsStep, fy, fv);
                ExperimentItems.Add(new ExperimentItem
                {
                    Content = "Lolkek",
                    Solutions = new List<Tuple<List<double>, List<double>, List<double>>> { Res, analiticalAns }
                });

                (new FallModelingResultView(Res, analiticalAns)).Show();

                return;
            }

            if (!IsArchimede && IsLinear && !IsSquare)
            {
                var v0 = InitialSpeed;
                var h0 = Height;
                
                var g = Gravity;
                var k = LinearSpeed;
                var m = Mass;
                Func<double, double> exp = delegate (double t) {
                    return Math.Exp(-(k / m) * t);
                };

                Func<double, double> fy = delegate (double t) {
                    return -g * m / k * t - (v0 + g * m / k) * (m / k) * (exp(t) - 1) + h0;
                };

                Func<double, double> fv = delegate (double t) {
                    return -g * m / k + (v0 + g * m / k) * exp(t);
                };

                var analiticalAns = MKM_Labs.MathUtils.AnaliticalAns(InitialTime, EndTime, steporn, IsStep, fy, fv);
                ExperimentItems.Add(new ExperimentItem {Content = "LolkekChebureck",
                    Solutions = new List<Tuple<List<double>, List<double>, List<double>>> {Res, analiticalAns} });
                (new FallModelingResultView(Res, analiticalAns)).Show();

                return;
            }

            if (IsArchimede && IsLinear && !IsSquare)
            {
                var v0 = InitialSpeed;
                var h0 = Height;
                var g = Gravity * (1 - DensityEnv * Volume / Mass);
                var k = LinearSpeed;
                var m = Mass;
                Func<double, double> exp = delegate (double t) {
                    return Math.Exp(-(k / m) * t);
                };

                Func<double, double> fy = delegate (double t) {
                    return -g * m / k * t - (v0 + g * m / k) * (m / k) * (exp(t) - 1) + h0;
                };

                Func<double, double> fv = delegate (double t) {
                    return -g * m / k + (v0 + g * m / k) * exp(t);
                };

                var analiticalAns = MKM_Labs.MathUtils.AnaliticalAns(InitialTime, EndTime, steporn, IsStep, fy, fv);
                ExperimentItems.Add(new ExperimentItem
                {
                    Content = "Lolkek",
                    Solutions = new List<Tuple<List<double>, List<double>, List<double>>> { Res, analiticalAns }
                });
                (new FallModelingResultView(Res, analiticalAns)).Show();

                return;
            }

            if (!IsArchimede && !IsLinear && !IsSquare)
            {
                Func<double, double> fy = delegate (double t) {
                    return Height + InitialSpeed * t - (Gravity / 2) * t * t;
                };

                Func<double, double> fv = delegate (double t) {
                    return InitialSpeed - Gravity * t;
                };
                var analiticalAns = MKM_Labs.MathUtils.AnaliticalAns(InitialTime, EndTime, steporn, IsStep, fy, fv);
                ExperimentItems.Add(new ExperimentItem
                {
                    Content = "Lolkek",
                    Solutions = new List<Tuple<List<double>, List<double>, List<double>>> { Res, analiticalAns }
                });
                (new FallModelingResultView(Res, analiticalAns)).Show();

                return;
            }
            ExperimentItems.Add(new ExperimentItem
            {
                Content = "test",
                Solutions = new List<Tuple<List<double>, List<double>, List<double>>> { Res}
            });
            (new FallModelingResultView(Res)).Show();
        }

        #endregion
    }
}
