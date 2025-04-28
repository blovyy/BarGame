using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarGamee
{
    public class Upgrade
    {
        public string Name { get; set; }
        public int Cost { get; set; }
        public Action<GameState> ApplyEffect { get; set; }

        public Upgrade(string name, int cost, Action<GameState> applyEffect)
        {
            Name = name;
            Cost = cost;
            ApplyEffect = applyEffect;
        }
    }
}
