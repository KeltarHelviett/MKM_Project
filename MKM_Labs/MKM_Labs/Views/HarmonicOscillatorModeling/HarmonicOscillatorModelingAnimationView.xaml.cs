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
    public partial class HarmonicOscillatorModelingAnimationView : Window
    {
        public void Invalidate(object o, EventArgs e)
        {
            VM.CalculateNextValue(0.02);
            VM.RedrawModel();
        }

        public HarmonicOscillatorModelingAnimationView()
        {
            InitializeComponent();
        }

        public HarmonicOscillatorModelingAnimationView(double x0, double v0, Func<double, double, double, double> a)
        {
            InitializeComponent();

            DataContext =  new HarmonicOscillatorModelingAnimationViewModel(x0, v0, a, ExperimentCanvas);

            VM = DataContext as HarmonicOscillatorModelingAnimationViewModel;

            timer.Interval = new TimeSpan(0, 0, 0, 0, 20);
            timer.Tick += Invalidate;
            timer.Start();
        }

        readonly System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();

        private HarmonicOscillatorModelingAnimationViewModel VM; // Perfomance reasons

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
