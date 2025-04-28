using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarGamee
{
    public class Event
    {
        public string Description { get; set; }
        public Action<GameState> ApplyEffect { get; set; }

        public Event(string description, Action<GameState> applyEffect)
        {
            Description = description;
            ApplyEffect = applyEffect;
        }
    }
}