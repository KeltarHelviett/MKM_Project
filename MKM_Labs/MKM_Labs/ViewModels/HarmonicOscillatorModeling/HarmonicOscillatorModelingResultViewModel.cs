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
        #region Ctor

        public HarmonicOscillatorModelingResultViewModel(Tuple<List<double>, List<double>, List<double>, List<double>> numeric)
        {
            for (var i = 0; i < numeric.Item1.Count; ++i)
            {
                Xt.Add(new ObservablePoint(numeric.Item1[i], numeric.Item2[i]));
                Vt.Add(new ObservablePoint(numeric.Item1[i], numeric.Item3[i]));
                E.Add(new ObservablePoint(numeric.Item1[i], numeric.Item4[i]));
                Vx.Add(new ObservablePoint(numeric.Item2[i], numeric.Item3[i]));
            }
            Collection.Add(new LineSeries()
            {
                Values = Xt
            });
        }

        public HarmonicOscillatorModelingResultViewModel(Tuple<List<double>, List<double>, List<double>, List<double>> numeric,
            Tuple<List<double>, List<double>, List<double>, List<double>> analytical): this(numeric)
        {
            for (var i = 0; i < numeric.Item1.Count; ++i)
            {
                AnalyticalXt.Add(new ObservablePoint(analytical.Item1[i], analytical.Item2[i]));
                AnalyticalVt.Add(new ObservablePoint(analytical.Item1[i], analytical.Item3[i]));
                AnalyticalE.Add(new ObservablePoint(analytical.Item1[i], analytical.Item4[i]));
            }
            Collection.Add(new LineSeries()
            {
                Values = AnalyticalXt
            });
            HasAnalytical = true;
        }

        #endregion

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
                        Values = Vx
                    });
                    if (HasAnalytical)
                        Collection.Add(new LineSeries()
                        {
                            Values = AnalyticalVt
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

        public ChartValues<ObservablePoint> Vx { get; set; } = new ChartValues<ObservablePoint>();

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
