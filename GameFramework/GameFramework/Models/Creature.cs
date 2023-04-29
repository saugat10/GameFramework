using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework.Models
{
    public class Creature
    {
        public int HitPoints { get;  set; }
        public string Name { get; set; }
        public Position Position { get; set; }

        public void Hit(Creature target, AttackItem weapon)
        {
            int damage = weapon.HitPoints;
            int distance = Position.DistanceTo(target.Position);

            if(distance <= weapon.Range)
            {
                target.ReceiveHit(damage);
                Console.WriteLine($"{Name} hists {target.Name} with {weapon.Name} for {damage} damage!");
            }
            else
            {
                Console.WriteLine($"{Name} is too far away to hit {target.Name} with {weapon.Name}");
            }
        }

        public void Loot(WorldObject obj)
        {
            if (obj.Lootable)
            {
                // TODO: Implement loot logic
                Console.WriteLine($"{Name} loots {obj.Name}!");
            }
            else
            {
                Console.WriteLine($"{Name} cannot loot {obj.Name}!");
            }
        }

        public void ReceiveHit(int damage)
        {
            HitPoints -= damage;
            if (HitPoints < 0)
            {
                HitPoints = 0;
            }
            Console.WriteLine($"{Name} receives {damage} damage! ({HitPoints} HP left)");
        }
    }
}
