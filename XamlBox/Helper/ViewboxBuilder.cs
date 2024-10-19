using System.Globalization;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace XamlBox.Helper
{
    /// <summary>
    /// For making viewbox classes string based on a xaml file
    /// </summary>
    public sealed class ViewboxBuilder
    {
        #region Constants

        /// <summary>
        /// Base indentation
        /// </summary>
        private const string BaseIndent = "    ";

        #endregion

        #region Private Members

        /// <summary>
        /// Contains the class
        /// </summary>
        private string _classString = "";

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ViewboxBuilder(Viewbox vb)
        {

        }

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        private void MakeHeader(StreamWriter writer, string className, string nameSpace = "XamlBox")
        {
            writer.WriteLine($"using System.Windows.Controls;");
            writer.WriteLine($"using System.Windows.Shapes;");
            writer.WriteLine();
            writer.WriteLine($"namespace {nameSpace}");
            writer.WriteLine($"{{");

            writer.WriteLine($"    public class {className} : Viewbox");
            writer.WriteLine($"    {{");
        }

        private void MakeConstructor(StreamWriter writer, Viewbox vb, string className)
        {
            // Path --> Data, Height, Canvas.Left, Stretch, Stroke, StrokeThickness, Canvas.Top, Width, Fill
            // Polyline --> Points, Stroke, StrokeThickness, Fill
            // Polygon --> Points, Fill, Stroke, StrokeThickness
            // Ellipse --> Fill, Stroke, StrokeThickness, Width, Height, Canvas.Left, Canvas.Top
            // Rectangle --> Fill, Stroke, StrokeThickness, Canvas.Left, Canvas.Top, Width, Height
            string baseIndent = MakeIndent(2);
            writer.WriteLine($"{baseIndent}public {className}()");
            writer.WriteLine($"{baseIndent}{{");
            writer.WriteLine($"{baseIndent}    Height = {vb.Height.ToString(CultureInfo.InvariantCulture)},");
            writer.WriteLine($"{baseIndent}    Width = {vb.Width.ToString(CultureInfo.InvariantCulture)},");
            writer.WriteLine($"{baseIndent}    Child = new Canvas");
            writer.WriteLine($"{baseIndent}    {{");


            // TODO: close the child
            // TODO: close the view 
        }

        private void MakeCanvas(StreamWriter writer, int indentLevel, Canvas canvas)
        {
            string baseIndent = MakeIndent(indentLevel);

            writer.WriteLine($"{baseIndent}Height = {canvas.Height.ToString(CultureInfo.InvariantCulture)},");
            writer.WriteLine($"{baseIndent}Width = {canvas.Height.ToString(CultureInfo.InvariantCulture)},");

            if (canvas.Children.Count > 0)
            {
                writer.WriteLine($"{baseIndent}    Children =");
                writer.WriteLine($"{baseIndent}    {{");

                foreach (var child in canvas.Children)
                {
                    if (child is System.Windows.Shapes.Path path)
                    {
                        MakePath(writer, indentLevel + 2, path);
                    }
                    else if (child is Polygon polygon)
                    {
                        MakePolygon(writer, indentLevel + 2, polygon);
                    }
                    else if (child is Polyline polyline)
                    {
                        MakepPolyline(writer, indentLevel + 2, polyline);
                    }
                    else if (child is Ellipse ellipse)
                    {
                        MakeEllipse(writer, indentLevel + 2, ellipse);
                    }
                    else if (child is Rectangle rectangle)
                    {
                        MakeRectangle(writer, indentLevel + 2, rectangle);
                    }
                    else if (child is Canvas canv)
                    {
                        writer.WriteLine($"{baseIndent}new Canvas");
                        writer.WriteLine($"{baseIndent}{{");
                        MakeCanvas(writer, indentLevel + 3, canv);
                    }
                    else
                    {
                        throw new NotImplementedException(child.GetType().ToString());
                    }
                }
            }

            writer.WriteLine($"{baseIndent}}},");
        }

        private void MakePath(StreamWriter writer, int indentLevel, System.Windows.Shapes.Path path)
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


            // TODO: Fill
            // TODO: Stroke

            writer.WriteLine($"{baseIndent}    Stretch = System.Windows.Media.Stretch.{path.Stretch.ToString()}");

        }

        private void MakePolygon(StreamWriter writer, int indentLevel, Polygon polygon)
        {
            string baseIndent = MakeIndent(indentLevel);


        }

        private void MakepPolyline(StreamWriter writer, int indentLevel, Polyline polyline)
        {
            string baseIndent = MakeIndent(indentLevel);
        }

        private void MakeEllipse(StreamWriter writer, int indentLevel, Ellipse ellipse)
        {
            string baseIndent = MakeIndent(indentLevel);
        }

        private void MakeRectangle(StreamWriter writer, int indentLevel, Rectangle rectangle)
        {
            string baseIndent = MakeIndent(indentLevel);
        }

        private void MakeFooter(StreamWriter writer)
        {

        }

        private string MakeIndent(int level)
        {
            return new string(' ', level * 4);
        }

        private string ConvertBrush(System.Windows.Media.Brush brush)
        {
            if (brush is SolidColorBrush scb)
            {
                return $"new SolidColorBrush(Colors.{scb.Color}),";
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
                    text += $"new GradientStop(Colors.{color.Color}, {color.Offset.ToString(CultureInfo.InvariantCulture)}),";
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
                    text += $"new GradientStop(Colors.{color.Color}, {color.Offset.ToString(CultureInfo.InvariantCulture)}),";
                }
                text += "})";
            }

            text += "),";

            return text;
        }

        #endregion
    }
}
