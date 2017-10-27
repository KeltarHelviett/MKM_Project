using System;
using System.Windows;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.Windows.Media;
using System.Drawing;


namespace MKM_Labs.ViewModels
{
    class HorizontalThrowModelingAnimationViewModel: INotifyPropertyChanged
    {
        #region Ctor

        public HorizontalThrowModelingAnimationViewModel(List<Tuple<double, double>> xy, Canvas ExperimentCanvas)
        {
            
            this.ExperimentCanvas = ExperimentCanvas;

            var ellipse = new Ellipse();
            ellipse.Stroke = System.Windows.Media.Brushes.Black;
            ellipse.Fill = System.Windows.Media.Brushes.DarkBlue;
            ellipse.Width = 15;
            ellipse.Height = 15;

            var rect = new Rectangle();
            rect.Stroke = System.Windows.Media.Brushes.Black;
            rect.Fill = System.Windows.Media.Brushes.Green;
            rect.Width = 1000;
            rect.Height = 300;

            Thickness margin = new Thickness(0, ExperimentCanvas.Height - 5, ExperimentCanvas.Width, ExperimentCanvas.Height - 5 + 300);
            rect.Margin = margin;

            var minx = 100000000.0;
            var miny = 100000000.0;
            var maxx = -100000000.0;
            var maxy = -100000000.0;

            foreach (var xys in xy) {
                if (xys.Item1 < minx) minx = xys.Item1;
                if (xys.Item2 < miny) miny = xys.Item2;
                if (xys.Item1 > maxx) maxx = xys.Item1;
                if (xys.Item2 > maxy) maxy = xys.Item2;
            }

            this.ExperimentCanvas.Children.Add(ellipse);
            this.ExperimentCanvas.Children.Add(rect);

            DoubleAnimationUsingKeyFrames AnimationX
                = new DoubleAnimationUsingKeyFrames();

            DoubleAnimationUsingKeyFrames AnimationY
                = new DoubleAnimationUsingKeyFrames();

            AnimationX.Duration = TimeSpan.FromSeconds(5);
            AnimationY.Duration = TimeSpan.FromSeconds(5);

            double t = 0;
            double dt = 5.0 / xy.Count;

            var lx = maxx - minx;
            var ly = maxy - miny;

            var h = ExperimentCanvas.Height - 20;
            var w = ExperimentCanvas.Width;
            var xlast = 0.0;
            var ylast = 0.0;

            foreach (var xys in xy)
            {
                var x = xys.Item1;
                var y = xys.Item2;

                AnimationX.KeyFrames.Add(
                    new LinearDoubleKeyFrame(
                        (x - minx) / lx * w,
                        KeyTime.FromTimeSpan(TimeSpan.FromSeconds(t))) 
                    );

                AnimationY.KeyFrames.Add(
                    new LinearDoubleKeyFrame(
                        h - (y - miny) / ly * h,
                        KeyTime.FromTimeSpan(TimeSpan.FromSeconds(t))) 
                    );

                xlast = (x - minx) / lx * w;
                ylast = h - (y - miny) / ly * h;

                t += dt;
            }


            ellipse.BeginAnimation(Canvas.LeftProperty, AnimationX);
            ellipse.BeginAnimation(Canvas.TopProperty, AnimationY);

        }

        #endregion

        public Canvas ExperimentCanvas { set; get; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
