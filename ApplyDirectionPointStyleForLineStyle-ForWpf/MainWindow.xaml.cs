using System.Windows;
using ThinkGeo.MapSuite;
using ThinkGeo.MapSuite.Drawing;
using ThinkGeo.MapSuite.Layers;
using ThinkGeo.MapSuite.Shapes;
using ThinkGeo.MapSuite.Styles;
using ThinkGeo.MapSuite.Wpf;

namespace ApplyDirectionPointStyleForLineStyle_ForWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void mapView_Loaded(object sender, RoutedEventArgs e)
        {
            var lineStyle = new LineStyle(new GeoPen(GeoColors.Black, 16) { StartCap = DrawingLineCap.Round, EndCap = DrawingLineCap.Round }, new GeoPen(GeoColors.White, 13) { StartCap = DrawingLineCap.Round, EndCap = DrawingLineCap.Round });
            lineStyle.RequiredColumnNames.Add("FENAME");
            lineStyle.DirectionPointStyle = new PointStyle(new GeoImage("AppData\\Arrow.png"));
            lineStyle.DrawingDirectionPoint += LineStyle_DrawingPointStyle;

            var streetsShapeFileFeatureLayer = new ShapeFileFeatureLayer("AppData\\Austinstreets.shp");
            streetsShapeFileFeatureLayer.DrawingQuality = DrawingQuality.HighQuality;
            streetsShapeFileFeatureLayer.ZoomLevelSet.ZoomLevel01.DefaultLineStyle = lineStyle;
            streetsShapeFileFeatureLayer.ZoomLevelSet.ZoomLevel01.ApplyUntilZoomLevel = ApplyUntilZoomLevel.Level20;

            var layerOverlay = new LayerOverlay();
            layerOverlay.Layers.Add(streetsShapeFileFeatureLayer);

            mapView.Overlays.Add(layerOverlay);
            mapView.MapUnit = GeographyUnit.DecimalDegree;
            mapView.CurrentExtent = new RectangleShape(-97.76312662255097, 30.30168722494507, -97.75471521508027, 30.29566834791565);
            mapView.Refresh();
        }

        private void LineStyle_DrawingPointStyle(object sender, DrawingDirectionPointEventArgs e)
        {
            if (e.Line.ColumnValues["FENAME"] =="Mo-Pac")
            {
                e.RotationAngle = 0;
            }
        }
    }
}
