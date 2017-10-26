using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MKM_Labs.ViewModels
{
    class HorizontalThrowModelingAnimationViewModel: INotifyPropertyChanged
    {
        #region Ctor

        public HorizontalThrowModelingAnimationViewModel(List<Tuple<double, double>> xy, Canvas ExperimentCanvas)
        {
            this.ExperimentCanvas = ExperimentCanvas;
        }

        #endregion

        public Canvas ExperimentCanvas { set; get; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
