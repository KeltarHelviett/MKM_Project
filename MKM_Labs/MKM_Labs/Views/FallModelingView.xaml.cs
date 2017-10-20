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
    public partial class FallModelingView : Window
    {
        public FallModelingView()
        {
            InitializeComponent();
            DataContext = new FallModelingViewModel();
        }

        private void CalculateBtnClick(object sender, RoutedEventArgs e)
        {
            ((FallModelingViewModel)DataContext).Calculate();
        }

        private void ExperimentsLBPreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = ExperimentsLB.SelectedItem as ExperimentItem;
            if (item != null)
            {
                if (item.Solutions.Count == 2)
                    (new FallModelingResultView(item.Solutions[0], item.Solutions[1])).Show();
                else
                    (new FallModelingResultView(item.Solutions[0])).Show();
            }
        }
    }
}
