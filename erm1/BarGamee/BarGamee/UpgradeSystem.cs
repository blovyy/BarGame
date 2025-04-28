using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarGamee
{
    public class UpgradeSystem
    {
        private static List<Upgrade> _upgrades = new List<Upgrade>
    {
        new Upgrade("Улучшение интерьера", 200, (gameState) =>
        {
            gameState.Happiness += 15;
        }),
        new Upgrade("Модернизация оборудования", 300, (gameState) =>
        {
            gameState.Money += 100;
        }),
        new Upgrade("Разнообразие напитков", 400, (gameState) =>
        {
            gameState.Happiness += 20;
            gameState.Money += 50;
        }),
    };

        public static bool TryApplyUpgrade(string upgradeName, GameState gameState)
        {
            var upgrade = _upgrades.FirstOrDefault(u => u.Name == upgradeName);
            if (upgrade != null && gameState.Money >= upgrade.Cost)
            {
                gameState.Money -= upgrade.Cost;
                upgrade.ApplyEffect(gameState);
                return true;
            }
            return false;
        }

        public static List<Upgrade> GetAvailableUpgrades()
        {
            return _upgrades;
        }
    }
}
