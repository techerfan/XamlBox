using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace XamlBox
{
    public class Sample1 : Viewbox
    {
        public Sample1()
        {
            Height = 112.5;
            Width = 112.5;
            Child = new Canvas
            {
                Height = 112.5,
                Width = 112.5,
                Children =
                {
                    new Canvas
                    {
                        Height = 110.884,
                        Width = 110.884,
                        Children =
                        {
                            new Path
                            {
                                Data = Geometry.Parse("F1M0,55.75C0,86.372,25.184,111.192,56.25,111.192L56.25,111.192C87.316,111.192,112.5,86.372,112.5,55.75L112.5,55.75C112.5,25.128,87.316,0.308000000000007,56.25,0.308000000000007L56.25,0.308000000000007C25.184,0.308000000000007,0,25.128,0,55.75"),
                                StrokeThickness = 1,
                                Height = 110.884,
                                Width = 112.5,
                                Fill = new RadialGradientBrush(new GradientStopCollection(new List<GradientStop> {new GradientStop((Color)ColorConverter.ConvertFromString("#FF747578"), 0),new GradientStop((Color)ColorConverter.ConvertFromString("#FFE0E1E2"), 0.82),new GradientStop((Color)ColorConverter.ConvertFromString("#FF747578"), 1),})),
                                Stretch = System.Windows.Media.Stretch.Fill,
                            },
                            new Path
                            {
                                Data = Geometry.Parse("M112.5,55.75C112.5,86.372 87.316,111.191 56.25,111.191 25.184,111.191 0,86.372 0,55.75 0,25.128 25.184,0.308999999999998 56.25,0.308999999999998 87.316,0.308999999999998 112.5,25.128 112.5,55.75z"),
                                StrokeThickness = 0.5,
                                Height = 111.382,
                                Width = 113,
                                Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4C4C4C")),
                                Stretch = System.Windows.Media.Stretch.Fill,
                            },
                        }
                    },
                    new Canvas
                    {
                        Height = 87.837,
                        Width = 87.837,
                        Children =
                        {
                            new Path
                            {
                                Data = Geometry.Parse("F1M99.041,53.7495C99.041,78.0075 79.378,97.6685 55.122,97.6685 30.866,97.6685 11.203,78.0075 11.203,53.7495 11.203,29.4985 30.866,9.8315 55.122,9.8315 79.378,9.8315 99.041,29.4985 99.041,53.7495"),
                                StrokeThickness = 1,
                                Height = 87.837,
                                Width = 87.838,
                                Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4C4C4C")),
                                Stretch = System.Windows.Media.Stretch.Fill,
                            },
                        }
                    },
                    new Canvas
                    {
                        Height = 85.911,
                        Width = 85.911,
                        Children =
                        {
                            new Path
                            {
                                Data = Geometry.Parse("F1M4.37,45.05C4.059,68.771,23.044,88.252,46.776,88.562L46.776,88.562C70.504,88.872,89.99,69.893,90.299,46.171L90.299,46.171C90.609,22.449,71.624,2.96899999999999,47.895,2.65900000000001L47.895,2.65900000000001C47.704,2.657,47.514,2.655,47.323,2.655L47.323,2.655C23.852,2.65600000000001,4.675,21.52,4.37,45.05"),
                                StrokeThickness = 1,
                                Height = 85.911,
                                Width = 85.937,
                                Fill = new RadialGradientBrush(new GradientStopCollection(new List<GradientStop> {new GradientStop((Color)ColorConverter.ConvertFromString("#FF6C6D6F"), 0.7),new GradientStop((Color)ColorConverter.ConvertFromString("#FF57585A"), 0.74),new GradientStop((Color)ColorConverter.ConvertFromString("#FF6C6D6F"), 0.78),new GradientStop((Color)ColorConverter.ConvertFromString("#FF6C6D6F"), 1),})),
                                Stretch = System.Windows.Media.Stretch.Fill,
                            },
                            new Path
                            {
                                Data = Geometry.Parse("M47.8955,2.6587C71.6245,2.9687 90.6095,22.4497 90.2985,46.1707 89.9905,69.8927 70.5035,88.8717 46.7755,88.5627 23.0435,88.2517 4.0585,68.7717 4.3695,45.0497 4.67749999999999,21.3287 24.1645,2.3487 47.8955,2.6587z"),
                                StrokeThickness = 0.25,
                                Height = 86.161,
                                Width = 86.187,
                                Stroke = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4C4C4C")),
                                Stretch = System.Windows.Media.Stretch.Fill,
                            },
                        }
                    },
                }
            };
        }
    }
}
