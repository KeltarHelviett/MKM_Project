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
using Rectangle = System.Windows.Shapes.Rectangle;

namespace MKM_Labs.ViewModels.HarmonicOscillatorModeling
{
    class HarmonicOscillatorModelingAnimationViewModel: INotifyPropertyChanged
    {
        public void CalculateNextValue(double deltat)
        {
            v = v + deltat * Fa(x, v, deltat);
            x = x + deltat * v;
        }

        public HarmonicOscillatorModelingAnimationViewModel(double x0, double v0, Func<double, double, double, double> a, Canvas Canvas)
        {
            x = x0;
            v = v0;
            Fa = a;

            ExperimentCanvas = Canvas;

            DrawFloor(false);
            DrawSpring(false);
            DrawBody(false);
        }

        public void DrawLine(double x1, double y1, double x2, double y2, bool isRedraw)
        {
            line.Dispatcher.Invoke(() =>
            {
                line = new Line();

                line.Stroke = System.Windows.Media.Brushes.Black;
                line.Fill = System.Windows.Media.Brushes.Black;
                line.StrokeThickness = 3;
                line.X1 = x1;
                line.Y1 = y1;
                line.X2 = x2;
                line.Y2 = y2;
            });

            if (isRedraw)
                ExperimentCanvas.Dispatcher.Invoke(() => ExperimentCanvas.Children.RemoveAt(0));

            ExperimentCanvas.Dispatcher.Invoke(() => ExperimentCanvas.Children.Add(line));           
        }

        public void DrawSpring(bool isRedraw)
        {
            DrawLine(0, 450, 30, 450, isRedraw);

            var x1 = 30.0;
            var x2 = x1 + (start + (x - 60)) / 20;
            var y1 = 450.0;
            var y2 = 490.0;

            DrawLine(x1, y1, x2, y2, isRedraw);

            for (int i = 0; i < 9; i++)
            {
                x1 = x2;
                x2 = x1 + (start + (x - 60)) / 10;
                y1 = y2;
                y2 = y1 + Math.Pow(-1, i + 1) * 80;

                DrawLine(x1, y1, x2, y2, isRedraw);
            }

            x1 = x2;
            x2 = x1 + (start + (x - 60)) / 20;
            y1 = y2;
            y2 = 450;

            DrawLine(x1, y1, x2, y2, isRedraw);
            DrawLine(x2, y2, x2 + 30, y2, isRedraw);
        }

        public void DrawBody(bool isRedraw)
        {
            Thickness margin = new Thickness(start + x, 400, 0, 0);

            body.Dispatcher.Invoke(() =>
            {
                body.Stroke = System.Windows.Media.Brushes.Black;
                body.Fill = System.Windows.Media.Brushes.Black;
                body.Width = 200;
                body.Height = 100;
                body.Margin = margin;
            });

            if (isRedraw)
                ExperimentCanvas.Dispatcher.Invoke(() => ExperimentCanvas.Children.RemoveAt(0));

            ExperimentCanvas.Dispatcher.Invoke(() => ExperimentCanvas.Children.Add(body));
        }

        public void DrawFloor(bool isRedraw)
        {
            Thickness margin = new Thickness(0, 500, 0, 0);

            floor.Dispatcher.Invoke(() =>
            {
                floor.Stroke = System.Windows.Media.Brushes.Black;
                floor.Fill = System.Windows.Media.Brushes.Green;
                floor.Width = 1000;
                floor.Height = 200;
                floor.Margin = margin;
            });

            if (isRedraw)
                ExperimentCanvas.Dispatcher.Invoke(() => ExperimentCanvas.Children.Remove(floor));

            ExperimentCanvas.Dispatcher.Invoke(() => ExperimentCanvas.Children.Add(floor));          
        }
        
        public void RedrawModel()
        {
            DrawFloor(true);
            DrawSpring(true);
            DrawBody(true);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public double x;
        public double v;
        public double start = 400;
        public Func<double, double, double, double> Fa;
        public Canvas ExperimentCanvas { set; get; }

        public Rectangle floor = new Rectangle();
        public Line line = new Line();
        public Rectangle body = new Rectangle();

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
