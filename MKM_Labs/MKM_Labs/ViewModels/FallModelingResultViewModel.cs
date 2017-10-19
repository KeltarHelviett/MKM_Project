using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using LiveCharts;
using LiveCharts.Wpf;

namespace MKM_Labs.ViewModels
{
    class FallModelingResultViewModel: INotifyPropertyChanged
    {
        #region Ctor

        public FallModelingResultViewModel(List<double> ts, List<double> ys, List<double> vs)
        {
            Ts = ts;
            Ys = ys;
            Vs = vs;
            SeriesCollection.Add(new LineSeries {});
        }

        #endregion

        #region PublicProperties

        public SeriesCollection SeriesCollection { get; set; }

        public List<double> Ts { get; set; }

        public List<double> Ys { get; set; }

        public List<double> Vs { get; set; }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
