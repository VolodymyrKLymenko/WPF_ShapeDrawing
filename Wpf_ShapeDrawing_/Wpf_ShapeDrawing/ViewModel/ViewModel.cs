using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Microsoft.Win32;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using Wpf_ShapeDrawing.Model;


namespace Wpf_ShapeDrawing
{
    class ViewModel : INotifyPropertyChanged
    {
        private int Count = 0;

        private ObservableCollection<Point> pointsOnCanvas;
        public ObservableCollection<Point> PointsOnCanvas
        {
            get
            {
                return pointsOnCanvas;
            }
            set
            {
                pointsOnCanvas = value;
                OnPropertyChanged("PointsOnCanvas");
            }
        }

        private ObservableCollection<SpecialPolygon> polygones;
        public ObservableCollection<SpecialPolygon> Polygones
        {
            get
            {
                return polygones;
            }
            set
            {
                polygones = value;
                OnPropertyChanged("Polygones");
            }
        }


        private RelayCommand drawCmd;
        public RelayCommand DrawCmd
        {
            get
            {
                return drawCmd ??
                    (
                        drawCmd = new RelayCommand( (obj) =>
                                            {
                                                Polygon p = new Polygon();
    
                                                foreach (Point item in PointsOnCanvas)
                                                {
                                                    p.Points.Add(item);
                                                }

                                                p.Fill = Brushes.YellowGreen;

                                                Polygones.Add(new SpecialPolygon(p, ++Count));

                                                for (int i = 0; i < Polygones.Count; i++)
                                                {
                                                    if (Polygones[i].Polygon.Name == "point")
                                                    Polygones.RemoveAt(i--);
                                                }

                                                PointsOnCanvas.Clear();
                                            },
                                            (obj) => {
                                                if (PointsOnCanvas.Count > 7)
                                                {
                                                    for (int i = 0; i < Polygones.Count; i++)
                                                    {
                                                        if (Polygones[i].Polygon.Name == "point")
                                                        Polygones.RemoveAt(i--);
                                                    }

                                                    PointsOnCanvas.Clear();
                                                }
                                                return (PointsOnCanvas.Count > 2);
                                            })
                                        );

            }
        }

        private RelayCommand newCanvasCmd;
        public RelayCommand NewCanvasCmd
                                    {
                                        get
                                        {
                                            return newCanvasCmd ??
                                              (newCanvasCmd = new RelayCommand(
                                                      (obj) =>
                                                      {
                                                          Polygones.Clear();
                                                          PointsOnCanvas.Clear();
                                                          Count = 0;
                                                      },
                                                      (obj) =>
                                                      {
                                                          return Count != 0;
                                                      })
                                              );
                                        }
                                    }

        private RelayCommand selectPolygonCommand;
        public RelayCommand SelectPolygonCommand
        {
            get
            {
                return selectPolygonCommand ??
                    (selectPolygonCommand = new RelayCommand((obj) =>
                    {
                        if (obj is SpecialPolygon)
                        {
                            SpecialPolygon p = obj as SpecialPolygon;

                            if (!p.IsSelected)
                            {
                                p.Stroke = Brushes.Black;
                                p.IsSelected = true;
                            }
                            else
                            {
                                p.Stroke = null;
                                p.IsSelected = false;
                            }

                            OnPropertyChanged("Polygones");
                        }

                    },
                    (obj) =>
                    {
                        return obj != null;
                    })
                );
            }
        }

        private RelayCommand svaeCmd;
        public RelayCommand SaveCmd
        {
            get
            {
                return svaeCmd ??
                    (svaeCmd = new RelayCommand((obj) =>
                        {
                            Stream stream = null;
                            SaveFileDialog fileDialog = new SaveFileDialog();
                            BinaryFormatter formater = new BinaryFormatter();
                            
                            if(fileDialog.ShowDialog() == true)
                            {
                                using (stream = new FileStream(fileDialog.FileName, FileMode.OpenOrCreate))
                                {
                                    formater.Serialize(stream, Polygones);
                                }
                            }
                        },
                        (obj) =>
                        {
                            return Polygones.Count() != 0;
                        })
                    );
            }
        }

        private RelayCommand openCmd;
        public RelayCommand OpenCmd
        {
            get
            {
                return openCmd ??
                    (openCmd = new RelayCommand((obj) =>
                    {
                        Stream stream = null;
                        OpenFileDialog fileDialog = new OpenFileDialog();
                        BinaryFormatter formater = new BinaryFormatter();

                        if (fileDialog.ShowDialog() == true)
                        {
                            using (stream = new FileStream(fileDialog.FileName, FileMode.Open))
                            {
                                Polygones = (ObservableCollection<SpecialPolygon>)formater.Deserialize(stream);
                                Count = Polygones.Count();
                            }
                        }
                    },
                        (obj) =>
                        {
                            return true;
                        })
                    );
            }
        }

        public ViewModel()
        {
            PointsOnCanvas = new ObservableCollection<Point>();
            Polygones = new ObservableCollection<SpecialPolygon>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
