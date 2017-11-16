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
using MKM_Labs.ViewModels;

namespace MKM_Labs.Views
{
    public partial class FallModelingResultView : Window
    {
        public FallModelingResultView()
        {
            InitializeComponent();
        }

        public FallModelingResultView(Tuple<List<double>, List<double>, List<double>> numeric): this()
        {
            
            DataContext = new FallModelingResultViewModel(numeric.Item1, numeric.Item2, numeric.Item3);
        }

        public FallModelingResultView(Tuple<List<double>, List<double>, List<double>> numeric,
            Tuple<List<double>, List<double>, List<double>> analitical): this()
        {
            DataContext = new FallModelingResultViewModel(numeric.Item1, numeric.Item2, numeric.Item3, analitical.Item2, analitical.Item3);
        }

        private void SaveToCsvBtnClick(object sender, RoutedEventArgs e)
        {
            ((FallModelingResultViewModel) DataContext).SaveToCsv();
        }
    }
}
