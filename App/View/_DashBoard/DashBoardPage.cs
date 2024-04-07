using System;
using System.Collections.ObjectModel;
using SkiaSharp;
using SkiaSharp.Views.Maui;
using SkiaSharp.Views.Maui.Controls;

namespace ISSProject
{
    public partial class DashBoardPage : ContentPage
    {
        public ObservableCollection<DataPoint> RevenueChartData { get; set; } = new ObservableCollection<DataPoint>();
        public ObservableCollection<string> StreamsLabelText { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> ClaimsLabelText { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> Artists { get; set; } = new ObservableCollection<string>();

        public DashBoardPage()
        {
            InitializeComponent();

            BindingContext = this;

            MockData();
        }

        private void BuyAds_Clicked(object sender, EventArgs e)
        {
            // Handle Buy More Ads button click
        }

        private void TakeDown_Clicked(object sender, EventArgs e)
        {
            // Handle Take Down Request button click
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Handle search text change event
        }

        private void ArtistsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // Handle artist list item selection
        }

        private void MockData()
        {
            // Mock data for revenue chart
            RevenueChartData.Add(new DataPoint("January", 1000));
            RevenueChartData.Add(new DataPoint("February", 1500));
            RevenueChartData.Add(new DataPoint("March", 2000));
            RevenueChartData.Add(new DataPoint("April", 2500));

            StreamsLabelText.Add("Streams: 10000");
            ClaimsLabelText.Add("Claims: 10");

            // Add sample artists
            Artists.Add("Artist 1");
            Artists.Add("Artist 2");
            Artists.Add("Artist 3");
        }

        private void OnPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            SKCanvas canvas = e.Surface.Canvas;
            canvas.Clear(SKColors.White);

            // Define chart dimensions
            float chartWidth = e.Info.Width;
            float chartHeight = e.Info.Height;
            float barWidth = chartWidth / RevenueChartData.Count;
            float maxValue = (float)RevenueChartData.Max(dp => dp.Value);

            // Define paint for drawing bars
            SKPaint barPaint = new SKPaint
            {
                Color = SKColors.Blue,
                IsAntialias = true
            };

            // Draw bars for each data point
            for (int i = 0; i < RevenueChartData.Count; i++)
            {
                // Calculate bar dimensions
                float barX = i * barWidth;
                float barHeight = (float)(chartHeight * (RevenueChartData[i].Value / maxValue));

                // Draw bar
                canvas.DrawRect(barX, chartHeight - barHeight, barWidth, barHeight, barPaint);
            }
        }
    }

    public class DataPoint
    {
        public string Label { get; set; }
        public double Value { get; set; }

        public DataPoint(string label, double value)
        {
            Label = label;
            Value = value;
        }
    }
}
