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

namespace MKM_Labs.ViewModels.HarmonicOscillatorModeling
{
    class HarmonicOscillatorModelingResultViewModel: INotifyPropertyChanged
    {
        #region PrivateProperties

        private bool HasAnalytical { set; get; } = false;

        #endregion

        #region PublicProperties

        private bool isXt = true;

        public bool IsXt
        {
            get { return isXt; }
            set
            {
                if (value == isXt)
                    return;
                isXt = value;
                if (isXt)
                {
                    Collection.Clear();
                    Collection.Add(new LineSeries()
                    {
                        Values = Xt
                    });
                    if (HasAnalytical)
                        Collection.Add(new LineSeries()
                        {
                            Values = AnalyticalXt
                        });
                }
                OnPropertyChanged(nameof(IsXt));
            }
        }

        private bool isVt = false;

        public bool IsVxt
        {
            get { return isVt; }
            set
            {
                if (value == isVt)
                    return;
                isVt = value;
                if (isVt)
                {
                    Collection.Clear();
                    Collection.Add(new LineSeries()
                    {
                        Values = Vt
                    });
                    if (HasAnalytical)
                        Collection.Add(new LineSeries()
                        {
                            Values = AnalyticalVt
                        });
                }
                OnPropertyChanged(nameof(IsVxt));
            }
        }

        private bool isE = false;

        public bool IsE
        {
            get { return isE; }
            set
            {
                if (value == isE)
                    return;
                isE = value;
                if (isE)
                {
                    Collection.Clear();
                    Collection.Add(new LineSeries()
                    {
                        Values = E
                    });
                    if (HasAnalytical)
                        Collection.Add(new LineSeries()
                        {
                            Values = AnalyticalE
                        });
                }
                OnPropertyChanged(nameof(IsE));
            }
        }

        public SeriesCollection Collection { get; set; } = new SeriesCollection();

        public ChartValues<ObservablePoint> Xt { get; set; } = new ChartValues<ObservablePoint>();

        public ChartValues<ObservablePoint> Vt { get; set; } = new ChartValues<ObservablePoint>();

        public ChartValues<ObservablePoint> E { get; set; } = new ChartValues<ObservablePoint>();

        public ChartValues<ObservablePoint> AnalyticalE { get; set; } = new ChartValues<ObservablePoint>();

        public ChartValues<ObservablePoint> AnalyticalXt { get; set; } = new ChartValues<ObservablePoint>();

        public ChartValues<ObservablePoint> AnalyticalVt { get; set; } = new ChartValues<ObservablePoint>();

        #endregion


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
