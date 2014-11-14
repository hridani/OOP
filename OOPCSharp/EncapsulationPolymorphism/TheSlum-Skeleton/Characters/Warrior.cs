namespace TheSlum.Characters
{
    using TheSlum.Interfaces;
    using System.Collections.Generic;
    using System;
    using System.Linq;

    public class Warrior : Character, IAttack
    {
        public Warrior(string id, int x, int y, Team team)
            : base(id, x, y, 200, 100, team, 2)
        {
            this.AttackPoints = 150;
        }

        public int AttackPoints { get; set; }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            return targetsList.FirstOrDefault(c => (c.IsAlive && this.Team != c.Team));
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
            return baseStr + string.Format(", Attack: {0}", this.AttackPoints);
        }
    }
}
