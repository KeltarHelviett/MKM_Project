using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MKM_Labs.ViewModels
{
    class HorizontalThrowModelingViewModel: INotifyPropertyChanged
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

        private double x0 = 100;

        public double X0
        {
            get { return x0; }
            set
            {
                if (value == x0)
                    return;
                x0 = value;
                OnPropertyChanged(nameof(X0));
            }
        }

        private double angle = 0;

        public double Angle
        {
            get { return angle; }
            set
            {
                if (value == angle)
                    return;
                angle = value;
                OnPropertyChanged(nameof(Angle));
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

        private double environmentDensity = 1000;

        public double EnvironmentDensity
        {
            get { return environmentDensity; }
            set
            {
                if (value == environmentDensity)
                    return;
                environmentDensity = value;
                OnPropertyChanged(nameof(EnvironmentDensity));
            }
        }

        private double environmentSpeed = 10;

        public double EnvironmentSpeed
        {
            get { return environmentSpeed; }
            set
            {
                if (value == environmentSpeed)
                    return;
                environmentSpeed = value;
                OnPropertyChanged(nameof(EnvironmentSpeed));
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

        private double density = 0.3;

        public double Density
        {
            get { return density; }
            set
            {
                if (density == value)
                    return;
                density = value;
                OnPropertyChanged(nameof(Density));
            }
        }

        private double volume = 0.5;

        public double Volume
        {
            get { return volume; }
            set
            {
                if (volume == value)
                    return;
                volume = value;
                OnPropertyChanged(nameof(Volume));
            }
        }

        private double c = 0.2;

        public double C
        {
            get { return c; }
            set
            {
                if (c == value)
                    return;
                c = value;
                OnPropertyChanged(nameof(C));
            }
        }

        private double r = 3;

        public double R
        {
            get { return r; }
            set
            {
                if (r == value)
                    return;
                r = value;
                OnPropertyChanged(nameof(R));
            }
        }

        private double nu = 0.8;

        public double Nu
        {
            get { return nu; }
            set
            {
                if (nu == value)
                    return;
                nu = value;
                OnPropertyChanged(nameof(Nu));
            }
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
