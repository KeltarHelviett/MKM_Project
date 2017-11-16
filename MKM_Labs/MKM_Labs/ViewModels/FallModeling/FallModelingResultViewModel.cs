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
using System.IO;
using System.Windows;
using Microsoft.Win32;

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

        public FallModelingResultViewModel(List<double> ts, List<double> ys, List<double> vs, List<double> ays, List<double> avs)
        {
            for (int i = 0; i < ts.Count; ++i)
            {
                Ys.Add(new ObservablePoint(ts[i], ys[i]));
                Vs.Add(new ObservablePoint(ts[i], vs[i]));
                AnaliticalYs.Add(new ObservablePoint(ts[i], ays[i]));
                AnaliticalVs.Add(new ObservablePoint(ts[i], avs[i]));
            }
            Collection.Add(new LineSeries()
            {
                Values = Ys
            });
            Collection.Add(new LineSeries()
            {
                Values = AnaliticalYs
            });
            hasAnaliticalSolution = true;
        }

        public void SaveToCsv()
        {
            var dlg = new SaveFileDialog();
            dlg.Filter = "CSV documents (.csv)|*.csv";
            Nullable<bool> result = dlg.ShowDialog();

            string filename = null;
            if (result == true)
            {
                filename = dlg.FileName;
            }

            String content = "k|Time|Height|Volume\n";
            for (int i = 0; i < Ys.Count; i++)
            {
                content += Convert.ToString(i) + "|" + Convert.ToString(Ys[i].X) + "|" + Convert.ToString(Ys[i].Y) + "|" + Convert.ToString(Vs[i].Y) + "\n";
            }
            File.WriteAllText(filename, content);

        }

        #endregion

            #region PublicProperties

        public SeriesCollection Collection { get; set; } = new SeriesCollection();

        public ChartValues<ObservablePoint> Ts { get; set; }

        public ChartValues<ObservablePoint> Ys { get; set; } = new ChartValues<ObservablePoint>();

        public ChartValues<ObservablePoint> Vs { get; set; } = new ChartValues<ObservablePoint>();

        public ChartValues<ObservablePoint> AnaliticalYs { get; set; } = new ChartValues<ObservablePoint>();

        public ChartValues<ObservablePoint> AnaliticalVs { get; set; } = new ChartValues<ObservablePoint>();

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
                    Collection.Add(new LineSeries()
                    {
                        Values = Vs
                    });
                    if (hasAnaliticalSolution)
                        Collection.Add(new LineSeries()
                        {
                            Values = AnaliticalVs
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
                    Collection.Add(new LineSeries()
                    {
                        Values = Ys
                    });
                    if (hasAnaliticalSolution)
                        Collection.Add(new LineSeries()
                        {
                            Values = AnaliticalYs
                        });
                }
                OnPropertyChanged(nameof(IsY));
            }
        }

        public bool hasAnaliticalSolution { set; get; } = false;
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
