using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace XamlBox
{
    public class Sample1 : Viewbox
    {
        public Sample1()
        {
            Height = 56.873;
            Width = 112.5;
            Child = new Canvas
            {
                Height = 56.873,
                Width = 56.873,
                Children =
                {
                    new Canvas
                    {
                        Height = 1.351,
                        Width = 1.351,
                        Children =
                        {
                            new Path
                            {
                                Data = Geometry.Parse("F1M12.5,55.998L78.717,55.998 78.717,54.647 12.5,54.647z"),
                                StrokeThickness = 1,
                                Height = 1.351,
                                Width = 66.217,
                                Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF000000")),
                                Stretch = System.Windows.Media.Stretch.Fill,
                            },
                            new Path
                            {
                                Data = Geometry.Parse("M12.5,55.998L78.717,55.998 78.717,54.647 12.5,54.647z"),
                                StrokeThickness = 0.25,
                                Height = 1.601,
                                Width = 66.467,
                                Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4C4C4C")),
                                Stretch = System.Windows.Media.Stretch.Fill,
                            },
                        }
                    },
                    new Canvas
                    {
                        Height = 54.956,
                        Width = 54.956,
                        Children =
                        {
                            new Path
                            {
                                Data = Geometry.Parse("F1M0,0.930999999999997L0,53.408 12.5,54.647 12.5,-0.308999999999998z"),
                                StrokeThickness = 1,
                                Height = 54.956,
                                Width = 12.5,
                                Fill = new LinearGradientBrush(new GradientStopCollection(new List<GradientStop> {new GradientStop((Color)ColorConverter.ConvertFromString("#FF3C3C3C"), 0.01),new GradientStop((Color)ColorConverter.ConvertFromString("#FFE8E8E8"), 0.51),new GradientStop((Color)ColorConverter.ConvertFromString("#FF3C3C3C"), 1),}),new System.Windows.Point(0.5, 1), new System.Windows.Point(0.5, 0)),
                                Stretch = System.Windows.Media.Stretch.Fill,
                            },
                            new Path
                            {
                                Data = Geometry.Parse("M12.5,54.6475L0,53.4085 0,0.9315 12.5,-0.308500000000002"),
                                StrokeThickness = 0.25,
                                Height = 55.206,
                                Width = 12.75,
                                Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4C4C4C")),
                                Stretch = System.Windows.Media.Stretch.Fill,
                            },
                        }
                    },
                    new Canvas
                    {
                        Height = 55.519,
                        Width = 55.519,
                        Children =
                        {
                            new Path
                            {
                                Data = Geometry.Parse("F1M12.5,-0.308L77.479,-0.308 89.979,0.930999999999997 89.979,53.409 78.717,54.647 12.5,54.647"),
                                StrokeThickness = 1,
                                Height = 54.955,
                                Width = 77.479,
                                Fill = new LinearGradientBrush(new GradientStopCollection(new List<GradientStop> {new GradientStop((Color)ColorConverter.ConvertFromString("#FF3C3C3C"), 0.01),new GradientStop((Color)ColorConverter.ConvertFromString("#FFE8E8E8"), 0.51),new GradientStop((Color)ColorConverter.ConvertFromString("#FF3C3C3C"), 1),}),new System.Windows.Point(0.5, 1), new System.Windows.Point(0.5, 0)),
                                Stretch = System.Windows.Media.Stretch.Fill,
                            },
                            new Path
                            {
                                Data = Geometry.Parse("M12.5,-0.308100000000003L77.479,-0.308100000000003 89.979,0.930899999999997 89.979,53.4089 78.717,54.6479 12.5,54.6479"),
                                StrokeThickness = 0.25,
                                Height = 55.206,
                                Width = 77.729,
                                Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4C4C4C")),
                                Stretch = System.Windows.Media.Stretch.Fill,
                            },
                            new Path
                            {
                                Data = Geometry.Parse("M12.5,54.6475L12.5,-0.308500000000002"),
                                StrokeThickness = 0.25,
                                Height = 55.206,
                                Width = 0.25,
                                Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4C4C4C")),
                                Stretch = System.Windows.Media.Stretch.Fill,
                            },
                            new Path
                            {
                                Data = Geometry.Parse("M78.7168,54.6475L78.7168,-0.308500000000002"),
                                StrokeThickness = 0.25,
                                Height = 55.206,
                                Width = 0.25,
                                Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4C4C4C")),
                                Stretch = System.Windows.Media.Stretch.Fill,
                            },
                            new Path
                            {
                                Data = Geometry.Parse("F1M0,1.606L12.5,1.606 12.5,-0.870999999999995 0,-0.870999999999995z"),
                                StrokeThickness = 1,
                                Height = 2.477,
                                Width = 12.5,
                                Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF7F7F7F")),
                                Stretch = System.Windows.Media.Stretch.Fill,
                            },
                            new Path
                            {
                                Data = Geometry.Parse("M0,1.606L12.5,1.606 12.5,-0.870999999999995 0,-0.870999999999995z"),
                                StrokeThickness = 0.25,
                                Height = 2.727,
                                Width = 12.75,
                                Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4C4C4C")),
                                Stretch = System.Windows.Media.Stretch.Fill,
                            },
                        }
                    },
                    new Canvas
                    {
                        Height = 50,
                        Width = 50,
                        Children =
                        {
                            new Path
                            {
                                Data = Geometry.Parse("M89.979,2.169L92.457,2.169 92.457,52.169 89.979,52.169z"),
                                StrokeThickness = 0.25,
                                Height = 50.25,
                                Width = 2.728,
                                Fill = new LinearGradientBrush(new GradientStopCollection(new List<GradientStop> {new GradientStop((Color)ColorConverter.ConvertFromString("#FF4C4C4C"), 0.01),new GradientStop((Color)ColorConverter.ConvertFromString("#FFE8E8E8"), 0.51),new GradientStop((Color)ColorConverter.ConvertFromString("#FF4C4C4C"), 1),}),new System.Windows.Point(0.5, 1), new System.Windows.Point(0.5, 0)),
                                Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4C4C4C")),
                                Stretch = System.Windows.Media.Stretch.Fill,
                            },
                            new Path
                            {
                                Data = Geometry.Parse("M92.455,5.998L94.934,5.998 94.934,48.453 92.455,48.453z"),
                                StrokeThickness = 0.25,
                                Height = 42.705,
                                Width = 2.729,
                                Fill = new LinearGradientBrush(new GradientStopCollection(new List<GradientStop> {new GradientStop((Color)ColorConverter.ConvertFromString("#FF4C4C4C"), 0.01),new GradientStop((Color)ColorConverter.ConvertFromString("#FFE8E8E8"), 0.51),new GradientStop((Color)ColorConverter.ConvertFromString("#FF4C4C4C"), 1),}),new System.Windows.Point(0.5, 1), new System.Windows.Point(0.5, 0)),
                                Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4C4C4C")),
                                Stretch = System.Windows.Media.Stretch.Fill,
                            },
                        }
                    },
                    new Canvas
                    {
                        Height = 19.256,
                        Width = 19.256,
                        Children =
                        {
                            new Path
                            {
                                Data = Geometry.Parse("M16.216,-0.871000000000002L74.887,-0.871000000000002 74.887,18.385 16.216,18.385z"),
                                StrokeThickness = 0.25,
                                Height = 19.506,
                                Width = 58.921,
                                Fill = new LinearGradientBrush(new GradientStopCollection(new List<GradientStop> {new GradientStop((Color)ColorConverter.ConvertFromString("#FF808080"), 0.01),new GradientStop((Color)ColorConverter.ConvertFromString("#FFE8E8E8"), 0.51),new GradientStop((Color)ColorConverter.ConvertFromString("#FF808080"), 1),}),new System.Windows.Point(0.5, 1), new System.Windows.Point(0.5, 0)),
                                Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4C4C4C")),
                                Stretch = System.Windows.Media.Stretch.Fill,
                            },
                            new Path
                            {
                                Data = Geometry.Parse("M16.2158,0.931199999999997L74.8868,0.931199999999997"),
                                StrokeThickness = 0.25,
                                Height = 0.25,
                                Width = 58.921,
                                Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4C4C4C")),
                                Stretch = System.Windows.Media.Stretch.Fill,
                            },
                            new Path
                            {
                                Data = Geometry.Parse("M16.2158,15.9082L74.8868,15.9082"),
                                StrokeThickness = 0.25,
                                Height = 0.25,
                                Width = 58.921,
                                Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4C4C4C")),
                                Stretch = System.Windows.Media.Stretch.Fill,
                            },
                            new Path
                            {
                                Data = Geometry.Parse("M16.2158,13.4312L74.8868,13.4312"),
                                StrokeThickness = 0.25,
                                Height = 0.25,
                                Width = 58.921,
                                Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4C4C4C")),
                                Stretch = System.Windows.Media.Stretch.Fill,
                            },
                            new Path
                            {
                                Data = Geometry.Parse("M16.2158,10.9531L74.8868,10.9531"),
                                StrokeThickness = 0.25,
                                Height = 0.25,
                                Width = 58.921,
                                Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4C4C4C")),
                                Stretch = System.Windows.Media.Stretch.Fill,
                            },
                            new Path
                            {
                                Data = Geometry.Parse("M16.2158,9.2642L74.8868,9.2642"),
                                StrokeThickness = 0.25,
                                Height = 0.25,
                                Width = 58.921,
                                Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4C4C4C")),
                                Stretch = System.Windows.Media.Stretch.Fill,
                            },
                            new Path
                            {
                                Data = Geometry.Parse("M16.2158,7.3501L74.8868,7.3501"),
                                StrokeThickness = 0.25,
                                Height = 0.25,
                                Width = 58.921,
                                Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4C4C4C")),
                                Stretch = System.Windows.Media.Stretch.Fill,
                            },
                            new Path
                            {
                                Data = Geometry.Parse("M16.2158,5.4351L74.8868,5.4351"),
                                StrokeThickness = 0.25,
                                Height = 0.25,
                                Width = 58.921,
                                Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4C4C4C")),
                                Stretch = System.Windows.Media.Stretch.Fill,
                            },
                            new Path
                            {
                                Data = Geometry.Parse("M16.2158,4.084L74.8868,4.084"),
                                StrokeThickness = 0.25,
                                Height = 0.25,
                                Width = 58.921,
                                Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4C4C4C")),
                                Stretch = System.Windows.Media.Stretch.Fill,
                            },
                            new Path
                            {
                                Data = Geometry.Parse("M16.2158,2.8447L74.8868,2.8447"),
                                StrokeThickness = 0.25,
                                Height = 0.25,
                                Width = 58.921,
                                Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4C4C4C")),
                                Stretch = System.Windows.Media.Stretch.Fill,
                            },
                            new Path
                            {
                                Data = Geometry.Parse("M16.2158,1.606L74.8868,1.606"),
                                StrokeThickness = 0.25,
                                Height = 0.25,
                                Width = 58.921,
                                Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4C4C4C")),
                                Stretch = System.Windows.Media.Stretch.Fill,
                            },
                            new Path
                            {
                                Data = Geometry.Parse("M16.2158,0.367199999999997L74.8868,0.367199999999997"),
                                StrokeThickness = 0.25,
                                Height = 0.25,
                                Width = 58.921,
                                Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4C4C4C")),
                                Stretch = System.Windows.Media.Stretch.Fill,
                            },
                        }
                    },
                    new Canvas
                    {
                        Height = 4.391,
                        Width = 4.391,
                        Children =
                        {
                            new Path
                            {
                                Data = Geometry.Parse("M94.934,24.692L112.5,24.692 112.5,29.083 94.934,29.083z"),
                                StrokeThickness = 0.25,
                                Height = 4.641,
                                Width = 17.816,
                                Fill = new LinearGradientBrush(new GradientStopCollection(new List<GradientStop> {new GradientStop((Color)ColorConverter.ConvertFromString("#FF656565"), 0.01),new GradientStop((Color)ColorConverter.ConvertFromString("#FFE8E8E8"), 0.51),new GradientStop((Color)ColorConverter.ConvertFromString("#FF656565"), 1),}),new System.Windows.Point(0.5, 1), new System.Windows.Point(0.5, 0)),
                                Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4C4C4C")),
                                Stretch = System.Windows.Media.Stretch.Fill,
                            },
                        }
                    },
                    new Canvas
                    {
                        Height = 32.545,
                        Width = 32.545,
                        Children =
                        {
                            new Path
                            {
                                Data = Geometry.Parse("F1M46.171,23.453L77.365,23.453 77.365,55.998 46.171,55.998z"),
                                StrokeThickness = 1,
                                Height = 32.545,
                                Width = 31.194,
                                Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF7F7F7F")),
                                Stretch = System.Windows.Media.Stretch.Fill,
                            },
                            new Path
                            {
                                Data = Geometry.Parse("M46.171,23.453L77.365,23.453 77.365,55.998 46.171,55.998z"),
                                StrokeThickness = 0.25,
                                Height = 32.795,
                                Width = 31.444,
                                Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4C4C4C")),
                                Stretch = System.Windows.Media.Stretch.Fill,
                            },
                        }
                    },
                    new Canvas
                    {
                        Height = 13.738,
                        Width = 13.738,
                        Children =
                        {
                            new Path
                            {
                                Data = Geometry.Parse("F1M48.085,25.931L64.977,25.931 64.977,39.669 48.085,39.669z"),
                                StrokeThickness = 1,
                                Height = 13.738,
                                Width = 16.892,
                                Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF5F5F5")),
                                Stretch = System.Windows.Media.Stretch.Fill,
                            },
                        }
                    },
                    new Canvas
                    {
                        Height = 30.63,
                        Width = 30.63,
                        Children =
                        {
                            new Path
                            {
                                Data = Geometry.Parse("M12.5,23.453L38.739,23.453 38.739,54.083 12.5,54.083z"),
                                StrokeThickness = 0.25,
                                Height = 30.88,
                                Width = 26.489,
                                Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF7F7F7F")),
                                Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4C4C4C")),
                                Stretch = System.Windows.Media.Stretch.Fill,
                            },
                            new Path
                            {
                                Data = Geometry.Parse("M13.739,25.931L33.672,25.931 33.672,53.409 13.739,53.409z"),
                                StrokeThickness = 0.25,
                                Height = 27.728,
                                Width = 20.183,
                                Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFA8A8A8")),
                                Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4C4C4C")),
                                Stretch = System.Windows.Media.Stretch.Fill,
                            },
                        }
                    },
                    new Canvas
                    {
                        Height = 17.453,
                        Width = 17.453,
                        Children =
                        {
                            new Path
                            {
                                Data = Geometry.Parse("F1M36.2612,37.1924L37.2752,37.7554 37.5002,38.4304 37.3872,38.9944 36.7122,39.5574 36.2612,39.6694 35.6982,39.5574 35.1352,38.9944 35.0222,38.4304 35.5852,37.4174z"),
                                StrokeThickness = 1,
                                Height = 2.477,
                                Width = 2.478,
                                Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF000000")),
                                Stretch = System.Windows.Media.Stretch.Fill,
                            },
                            new Path
                            {
                                Data = Geometry.Parse("M34.9102,38.4307L37.5002,38.4307"),
                                StrokeThickness = 0.25,
                                Height = 0.25,
                                Width = 2.84,
                                Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF7F7F7F")),
                                Stretch = System.Windows.Media.Stretch.Fill,
                            },
                            new Path
                            {
                                Data = Geometry.Parse("M36.1479,39.6689L36.1479,37.1919"),
                                StrokeThickness = 0.25,
                                Height = 2.727,
                                Width = 0.25,
                                Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF7F7F7F")),
                                Stretch = System.Windows.Media.Stretch.Fill,
                            },
                            new Path
                            {
                                Data = Geometry.Parse("F1M48.6479,52.1689L49.7739,52.7319 49.8859,53.4079 49.8859,53.9709 49.2109,54.5339 48.6479,54.6459 48.1979,54.5339 47.5219,53.9709 47.5219,53.4079 47.9729,52.3939z"),
                                StrokeThickness = 1,
                                Height = 2.477,
                                Width = 2.364,
                                Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF000000")),
                                Stretch = System.Windows.Media.Stretch.Fill,
                            },
                            new Path
                            {
                                Data = Geometry.Parse("M47.4102,53.4082L49.8882,53.4082"),
                                StrokeThickness = 0.25,
                                Height = 0.25,
                                Width = 2.728,
                                Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF7F7F7F")),
                                Stretch = System.Windows.Media.Stretch.Fill,
                            },
                            new Path
                            {
                                Data = Geometry.Parse("M48.6479,54.6475L48.6479,52.1685"),
                                StrokeThickness = 0.25,
                                Height = 2.729,
                                Width = 0.25,
                                Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF7F7F7F")),
                                Stretch = System.Windows.Media.Stretch.Fill,
                            },
                            new Path
                            {
                                Data = Geometry.Parse("F1M74.8867,52.1689L76.0137,52.7319 76.1257,53.4079 76.1257,53.9709 75.4507,54.5339 74.8867,54.6459 74.4377,54.5339 73.7617,53.9709 73.7617,53.4079 74.2117,52.3939z"),
                                StrokeThickness = 1,
                                Height = 2.477,
                                Width = 2.364,
                                Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF000000")),
                                Stretch = System.Windows.Media.Stretch.Fill,
                            },
                            new Path
                            {
                                Data = Geometry.Parse("M73.6484,53.4082L76.1264,53.4082"),
                                StrokeThickness = 0.25,
                                Height = 0.25,
                                Width = 2.728,
                                Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF7F7F7F")),
                                Stretch = System.Windows.Media.Stretch.Fill,
                            },
                            new Path
                            {
                                Data = Geometry.Parse("M74.8867,54.6475L74.8867,52.1685"),
                                StrokeThickness = 0.25,
                                Height = 2.729,
                                Width = 0.25,
                                Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF7F7F7F")),
                                Stretch = System.Windows.Media.Stretch.Fill,
                            },
                        }
                    },
                }
            };
            Canvas.SetLeft(((Canvas)Child).Children[0], 12.5);
            Canvas.SetTop(((Canvas)Child).Children[0], 54.647);
            Canvas.SetLeft(((Canvas)(((Canvas)Child).Children[0])).Children[0], 0);
            Canvas.SetTop(((Canvas)(((Canvas)Child).Children[0])).Children[0], 0);
            Canvas.SetLeft(((Canvas)(((Canvas)Child).Children[0])).Children[1], -0.125);
            Canvas.SetTop(((Canvas)(((Canvas)Child).Children[0])).Children[1], -0.125);
            Canvas.SetLeft(((Canvas)Child).Children[1], 0);
            Canvas.SetTop(((Canvas)Child).Children[1], -0.309);
            Canvas.SetLeft(((Canvas)(((Canvas)Child).Children[1])).Children[0], 0);
            Canvas.SetTop(((Canvas)(((Canvas)Child).Children[1])).Children[0], 0);
            Canvas.SetLeft(((Canvas)(((Canvas)Child).Children[1])).Children[1], -0.125);
            Canvas.SetTop(((Canvas)(((Canvas)Child).Children[1])).Children[1], -0.125);
            Canvas.SetLeft(((Canvas)Child).Children[2], 0);
            Canvas.SetTop(((Canvas)Child).Children[2], -0.871);
            Canvas.SetLeft(((Canvas)(((Canvas)Child).Children[2])).Children[0], 12.5);
            Canvas.SetTop(((Canvas)(((Canvas)Child).Children[2])).Children[0], 0.563);
            Canvas.SetLeft(((Canvas)(((Canvas)Child).Children[2])).Children[1], 12.375);
            Canvas.SetTop(((Canvas)(((Canvas)Child).Children[2])).Children[1], 0.438);
            Canvas.SetLeft(((Canvas)(((Canvas)Child).Children[2])).Children[2], 12.375);
            Canvas.SetTop(((Canvas)(((Canvas)Child).Children[2])).Children[2], 0.438);
            Canvas.SetLeft(((Canvas)(((Canvas)Child).Children[2])).Children[3], 78.592);
            Canvas.SetTop(((Canvas)(((Canvas)Child).Children[2])).Children[3], 0.438);
            Canvas.SetLeft(((Canvas)(((Canvas)Child).Children[2])).Children[4], 0);
            Canvas.SetTop(((Canvas)(((Canvas)Child).Children[2])).Children[4], 0);
            Canvas.SetLeft(((Canvas)(((Canvas)Child).Children[2])).Children[5], -0.125);
            Canvas.SetTop(((Canvas)(((Canvas)Child).Children[2])).Children[5], -0.125);
            Canvas.SetLeft(((Canvas)Child).Children[3], 89.979);
            Canvas.SetTop(((Canvas)Child).Children[3], 2.169);
            Canvas.SetLeft(((Canvas)(((Canvas)Child).Children[3])).Children[0], -0.125);
            Canvas.SetTop(((Canvas)(((Canvas)Child).Children[3])).Children[0], -0.125);
            Canvas.SetLeft(((Canvas)(((Canvas)Child).Children[3])).Children[1], 2.351);
            Canvas.SetTop(((Canvas)(((Canvas)Child).Children[3])).Children[1], 3.704);
            Canvas.SetLeft(((Canvas)Child).Children[4], 16.216);
            Canvas.SetTop(((Canvas)Child).Children[4], -0.871);
            Canvas.SetLeft(((Canvas)(((Canvas)Child).Children[4])).Children[0], -0.125);
            Canvas.SetTop(((Canvas)(((Canvas)Child).Children[4])).Children[0], -0.125);
            Canvas.SetLeft(((Canvas)(((Canvas)Child).Children[4])).Children[1], -0.125);
            Canvas.SetTop(((Canvas)(((Canvas)Child).Children[4])).Children[1], 1.677);
            Canvas.SetLeft(((Canvas)(((Canvas)Child).Children[4])).Children[2], -0.125);
            Canvas.SetTop(((Canvas)(((Canvas)Child).Children[4])).Children[2], 16.654);
            Canvas.SetLeft(((Canvas)(((Canvas)Child).Children[4])).Children[3], -0.125);
            Canvas.SetTop(((Canvas)(((Canvas)Child).Children[4])).Children[3], 14.177);
            Canvas.SetLeft(((Canvas)(((Canvas)Child).Children[4])).Children[4], -0.125);
            Canvas.SetTop(((Canvas)(((Canvas)Child).Children[4])).Children[4], 11.699);
            Canvas.SetLeft(((Canvas)(((Canvas)Child).Children[4])).Children[5], -0.125);
            Canvas.SetTop(((Canvas)(((Canvas)Child).Children[4])).Children[5], 10.01);
            Canvas.SetLeft(((Canvas)(((Canvas)Child).Children[4])).Children[6], -0.125);
            Canvas.SetTop(((Canvas)(((Canvas)Child).Children[4])).Children[6], 8.096);
            Canvas.SetLeft(((Canvas)(((Canvas)Child).Children[4])).Children[7], -0.125);
            Canvas.SetTop(((Canvas)(((Canvas)Child).Children[4])).Children[7], 6.181);
            Canvas.SetLeft(((Canvas)(((Canvas)Child).Children[4])).Children[8], -0.125);
            Canvas.SetTop(((Canvas)(((Canvas)Child).Children[4])).Children[8], 4.83);
            Canvas.SetLeft(((Canvas)(((Canvas)Child).Children[4])).Children[9], -0.125);
            Canvas.SetTop(((Canvas)(((Canvas)Child).Children[4])).Children[9], 3.591);
            Canvas.SetLeft(((Canvas)(((Canvas)Child).Children[4])).Children[10], -0.125);
            Canvas.SetTop(((Canvas)(((Canvas)Child).Children[4])).Children[10], 2.352);
            Canvas.SetLeft(((Canvas)(((Canvas)Child).Children[4])).Children[11], -0.125);
            Canvas.SetTop(((Canvas)(((Canvas)Child).Children[4])).Children[11], 1.113);
            Canvas.SetLeft(((Canvas)Child).Children[5], 94.934);
            Canvas.SetTop(((Canvas)Child).Children[5], 24.692);
            Canvas.SetLeft(((Canvas)(((Canvas)Child).Children[5])).Children[0], -0.125);
            Canvas.SetTop(((Canvas)(((Canvas)Child).Children[5])).Children[0], -0.125);
            Canvas.SetLeft(((Canvas)Child).Children[6], 46.171);
            Canvas.SetTop(((Canvas)Child).Children[6], 23.453);
            Canvas.SetLeft(((Canvas)(((Canvas)Child).Children[6])).Children[0], 0);
            Canvas.SetTop(((Canvas)(((Canvas)Child).Children[6])).Children[0], 0);
            Canvas.SetLeft(((Canvas)(((Canvas)Child).Children[6])).Children[1], -0.125);
            Canvas.SetTop(((Canvas)(((Canvas)Child).Children[6])).Children[1], -0.125);
            Canvas.SetLeft(((Canvas)Child).Children[7], 48.085);
            Canvas.SetTop(((Canvas)Child).Children[7], 25.931);
            Canvas.SetLeft(((Canvas)(((Canvas)Child).Children[7])).Children[0], 0);
            Canvas.SetTop(((Canvas)(((Canvas)Child).Children[7])).Children[0], 0);
            Canvas.SetLeft(((Canvas)Child).Children[8], 12.5);
            Canvas.SetTop(((Canvas)Child).Children[8], 23.453);
            Canvas.SetLeft(((Canvas)(((Canvas)Child).Children[8])).Children[0], -0.125);
            Canvas.SetTop(((Canvas)(((Canvas)Child).Children[8])).Children[0], -0.125);
            Canvas.SetLeft(((Canvas)(((Canvas)Child).Children[8])).Children[1], 1.114);
            Canvas.SetTop(((Canvas)(((Canvas)Child).Children[8])).Children[1], 2.353);
            Canvas.SetLeft(((Canvas)Child).Children[9], 35.022);
            Canvas.SetTop(((Canvas)Child).Children[9], 37.192);
            Canvas.SetLeft(((Canvas)(((Canvas)Child).Children[9])).Children[0], 0);
            Canvas.SetTop(((Canvas)(((Canvas)Child).Children[9])).Children[0], 0);
            Canvas.SetLeft(((Canvas)(((Canvas)Child).Children[9])).Children[1], -0.237);
            Canvas.SetTop(((Canvas)(((Canvas)Child).Children[9])).Children[1], 1.113);
            Canvas.SetLeft(((Canvas)(((Canvas)Child).Children[9])).Children[2], 1.001);
            Canvas.SetTop(((Canvas)(((Canvas)Child).Children[9])).Children[2], -0.126);
            Canvas.SetLeft(((Canvas)(((Canvas)Child).Children[9])).Children[3], 12.5);
            Canvas.SetTop(((Canvas)(((Canvas)Child).Children[9])).Children[3], 14.976);
            Canvas.SetLeft(((Canvas)(((Canvas)Child).Children[9])).Children[4], 12.263);
            Canvas.SetTop(((Canvas)(((Canvas)Child).Children[9])).Children[4], 16.091);
            Canvas.SetLeft(((Canvas)(((Canvas)Child).Children[9])).Children[5], 13.501);
            Canvas.SetTop(((Canvas)(((Canvas)Child).Children[9])).Children[5], 14.851);
            Canvas.SetLeft(((Canvas)(((Canvas)Child).Children[9])).Children[6], 38.74);
            Canvas.SetTop(((Canvas)(((Canvas)Child).Children[9])).Children[6], 14.976);
            Canvas.SetLeft(((Canvas)(((Canvas)Child).Children[9])).Children[7], 38.501);
            Canvas.SetTop(((Canvas)(((Canvas)Child).Children[9])).Children[7], 16.091);
            Canvas.SetLeft(((Canvas)(((Canvas)Child).Children[9])).Children[8], 39.74);
            Canvas.SetTop(((Canvas)(((Canvas)Child).Children[9])).Children[8], 14.851);
        }
    }
}
