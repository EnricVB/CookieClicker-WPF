using CookieClicker.usercontrols;

using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace CookieClicker {
    public partial class MainWindow : Window, INotifyPropertyChanged {
        private GameDataManager dataManager;
        private EventManager eventManager;

        private DispatcherTimer generateCookieTicker;
        private DispatcherTimer cursorClickTicker;
        private DispatcherTimer autosaveTicker;
        private DispatcherTimer cookieEventTicker;

        public int? _cookies = 0;
        public int? CookiesAmount { get { return _cookies; } set { _cookies = value; OnPropertyChanged(nameof(CookiesAmount)); } }


        public MainWindow() {
            InitializeComponent();

            this.DataContext = this;
            BuyCursor.DataContext = this;
            BuyGrandma.DataContext = this;
            BuyFarm.DataContext = this;
            BuyMine.DataContext = this;
            BuyFactory.DataContext = this;

            // Managers initialization
            dataManager = new(this);
            eventManager = new(this);

            // Generate Cookies Ticker
            generateCookieTicker = new();
            generateCookieTicker.Interval = TimeSpan.FromSeconds(1);
            generateCookieTicker.Tick += GenerateCookies;
            generateCookieTicker.Start();

            // Cursor Bought Ticker
            cursorClickTicker = new();
            cursorClickTicker.Interval = TimeSpan.FromSeconds(Int16.MaxValue);
            cursorClickTicker.Tick += OnCursorClickCookie;
            cursorClickTicker.Start();

            // Autosave Ticker
            autosaveTicker = new();
            autosaveTicker.Interval = TimeSpan.FromMinutes(5);
            autosaveTicker.Tick += (sender, e) => dataManager.Save();
            autosaveTicker.Start();

            // Event Tickers
            cookieEventTicker = new();
            cookieEventTicker.Interval = TimeSpan.FromMinutes(new Random().Next(1, 5));
            cookieEventTicker.Tick += (sender, e) => eventManager.RunRandomEvent();
            cookieEventTicker.Start();

            // Save data
            Closing += (sender, e) => dataManager.Save();

            // Load data
            dataManager.Load();
        }


        private static void AnimateCookie(Button button, double originalScale, double enlargedScale) {
            // On click, no matter the actual height, it will increase to maximum size (200) simulating a click.
            DoubleAnimation clickAnimation = new() {
                From = button.ActualHeight - 10, // Decrease by 10 to give a press effect
                To = enlargedScale, // Maximum size
                Duration = TimeSpan.FromSeconds(0.1),
            };

            clickAnimation.Completed += (s, args) => {
                // This code will be executed on finish the clickAnimation.
                DoubleAnimation reverseAnimation = new() {
                    From = enlargedScale,
                    To = originalScale,
                    Duration = TimeSpan.FromSeconds(0.1),
                };

                // Start reverse animation
                button.BeginAnimation(Image.HeightProperty, reverseAnimation);
                button.BeginAnimation(Image.WidthProperty, reverseAnimation);
            };

            // Animate the height of the border to simulate a press effect.
            button.BeginAnimation(Border.HeightProperty, clickAnimation);
            button.BeginAnimation(Border.WidthProperty, clickAnimation);
        }

        private void OnChangeWindowSize(object sender, SizeChangedEventArgs e) {
            double windowWidth = this.ActualWidth;

            // Change Cookie size automatically
            Cookie.MaxWidth = windowWidth / 6;
            Cookie.MaxHeight = windowWidth / 6;

            Cookie.MinWidth = windowWidth / 6.5;
            Cookie.MinHeight = windowWidth / 6.5;
        }

        private void OnCursorClickCookie(object? sender, EventArgs e) {
            AnimateCookie(Cookie, Cookie.MinWidth, Cookie.MaxWidth);
        }

        private void OnCookieClick(object sender, RoutedEventArgs e) {
            Button button = (sender as Button)!;
            UpdateItemShopVisibility();

            AnimateCookie(button, button.MinWidth, button.MaxWidth);
            CookiesAmount += 1;
        }

        private void OnBuyCursor(object sender, MouseButtonEventArgs e) {
            int cursorQuantity = (int) BuyCursor.ItemQuantity!;

            if (cursorQuantity > 0) {
                cursorClickTicker.Interval = TimeSpan.FromMilliseconds(1000 / Math.Min(3, (cursorQuantity / 10) + 1));
            }
        }

        private void OnBuyItem(object sender, MouseButtonEventArgs e) {
            ItemShop item = (ItemShop)sender;

            if (BuyItem(item)) GenerateItem(item);
            UpdateItemShopVisibility();
        }

        private bool BuyItem(ItemShop item) {
            int itemPrice = (int)Math.Round(item.ItemPrice.GetValueOrDefault(0));

            if (CookiesAmount >= itemPrice) {
                CookiesAmount -= itemPrice;
                item.ItemPrice *= 1.2f;
                item.ItemQuantity++;

                return true;
            }

            return false;
        }

        private void GenerateItemsOnStart() {
            List<ItemShop> items = [BuyCursor, BuyGrandma, BuyFarm, BuyMine, BuyFactory];

            foreach (var item in items) {
                for (int quantity = 0; quantity < item.ItemQuantity; quantity++) {
                    GenerateItem(item, quantity);
                }
            }
        }

        private void GenerateItem(ItemShop item, float? quantity) {
            int itemQuantity = (int)Math.Max(1, quantity!.Value);

            string itemName = item.Name[3..];
            (int imageSize, Canvas? canvas) = itemName switch {
                "Grandma" => (50, GrandmaCanvas),
                "Farm" => (30, FarmCanvas),
                "Mine" => (35, MineCanvas),
                "Factory" => (40, FactoryCanvas),
                _ => (0, null)
            };

            if (canvas == null || itemQuantity > 80) return;

            Border randomImageBorder = new() {
                Width = imageSize,
                Height = imageSize,
                Background = (ImageBrush)FindResource(itemName)
            };

            double height = GrandmaCanvas.ActualHeight;

            Random random = new();

            double xPos = itemQuantity * 10;
            double yPos = height / Math.Max(1.35F, (itemQuantity % 3) + 1);
            yPos += (random.NextDouble() - 0.5) * 20;

            Canvas.SetLeft(randomImageBorder, xPos);
            Canvas.SetTop(randomImageBorder, yPos);
            canvas.Children.Add(randomImageBorder);
        }

        private void GenerateItem(ItemShop item) {
            GenerateItem(item, item.ItemQuantity);
        }

        private void GenerateCookies(object? sender, EventArgs e) {
            List<ItemShop> items = [BuyCursor, BuyGrandma, BuyFarm, BuyMine, BuyFactory];

            int cookiesPerSecond = (int)items.Sum(item => item.ItemQuantity! * item.CookiesPerItem!)!;
            CookiesAmount += cookiesPerSecond;

            UpdateItemShopVisibility();
        }

        /* EVENT RELATED */
        public void SummonRainCookie(int cookieMultiplier)
        {
            Random random = new();
            double width = this.ActualWidth * (random.NextDouble() + 0.5);

            Button cookieButton = new()
            {
                Background = (Brush)FindResource("Cookie"),
                Template = (ControlTemplate)FindResource("NoHoverButtonStyle"),
                MaxWidth = width / 15,
                MaxHeight = width / 15,
                MinWidth = width / 17,
                MinHeight = width / 17
            };

            SimpleMovementBorder.Children.Add(cookieButton);
            AnimateRainCookie(cookieButton);

            cookieButton.Click += (sender, e) =>
            {
                SimpleMovementBorder.Children.Remove(cookieButton);
                CookiesAmount += BuyCursor.CookiesPerItem * cookieMultiplier;
            };
        }

        private void AnimateRainCookie(Button cookieButton)
        {
            Random random = new();
            int duration = random.Next(2, 5);

            int initialVerticalPosition = random.Next((int) -ActualWidth, (int) ActualWidth);
            int finalVerticalPosition = initialVerticalPosition + random.Next(0, 350);

            int initialHorizontalPosition = (int) -ActualHeight - 100;
            int finalHorizontalPosition = (int) (ActualHeight + 100);

            ThicknessAnimation animation = new()
            {
                From = new Thickness(initialVerticalPosition, initialHorizontalPosition, 0, 0),
                To = new Thickness(finalVerticalPosition, finalHorizontalPosition, 0, 0),
                Duration = TimeSpan.FromSeconds(duration),
            };

            // Remove on finish animation
            animation.Completed += (sender, e) => {
                SimpleMovementBorder.Children.Remove(cookieButton);
            };

            cookieButton.BeginAnimation(Button.MarginProperty, animation);
        }

        public void SummonGoldenCookie(int cookieMultiplier)
        {
            Random random = new();
            double width = this.ActualWidth * (random.NextDouble() + 0.5);

            Button goldCookieButton = new()
            {
                Background = (Brush)FindResource("GoldCookie"),
                Template = (ControlTemplate)FindResource("NoHoverButtonStyle"),
                MaxWidth = width / 15,
                MaxHeight = width / 15,
                MinWidth = width / 17,
                MinHeight = width / 17
            };

            SimpleMovementBorder.Children.Add(goldCookieButton);
            AnimateGoldCookie(goldCookieButton);

            goldCookieButton.Click += (sender, e) =>
            {
                SimpleMovementBorder.Children.Remove(goldCookieButton);
                CookiesAmount += BuyCursor.CookiesPerItem * cookieMultiplier;
            };
        }

        private void AnimateGoldCookie(Button cookieButton)
        {
            Random random = new();
            int duration = random.Next(2, 5);

            int verticalPosition = random.Next((int)-ActualWidth, (int)ActualWidth);
            int horizontalPosition = random.Next((int)-ActualHeight, (int)ActualHeight);

            cookieButton.Margin = new Thickness(verticalPosition, horizontalPosition, 0, 0);

            DoubleAnimation animation = new DoubleAnimation()
            {
                From = 1,
                To = 0,
                Duration = TimeSpan.FromSeconds(10),
            };

            // Remove on finish animation
            animation.Completed += (sender, e) => {
                SimpleMovementBorder.Children.Remove(cookieButton);
            };

            cookieButton.BeginAnimation(Button.OpacityProperty, animation);
        }



        /* UPDATE DATA */

        private void UpdateItemShopVisibility() {
            List<ItemShop> items = [BuyCursor, BuyGrandma, BuyFarm, BuyMine, BuyFactory];

            foreach (ItemShop item in items) {
                bool mustBeVisible = CookiesAmount >= (int)Math.Round(item.ItemPrice.GetValueOrDefault(0));
                item.UpdateItemVisibility(mustBeVisible);
            }
        }

        /* BINDING */

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void GameSpace_Loaded(object sender, RoutedEventArgs e) {
            GenerateItemsOnStart();
        }
    }
}