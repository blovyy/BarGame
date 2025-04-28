using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BarGamee
{
    public class RandomEventGenerator
    {
        private static Random _random = new Random();

        // Список возможных событий
        private static List<Event> _events = new List<Event>
    {
        new Event("Событие: Повышение настроения посетителей!", (gameState) =>
        {
            gameState.Happiness += 10;
            if (gameState.Happiness > 100) gameState.Happiness = 100;
        }),
        new Event("Событие: Пожар в баре, ущерб!", (gameState) =>
        {
            gameState.Money -= 30;
            gameState.Happiness -= 20;
        }),
        new Event("Событие: Новый клиент оставил чаевые!", (gameState) =>
        {
            gameState.Money += 50;
        }),
        new Event("Событие: Ушёл важный клиент", (gameState) =>
        {
            gameState.Happiness -= 15;
        }),
    };

        // Метод для генерации случайного события
        public static void TriggerRandomEvent(GameState gameState)
        {
            if (_random.NextDouble() < 0.3) // 30% вероятность
            {
                var randomEvent = _events[_random.Next(_events.Count)];
                MessageBox.Show(randomEvent.Description);
                randomEvent.ApplyEffect(gameState);
            }
        }
    }
}
