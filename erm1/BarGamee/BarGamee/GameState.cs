using BarGamee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GameState
{
    public int Money { get; set; }
    public int Happiness { get; set; }
    public int Hunger { get; set; }
    public int BarLevel { get; set; }
    public DateTime LastSaveTime { get; set; }
    public int PeriodCount { get; set; } // Счётчик времени

    public GameState()
    {
        Money = 100; // Начальные деньги
        Happiness = 100; // Начальное настроение
        Hunger = 100; // Начальная сытость
        BarLevel = 1; // Начальный уровень бара
        LastSaveTime = DateTime.Now;
        PeriodCount = 0;
    }

    public void PassTime()
    {
        PeriodCount++;
        Hunger -= 5; // Сытость падает
        Happiness -= 3; // Настроение падает

        // Проверяем, не слишком ли сильно упали ресурсы
        if (Happiness < 0) Happiness = 0;
        if (Hunger < 0) Hunger = 0;

        // Раз в месяц (каждые 30 дней) начисляем зарплату
        if (PeriodCount % 30 == 0)
        {
            Money += 50; // Зарплата
        }
        // Генерация клиента
        var customer = CustomerGenerator.GenerateCustomer();
        Money += customer.SpendMoney;
        Happiness += customer.HappinessEffect;

        // Генерация случайного события
        RandomEventGenerator.TriggerRandomEvent(this);

        // Проверка баланса
        CheckBalance();
    }

    public void UpgradeBar()
    {
        if (Money >= 200) // Нужно 200 для улучшения бара
        {
            BarLevel++;
            Money -= 200;
        }
    }
    public void CheckBalance()
    {
        if (Happiness <= 20)
        {
            Money -= 20; // Если счастье низкое, игрок теряет деньги
        }
        if (Hunger <= 20)
        {
            Happiness -= 10; // Если сытость низкая, настроение падает
        }
    }

}
