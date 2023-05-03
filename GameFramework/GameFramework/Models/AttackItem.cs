using GameFramework.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework.Models
{
    /// <summary>
    /// Represents an attack item in the game world.
    /// </summary>
    public class AttackItem : IWorldObject
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public Position position { get; set; }
        public int Defence { get; set; }

        /// <summary>
        /// Creates a new instance of the <see cref="AttackItem"/> class with the specified name, damage, and maximum x and y values.
        /// </summary>
        /// <param name="name">The name of the attack item.</param>
        /// <param name="damage">The amount of damage that the attack item inflicts.</param>
        /// <param name="maxX">The maximum x value for the attack item's position.</param>
        /// <param name="maxY">The maximum y value for the attack item's position.</param>
        public AttackItem(string name, int damage, int maxX, int maxY)
        {
            Name = name;
            Damage = damage;
            position = new Position(maxX, maxY);
            Defence = 0;
        }

        /// <summary>
        /// Initializes a new instance of the AttackItem class with the specified name and damage, and a random position within the world.
        /// </summary>
        /// <param name="name">The name of the attack item.</param>
        /// <param name="damage">The amount of damage that the attack item inflicts.</param>
        public AttackItem(string name, int damage)
        {
            Name = name;
            Damage = damage;
            position = GetRandomPosition();
            Defence = 0;
        }

        /// <summary>
        /// Gets a random position within the world.
        /// </summary>
        /// <returns>A random position within the world.</returns>
        public Position GetRandomPosition()
        {
            Random rnd = new Random();
            int x = rnd.Next(1, World.Instance.maxX - 1);
            int y = rnd.Next(1, World.Instance.maxY - 1);
            return new Position(x, y);
        }

    }
}
