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
    class HorizontalThrowModelingResultViewModel: INotifyPropertyChanged
    {
        #region Ctor

        public HorizontalThrowModelingResultViewModel(
            Tuple<List<double>, List<Tuple<double, double>>, List<Tuple<double, double>>> numericValues)
        {
            List<double> ts = numericValues.Item1;
            List<Tuple<double, double>> xy = numericValues.Item3, vs = numericValues.Item3;
            for (int i = 0; i < ts.Count; ++i)
            {
                Yt.Add(new ObservablePoint(ts[i], xy[i].Item1));
                Xt.Add(new ObservablePoint(ts[i], xy[i].Item2));
                Yx.Add(new ObservablePoint(xy[i].Item1, xy[i].Item2));
                Vxt.Add(new ObservablePoint(ts[i], vs[i].Item1));
                Vyt.Add(new ObservablePoint(ts[i], vs[i].Item2));
            }
            Collection.Add(new LineSeries()
            {
                Values = Yx
            });
        }

        public HorizontalThrowModelingResultViewModel(
            Tuple<List<double>, List<Tuple<double, double>>, List<Tuple<double, double>>> numericValues,
            Tuple<List<double>, List<Tuple<double, double>>, List<Tuple<double, double>>> analyticalValues): this(numericValues)
        {
            List<double> ts = analyticalValues.Item1;
            List<Tuple<double, double>> xy = analyticalValues.Item3, vs = analyticalValues.Item3;
            for (int i = 0; i < ts.Count; ++i)
            {
                AnalyticalYt.Add(new ObservablePoint(ts[i], xy[i].Item1));
                AnalyticalXt.Add(new ObservablePoint(ts[i], xy[i].Item2));
                AnalyticalYx.Add(new ObservablePoint(xy[i].Item1, xy[i].Item2));
                AnalyticalVxt.Add(new ObservablePoint(ts[i], vs[i].Item1));
                AnalyticalVyt.Add(new ObservablePoint(ts[i], vs[i].Item2));
            }
            Collection.Add(new LineSeries()
            {
                Values = AnalyticalYx
            });
            HasAnalytical = true;
        }

        #endregion

        #region PrivateProperties

        private bool HasAnalytical { set; get; } = false;

        #endregion

        #region PublicProperties

        public SeriesCollection Collection { get; set; } = new SeriesCollection();

        public ChartValues<ObservablePoint> Yt { get; set; } = new ChartValues<ObservablePoint>();

        public ChartValues<ObservablePoint> Xt { get; set; } = new ChartValues<ObservablePoint>();

        public ChartValues<ObservablePoint> Vxt { get; set; } = new ChartValues<ObservablePoint>();

        public ChartValues<ObservablePoint> Vyt { get; set; } = new ChartValues<ObservablePoint>();

        public ChartValues<ObservablePoint> Yx { get; set; } = new ChartValues<ObservablePoint>();

        public ChartValues<ObservablePoint> AnalyticalYt { get; set; } = new ChartValues<ObservablePoint>();
                                           
        public ChartValues<ObservablePoint> AnalyticalXt { get; set; } = new ChartValues<ObservablePoint>();
                                            
        public ChartValues<ObservablePoint> AnalyticalVxt { get; set; } = new ChartValues<ObservablePoint>();
                                           
        public ChartValues<ObservablePoint> AnalyticalVyt { get; set; } = new ChartValues<ObservablePoint>();
                                            
        public ChartValues<ObservablePoint> AnalyticalYx { get; set; } = new ChartValues<ObservablePoint>();


        private bool isXt = false;

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

        private bool isYt = false;

        public bool IsYt
        {
            get { return isYt; }
            set
            {
                if (value == isYt)
                    return;
                isYt = value;
                if (isYt)
                {
                    Collection.Clear();
                    Collection.Add(new LineSeries()
                    {
                        Values = Yt
                    });
                    if (HasAnalytical)
                        Collection.Add(new LineSeries()
                        {
                            Values = AnalyticalYt
                        });
                }
                OnPropertyChanged(nameof(IsYt));
            }
        }

        private bool isVxt = false;

        public bool IsVxt
        {
            get { return isVxt; }
            set
            {
                if (value == isVxt)
                    return;
                isVxt = value;
                if (isVxt)
                {
                    Collection.Clear();
                    Collection.Add(new LineSeries()
                    {
                        Values = Vxt
                    });
                    if (HasAnalytical)
                        Collection.Add(new LineSeries()
                        {
                            Values = AnalyticalVxt
                        });
                }
                OnPropertyChanged(nameof(IsVxt));
            }
        }

        private bool isVyt = false;

        public bool IsVyt
        {
            get { return isVyt; }
            set
            {
                if (value == isVyt)
                    return;
                isVyt = value;
                if (isVyt)
                {
                    Collection.Clear();
                    Collection.Add(new LineSeries()
                    {
                        Values = Vyt
                    });
                    if (HasAnalytical)
                        Collection.Add(new LineSeries()
                        {
                            Values = AnalyticalVyt
                        });
                }
                OnPropertyChanged(nameof(IsVyt));
            }
        }

        private bool isYx = true;

        public bool IsYx
        {
            get { return isYx; }
            set
            {
                if (value == isYx)
                    return;
                isYx = value;
                if (isVyt)
                {
                    Collection.Clear();
                    Collection.Add(new LineSeries()
                    {
                        Values = Vyt
                    });
                    if (HasAnalytical)
                        Collection.Add(new LineSeries()
                        {
                            Values = AnalyticalVyt
                        });
                }
                OnPropertyChanged(nameof(IsYx));
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
