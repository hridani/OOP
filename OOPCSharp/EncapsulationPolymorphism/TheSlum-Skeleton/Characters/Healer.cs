namespace TheSlum.Characters
{
    using TheSlum.Interfaces;
    using System.Collections.Generic;
    using System;
    using System.Linq;

    public class Healer : Character, IHeal
    {
       public Healer(string id, int x, int y, Team team)
           : base(id, x, y, 75, 50, team, 6)
        {
            this.HealingPoints = 60;
        }
        
        public int HealingPoints { get; set; }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            var targets = from target in targetsList
                          where target.IsAlive && target.Team == this.Team && target != this
                          orderby target.HealthPoints
                          select target;
            return targets.FirstOrDefault() as Character;
        }

        public override void AddToInventory(Item item)
        {
            this.Inventory.Add(item);
        }

        public override void RemoveFromInventory(Item item)
        {
            this.Inventory.Remove(item);
        }
        
        public override string ToString()
        {
            string baseStr = base.ToString();
            return baseStr + string.Format(", Healing: {0}", this.HealingPoints);
        }
    }
}
