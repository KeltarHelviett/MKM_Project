using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace MKM_Labs.ViewModels
{
    class FallModelingResultViewModel: INotifyPropertyChanged
    {
        #region Ctor

        public FallModelingResultViewModel(List<double> ts, List<double> ys, List<double> vs)
        {
            for (int i = 0; i < ts.Count; ++i)
            {
                Ys.Add(new ObservablePoint(ts[i], ys[i]));
                Vs.Add(new ObservablePoint(ts[i], vs[i]));
            }
            Collection.Add(new LineSeries()
            {
                Values = Ys
            });
        }
        #endregion

        #region PublicProperties

        public SeriesCollection Collection { get; set; } = new SeriesCollection();

        public ChartValues<ObservablePoint> Ts { get; set; }

        public ChartValues<ObservablePoint> Ys { get; set; } = new ChartValues<ObservablePoint>();

        public ChartValues<ObservablePoint> Vs { get; set; } = new ChartValues<ObservablePoint>();

        private bool isSpeed = false;

        public bool IsSpeed
        {
            get { return isSpeed; }
            set
            {
                if (isSpeed == value)
                    return;
                isSpeed = value;
                if (isSpeed)
                {
                    Collection.Clear();
                    Collection.Add(new LineSeries
                    {
                        Values = Vs
                    });
                }
                OnPropertyChanged(nameof(IsSpeed));
            }
        }

        private bool isY = true;

        public bool IsY
        {
            get { return isY; }
            set
            {
                if (isY == value)
                    return;
                isY = value;
                if (isY)
                {
                    Collection.Clear();
                    Collection.Add(new LineSeries
                    {
                        Values = Ys
                    });
                }
                OnPropertyChanged(nameof(IsY));
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
