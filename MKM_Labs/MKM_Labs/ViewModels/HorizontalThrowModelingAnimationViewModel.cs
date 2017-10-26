using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MKM_Labs.ViewModels
{
    class HorizontalThrowModelingAnimationViewModel: INotifyPropertyChanged
    {
        #region Ctor

        public HorizontalThrowModelingAnimationViewModel(List<Tuple<double, double>> xy)
        {
            
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
