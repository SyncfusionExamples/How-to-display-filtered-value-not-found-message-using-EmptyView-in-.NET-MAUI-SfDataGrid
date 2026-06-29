namespace SfDataGridSample
{
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
}
