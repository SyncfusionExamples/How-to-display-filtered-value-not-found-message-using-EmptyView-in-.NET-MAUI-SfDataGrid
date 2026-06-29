# How to display filtered value not found message using EmptyView in .NET MAUI SfDataGrid?
This article shows How to display filtered value not found message using EmptyView in [.NET MAUI DataGrid?](https://help.syncfusion.com/maui/datagrid/overview) (SfDataGrid)
It demonstrates how to implement search-based filtering and use EmptyView with a custom template to dynamically display a message when no matching records are found.

## Xaml
```
<ContentPage.BindingContext>
    <local:OrderInfoRepository x:Name="viewModel"/>
</ContentPage.BindingContext>

<Grid RowDefinitions="Auto,*" Padding="10">
    <!-- Search Bar at the top -->
    <Grid Grid.Row="0" Margin="0,5,0,10" HorizontalOptions="Center">
        <SearchBar x:Name="filterText" WidthRequest="350" HorizontalOptions="Center"
                       Placeholder="Search..." 
                       PlaceholderColor="Gray"
                       TextChanged="OnSearchBarTextChanged"/>
    </Grid>
    <syncfusion:SfDataGrid Grid.Row="1" x:Name="dataGrid" HorizontalOptions="Center" Margin="20"
                        ColumnWidthMode="Auto"
                        GridLinesVisibility="Both" 
                        HeaderGridLinesVisibility="Both"
                        ItemsSource="{Binding OrderInfoCollection}">
        <syncfusion:SfDataGrid.Columns>
            <syncfusion:DataGridNumericColumn MappingName="OrderID" HeaderText="Order ID" Format="#"/>
            <syncfusion:DataGridTextColumn MappingName="CustomerName" HeaderText="Customer Name"/>
            <syncfusion:DataGridTextColumn MappingName="ShipCountry" HeaderText="Ship Country"/>
            <syncfusion:DataGridTextColumn MappingName="ShipCity" HeaderText="Ship City"/>
            <syncfusion:DataGridDateColumn MappingName="OrderDate" HeaderText="Order Date"/>
        </syncfusion:SfDataGrid.Columns>
        <syncfusion:SfDataGrid.EmptyView>
            <local:FilterItem Filter="{Binding Source={x:Reference filterText},Path=Text}"
                              x:Name="filter"/>
        </syncfusion:SfDataGrid.EmptyView>
        <syncfusion:SfDataGrid.EmptyViewTemplate>
            <DataTemplate>
                <Label Text="{Binding Source={x:Reference filterText},Path=Text, StringFormat='{0} is not found'}"
                       TextColor="Black"
                       HorizontalTextAlignment="Center"
                       VerticalOptions="Center"
                       FontSize="14"
                       FontFamily="Roboto-Regular"/>
            </DataTemplate>
        </syncfusion:SfDataGrid.EmptyViewTemplate>
    </syncfusion:SfDataGrid>
</Grid>
```
## Xaml.cs
```
 public partial class MainPage : ContentPage
 {
     public MainPage()
     {
         InitializeComponent();
     }

     private void OnSearchBarTextChanged(object sender, TextChangedEventArgs e)
     {
         // Apply filter when text changes
         if (dataGrid.View != null)
         {
             dataGrid.View.Filter = FilterRecords;
             dataGrid.View.RefreshFilter();
         }
     }

     public bool FilterRecords(object record)
     {
         if (string.IsNullOrEmpty(filterText.Text))
             return true;

         string searchText = filterText.Text.ToLower();

         if (record is OrderInfo orderInfo)
         {
             // Match in any of these fields (case-insensitive)
             return orderInfo.OrderID.ToString().ToLower().Contains(searchText) ||
                 (orderInfo.CustomerName ?? string.Empty).ToLower().Contains(searchText) ||
                 orderInfo.OrderDate.ToString("d").ToLower().Contains(searchText) ||
                 (orderInfo.ShipCity ?? string.Empty).ToLower().Contains(searchText) ||
                 (orderInfo.ShipCountry ?? string.Empty).ToLower().Contains(searchText);
         }

         return false;
     }
 }

```
## Requirements to run the demo

To run the demo, refer to [System Requirements for .NET MAUI](https://help.syncfusion.com/maui/system-requirements)

## Troubleshooting:
### Path too long exception

If you are facing path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.

## License

Syncfusion has no liability for any damage or consequence that may arise from using or viewing the samples. The samples are for demonstrative purposes. If you choose to use or access the samples, you agree to not hold Syncfusion liable, in any form, for any damage related to use, for accessing, or viewing the samples. By accessing, viewing, or seeing the samples, you acknowledge and agree Syncfusion's samples will not allow you seek injunctive relief in any form for any claim related to the sample. If you do not agree to this, do not view, access, utilize, or otherwise do anything with Syncfusion's samples.
