using System.Windows.Controls;
using System.Windows.Shapes;

namespace XamlBox.Sample
{
    public class SampleViewbox : Viewbox
    {
        public SampleViewbox()
        { 
            Canvas c = new Canvas();

            Child = c;

            c.Children.Add(new Path { });

            var p = new Path();
        }
    }
}
