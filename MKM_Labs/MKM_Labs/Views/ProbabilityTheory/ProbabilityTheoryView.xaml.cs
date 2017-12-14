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
using MKM_Labs.ViewModels.ProbabilityTheory;

namespace MKM_Labs.Views.ProbabilityTheory
{
    public partial class ProbabilityTheoryView : Window
    {
        public ProbabilityTheoryView()
        {
            InitializeComponent();
            DataContext = new ProbabilityTheoryViewModel();
        }

        private void ClassicalExperimentCalculateBtnClick(object sender, RoutedEventArgs e)
        {
            (DataContext as ProbabilityTheoryViewModel)?.CalculateClassicTask();
        }

        private void GeometryExperimentCalculateBtnOnClick(object sender, RoutedEventArgs e)
        {
            (DataContext as ProbabilityTheoryViewModel)?.CalculateGeometryTask();
        }
    }
}
