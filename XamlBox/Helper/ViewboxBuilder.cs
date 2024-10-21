using System;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.IO;
using System.Security.Policy;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace XamlBox.Helper
{
    /// <summary>
    /// To specify the distance
    /// </summary>
    enum CanvasDirection {  Left, Right, Top, Bottom }

    internal class DistanceSpecs {
        /// <summary>
        /// Direction of the distance
        /// </summary>
        public CanvasDirection Direction { get; set; }

        /// <summary>
        /// Specifies how to reach the element
        /// </summary>
        public List<int> TrackingList { get; set; } = new List<int>();

        /// <summary>
        /// Distance Value
        /// </summary>
        public double DistanceValue { get; set; }
    }

    /// <summary>
    /// For making viewbox classes string based on a xaml file
    /// </summary>
    public sealed class ViewboxBuilder
    {
        #region Private Members

        /// <summary>
        /// The made class as a string
        /// </summary>
        private string _classString = "";

        /// <summary>
        /// Name of the class
        /// </summary>
        private string _className = "";

        /// <summary>
        /// Namespace
        /// </summary>
        private string _namespace = "";

        /// <summary>
        /// For tracking the indcies of the current tracked element
        /// </summary>
        private List<int> _trackingIndices = new List<int>();

        /// <summary>
        /// A list of distances to add to the canvas lastly 
        /// </summary>
        private List<DistanceSpecs> _distances = new List<DistanceSpecs>();

        #endregion

        #region Public Properties

        /// <summary>
        /// The made class as a string
        /// </summary>
        public string ClassString { get => _classString; }

        /// <summary>
        /// Name of class
        /// </summary>
        public string ClassName { get => _className; }

        /// <summary>
        /// Namespace
        /// </summary>
        public string Namespace { get => _namespace; }

        /// <summary>
        /// Viewbox that class must be made of
        /// </summary>
        public Viewbox Vb { get; private set; } 

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ViewboxBuilder(Viewbox vb, string className, string nameSpace = "XamlBox")
        {
            _className = className;
            _namespace = nameSpace;
            Vb = vb;
        }

        #endregion

        #region Public Methods

        public void Build()
        {
            StringBuilder builder = new StringBuilder();
            using (StringWriter writer = new StringWriter(builder))
            {
                MakeHeader(writer, _className, _namespace);
                MakeConstructor(writer, Vb, _className);
                MakeFooter(writer);
            }

            _classString = builder.ToString();
        }

        #endregion

        #region Private Methods

        private void MakeHeader(StringWriter writer, string className, string nameSpace)
        {
            writer.WriteLine($"using System.Windows.Controls;");
            writer.WriteLine($"using System.Windows.Shapes;");
            writer.WriteLine();
            writer.WriteLine($"namespace {nameSpace}");
            writer.WriteLine($"{{");

            writer.WriteLine($"    public class {className} : Viewbox");
            writer.WriteLine($"    {{");
        }

        private void MakeConstructor(StringWriter writer, Viewbox vb, string className)
        {
            // Path --> Data, Height, Canvas.Left, Stretch, Stroke, StrokeThickness, Canvas.Top, Width, Fill
            // Polyline --> Points, Stroke, StrokeThickness, Fill
            // Polygon --> Points, Fill, Stroke, StrokeThickness
            // Ellipse --> Fill, Stroke, StrokeThickness, Width, Height, Canvas.Left, Canvas.Top
            // Rectangle --> Fill, Stroke, StrokeThickness, Canvas.Left, Canvas.Top, Width, Height
            string baseIndent = MakeIndent(2);
            writer.WriteLine($"{baseIndent}public {className}()");
            writer.WriteLine($"{baseIndent}{{");
            writer.WriteLine($"{baseIndent}    Height = {vb.Height.ToString(CultureInfo.InvariantCulture)};");
            writer.WriteLine($"{baseIndent}    Width = {vb.Width.ToString(CultureInfo.InvariantCulture)};");
            writer.WriteLine($"{baseIndent}    Child = new Canvas");
            writer.WriteLine($"{baseIndent}    {{");
            MakeCanvas(writer, 4, vb.Child as Canvas);
            writer.WriteLine($"{baseIndent}    }};");

            foreach (var disSpec in _distances)
            {
                var text = GenerateCanvasSetDirection(disSpec);
                writer.WriteLine($"{baseIndent}    {text};");
            }
            writer.WriteLine($"{baseIndent}}}");
        }

        private void MakeCanvas(StringWriter writer, int indentLevel, Canvas canvas)
        {
            string baseIndent = MakeIndent(indentLevel);

            writer.WriteLine($"{baseIndent}Height = {canvas.Height.ToString(CultureInfo.InvariantCulture)},");
            writer.WriteLine($"{baseIndent}Width = {canvas.Height.ToString(CultureInfo.InvariantCulture)},");

            if (canvas.Children.Count > 0)
            {
                writer.WriteLine($"{baseIndent}Children =");
                writer.WriteLine($"{baseIndent}{{");
                int counter = 0;
                foreach (var child in canvas.Children)
                {
                    _trackingIndices.Add(counter);
                    if (!double.IsNaN(Canvas.GetLeft(child as UIElement)))
                        _distances.Add(new DistanceSpecs { Direction = CanvasDirection.Left, TrackingList = _trackingIndices.ToList(), DistanceValue = Canvas.GetLeft(child as UIElement) });

                    if (!double.IsNaN(Canvas.GetRight(child as UIElement)))
                        _distances.Add(new DistanceSpecs { Direction = CanvasDirection.Right, TrackingList = _trackingIndices.ToList(), DistanceValue = Canvas.GetRight(child as UIElement) });

                    if (!double.IsNaN(Canvas.GetTop(child as UIElement)))
                        _distances.Add(new DistanceSpecs { Direction = CanvasDirection.Top, TrackingList = _trackingIndices.ToList(), DistanceValue = Canvas.GetTop(child as UIElement) });

                    if (!double.IsNaN(Canvas.GetBottom(child as UIElement)))
                        _distances.Add(new DistanceSpecs { Direction = CanvasDirection.Bottom, TrackingList = _trackingIndices.ToList(), DistanceValue = Canvas.GetBottom(child as UIElement) });


                    if (child is System.Windows.Shapes.Path path)
                    {
                        MakePath(writer, indentLevel + 1, path);
                    }
                    else if (child is Polygon polygon)
                    {
                        MakePolygon(writer, indentLevel + 1, polygon);
                    }
                    else if (child is Polyline polyline)
                    {
                        MakepPolyline(writer, indentLevel + 1, polyline);
                    }
                    else if (child is Ellipse ellipse)
                    {
                        MakeEllipse(writer, indentLevel + 1, ellipse);
                    }
                    else if (child is Rectangle rectangle)
                    {
                        MakeRectangle(writer, indentLevel + 1, rectangle);
                    }
                    else if (child is Canvas canv)
                    {
                        writer.WriteLine($"{baseIndent}    new Canvas");
                        writer.WriteLine($"{baseIndent}    {{");
                        MakeCanvas(writer, indentLevel + 2, canv);
                        writer.WriteLine($"{baseIndent}    }},");
                    }
                    else
                    {
                        throw new NotImplementedException(child.GetType().ToString());
                    }
                    _trackingIndices.RemoveAt(_trackingIndices.Count-1);
                    counter++;
                }
                writer.WriteLine($"{baseIndent}}}");
            }
        }

        private void MakePath(StringWriter writer, int indentLevel, System.Windows.Shapes.Path path)
        {
            string baseIndent = MakeIndent(indentLevel);



            writer.WriteLine($"{baseIndent}new Path");
            writer.WriteLine($"{baseIndent}{{");

            if (!string.IsNullOrWhiteSpace(path.Data.ToString()))
                writer.WriteLine($"{baseIndent}    Data = Geometry.Parse(\"{path.Data}\"),");

            if (path.StrokeThickness != double.NaN)
                writer.WriteLine($"{baseIndent}    StrokeThickness = {path.StrokeThickness.ToString(CultureInfo.InvariantCulture)},");

            if (path.Height != double.NaN)
                writer.WriteLine($"{baseIndent}    Height = {path.Height.ToString(CultureInfo.InvariantCulture)},");

            if (path.Width != double.NaN)
                writer.WriteLine($"{baseIndent}    Width = {path.Width.ToString(CultureInfo.InvariantCulture)},");

            if (path.Fill != null)
                writer.WriteLine($"{baseIndent}    Fill = {ConvertBrush(path.Fill)}");

            if (path.Stroke != null)
                writer.WriteLine($"{baseIndent}    Stroke = {ConvertBrush(path.Stroke)}");

            writer.WriteLine($"{baseIndent}    Stretch = System.Windows.Media.Stretch.{path.Stretch.ToString()},");

            writer.WriteLine($"{baseIndent}}},");
        }

        private void MakePolygon(StringWriter writer, int indentLevel, Polygon polygon)
        {
            string baseIndent = MakeIndent(indentLevel);

            writer.WriteLine($"{baseIndent}new Polygon");
            writer.WriteLine($"{baseIndent}{{");

            if (polygon.Points.Count > 0)
            {
                writer.Write($"{baseIndent}    Points = ");
                var pointsText = "new PointCollection { ";
                foreach (var point in polygon.Points) 
                {
                    new Polygon { Points = new PointCollection { new System.Windows.Point(1, 2), new System.Windows.Point(1, 2), } };
                    pointsText += $"new System.Windows.Point({point.X.ToString(CultureInfo.InvariantCulture)}, {point.Y.ToString(CultureInfo.InvariantCulture)}),";
                }

                pointsText += " },";

                writer.WriteLine(pointsText);
            }

            if (polygon.StrokeThickness != double.NaN)
                writer.WriteLine($"{baseIndent}    StrokeThickness = {polygon.StrokeThickness.ToString(CultureInfo.InvariantCulture)},");

            if (polygon.Height != double.NaN)
                writer.WriteLine($"{baseIndent}    Height = {polygon.Height.ToString(CultureInfo.InvariantCulture)},");

            if (polygon.Width != double.NaN)
                writer.WriteLine($"{baseIndent}    Width = {polygon.Width.ToString(CultureInfo.InvariantCulture)},");

            if (polygon.Fill != null)
                writer.WriteLine($"{baseIndent}    Fill = {ConvertBrush(polygon.Fill)}");

            if (polygon.Stroke != null)
                writer.WriteLine($"{baseIndent}    Stroke = {ConvertBrush(polygon.Stroke)}");

            writer.WriteLine($"{baseIndent}    Stretch = System.Windows.Media.Stretch.{polygon.Stretch.ToString()},");

            writer.WriteLine($"{baseIndent}}},");
        }

        private void MakepPolyline(StringWriter writer, int indentLevel, Polyline polyline)
        {
            string baseIndent = MakeIndent(indentLevel);

            writer.WriteLine($"{baseIndent}new Polyline");
            writer.WriteLine($"{baseIndent}{{");

            if (polyline.Points.Count > 0)
            {
                writer.Write($"{baseIndent}    Points = ");
                var pointsText = "new PointCollection { ";
                foreach (var point in polyline.Points)
                {
                    new Polygon { Points = new PointCollection { new System.Windows.Point(1, 2), new System.Windows.Point(1, 2), } };
                    pointsText += $"new System.Windows.Point({point.X.ToString(CultureInfo.InvariantCulture)}, {point.Y.ToString(CultureInfo.InvariantCulture)}),";
                }

                pointsText += " },";

                writer.WriteLine(pointsText);
            }

            if (polyline.StrokeThickness != double.NaN)
                writer.WriteLine($"{baseIndent}    StrokeThickness = {polyline.StrokeThickness.ToString(CultureInfo.InvariantCulture)},");
             
            if (polyline.Height != double.NaN)
                writer.WriteLine($"{baseIndent}    Height = {polyline.Height.ToString(CultureInfo.InvariantCulture)},");

            if (polyline.Width != double.NaN)
                writer.WriteLine($"{baseIndent}    Width = {polyline.Width.ToString(CultureInfo.InvariantCulture)},");

            if (polyline.Fill != null)
                writer.WriteLine($"{baseIndent}    Fill = {ConvertBrush(polyline.Fill)}");

            if (polyline.Stroke != null)
                writer.WriteLine($"{baseIndent}    Stroke = {ConvertBrush(polyline.Stroke)}");

            writer.WriteLine($"{baseIndent}    Stretch = System.Windows.Media.Stretch.{polyline.Stretch.ToString()},");

            writer.WriteLine($"{baseIndent}}},");
        }

        private void MakeEllipse(StringWriter writer, int indentLevel, Ellipse ellipse)
        {
            string baseIndent = MakeIndent(indentLevel);

            writer.WriteLine($"{baseIndent}new Ellipse");
            writer.WriteLine($"{baseIndent}{{");

            if (ellipse.StrokeThickness != double.NaN)
                writer.WriteLine($"{baseIndent}    StrokeThickness = {ellipse.StrokeThickness.ToString(CultureInfo.InvariantCulture)},");

            if (ellipse.Height != double.NaN)
                writer.WriteLine($"{baseIndent}    Height = {ellipse.Height.ToString(CultureInfo.InvariantCulture)},");

            if (ellipse.Width != double.NaN)
                writer.WriteLine($"{baseIndent}    Width = {ellipse.Width.ToString(CultureInfo.InvariantCulture)},");

            if (ellipse.Fill != null)
                writer.WriteLine($"{baseIndent}    Fill = {ConvertBrush(ellipse.Fill)}");

            if (ellipse.Stroke != null)
                writer.WriteLine($"{baseIndent}    Stroke = {ConvertBrush(ellipse.Stroke)}");

            writer.WriteLine($"{baseIndent}    Stretch = System.Windows.Media.Stretch.{ellipse.Stretch.ToString()},");

            writer.WriteLine($"{baseIndent}}},");
        }

        private void MakeRectangle(StringWriter writer, int indentLevel, Rectangle rectangle)
        {
            string baseIndent = MakeIndent(indentLevel);

            writer.WriteLine($"{baseIndent}new Rectangle");
            writer.WriteLine($"{baseIndent}{{");

            if (rectangle.StrokeThickness != double.NaN)
                writer.WriteLine($"{baseIndent}    StrokeThickness = {rectangle.StrokeThickness.ToString(CultureInfo.InvariantCulture)},");

            if (rectangle.Height != double.NaN)
                writer.WriteLine($"{baseIndent}    Height = {rectangle.Height.ToString(CultureInfo.InvariantCulture)},");

            if (rectangle.Width != double.NaN)
                writer.WriteLine($"{baseIndent}    Width = {rectangle.Width.ToString(CultureInfo.InvariantCulture)},");

            if (rectangle.Fill != null)
                writer.WriteLine($"{baseIndent}    Fill = {ConvertBrush(rectangle.Fill)}");

            if (rectangle.Stroke != null)
                writer.WriteLine($"{baseIndent}    Stroke = {ConvertBrush(rectangle.Stroke)}");

            writer.WriteLine($"{baseIndent}    Stretch = System.Windows.Media.Stretch.{rectangle.Stretch.ToString()},");

            writer.WriteLine($"{baseIndent}}},");
        }

        private void MakeFooter(StringWriter writer)
        {
            writer.WriteLine("    }");
            writer.WriteLine("}");
        }

        private string MakeIndent(int level)
        {
            return new string(' ', level * 4);
        }

        private string ConvertBrush(System.Windows.Media.Brush brush)
        {
            if (brush is SolidColorBrush scb)
            {
                return $"new SolidColorBrush((Color)ColorConverter.ConvertFromString(\"{scb.Color}\")),";
            }
            else if (brush is LinearGradientBrush lgb)
            {
                return GenerateLinearGradientBrush(lgb);
            }
            else if (brush is RadialGradientBrush rgb)
            {
                return GenerateRadialGradientBrush(rgb);
            }
            else
            {
                throw new NotImplementedException($"Unimplmented brush type: {brush.GetType().ToString()}");
            }
        }

        private string GenerateLinearGradientBrush(LinearGradientBrush lgb)
        {
            // Initialize the LinearGradientBrush
            var text = "new LinearGradientBrush(";

            // Appending GradientStops
            if (lgb.GradientStops.Count > 0)
            {
                text += "new GradientStopCollection(new List<GradientStop> {";
                foreach (var color in lgb.GradientStops)
                {
                    text += $"new GradientStop((Color)ColorConverter.ConvertFromString(\"{color.Color}\"), {color.Offset.ToString(CultureInfo.InvariantCulture)}),";
                }
                text += "}),";
            }

            // Adding the start point
            text += $"new System.Windows.Point({lgb.StartPoint.X.ToString()}, {lgb.StartPoint.Y.ToString()}), ";

            // Adding the end point
            text += $"new System.Windows.Point({lgb.EndPoint.X.ToString()}, {lgb.EndPoint.Y.ToString()})),";

            return text;
        }

        private string GenerateRadialGradientBrush(RadialGradientBrush rgb)
        {
            // Initialize the RadialGradientBrush
            var text = "new RadialGradientBrush(";

            // Appending GradientStops
            if (rgb.GradientStops.Count > 0)
            {
                text += "new GradientStopCollection(new List<GradientStop> {";
                foreach (var color in rgb.GradientStops)
                {
                    text += $"new GradientStop((Color)ColorConverter.ConvertFromString(\"{color.Color}\"), {color.Offset.ToString(CultureInfo.InvariantCulture)}),";
                }
                text += "})";
            }

            text += "),";

            return text;
        }

        private string GenerateCanvasSetDirection(DistanceSpecs specs)
        {
            if (specs.TrackingList.Count <= 0)
                throw new Exception("Tracking List cannot be empty. This indicates a bug in the detector code section.");

            string text = "Canvas.Set";
            switch (specs.Direction)
            {
                case CanvasDirection.Left:
                    text += "Left(";
                    break;
                case CanvasDirection.Right:
                    text += "Right(";
                    break;
                case CanvasDirection.Top:
                    text += "Top(";
                    break;
                case CanvasDirection.Bottom:
                    text += "Bottom(";
                    break;
                default:
                    throw new NotImplementedException();
            }

            string element = $"((Canvas)Child).Children[{specs.TrackingList[0]}]";

            // (Canvas)((Canvas)((Canvas)Child.Children[2]).Children[3])).Children[1]

            for (int i = 1; i < specs.TrackingList.Count - 2; i++)
            {
                element = $"((Canvas)({element})).Children[{specs.TrackingList[i]}]";
            }

            if (specs.TrackingList.Count > 1)
            {
                element = $"((Canvas)({element})).Children[{specs.TrackingList[specs.TrackingList.Count - 1]}]";
            }

            return $"{text}{element}, {specs.DistanceValue})";
        }

        #endregion
    }
}
