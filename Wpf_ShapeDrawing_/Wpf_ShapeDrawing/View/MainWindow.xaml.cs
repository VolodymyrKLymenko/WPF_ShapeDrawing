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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new ViewModel();
        }

        private void Canvas_MouseLeftButtonDown(object sender, MouseEventArgs e)
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
}
