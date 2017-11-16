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

        private double friction;

        public double Friction
        {
            get { return friction; }
            set
            {
                friction = value;
                OnPropertyChanged(nameof(Friction));
            }
        }

        private double rigidity;

        public double Rigidity
        {
            get { return rigidity; }
            set
            {
                rigidity = value;
                OnPropertyChanged(nameof(Rigidity));
            }
        }

        private double mass;

        public double Mass
        {
            get { return mass; }
            set
            {
                mass = value;
                OnPropertyChanged(nameof(mass));
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

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
