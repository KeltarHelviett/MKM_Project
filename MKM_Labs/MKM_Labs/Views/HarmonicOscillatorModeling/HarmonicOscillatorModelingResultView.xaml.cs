using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MKM_Labs.ViewModels.HarmonicOscillatorModeling;

namespace MKM_Labs.Views.HarmonicOscillatorModeling
{
    public partial class HarmonicOscillatorModelingResultView : Window
    {
        public HarmonicOscillatorModelingResultView()
        {
            InitializeComponent();
        }

        public HarmonicOscillatorModelingResultView(Tuple<List<double>, List<double>, List<double>, List<double>> numeric,
            Tuple<List<double>, List<double>, List<double>, List<double>> analytical) : this()
        {
            DataContext = new HarmonicOscillatorModelingResultView(numeric, analytical);
        }

        public HarmonicOscillatorModelingResultView(Tuple<List<double>, List<double>, List<double>, List<double>> numeric) : this()
        {
            DataContext = new HarmonicOscillatorModelingResultViewModel(numeric);
        }
    }
}
