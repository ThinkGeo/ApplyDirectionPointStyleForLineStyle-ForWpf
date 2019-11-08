# Apply DirectionPointStyle for LineStyle for Wpf

### Description

The Map Suite WPF ApplyDirectionPointStyleForLineStyle sample will guide you to how to draw directionPointStyle of lineStyle on map. This ApplyDirectionPointStyleForLineStyle sample supports Map Suite 10.0.0.0 and higher and will show you how to create a WPF application using Map Suite WPF components.

Please refer to [Wiki](http://wiki.thinkgeo.com/wiki/map_suite_desktop_for_wpf) for the details.

![Screenshot](https://github.com/ThinkGeo/ApplyDirectionPointStyleForLineStyle-ForWpf/blob/master/Screenshot.png)

### About the Code

``` csharp
var lineStyle = new LineStyle(new GeoPen(GeoColors.Black, 16) { StartCap = DrawingLineCap.Round, EndCap = DrawingLineCap.Round }, new GeoPen(GeoColors.White, 13) { StartCap = DrawingLineCap.Round, EndCap = DrawingLineCap.Round });
lineStyle.RequiredColumnNames.Add("FENAME");
lineStyle.DirectionPointStyle = new PointStyle(new GeoImage("AppData\\Arrow.png"));
lineStyle.DrawingDirectionPoint += LineStyle_DrawingPointStyle;

private void LineStyle_DrawingPointStyle(object sender, DrawingDirectionPointEventArgs e)
{
    if (e.Line.ColumnValues["FENAME"] =="Mo-Pac")
    {
        e.RotationAngle = 0;
    }
}
```

### Getting Help

[Map Suite Desktop for Wpf Wiki Resources](http://wiki.thinkgeo.com/wiki/map_suite_desktop_for_wpf)

[Map Suite Desktop for Wpf Product Description](https://thinkgeo.com/ui-controls#desktop-platforms)

[ThinkGeo Community Site](http://community.thinkgeo.com/)

[ThinkGeo Web Site](http://www.thinkgeo.com)

### About ThinkGeo

ThinkGeo is a GIS (Geographic Information Systems) company founded in 2004 and located in Frisco, TX. Our clients are in more than 40 industries including agriculture, energy, transportation, government, engineering, software development, and defense.

