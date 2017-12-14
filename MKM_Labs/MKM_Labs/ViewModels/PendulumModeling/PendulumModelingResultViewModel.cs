using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace MKM_Labs.ViewModels.PendulumModeling
{
    class PendulumModelingResultViewModel: INotifyPropertyChanged
    {
        #region Ctor

        public PendulumModelingResultViewModel(Tuple<List<double>, List<double>, List<double>, List<double>> numeric)
        {
            for (var i = 0; i < numeric.Item1.Count; ++i)
            {
                Thetat.Add(new ObservablePoint(numeric.Item1[i], numeric.Item2[i]));
                Vt.Add(new ObservablePoint(numeric.Item1[i], numeric.Item3[i]));
                E.Add(new ObservablePoint(numeric.Item1[i], numeric.Item4[i]));
                PhasePortrait.Add(new ObservablePoint(numeric.Item2[i], numeric.Item3[i]));
            }
            Collection.Add(new LineSeries()
            {
                Values = Thetat
            });
        }

        #endregion

        #region PublicProperties

        private bool isThetat = true;

        public bool IsThetat
        {
            get { return isThetat; }
            set
            {
                if (value == isThetat)
                    return;
                isThetat = value;
                if (isThetat)
                {
                    Collection.Clear();
                    Collection.Add(new LineSeries()
                    {
                        Values = Thetat
                    });
                }
                OnPropertyChanged(nameof(IsThetat));
            }
        }

        private bool isVt = false;

        public bool IsVt
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
                        Fill = null,
                        Values = Vt
                    });
                }
                OnPropertyChanged(nameof(IsVt));
            }
        }

        private bool isPhasePortrait = false;

        public bool IsPhasePortrait
        {
            get { return isPhasePortrait; }
            set
            {
                if (value == isPhasePortrait)
                    return;
                isPhasePortrait = value;
                if (isPhasePortrait)
                {
                    Collection.Clear();
                    Collection.Add(new LineSeries()
                    {
                        Fill = System.Windows.Media.Brushes.Transparent,
                        Values = PhasePortrait
                    });
                }
                OnPropertyChanged(nameof(IsVt));
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
                }
                OnPropertyChanged(nameof(IsE));
            }
        }

        public SeriesCollection Collection { get; set; } = new SeriesCollection();

        public ChartValues<ObservablePoint> Thetat { get; set; } = new ChartValues<ObservablePoint>();

        public ChartValues<ObservablePoint> Vt { get; set; } = new ChartValues<ObservablePoint>();

        public ChartValues<ObservablePoint> PhasePortrait { get; set; } = new ChartValues<ObservablePoint>();

        public ChartValues<ObservablePoint> E { get; set; } = new ChartValues<ObservablePoint>();

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
