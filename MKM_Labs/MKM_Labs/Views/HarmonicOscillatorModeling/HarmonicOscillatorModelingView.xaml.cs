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
    public partial class HarmonicOscillatorModelingView : Window
    {
        public HarmonicOscillatorModelingView()
        {
            InitializeComponent();
            DataContext = new HarmonicOscillatorModelingViewModel();
        }
    }
}
