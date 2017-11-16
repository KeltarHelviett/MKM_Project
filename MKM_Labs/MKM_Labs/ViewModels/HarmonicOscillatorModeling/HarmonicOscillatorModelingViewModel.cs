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
                OnPropertyChanged(nameof(Mass));
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
