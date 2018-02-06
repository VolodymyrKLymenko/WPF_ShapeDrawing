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
using System.Windows.Navigation;
using System.Windows.Shapes;

using Wpf_ShapeDrawing.Model;

namespace Wpf_ShapeDrawing.View
{
    public enum Mode:byte
    {
        None    = 1,
        Moving  = 2,
        Drawing = 3
    }

    public partial class MainWindow : Window
    {
        private Mode mode = Mode.Drawing;
        private Point startPoint = new Point();
        private bool isPressed = false;

        public MainWindow()
        {
            InitializeComponent();

            DataContext = new ViewModel();
        }


        private void Drawing_Click(object sender, RoutedEventArgs e)
        {
            if (mode == Mode.Drawing)
            {
                mode = Mode.None;
                DrawingMenu.IsChecked = false;
            }
            else
            {
                mode = Mode.Drawing;
                DrawingMenu.IsChecked = true;
                MovingMenu.IsChecked = false;
            }
        }
        private void Moving_Click(object sender, RoutedEventArgs e)
        {
            if (mode == Mode.Moving)
            {
                mode = Mode.None;
                MovingMenu.IsChecked = false;
            }
            else
            {
                mode = Mode.Moving;
                MovingMenu.IsChecked = true;
                DrawingMenu.IsChecked = false;
            }
        }

        private void ItemsControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (mode == Mode.Moving)
            {
                startPoint = e.MouseDevice.GetPosition(this);
                isPressed = true;
            }
            else if (mode == Mode.Drawing)
            {
                Point p = e.GetPosition(this);
                p.Y -= menu.ActualHeight;

                Polygon pol = new Polygon();
                pol.Fill = Brushes.YellowGreen;
                pol.Points.Add(new Point(p.X - 2, p.Y + 2));
                pol.Points.Add(new Point(p.X - 2, p.Y - 2));
                pol.Points.Add(new Point(p.X + 2, p.Y - 2));
                pol.Points.Add(new Point(p.X + 2, p.Y + 2));
                pol.Name = "point";

                ((ViewModel)DataContext).PointsOnCanvas.Add(p);
                ((ViewModel)DataContext).Polygones.Add(new SpecialPolygon(pol));
            }
        }

        private void ItemsControl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (mode == Mode.Moving)
            {
                startPoint = new Point();
                isPressed = false;
            }
        }

        private void ItemsControl_MouseMove(object sender, MouseEventArgs e)
        {
            if(mode == Mode.Moving && isPressed == true)
            {
                Point curPoint = e.MouseDevice.GetPosition(this);
                double x = curPoint.X - startPoint.X;
                double y = curPoint.Y - startPoint.Y;

                var polygones = ((ViewModel)DataContext).Polygones;
                for (int i = 0; i < polygones.Count(); i++)
                {
                    if (polygones[i].IsSelected == true)
                    {
                        var points = polygones[i].Polygon.Points;
                        for (int j = 0; j < points.Count(); j++)
                        {
                            points[j] = new Point((points[j].X + x), (points[j].Y + y));
                        }

                    }
                }

                startPoint = curPoint;
            }
        }
    }
}
