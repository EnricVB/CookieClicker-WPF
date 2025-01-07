using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using CookieClicker.usercontrols;

namespace CookieClicker {
    internal class GameDataManager {
        private MainWindow game;
        private Configuration config;
        private KeyValueConfigurationCollection data;

        public GameDataManager(MainWindow window) {
            game = window;
            config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            data = config.AppSettings.Settings;
        }

        public void Save() {
            RemovePreviousData(data);

            data.Add("_cookies", game._cookies!.ToString());
            SaveItem(game.BuyCursor);
            SaveItem(game.BuyGrandma);
            SaveItem(game.BuyFarm);
            SaveItem(game.BuyMine);
            SaveItem(game.BuyFactory);

            config.Save(ConfigurationSaveMode.Full);
            ConfigurationManager.RefreshSection("appSettings");
        }

        private void SaveItem(ItemShop item) {
            data.Add(item.Name + "_price", ((int) Math.Round(item.ItemPrice.GetValueOrDefault(0))).ToString());
            data.Add(item.Name + "_quantity", ((int)Math.Round(item.ItemQuantity.GetValueOrDefault(0))).ToString());
        }

        private void RemovePreviousData(KeyValueConfigurationCollection data) {
            data.Remove("_cookies");
            data.Remove("BuyCursor_price");
            data.Remove("BuyCursor_quantity");
            data.Remove("BuyGrandma_price");
            data.Remove("BuyGrandma_quantity");
            data.Remove("BuyFarm_price");
            data.Remove("BuyFarm_quantity");
            data.Remove("BuyMine_price");
            data.Remove("BuyMine_quantity");
            data.Remove("BuyFactory_price");
            data.Remove("BuyFactory_quantity");
        }

        public void Load() {

            if (data["_cookies"] != null) {
                game._cookies = int.Parse(data["_cookies"].Value.Replace(",", ""));
            }

            LoadItem(game.BuyCursor);
            LoadItem(game.BuyGrandma);
            LoadItem(game.BuyFarm);
            LoadItem(game.BuyMine);
            LoadItem(game.BuyFactory);
        }

        private void LoadItem(ItemShop item) {
            string priceKey = item.Name + "_price";
            string quantityKey = item.Name + "_quantity";

            if (data[priceKey] != null && data[quantityKey] != null) {
                item.ItemPrice = int.Parse(data[priceKey].Value.Replace(",", ""));
                item.ItemQuantity = int.Parse(data[quantityKey].Value.Replace(",", ""));
            }
        }
    }
}
