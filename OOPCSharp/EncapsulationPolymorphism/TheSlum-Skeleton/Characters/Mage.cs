

namespace TheSlum.Characters
{
    using TheSlum.Interfaces;
    using System.Collections.Generic;
    using System;
    using System.Linq;

    class Mage : Character, IAttack
    {
        public Mage(string id, int x, int y, Team team)
            : base(id, x, y, 150, 50, team, 5)
        {
            this.AttackPoints = 300;
        }

        public int AttackPoints { get; set; }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            //var targets = from target in targetsList
            //              where target.IsAlive && target.Team != this.Team
            //              select target;
            //return targets.LastOrDefault() as Character;
            return targetsList.LastOrDefault(ch => (ch.Team != this.Team && ch.IsAlive));
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
