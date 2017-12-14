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
    public partial class PendulumModelingView : Window
    {
        public PendulumModelingView()
        {
            InitializeComponent();
            DataContext = new PendulumModelingViewModel();
        }

        private void CalculateBtnClick(object sender, RoutedEventArgs e)
        {
            (DataContext as PendulumModelingViewModel)?.Calculate();
        }
    }
}
