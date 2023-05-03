using GameFramework.Interface;
using System;

namespace GameFramework.Models
{
    /// <summary>
    /// Represents a player character in the game.
    /// </summary>
    public class Player : ICreature, IPowerAttack
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public int Defence { get; set; }
        public int Energy { get; set; }
        public Position position { get; set; }
        public List<AttackItem> weapons { get; set; }
        public List<DefenceItem> shields { get; set; }
        public World world { get; set; }
        private readonly Random random = new Random();

        /// <summary>
        /// Initializes a new instance of the Player class.
        /// </summary>
        /// <param name="name">The name of the player.</param>
        /// <param name="health">The starting health of the player.</param>
        /// <param name="damage">The starting damage of the player.</param>
        /// <param name="energy">The starting energy of the player.</param>
        public Player(string name, int health, int damage, int energy)
        {
            Name = name;
            Health = health;
            Damage = damage;
            Energy = energy;
            position = new Position(1, 5); 

            weapons = new List<AttackItem>();
            shields = new List<DefenceItem>();

            Logger.Log($"Player with name: {Name}, health: {Health}, damage: {Damage}, energy: {Energy} is created");
        }

        /// <summary>
        /// Picks up a world object and adds it to the player's inventory.
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
                Logger.Log($"You picked up {attackItem.Name}, + {attackItem.Damage} damage.");

                weapons.Add(attackItem);
            }
            else if (worldObject is DefenceItem defenceItem)
            {
                Logger.Log($"You picked up {defenceItem.Name}, + {defenceItem.Defence} defence.");

                shields.Add(defenceItem);
            }
        }


        /// <summary>
        /// Attacks an enemy and reduces their health.
        /// </summary>
        /// <param name="enemy">The enemy to attack.</param>
        public void Attack(Enemy enemy)
        {
            int totalDmg = Damage - enemy.Defence;
            if (totalDmg < 0) { totalDmg = 0; }
            enemy.Health -= totalDmg;

            Logger.Log($"{Name} attacked {enemy.Name} and dealt {totalDmg} damage.");

            if (enemy.Health <= 0)
            {
                Logger.Log($"{enemy.Name} was defeated!");
            }
        }

        /// <summary>
        /// Calculates the total damage dealt by the player including damage from all equipped weapons.
        /// </summary>
        /// <returns>The total damage dealt by the player.</returns>
        public int TotalDmg()
        {
            foreach (AttackItem item in weapons)
            {
                Damage += item.Damage;
            }
            return Damage;
        }


        /// <summary>
        /// Calculates the total defence of the player including defence from all equipped shields.
        /// </summary>
        /// <returns>The total defence of the player.</returns>
        public int TotadDef()
        {
            foreach (DefenceItem item in shields)
            {
                Defence += item.Defence;
            }
            return Defence;
        }


        /// <summary>
        /// Displays the current stats of the player, including health, damage, defence, and energy.
        /// </summary>
        /// <param name="player">The player whose stats should be displayed.</param>
        public void DisplayPlayerInfo(Player player)
        {
            Console.WriteLine($"Player health: {player.Health}");
            Console.WriteLine($"Player damage: {player.Damage}");
            Console.WriteLine($"Player defence: {player.Defence}");
            Console.WriteLine($"Player energy: {player.Energy}");
        }

        /// <summary>
        /// Attacks an enemy using a power attack, which reduces the enemy's health.
        /// </summary>
        /// <param name="enemy">The enemy to attack.</param>
        public void PowerAttack(Enemy enemy)
        {
            Logger.Log($"You used Power attack on {enemy.Name}");

            Attack(enemy);
            Energy -= 10;

        }

        public void Attack(Player player)
        {
            throw new NotImplementedException();
        }

        public void PlayerRandomMovement(int distance, World world)
        {
            var directions = new[] { 'w', 'a', 's', 'd' };
            var direction = directions[random.Next(directions.Length)];
            //Logger.Log($"Player moved to new direction ({direction}).");
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
                    Logger.Log($"Player moved to new position ({newX}, {newY}).");

                    world.grid[position.X, position.Y] = ' ';
                    position.X = newX;
                    position.Y = newY;
                    world.grid[newX, newY] = 'P';
                }
                else if(world.grid[newX, newY] == '#') 
                {
                    Logger.Log($"Connot move out of the world");
                    world.grid[position.X, position.Y] = 'P';
                }
                else
                {
                    world.grid[position.X, position.Y] = 'P';
                }
            }
        }
    }
}
