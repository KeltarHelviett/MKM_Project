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
    public partial class HorizontalThrowModelingResultView : Window
    {
        public HorizontalThrowModelingResultView()
        {
            InitializeComponent();
        }

        public HorizontalThrowModelingResultView(
            Tuple<List<double>, List<Tuple<double, double>>, List<Tuple<double, double>>> numericValues) :
            this()
        {
            DataContext = new HorizontalThrowModelingResultViewModel(numericValues);
        }

        public HorizontalThrowModelingResultView(
            Tuple<List<double>, List<Tuple<double, double>>, List<Tuple<double, double>>> numericValues,
            Tuple<List<double>, List<Tuple<double, double>>, List<Tuple<double, double>>> analyticalValues) :
            this()
        {
            DataContext = new HorizontalThrowModelingResultViewModel(numericValues, analyticalValues);
        }
    }
}
