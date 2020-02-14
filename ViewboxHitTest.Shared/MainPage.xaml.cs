using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ViewboxHitTest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static readonly DependencyProperty SelectedRegionProperty = DependencyProperty.Register("SelectedRegion", typeof(string), typeof(MainPage), new PropertyMetadata("No region selected"));

        public MainPage()
        {
            this.InitializeComponent();
        }

        private IEnumerable<Path> GetRegions()
        {
            return new[]
            {
                Region1,
                Region2,
                Region3,
                Region4,
                Region5,
                Region6,
                Region7,
                Region8,
                Region9,
                Region10,
                Region11,
                Region12,
                Region13,
                Region14
            };
        }

        private string GetRegionForSender(object sender)
        {
            switch (sender)
            {
                case Path x when Equals(x, Region1): return  "North Scotland";
                case Path x when Equals(x, Region2): return  "South Scotland";
                case Path x when Equals(x, Region3): return  "North West England";
                case Path x when Equals(x, Region4): return  "North East England";
                case Path x when Equals(x, Region5): return  "Yorkshire";
                case Path x when Equals(x, Region6): return  "North Wales and Merseyside";
                case Path x when Equals(x, Region7): return  "South Wales";
                case Path x when Equals(x, Region8): return  "West Midlands";
                case Path x when Equals(x, Region9): return  "East Midlands";
                case Path x when Equals(x, Region10): return "East England";
                case Path x when Equals(x, Region11): return "South West England";
                case Path x when Equals(x, Region12): return "South England";
                case Path x when Equals(x, Region13): return "London";
                case Path x when Equals(x, Region14): return "South East England";
                default: return "No region selected";
            }
        }

        private void Region_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var child = viewBox.Child;

            var position = e.GetPosition(view);
            var transform = layer1.TransformToVisual(view);
            var actual = transform.TransformPoint(position);

            var region11Left = Canvas.GetLeft(Region11);
            var region11Top = Canvas.GetTop(Region11);
            var width = Region11.Width;
            var height = Region11.Height;

            SelectedRegion = GetRegionForSender(sender);
        }

        public string SelectedRegion
        {
            get { return (string)GetValue(SelectedRegionProperty); }
            set { SetValue(SelectedRegionProperty, value); }
        }
    }
}
