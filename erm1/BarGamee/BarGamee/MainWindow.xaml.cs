using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Newtonsoft.Json;


namespace BarGamee
{
    public partial class MainWindow : Window
    {
        private GameState _gameState;

        public MainWindow()
        {
            InitializeComponent();
            _gameState = new GameState();
            UpdateUI();
        }

        private void PassTimeButton_Click(object sender, RoutedEventArgs e)
        {
            _gameState.PassTime();
            UpdateUI();
        }

        private void UpgradeBarButton_Click(object sender, RoutedEventArgs e)
        {
            _gameState.UpgradeBar();
            UpdateUI();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveGame();
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            LoadGame();
            UpdateUI();
        }

        private void UpdateUI()
        {
            MoneyText.Text = $"Деньги: {_gameState.Money}";
            HappinessText.Text = $"Настроение: {_gameState.Happiness}";
            HungerText.Text = $"Сытость: {_gameState.Hunger}";
            BarLevelText.Text = $"Уровень бара: {_gameState.BarLevel}";
        }

        private void SaveGame()
        {
            string json = JsonConvert.SerializeObject(_gameState);
            File.WriteAllText("savegame.json", json); MessageBox.Show("Игра сохранена");
        }

        private void LoadGame()
        {
            if (File.Exists("savegame.json"))
            {
                string json = File.ReadAllText("savegame.json");
                _gameState = JsonConvert.DeserializeObject<GameState>(json);
            }
            else
            {
                MessageBox.Show("Не удалось загрузить игру.");
            }
        }
        private void UpgradeButton_Click(object sender, RoutedEventArgs e)
        {
            var upgrades = UpgradeSystem.GetAvailableUpgrades();
            foreach (var upgrade in upgrades)
            {
                if (UpgradeSystem.TryApplyUpgrade(upgrade.Name, _gameState))
                {
                    MessageBox.Show($"Вы улучшили бар: {upgrade.Name}");
                    UpdateUI();
                    break;
                }
                else
                {
                    MessageBox.Show($"Не хватает денег для улучшения: {upgrade.Name}");
                }
            }
        }
    }
}