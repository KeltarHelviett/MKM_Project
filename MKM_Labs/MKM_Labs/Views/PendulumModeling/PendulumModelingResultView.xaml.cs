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
using MKM_Labs.ViewModels.PendulumModeling;

namespace MKM_Labs.Views.PendulumModeling
{
    /// <summary>
    /// Interaction logic for PendulumModelingResultView.xaml
    /// </summary>
    public partial class PendulumModelingResultView : Window
    {
        public PendulumModelingResultView()
        {
            InitializeComponent();
        }

        public PendulumModelingResultView(Tuple<List<double>, List<double>, List<double>, List<double>> numeric,
            Tuple<List<double>, List<double>, List<double>, List<double>> analytical) : this()
        {
            DataContext = new PendulumModelingResultView(numeric, analytical);
        }

        public PendulumModelingResultView(Tuple<List<double>, List<double>, List<double>, List<double>> numeric) : this()
        {
            DataContext = new PendulumModelingResultViewModel(numeric);
        }
    }
}
