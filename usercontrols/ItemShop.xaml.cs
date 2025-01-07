using System.ComponentModel;
using System.Net;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CookieClicker.usercontrols
{

    public partial class ItemShop : UserControl, INotifyPropertyChanged
    { 

        // Constructor
        public ItemShop()
        {
            InitializeComponent();
            DataContext = this;
            UserControl.DataContext = this;
        }

        // DataBinding / Variables
        private float? _itemPrice = 1, _itemQuantity = 1;
        private string? _itemName;
        private ImageBrush? _itemIcon, _ucBg;

        public string? ItemName { get { return _itemName; } set { _itemName = value; OnPropertyChanged(nameof(ItemName)); } }
        public ImageBrush? ItemIcon { get { return _itemIcon; } set { _itemIcon = value; OnPropertyChanged(nameof(ItemIcon)); } }
        public ImageBrush? UCBackground { get { return _ucBg; } set { _ucBg = value; OnPropertyChanged(nameof(UCBackground)); } }
        public float? ItemPrice { get { return _itemPrice; } set { _itemPrice = value; OnPropertyChanged(nameof(ItemPrice)); } }
        public float? ItemQuantity { get { return _itemQuantity; } set { _itemQuantity = value; OnPropertyChanged(nameof(ItemQuantity)); } }
        public float Multiplier { get; set; }
        public int? CookiesPerItem { get; set; }

        public void UpdateItemVisibility(bool mustBeVisible)
        {
            ImageBrush allowedButton = (ImageBrush)Application.Current.Resources["AllowedButtonTile"];
            ImageBrush unallowedButton = (ImageBrush)Application.Current.Resources["UnallowedButtonTile"];

            UCBackground = mustBeVisible ? allowedButton : unallowedButton;
        }

        /* BINDING */

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
