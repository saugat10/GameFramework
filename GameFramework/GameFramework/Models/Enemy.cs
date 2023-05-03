using GameFramework.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework.Models
{
    /// <summary>
    /// Represents an enemy in a game.
    /// </summary>
    public class Enemy : ICreature
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public int Defence { get; set; }
        public Position position { get; set; }
        public World world { get; set; }
        public List<AttackItem> Weapons { get; set; }
        public List<DefenceItem> Shields { get; set; }

        private readonly Random random = new Random();

        /// <summary>
        /// Creates a new instance of the <see cref="Enemy"/> class.
        /// </summary>
        /// <param name="name">The name of the enemy.</param>
        /// <param name="health">The health of the enemy.</param>
        /// <param name="damage">The base damage of the enemy.</param>
        public Enemy(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
            position = new Position(5, 1);

            Weapons = new List<AttackItem>();
            Shields = new List<DefenceItem>();

            Logger.Log($"Enemy with name: {Name}, health: {Health}, damage: {Damage} is created");
        }

        /// <summary>
        /// Allows the enemy to pick up a world object.
        /// </summary>
        /// <param name="worldObject">The world object to pick up.</param>
        public void PickUp(IWorldObject worldObject)
        {
            if (worldObject == null)
            {
                Logger.Log("Error: World object cannot be null.");

                return;
            }

            if (worldObject is AttackItem attackItem)
            {
                Logger.Log($"Enemy picked up {attackItem.Name}.");

                Weapons.Add(attackItem);

            }
            else if (worldObject is DefenceItem defenceItem)
            {
                Logger.Log($"Enemy picked up {defenceItem.Name}.");

                Shields.Add(defenceItem);

            }
        }

        /// <summary>
        /// Allows the enemy to attack a player.
        /// </summary>
        /// <param name="player">The player to attack.</param>
        public void Attack(Player player)
        {
            int totalDmg = Damage - player.Defence;
            if (totalDmg < 0) { totalDmg = 0; }
            player.Health -= totalDmg;
            Logger.Log($"{Name} attacked {player.Name} and dealt {totalDmg} damage.");
            if (player.Health <= 0)
            {
                Logger.Log($"{player.Name} was defeated!");
            }
        }

        /// <summary>
        /// Calculates the total damage of the enemy by adding the damage of all the weapons in the 'Weapons' list.
        /// </summary>
        /// <returns>The total damage of the enemy</returns>
        public int TotalDmg()
        {
            foreach (AttackItem item in Weapons)
            {
                Damage += item.Damage;
            }
            return Damage;
        }

        // <summary>
        /// Calculates the total defence of the enemy by adding the defence of all the shields in the 'Shields' list.
        /// </summary>
        /// <returns>The total defence of the enemy</returns>
        public int TotalDef()
        {
            foreach (DefenceItem item in Shields)
            {
                Defence += item.Defence;
            }
            return Defence;
        }

        /// <summary>
        /// Displays the current health, damage, and defence of the given 'Enemy' instance.
        /// </summary>
        /// <param name="enemy">The 'Enemy' instance to display information about</param>
        public void DisplayEnemyInfo(Enemy enemy)
        {
            Console.WriteLine($"Enemy health: {enemy.Health}");
            Console.WriteLine($"Enemy damage: {enemy.Damage}");
            Console.WriteLine($"Enemy defence: {enemy.Defence}");
        }

        public void Attack(Enemy enemy)
        {
            throw new NotImplementedException();
        }

        public void EnemyRandomMovement(int distance, World world)
        {
            var directions = new[] { 'w', 'a', 's', 'd' };
            var direction = directions[random.Next(directions.Length)];
           
            MoveToRandomPosition(distance, world, direction);
        }

        public void MoveToRandomPosition(int distance, World world, char direction)
        {
            int newX = position.X;
            int newY = position.Y;

            switch (direction)
            {
                case 'w':
                    newY -= distance;
                    break;
                case 'a':
                    newX -= distance;
                    break;
                case 's':
                    newY += distance;
                    break;
                case 'd':
                    newX += distance;
                    break;
                default:
                    break;
            }
            if (newX >= 0 && newX < world.maxX && newY >= 0 && newY < world.maxY)
            {
                if (world.grid[newX, newY] == ' ')
                {
                    Logger.Log($"Enemy moved to new position ({newX}, {newY}).");

                    
                    world.grid[position.X, position.Y] = ' ';
                    position.X = newX;
                    position.Y = newY;
                    world.grid[newX, newY] = 'E';
                }
                else if(world.grid[newX, newY] == '#')
                {
                    Logger.Log($"Connot move out of the world");
                    world.grid[position.X, position.Y] = 'E';
                }
                else
                {
                    world.grid[position.X, position.Y] = 'E';
                }
            }
        }

    }
}
