using System;
using System.Collections.ObjectModel;
using SkiaSharp;
using SkiaSharp.Views.Maui;
using SkiaSharp.Views.Maui.Controls;
using App.Service;

namespace ISSProject
{
    public partial class DashBoardPage : ContentPage
    {
        public ObservableCollection<DataPoint> RevenueChartData { get; set; } = new ObservableCollection<DataPoint>();
        public ObservableCollection<string> StreamsLabelText { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> ClaimsLabelText { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> Artists { get; set; } = new ObservableCollection<string>();

        public Service _service = new Service();

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
            RevenueChartData.Add(new DataPoint("Jan.", 1000));
            RevenueChartData.Add(new DataPoint("Feb.", 1500));
            RevenueChartData.Add(new DataPoint("Mar.", 2000));
            RevenueChartData.Add(new DataPoint("Apr.", 2500));
            RevenueChartData.Add(new DataPoint("Jun.", 2000));
            RevenueChartData.Add(new DataPoint("Jul.", 500));
            StreamsLabelText.Add("Streams: 10000");
            ClaimsLabelText.Add("Claims: 10");

            // Add sample artists
            Artists = _service.GetClients();
        }

        private void OnPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            SKCanvas canvas = e.Surface.Canvas;
            canvas.Clear(SKColors.Transparent);

            // Define chart dimensions
            float chartWidth = e.Info.Width;
            float chartHeight = e.Info.Height;
            float barWidth = chartWidth / (RevenueChartData.Count + 1); // Adding padding between bars
            float maxValue = (float)RevenueChartData.Max(dp => dp.Value);

            // Define paint for drawing bars
            SKPaint barPaint = new SKPaint
            {
                Color = SKColors.CornflowerBlue,
                IsAntialias = true
            };

            // Define paint for drawing line chart
            SKPaint linePaint = new SKPaint
            {
                Color = SKColors.OrangeRed,
                StrokeWidth = 10,
                IsAntialias = true
            };

            SKPaint textPaint = new SKPaint
            {
                Color = SKColors.White,
                TextSize = 35,
                IsAntialias = true
            };


            // Draw labels on y-axis
            for (int i = 0; i < 6; i++)
            {
                float yPos = chartHeight - 50 - (chartHeight - 100) * i / 5;
                string label = (maxValue * i / 5).ToString("C0"); // Format label as currency
                canvas.DrawText(label, 50, yPos + 10, textPaint);
            }

            // Draw labels on x-axis
            for (int i = 0; i < RevenueChartData.Count; i++)
            {
                float xPos = 100 + (i + 1) * barWidth;
                string label = RevenueChartData[i].Label;
                canvas.DrawText(label, xPos - (textPaint.MeasureText(label) / 2), chartHeight - 25, textPaint);
            }

            // Draw bars for each data point
            for (int i = 0; i < RevenueChartData.Count; i++)
            {
                // Calculate bar dimensions
                float barX = 100 + (i + 1) * barWidth;
                float barHeight = (float)((chartHeight - 100) * (RevenueChartData[i].Value / maxValue));

                // Draw bar
                canvas.DrawRect(barX - (barWidth / 2), chartHeight - 50 - barHeight, barWidth, barHeight, barPaint);
            }


            for (int i = 0; i < RevenueChartData.Count - 1; i++)
            {
                float currentXPos = 100 + (i + 1) * barWidth;
                float currentYPos = chartHeight - 50 - (float)((chartHeight - 100) * (RevenueChartData[i].Value / maxValue));

                float nextXPos = 100 + (i + 2) * barWidth;
                float nextYPos = chartHeight - 50 - (float)((chartHeight - 100) * (RevenueChartData[i + 1].Value / maxValue));

                canvas.DrawLine(currentXPos, currentYPos, nextXPos, nextYPos, linePaint);
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
