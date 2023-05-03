using GameFramework.Interface;

namespace GameFramework.Models
{
    /// <summary>
    /// Represents a defence item that can be used in a game.
    /// </summary>
    public class DefenceItem : IWorldObject
    {
        public int Defence { get; set; }
        public string Name { get; set; }
        public Position position { get; set; }
        public int Damage { get; set; }

        /// <summary>
        /// Initializes a new instance of the DefenceItem class with the specified name, defence, and maximum X and Y coordinates.
        /// </summary>
        /// <param name="name">The name of the defence item.</param>
        /// <param name="defence">The amount of defence that the defence item provides.</param>
        /// <param name="maxX">The maximum X coordinate for the defence item's position.</param>
        /// <param name="maxY">The maximum Y coordinate for the defence item's position.</param>
        public DefenceItem(string name, int defence, int maxX, int maxY) 
        {
            Name = name;
            Defence = defence;
            position = new Position(maxX, maxY);
            Damage = 0;

        }

        /// <summary>
        /// Initializes a new instance of the DefenceItem class with the specified name and defence, and a random position within the world.
        /// </summary>
        /// <param name="name">The name of the defence item.</param>
        /// <param name="defence">The amount of defence that the defence item provides.</param>
        public DefenceItem(string name, int defence) 
        {
            Name = name;
            Defence = defence;
            position = GetRandomPosition();
            Damage = 0;
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
