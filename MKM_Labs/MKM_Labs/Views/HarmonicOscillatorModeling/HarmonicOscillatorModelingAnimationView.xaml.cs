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
using System.Timers;
using MKM_Labs.ViewModels.HarmonicOscillatorModeling;

namespace MKM_Labs.Views.HarmonicOscillatorModeling
{
    /// <summary>
    /// Interaction logic for HarmonicOscillatorModelingAnimationView.xaml
    /// </summary>
    public partial class HarmonicOscillatorModelingAnimationView : Window
    {
        public void SetTimer()
        {
            timer = new System.Timers.Timer(20);
            var AnimationViewModel = DataContext as HarmonicOscillatorModelingAnimationViewModel;

            timer.Elapsed += (sender, e) =>
            {
                AnimationViewModel.CalculateNextValue(0.02);
                AnimationViewModel.RedrawModel();
            };
            timer.AutoReset = true;
            timer.Enabled = true;

            timer.Start();
        }

        public HarmonicOscillatorModelingAnimationView()
        {
            InitializeComponent();
        }

        public HarmonicOscillatorModelingAnimationView(double x0, double v0, Func<double, double, double, double> a)
        {
            InitializeComponent();

            DataContext = new HarmonicOscillatorModelingAnimationViewModel(x0, v0, a, ExperimentCanvas);

            SetTimer();
        }

        public System.Timers.Timer timer;

        private void Form_Closed(object sender, EventArgs e)
        {
            timer.Stop();
        }

        private void Form_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            (DataContext as HarmonicOscillatorModelingAnimationViewModel).v += 400;
        }
    }
}
