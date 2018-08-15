using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Input;
using System.Windows.Media;
using System.ComponentModel;
using System.IO;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace Wpf_ShapeDrawing.Model
{
    [Serializable]
    class SpecialPolygon : INotifyPropertyChanged
    {
        [NonSerialized]
        private Brush fill;
        public Brush Fill
        {
            get { return fill; }
            set
            {
                fill = value;
                polygon.Fill = value;

                OnPropertyChanged("Fill");
                OnPropertyChanged("Polygon");
            }
        }

        [NonSerialized]
        private Brush stroke;
        public Brush Stroke
        {
            get { return stroke; }
            set
            {
                stroke = value;
                polygon.Stroke = (Brush)value;
                polygon.StrokeThickness = (value == null)?0:3;

                OnPropertyChanged("Stroke");
                OnPropertyChanged("Polygon");
            }
        }

        [NonSerialized]
        private Polygon polygon;
        public Polygon Polygon
        {
            get { return polygon; }
            set
            {
                polygon = value;
                OnPropertyChanged("Polygon");
            }
        }

        private bool isSelected;
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }

        private int id = -1;
        public int Id
        {
            get
            {
                return id;
            }
        }

         //TO DO It`s just for searilizing. Try to find better way.
        public string serializedPoints;

        public SpecialPolygon()
        {

        }

        public SpecialPolygon(Polygon p, int _id = -1)
        {
            Polygon = p;
            if (_id != -1)
                id = _id;
            isSelected = false;
        }

        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string nameProp)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(nameProp));
        }

        [OnSerializing]
        public void OnSerializing(StreamingContext context)
        {
            serializedPoints = "";

            foreach (var item in polygon.Points)
            {
                serializedPoints += item.X + ";" + item.Y + "|";
            }
        }

        [OnDeserialized]
        public void OnDeserelized(StreamingContext context)
        {
            var p = new Polygon();
            p.Points = new PointCollection();
            fill = Brushes.YellowGreen;

            var newPoints = serializedPoints.Split('|');

            foreach (var item in newPoints)
            {
                var newPoint = item.Split(';');
                if (newPoint.Count() == 2)
                {
                    p.Points.Add(new System.Windows.Point(Double.Parse(newPoint[0]), Double.Parse(newPoint[1])));
                }
            }

            p.Fill = fill;
            IsSelected = false;
            Polygon = p;
        }
    }
}
