# How-to-show-the-font-icons-or-symbols-in-MAUI-DataGrid (SfDataGrid)?

This article illustrates how to show the icons or symbols in a [.NET MAUI DataGrid](https://www.syncfusion.com/maui-controls/maui-datagrid) cell. In this example, we will show the icons using the Unicode character value of the font icon.

**STEP 1:** Register the font in your `MauiProgram.cs`. Here we are using the `FontAwesome` unicode characters. 

 ```C#
namespace MauiApp1;
using Syncfusion.Maui.Core.Hosting;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{   
                             fonts.AddFont("fa-solid.ttf", "FontAwesome");
                             fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
		             fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        builder.ConfigureSyncfusionCore();
        return builder.Build();
	}
}

 ```
 
**STEP 2:** Initialize the [SfDataGrid](https://help.syncfusion.com/maui/datagrid/getting-started) with the required properties. The display content of the DataGridColumn is determined by the `DataGridColumn.DisplayBinding` property. It gets or sets display binding that associates the DataGridColumn with a property in the data source. Create a custom [DataGridColumn.DisplayBinding](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.DataGrid.DataGridColumn.html#Syncfusion_Maui_DataGrid_DataGridColumn_DisplayBinding) Converter for the desired column to display the icon in the cell. This converter will provide the icon to display in the cells according to the cell value. Alternatively, you can use the [DataGridTemplateColumn](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.DataGrid.DataGridTemplateColumn.html) for the same column to achieve a similar outcome.


**MainPage.xaml**
 ```xml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:local="clr-namespace:MauiApp1"
             xmlns:dataGrid="clr-namespace:Syncfusion.Maui.DataGrid;assembly=Syncfusion.Maui.DataGrid"
             x:Class="MauiApp1.MainPage">
    <ContentPage.BindingContext>
        <local:OrderInfoRepository x:Name="viewModel"/>
    </ContentPage.BindingContext>
    <ContentPage.Resources>
        <local:CustomValueConverter x:Key="CustomValueConverter" />
        <Style TargetType="dataGrid:DataGridCell" x:Key="DataGridSelectedCellStyle">
            <Setter Property="BackgroundColor" Value="Honeydew"/>
            <Setter Property="TextAlignment" Value="Center"/>
            <Setter Property="FontSize" Value="15"/>
            <Setter Property="FontFamily" Value="FontAwesome"/>
        </Style>
    </ContentPage.Resources>

    <dataGrid:SfDataGrid x:Name="dataGrid"
                         SelectionMode="SingleDeselect"
                         ColumnWidthMode="Auto"
                         ItemsSource="{Binding OrderInfoCollection}">
        <dataGrid:SfDataGrid.Columns>
            <dataGrid:DataGridTemplateColumn HeaderText="Price"
                                             HeaderTextAlignment="Center"
                                             MappingName="Price">

                <dataGrid:DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <Grid Margin="15,0,0,0">
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition Width="*"/>
                                <ColumnDefinition Width="*"/>
                            </Grid.ColumnDefinitions>
                            <Label Text="{Binding Price}" 
                                   HorizontalOptions="Center"
                                   Grid.Column="0"
                                   VerticalOptions="Center"/>
                            <Label Text="{Binding Symbol, Converter={x:StaticResource CustomValueConverter}}"
                                   HorizontalOptions="Start"
                                   VerticalOptions="Center"
                                   FontSize="15"
                                   Grid.Column="1"/>
                            </Grid>
                    </DataTemplate>
                </dataGrid:DataGridTemplateColumn.CellTemplate>
            </dataGrid:DataGridTemplateColumn>
            <dataGrid:DataGridTextColumn HeaderText="Symbol"
                                         HeaderTextAlignment="Center"
                                         MappingName="Symbol"
                                         CellStyle="{StaticResource DataGridSelectedCellStyle}"
                                         DisplayBinding="{Binding Symbol, Converter={x:StaticResource CustomValueConverter}}"/>
        </dataGrid:SfDataGrid.Columns>
    </dataGrid:SfDataGrid>

</ContentPage>
 ```
 
**MainPage.xaml.cs**

 ```C#
using System.Globalization;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
    }

    public class CustomValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string val = value.ToString();
            if (val == "circle")
            {
                return IconCodes.Circle;
            }
            else if (val == "square")
            {
                return IconCodes.Square; 
            }
            else if (val == "triangle")
            {
                return IconCodes.TriangleExclamation;
            }
            else
            {
                return IconCodes.CircleUp;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)

        {
            throw new NotImplementedException();
        }
    }

}
 ```
