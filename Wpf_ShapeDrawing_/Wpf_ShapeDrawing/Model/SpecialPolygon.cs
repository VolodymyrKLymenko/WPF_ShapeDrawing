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

namespace Wpf_ShapeDrawing.Model
{
    [Serializable]
    class SpecialPolygon : INotifyPropertyChanged
    {
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


        public SpecialPolygon(Polygon p, int _id = -1)
        {
            Polygon = p;
            if (_id != -1)
                id = _id;
            isSelected = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string nameProp)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(nameProp));
        }
    }
}
